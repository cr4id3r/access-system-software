using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

public class SerialCommunicationManager
{
    private SerialPort miPuertoSerial;
    private StringBuilder buffer = new StringBuilder();


    // Delegado para el evento de recepción de datos
    public delegate void DataReceivedEventHandler(string data);
    // Evento que se dispara cuando se reciben datos
    public event DataReceivedEventHandler DataReceived;

    public SerialCommunicationManager(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
    {
        miPuertoSerial = new SerialPort()
        {
            PortName = portName,
            BaudRate = baudRate,
            Parity = parity,
            StopBits = stopBits,
            DataBits = dataBits,
            Handshake = Handshake.None,
        };

        miPuertoSerial.DataReceived += MiPuertoSerial_DataReceived;
    }

    private void MiPuertoSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        // Lee los datos disponibles en el búfer
        string receivedData = miPuertoSerial.ReadExisting();
        buffer.Append(receivedData); // Acumula los datos en el buffer

        // Verifica si el buffer contiene el carácter de fin de línea
        if (buffer.ToString().Contains("\n"))
        {
            string completeData = buffer.ToString();
            buffer.Clear(); // Limpia el buffer para el próximo mensaje

            // Dispara el evento DataReceived con los datos completos
            DataReceived?.Invoke(completeData);
        }
    }

    public void OpenPort()
    {
        try
        {
            if (!miPuertoSerial.IsOpen)
            {
                miPuertoSerial.Open();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al abrir el puerto serial: {ex.Message}");
        }
    }

    public void ClosePort()
    {
        if (miPuertoSerial.IsOpen)
        {
            miPuertoSerial.Close();
        }
    }

    public bool IsPortOpen()
    {
        return miPuertoSerial.IsOpen;
    }

    public void SendCommand(string command)
    {
        if (miPuertoSerial.IsOpen)
        {
            miPuertoSerial.WriteLine(command);
        }
        else
        {
            MessageBox.Show("El puerto serial no está abierto.");
        }
    }
}
