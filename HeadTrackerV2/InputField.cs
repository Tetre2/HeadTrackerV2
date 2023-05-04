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

        public event EventHandler InputFieldTextChanged;

        protected virtual void OnInputFieldTextChaned(EventArgs e)
        {
            InputFieldTextChanged?.Invoke(this, e);
        }

        public float InputFieldPitch { get; set; }
        public float InputFieldYaw { get; set; }
        public float InputFieldRoll { get; set; }

        public InputField()
        {
            InitializeComponent();
            
        }

        public void SetPlaceholderText(string text)
        {
            pitchTextBox.PlaceholderText = text;
            yawTextBox.PlaceholderText = text;
            rollTextBox.PlaceholderText = text;
        }

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
    }
}
