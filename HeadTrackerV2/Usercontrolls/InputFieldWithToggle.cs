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

        public override void SetPlaceholderText(string text)
        {
            commonTextBox.PlaceholderText = text;
            base.SetPlaceholderText(text);
        }

        private void validateInput(object sender, EventArgs e)
        {
            if (sender != null && sender is TextBox)
            {
                TextBox textBox = sender as TextBox;
                if (!tryParseFloat(textBox.Text, out float f)) { textBox.Text = ""; }
            }
        }

    }
}
