using HeadTrackerV2.Properties;
using System.Globalization;
using gma.System.Windows;

namespace HeadTrackerV2
{
    public partial class Form1 : Form
    {
        SerialCommunicator serial;
        UserActivityHook actHook;
        UserPersistence userPersistence;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial = new SerialCommunicator(printToSerialOutput);

            actHook = new UserActivityHook();
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);

            userPersistence = new UserPersistence();

            Console.WriteLine(userPersistence.Profiles.Count);

            bindData();

            zeroHotkey.Items.Add(new ComboboxItem("F1", Keys.F1));
            zeroHotkey.SelectedIndex = 0;
            zeroHotkey.SelectedItem = zeroHotkey.SelectedIndex;

        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (zeroHotkey.SelectedItem == null) return;
            if (e.KeyCode == ((ComboboxItem) zeroHotkey.SelectedItem).key)
            {
                serial.resetView();

            }
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

        private bool tryParseFloat(string possibleFloat, out float result)
        {
            var fmt = new NumberFormatInfo();
            fmt.NegativeSign = "-";
            
            bool isValid = float.TryParse(possibleFloat, NumberStyles.Float, fmt, out float r);
            result = r;
            return isValid;
        }


        private void validateInput(object sender, EventArgs e)
        {
            if (sender != null && sender is TextBox)
            {
                TextBox textBox = sender as TextBox;
                if (!tryParseFloat(textBox.Text, out float f)) { textBox.Text = ""; }
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


        private void updateSens_Click(object sender, EventArgs e)
        {
            
            

            if (individualSens.Checked)
            {
                Console.WriteLine("aaa");
                bool isValidFloat = tryParseFloat(pitchSens.Text, out float pitch);
                isValidFloat = tryParseFloat(yawSens.Text, out float yaw) && isValidFloat;
                isValidFloat = tryParseFloat(rollSens.Text, out float roll) && isValidFloat;
                if (!isValidFloat) { printToSerialOutput("ERROR: Sensitivity value is not a float!"); return; }
                serial.setSensitivity(pitch, yaw, roll);
            }
            else
            {
                Console.WriteLine("bbb");
                bool isValidFloat = tryParseFloat(commonSens.Text, out float sens);
                if (!isValidFloat) { printToSerialOutput("ERROR: Sensitivity value is not a float!"); return; }
                serial.setSensitivity(sens, sens, sens);
            }
        }

        private void updateExp_Click(object sender, EventArgs e)
        {
            

            if (individualExp.Checked)
            {
                Console.WriteLine("ccc");
                bool isValidFloat = tryParseFloat(pitchExp.Text, out float pitch);
                isValidFloat = tryParseFloat(yawExp.Text, out float yaw) && isValidFloat;
                isValidFloat = tryParseFloat(rollExp.Text, out float roll) && isValidFloat;
                if (!isValidFloat) { printToSerialOutput("ERROR: Exponential value is not a float!"); return; }
                serial.setExponentialView(pitch, yaw, roll);
            }
            else
            {
                Console.WriteLine("ddd");
                bool isValidFloat = tryParseFloat(commonExp.Text, out float exp);
                if (!isValidFloat) { printToSerialOutput("ERROR: Exponential value is not a float!"); return; }
                serial.setSensitivity(exp, exp, exp);
            }
        }

        private void updateOffset_Click(object sender, EventArgs e)
        {
            

            Console.WriteLine("eee"); 
            bool isValidFloat = tryParseFloat(pitchOffset.Text, out float pitch);
            isValidFloat = tryParseFloat(yawOffset.Text, out float yaw) && isValidFloat;
            isValidFloat = tryParseFloat(rollOffset.Text, out float roll) && isValidFloat;
            if (!isValidFloat) { printToSerialOutput("ERROR: Offset value is not a float!"); return; }
            serial.setOffset(pitch, yaw, roll);
        }

        private void updateLimits_Click(object sender, EventArgs e)
        {
            

            Console.WriteLine("fff");
            bool isValidFloat = tryParseFloat(pitchLimit.Text, out float pitch);
            isValidFloat = tryParseFloat(yawLimit.Text, out float yaw) && isValidFloat;
            isValidFloat = tryParseFloat(rollLimit.Text, out float roll) && isValidFloat;
            if (!isValidFloat) { printToSerialOutput("ERROR: Limit value is not a float!"); return; }
            serial.setLimit(pitch, yaw, roll);
        }

        private void useExp_CheckedChanged(object sender, EventArgs e)
        {
            serial.setExponentialMode(useExp.Checked);
        }

        private void smoothness_CheckedChanged(object sender, EventArgs e)
        {
            serial.setSmoothness(smoothness.Checked);
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
}