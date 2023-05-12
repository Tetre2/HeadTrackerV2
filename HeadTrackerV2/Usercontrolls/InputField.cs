using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using gma.System.Windows;

namespace HeadTrackerV2
{
    public partial class InputField : UserControl
    {

        public event EventHandler InputFieldIsValid;

        protected virtual void OnInputFieldIsValid(EventArgs e)
        {
            InputFieldIsValid?.Invoke(this, e);
            Console.WriteLine("event Invoced by: {0}", this.Name);
        }


        public Utils.UpdatableProperty<float> InputFieldPitch = new Utils.UpdatableProperty<float>();
        public Utils.UpdatableProperty<float> InputFieldYaw = new Utils.UpdatableProperty<float>();
        public Utils.UpdatableProperty<float> InputFieldRoll = new Utils.UpdatableProperty<float>();

        public InputField()
        {
            InitializeComponent();
            pitchTextBox.DataBindings.Add(nameof(pitchTextBox.Text), InputFieldPitch, "Value", true);
            yawTextBox.DataBindings.Add(nameof(yawTextBox.Text), InputFieldYaw, "Value", true);
            rollTextBox.DataBindings.Add(nameof(rollTextBox.Text), InputFieldRoll, "Value", true);
        }

        public virtual void SetValues(float pitch, float yaw, float roll, bool fireEvent)
        {
            InputFieldPitch.Value = pitch;
            InputFieldYaw.Value = yaw;
            InputFieldRoll.Value = roll;
            if (fireEvent)
            {
                validateInput(this, new CancelEventArgs());
            }
        }

        public virtual void SetPlaceholderText(string text)
        {
            pitchTextBox.PlaceholderText = text;
            yawTextBox.PlaceholderText = text;
            rollTextBox.PlaceholderText = text;
        }

        protected virtual bool tryParseFloat(string possibleFloat, out float result)
        {
            var fmt = new NumberFormatInfo();
            fmt.NegativeSign = "-";
            fmt.NumberDecimalSeparator = ",";

            bool isValid = float.TryParse(possibleFloat, NumberStyles.Float, fmt, out float r);
            result = r;
            return isValid;
        }


        protected virtual bool AreTextBoxesValid()
        {
            bool isValid = true;
            if (tryParseFloat(pitchTextBox.Text, out float pitch))
            {
                InputFieldPitch.Value = pitch;
            }else
            {
                isValid = false;
                pitchTextBox.Text = "";
                SerialCommunicator.Instance.outputString("ERROR: Pitch value is not a float!");
            }

            if (tryParseFloat(yawTextBox.Text, out float yaw))
            {
                InputFieldYaw.Value = yaw;
            }else
            {
                isValid = false;
                yawTextBox.Text = "";
                SerialCommunicator.Instance.outputString("ERROR: Yaw value is not a float!");
            }

            if (tryParseFloat(rollTextBox.Text, out float roll))
            {
                InputFieldRoll.Value = roll;
            }else
            {
                isValid = false;
                rollTextBox.Text = "";
                SerialCommunicator.Instance.outputString("ERROR: Roll value is not a float!");
            }
            return isValid;

        }


        private void validateInput(object sender, CancelEventArgs e)
        {
            if (AreTextBoxesValid())
            {
                OnInputFieldIsValid(e);
                //Console.WriteLine("inputField: {0}, {1}, {2}, {3}", isValid, pitchTextBox.Text, yawTextBox.Text, rollTextBox.Text);
            }
        }
    }
}
