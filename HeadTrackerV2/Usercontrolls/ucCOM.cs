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
            Console.WriteLine(e.Text);
            printToSerialOutput(e.Text);
        }

        private void ucCOM_Load(object sender, EventArgs e)
        {

        }

        public void printToSerialOutput(String s)
        {
            Console.WriteLine(s);
            serialOutput.Text += s + '\n';
        }
    }
}
