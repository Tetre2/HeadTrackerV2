using HeadTrackerV2.Properties;

namespace HeadTrackerV2
{
    public partial class Form1 : Form
    {
        SerialCommunicator serial;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial = new SerialCommunicator(printToSerialOutput);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serial.close();
            Settings.Default.Save();
            Application.Exit();
        }

        public void printToSerialOutput(String s)
        {
            if (InvokeRequired)
            { 
                this.Invoke(new MethodInvoker(delegate {
                    serialOutput.Text += s + '\n';
                }));
            }
        }

        private void scanPorts_Click(object sender, EventArgs e)
        {
            string[] comPorts = serial.getOpenPorts(); 
            ports.Items.Clear();
            foreach (string comPort in comPorts)
            {
                ports.Items.Add(comPort);
            }
        }

        private void connectToSerial_Click(object sender, EventArgs e)
        {
            if (serial.open())
            {
                connectToSerial.Visible = false;
                disconnectSerial.Visible = true;
            }
        }

        private void disconnectSerial_Click(object sender, EventArgs e)
        {
            serial.close();
            connectToSerial.Visible = true;
            disconnectSerial.Visible = false;
        }

        private void recenterGyro_Click(object sender, EventArgs e)
        {
            serial.resetView();
        }

        private void ports_SelectedValueChanged(object sender, EventArgs e)
        {
            serial.setCOMPort(ports.Text);
        }

        private void serialOutput_TextChanged(object sender, EventArgs e)
        {
            serialOutput.SelectionStart = serialOutput.Text.Length;
            serialOutput.ScrollToCaret();
        }
    }
}