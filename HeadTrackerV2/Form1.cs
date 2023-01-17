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
            Binding bindSens = new Binding(nameof(commonSens.Visible), individualSens, nameof(individualSens.Checked));
            bindSens.Format += SwitchBool;
            bindSens.Parse += SwitchBool;

            commonSens.DataBindings.Add(bindSens);

            //Save the values for exponential
            pitchExp.DataBindings.Add(nameof(pitchExp.Text), Properties.Settings.Default, "pitchExp", true, ds);
            yawExp.DataBindings.Add(nameof(yawExp.Text), Properties.Settings.Default, "yawExp", true, ds);
            rollExp.DataBindings.Add(nameof(rollExp.Text), Properties.Settings.Default, "rollExp", true, ds);
            commonExp.DataBindings.Add(nameof(commonExp.Text), Properties.Settings.Default, "commonExp", true, ds);

            //Bind commonExp to individualExp checkbox
            Binding bindExp = new Binding(nameof(commonExp.Visible), individualExp, nameof(individualExp.Checked));
            bindExp.Format += SwitchBool;
            bindExp.Parse += SwitchBool;

            commonExp.DataBindings.Add(bindExp);
            //commonExp.DataBindings.Add(nameof(commonExp.Visible), individualExp, nameof(individualExp.Checked), true, ds);

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

        private void SwitchBool(object sender, ConvertEventArgs e)
        {
            e.Value = !((bool)e.Value);
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
                bool isValidFloat = float.TryParse(textBox.Text, out float result);
                if (!isValidFloat) { textBox.Text = ""; }
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

        private void getGyroDataBtn_Click(object sender, EventArgs e)
        {
            serial.getGyroData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
        }

        private void updateSens_Click(object sender, EventArgs e)
        {
            bool isValidFloat = float.TryParse(pitchSens.Text, out float result1);
            isValidFloat = float.TryParse(yawSens.Text, out float result2) && isValidFloat;
            isValidFloat = float.TryParse(rollSens.Text, out float result3) && isValidFloat;
            if (!isValidFloat) { printToSerialOutput("ERROR: Sensitivity value is not a float!"); return; }

            if (individualSens.Checked)
            {
                Console.WriteLine("aaa");
                float pitch = float.Parse(pitchSens.Text);
                float yaw = float.Parse(yawSens.Text);
                float roll = float.Parse(rollSens.Text);
                serial.setSensitivity(pitch, yaw, roll);
            }
            else
            {
                Console.WriteLine("bbb");
                float sens = float.Parse(commonSens.Text);
                serial.setSensitivity(sens, sens, sens);
            }
        }

        private void updateExp_Click(object sender, EventArgs e)
        {
            bool isValidFloat = float.TryParse(pitchExp.Text, out float result1);
            isValidFloat = float.TryParse(yawExp.Text, out float result2) && isValidFloat;
            isValidFloat = float.TryParse(rollExp.Text, out float result3) && isValidFloat;
            if (!isValidFloat) { printToSerialOutput("ERROR: Exponential value is not a float!"); return; }

            if (individualExp.Checked)
            {
                Console.WriteLine("ccc");
                float pitch = float.Parse(pitchExp.Text);
                float yaw = float.Parse(yawExp.Text);
                float roll = float.Parse(rollExp.Text);
                serial.setExponentialView(pitch, yaw, roll);
            }
            else
            {
                Console.WriteLine("ddd");
                float exp = float.Parse(commonExp.Text);
                serial.setSensitivity(exp, exp, exp);
            }
        }

        private void updateOffset_Click(object sender, EventArgs e)
        {
            bool isValidFloat = float.TryParse(pitchOffset.Text, out float result1);
            isValidFloat = float.TryParse(yawOffset.Text, out float result2) && isValidFloat;
            isValidFloat = float.TryParse(rollOffset.Text, out float result3) && isValidFloat;
            if (!isValidFloat) { printToSerialOutput("ERROR: Offset value is not a float!"); return; }

            Console.WriteLine("eee");
            float pitch = float.Parse(pitchOffset.Text);
            float yaw = float.Parse(yawOffset.Text);
            float roll = float.Parse(rollOffset.Text);
            serial.setOffset(pitch, yaw, roll);
        }

        private void updateLimits_Click(object sender, EventArgs e)
        {
            bool isValidFloat = float.TryParse(pitchLimit.Text, out float result1);
            isValidFloat = float.TryParse(yawLimit.Text, out float result2) && isValidFloat;
            isValidFloat = float.TryParse(rollLimit.Text, out float result3) && isValidFloat;
            if (!isValidFloat) { printToSerialOutput("ERROR: Limit value is not a float!"); return; }

            Console.WriteLine("fff");
            float pitch = float.Parse(pitchLimit.Text);
            float yaw = float.Parse(yawLimit.Text);
            float roll = float.Parse(rollLimit.Text);
            serial.setLimit(pitch, yaw, roll);
        }

        private void useExp_CheckedChanged(object sender, EventArgs e)
        {
            serial.setExponentialMode(useExp.Checked);
        }

        private void smoothness_CheckedChanged(object sender, EventArgs e)
        {
            serial.setSmoothness(useExp.Checked);
        }

        private void enableGyro_CheckedChanged(object sender, EventArgs e)
        {
            serial.setEnabled(enableGyro.Checked);
        }

        private void recalibrateGyro_Click(object sender, EventArgs e)
        {
            serial.calibrateGyro();
        }
    }
}