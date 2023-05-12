using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadTrackerV2
{
    public partial class InputFieldWithToggle : InputField
    {
        public Utils.UpdatableProperty<bool> ToggleCommon = new Utils.UpdatableProperty<bool>(); // It is possible this is bugged and does not update untill it is observerd via user interaction
        public Utils.UpdatableProperty<float> InputFieldCommon = new Utils.UpdatableProperty<float>();
        public InputFieldWithToggle()
        {
            InitializeComponent();

            //Needs to be called even though the same calls are made in the base class
            pitchTextBox.DataBindings.Add(nameof(pitchTextBox.Text), InputFieldPitch, "Value", true);
            yawTextBox.DataBindings.Add(nameof(yawTextBox.Text), InputFieldYaw, "Value", true);
            rollTextBox.DataBindings.Add(nameof(rollTextBox.Text), InputFieldRoll, "Value", true);




            commonTextBox.DataBindings.Add(nameof(commonTextBox.Text), InputFieldCommon, "Value", true);
            commonTextBox.DataBindings.Add(nameof(commonTextBox.Visible), toggleCommon, "Checked", true);

            toggleCommon.DataBindings.Add(nameof(toggleCommon.Checked), ToggleCommon, "Value", true);

        }

        public void setToggle()
        {

        }

        public void SetValues(float pitch, float yaw, float roll, float common, bool fireEvent)
        {
            InputFieldCommon.Value = common;
            base.SetValues(pitch, yaw, roll, fireEvent);

        }

        public override void SetPlaceholderText(string text)
        {
            commonTextBox.PlaceholderText = text;
            base.SetPlaceholderText(text);
        }


        protected override bool AreTextBoxesValid()
        {

            bool isValid = true;
            if (ToggleCommon.Value)
            {
                if (!tryParseFloat(commonTextBox.Text, out float common))
                {
                    isValid = false;
                    commonTextBox.Text = "";
                    SerialCommunicator.Instance.outputString("ERROR: Common value is not a float!");
                }
            }
            else
            {
                isValid = base.AreTextBoxesValid();
            }

            return isValid;
        }

        private void ValidateInput(object sender, CancelEventArgs e)
        {
            if (this.AreTextBoxesValid())
            {
                OnInputFieldIsValid(new EventArgs());
                //Console.WriteLine("inputField: {0}, {1}, {2}, {3}", isValid, pitchTextBox.Text, yawTextBox.Text, rollTextBox.Text);
            }
        }
    }
}
