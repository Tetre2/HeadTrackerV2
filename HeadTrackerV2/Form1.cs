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
            bindData();

        }

        private void bindData()
        {
            DataSourceUpdateMode ds = DataSourceUpdateMode.OnValidation;
            //Save the values for checkboxes
            individualSens.DataBindings.Add(nameof(individualSens.Checked), Properties.Settings.Default, "individualSens", true, ds);
            individualExp.DataBindings.Add(nameof(individualExp.Checked), Properties.Settings.Default, "individualExp", true, ds);

            //Save the values for sensitivity
            pitchSens.DataBindings.Add(nameof(pitchSens.Text), Properties.Settings.Default, "pitchSens", true, ds);
            yawSens.DataBindings.Add(nameof(yawSens.Text), Properties.Settings.Default, "yawSens", true, ds);
            rollSens.DataBindings.Add(nameof(rollSens.Text), Properties.Settings.Default, "rollSens", true, ds);
            commonSens.DataBindings.Add(nameof(commonSens.Text), Properties.Settings.Default, "commonSens", true, ds);

            //Bind commonSens to individualSens checkbox
            commonSens.DataBindings.Add(nameof(commonSens.Visible), individualSens, nameof(individualSens.Checked), true, ds);

            //Save the values for exponential
            pitchExp.DataBindings.Add(nameof(pitchExp.Text), Properties.Settings.Default, "pitchExp", true, ds);
            yawExp.DataBindings.Add(nameof(yawExp.Text), Properties.Settings.Default, "yawExp", true, ds);
            rollExp.DataBindings.Add(nameof(rollExp.Text), Properties.Settings.Default, "rollExp", true, ds);
            commonExp.DataBindings.Add(nameof(commonExp.Text), Properties.Settings.Default, "commonExp", true, ds);

            //Bind commonExp to individualExp checkbox
            commonExp.DataBindings.Add(nameof(commonExp.Visible), individualExp, nameof(individualExp.Checked), true, ds);

            //Save the values for offsets
            pitchOffset.DataBindings.Add(nameof(pitchOffset.Text), Properties.Settings.Default, "pitchOffset", true, ds);
            yawOffset.DataBindings.Add(nameof(yawOffset.Text), Properties.Settings.Default, "yawOffset", true, ds);
            rollOffset.DataBindings.Add(nameof(rollOffset.Text), Properties.Settings.Default, "rollOffset", true, ds);

            //Save the values for angel litits
            pitchLimit.DataBindings.Add(nameof(pitchLimit.Text), Properties.Settings.Default, "pitchLimit", true, ds);
            yawLimit.DataBindings.Add(nameof(yawLimit.Text), Properties.Settings.Default, "yawLimit", true, ds);
            rollLimit.DataBindings.Add(nameof(rollLimit.Text), Properties.Settings.Default, "rollLimit", true, ds);

            //Save the values for the Smoothness checkbox
            smoothness.DataBindings.Add(nameof(smoothness.Checked), Properties.Settings.Default, "smoothness", true, ds);

            //Save the values for the useExponential checkbox
            useExp.DataBindings.Add(nameof(useExp.Checked), Properties.Settings.Default, "useExp", true, ds);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serial.close();
            Settings.Default.Save();
            Application.Exit();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            //remove focus
            ActiveControl = label1;
        }

        // ----------------- USER INPUT ----------------- 

        private void validateInput(object sender, EventArgs e)
        {
            if (sender != null && sender is TextBox)
            {
                TextBox textBox = sender as TextBox;

                try
                {
                    float.Parse(textBox.Text);
                }
                catch (Exception)
                {
                    textBox.Text = "";
                }
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //remove focus
                ActiveControl = label1;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }


        // ----------------- SERIAL ----------------- 
        public void printToSerialOutput(String s)
        {

            Console.WriteLine(s);
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

        private void ports_SelectedValueChanged(object sender, EventArgs e)
        {
            serial.setCOMPort(ports.Text);
        }

        private void serialOutput_TextChanged(object sender, EventArgs e)
        {
            serialOutput.SelectionStart = serialOutput.Text.Length;
            serialOutput.ScrollToCaret();
        }


        // ----------------- GYRO ----------------- 
        private void recenterGyro_Click(object sender, EventArgs e)
        {
            serial.resetView();
        }

        private void individualSens_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void individualExp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void getGyroDataBtn_Click(object sender, EventArgs e)
        {
            serial.getGyroData();
        }
    }
}