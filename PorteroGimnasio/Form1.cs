
using System.Diagnostics;
using System.Management;

namespace PorteroGimnasio
{
    public partial class Form1 : Form
    {

        private SerialCommunicationManager serialManager;


        public Form1()
        {
            InitializeComponent();
            FillAvailableComDevices();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialManager != null)
            {
                serialManager.ClosePort();
            }
        }

        private void FillAvailableUsbDevices()
        {
            try
            {
                // Crea un objeto de consulta de administración para buscar dispositivos USB
                ManagementObjectSearcher buscador = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE 'USB%'");

                foreach (ManagementObject dispositivo in buscador.Get())
                {
                    // Aquí asumimos que quieres añadir el nombre del dispositivo al ComboBox
                    string nombreDispositivo = dispositivo["Name"] as string;

                    if (!string.IsNullOrEmpty(nombreDispositivo))
                    {
                        availableUsbComboBox.Items.Add(nombreDispositivo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar dispositivos USB: " + ex.Message);
            }
        }

        private void FillAvailableComDevices()
        {
            try
            {
                // Crea un objeto de consulta de administración para buscar dispositivos de puerto serie
                ManagementObjectSearcher buscador = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity WHERE (Caption LIKE '%(COM%)')");

                foreach (ManagementObject dispositivo in buscador.Get())
                {
                    // Extrae el nombre del dispositivo y el número de puerto COM
                    string caption = dispositivo["Caption"] as string;
                    if (!string.IsNullOrEmpty(caption))
                    {
                        // Filtra para asegurarse de que solo añade los dispositivos que efectivamente son puertos COM
                        if (caption.Contains("(COM"))
                        {
                            availableUsbComboBox.Items.Add(caption);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar dispositivos COM: " + ex.Message);
            }
        }

        private void testConnectorButton_Click(object sender, EventArgs e)
        {
            // Get the selected device from the ComboBox
            string selectedDevice = availableUsbComboBox.SelectedItem as string;

            if (selectedDevice == null)
            {
                MessageBox.Show("Por favor, selecciona un dispositivo.");
                return;
            }

            // Get the COM port number from the selected device
            string comPort = selectedDevice.Substring(selectedDevice.IndexOf("(COM") + 1);
            comPort = comPort.Substring(0, comPort.IndexOf(")"));

            writeLog("Enviando comando de prueba al concentrador...");

            // Send ansii command to the COM port
            serialManager.SendCommand("TestCtrLink");
        }

        private void connectToComButton_Click(object sender, EventArgs e)
        {
            // Asegúrate de que se haya seleccionado un dispositivo
            string selectedDevice = availableUsbComboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedDevice))
            {
                MessageBox.Show("Por favor, selecciona un dispositivo del ComboBox.");
                return;
            }

            // Extrae el número del puerto COM del dispositivo seleccionado
            // Asumiendo que el formato es "Nombre del Dispositivo (COMX)"
            int startIndex = selectedDevice.LastIndexOf("(COM") + 4;
            int endIndex = selectedDevice.IndexOf(")", startIndex);
            string comPort = selectedDevice.Substring(startIndex, endIndex - startIndex);

            // Inicializa el SerialCommunicationManager con el puerto COM seleccionado
            if (serialManager == null || !serialManager.IsPortOpen())
            {
                serialManager = new SerialCommunicationManager($"COM{comPort}", 9600);
                serialManager.DataReceived += SerialManager_DataReceived;
                serialManager.OpenPort();
                writeLog($"Conexión abierta en {selectedDevice}.");
            }
            else
            {
                writeLog("Ya existe una conexión abierta.");
            }
        }

        private void closeCom_button_Click(object sender, EventArgs e)
        {
            serialManager.ClosePort();
            writeLog("Conexión cerrada.");
        }

        private void SerialManager_DataReceived(string data)
        {
            // Este código se ejecuta en un hilo diferente al de la UI
            // Usa Invoke para modificar la UI desde este hilo
            Invoke((MethodInvoker)delegate
            {
                // Actualiza tu UI aquí, por ejemplo, añadiendo los datos a un TextBox
                writeLog(data + Environment.NewLine);
            });
        }

        private void clearConsoleButton_Click(object sender, EventArgs e)
        {
            clearLog();
        }

        private void writeLog(string message)
        {
            richTextBox1.AppendText(message + "\n");
        }

        private void clearLog()
        {
            richTextBox1.Clear();
        }
    }
}
