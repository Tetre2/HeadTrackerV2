using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadTrackerV2.Usercontrolls
{
    public partial class ucCOM : UserControl
    {
        public ucCOM()
        {
            InitializeComponent();
            SerialCommunicator.Instance.SerialCommunicatorOutput += Instance_SampleEvent; ;
        }

        private void Instance_SampleEvent(object sender, SerialCommunicator.SerialCommunicatorOutputEventArgs e)
        {
            printToSerialOutput(e.Text);
        }

        public void printToSerialOutput(String s)
        {
            Console.WriteLine("ucCOM: {0}",s);
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    serialOutput.Text += s + '\n';
                }));
            }
            else
            {
                serialOutput.Text += s + '\n';
            }
        }

        private void scanPorts_Click(object sender, EventArgs e)
        {
            string[] comPorts = SerialCommunicator.Instance.getOpenPorts();
            ports.Items.Clear();
            foreach (string comPort in comPorts)
            {
                ports.Items.Add(comPort);
            }
        }

        private void connectToSerial_Click(object sender, EventArgs e)
        {
            if (SerialCommunicator.Instance.open())
            {
                connectToSerial.Visible = false;
                disconnectSerial.Visible = true;
            }
        }

        private void disconnectSerial_Click(object sender, EventArgs e)
        {
            SerialCommunicator.Instance.close();
            connectToSerial.Visible = true;
            disconnectSerial.Visible = false;
        }

        private void ports_SelectedValueChanged(object sender, EventArgs e)
        {
            SerialCommunicator.Instance.setCOMPort(ports.Text);
        }

        private void serialOutput_TextChanged(object sender, EventArgs e)
        {
            serialOutput.SelectionStart = serialOutput.Text.Length;
            serialOutput.ScrollToCaret();
        }

        private void getGyroDataBtn_Click(object sender, EventArgs e)
        {
            SerialCommunicator.Instance.getGyroData();
        }
    }
}
