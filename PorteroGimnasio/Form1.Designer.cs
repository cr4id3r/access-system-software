namespace PorteroGimnasio
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            availableUsbComboBox = new ComboBox();
            testConnectorButton = new Button();
            button2 = new Button();
            button3 = new Button();
            connectToComButton = new Button();
            closeCom_button = new Button();
            clearConsoleButton = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(220, 43);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(575, 220);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(220, 13);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 1;
            label1.Text = "Puertos disponibles";
            // 
            // availableUsbComboBox
            // 
            availableUsbComboBox.FormattingEnabled = true;
            availableUsbComboBox.Location = new Point(336, 10);
            availableUsbComboBox.Name = "availableUsbComboBox";
            availableUsbComboBox.Size = new Size(378, 23);
            availableUsbComboBox.TabIndex = 2;
            // 
            // testConnectorButton
            // 
            testConnectorButton.Location = new Point(46, 41);
            testConnectorButton.Name = "testConnectorButton";
            testConnectorButton.Size = new Size(134, 24);
            testConnectorButton.TabIndex = 3;
            testConnectorButton.Text = "Test concentrador";
            testConnectorButton.UseVisualStyleBackColor = true;
            testConnectorButton.Click += testConnectorButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(46, 85);
            button2.Name = "button2";
            button2.Size = new Size(134, 23);
            button2.TabIndex = 4;
            button2.Text = "Test portero 1";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(46, 129);
            button3.Name = "button3";
            button3.Size = new Size(134, 23);
            button3.TabIndex = 5;
            button3.Text = "Test portero 2";
            button3.UseVisualStyleBackColor = true;
            // 
            // connectToComButton
            // 
            connectToComButton.Location = new Point(720, 9);
            connectToComButton.Name = "connectToComButton";
            connectToComButton.Size = new Size(75, 23);
            connectToComButton.TabIndex = 6;
            connectToComButton.Text = "Conectar";
            connectToComButton.UseVisualStyleBackColor = true;
            connectToComButton.Click += connectToComButton_Click;
            // 
            // closeCom_button
            // 
            closeCom_button.Location = new Point(638, 286);
            closeCom_button.Name = "closeCom_button";
            closeCom_button.Size = new Size(123, 23);
            closeCom_button.TabIndex = 7;
            closeCom_button.Text = "Cerrar conexión";
            closeCom_button.UseVisualStyleBackColor = true;
            closeCom_button.Click += closeCom_button_Click;
            // 
            // clearConsoleButton
            // 
            clearConsoleButton.Location = new Point(229, 286);
            clearConsoleButton.Name = "clearConsoleButton";
            clearConsoleButton.Size = new Size(75, 23);
            clearConsoleButton.TabIndex = 8;
            clearConsoleButton.Text = "Limpiar consola";
            clearConsoleButton.UseVisualStyleBackColor = true;
            clearConsoleButton.Click += clearConsoleButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 330);
            Controls.Add(clearConsoleButton);
            Controls.Add(closeCom_button);
            Controls.Add(connectToComButton);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(testConnectorButton);
            Controls.Add(availableUsbComboBox);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Portero Gimnasio (acabeza)";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Label label1;
        private ComboBox availableUsbComboBox;
        private Button testConnectorButton;
        private Button button2;
        private Button button3;
        private Button connectToComButton;
        private Button closeCom_button;
        private Button clearConsoleButton;
    }
}
