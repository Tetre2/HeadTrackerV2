using HeadTrackerV2.Properties;
using System.Globalization;
using gma.System.Windows;

namespace HeadTrackerV2
{
    public partial class Form1 : Form
    {
        UserActivityHook actHook;
        public Form1()
        {
            InitializeComponent();
            ucpyr1.actOnEvents = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            actHook = new UserActivityHook();
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SerialCommunicator.Instance.resetView();
            }
            //if (zeroHotkey.SelectedItem == null) return;
            //if (e.KeyCode == ((ComboboxItem) zeroHotkey.SelectedItem).key)
            //{
            //    SerialCommunicator.Instance.resetView();

            //}

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SerialCommunicator.Instance.close();
            Settings.Default.Save();
            Application.Exit();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //remove focus
                //ActiveControl = label1;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //f.Show(this);
        }
    }
    
}