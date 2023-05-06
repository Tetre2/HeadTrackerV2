﻿using System;
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


        private void validating(object sender, CancelEventArgs e)
        {
            bool isValidFloat = tryParseFloat(pitchTextBox.Text, out float pitch);
            isValidFloat = tryParseFloat(yawTextBox.Text, out float yaw) && isValidFloat;
            isValidFloat = tryParseFloat(rollTextBox.Text, out float roll) && isValidFloat;
            if (isValidFloat){
                OnInputFieldIsValid(e);
                //Console.WriteLine("inputField: {0}, {1}, {2}, {3}", isValidFloat, pitchTextBox.Text, yawTextBox.Text, rollTextBox.Text);
            }
            else
            {
                SerialCommunicator.Instance.outputString("ERROR: value is not a float!");
            }
        }
    }
}
