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
    public partial class ucBTNS : UserControl
    {
        public ucBTNS()
        {
            InitializeComponent();

            zeroHotkey.Items.Add(new ComboboxItem("F1", Keys.F1));
            zeroHotkey.SelectedIndex = 0;
            zeroHotkey.SelectedItem = zeroHotkey.SelectedIndex;
        }

        private void recenterGyro_Click(object sender, EventArgs e)
        {
            SerialCommunicator.Instance.resetView();
        }

        private void recalibrateGyro_Click(object sender, EventArgs e)
        {
            SerialCommunicator.Instance.calibrateGyro();
        }

        private void getGyroDataBtn_Click(object sender, EventArgs e)
        {
            SerialCommunicator.Instance.getGyroData();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public Keys key { get; set; }
            public ComboboxItem(string text, Keys key)
            {
                this.Text = text;
                this.key = key;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void turnOnGyro_Click(object sender, EventArgs e)
        {
            SerialCommunicator.Instance.setEnabled(true);
            turnOnGyro.Visible = false;
            turnOffGyro.Visible = true;
            turnOffGyro.Focus();
        }

        private void turnOffGyro_Click(object sender, EventArgs e)
        {
            SerialCommunicator.Instance.setEnabled(false);
            turnOnGyro.Visible = true;
            turnOffGyro.Visible = false;
            turnOnGyro.Focus();
        }

        private void profiles_Click(object sender, EventArgs e)
        {
            Form f = new ProfilesPopup();
            f.ShowDialog();
        }
    }
}
