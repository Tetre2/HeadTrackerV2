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
    public partial class ucPYR : UserControl
    {
        public ucPYR()
        {
            InitializeComponent();

            ifSens.SetPlaceholderText("Sens");
            ifExp.SetPlaceholderText("Eep");
            ifOff.SetPlaceholderText("Offset");
            ifAng.SetPlaceholderText("Limit");

            ifSens.InputFieldIsValid += IfSens_InputFieldIsValid;
            ifExp.InputFieldIsValid += IfExp_InputFieldIsValid;
            ifOff.InputFieldIsValid += IfOff_InputFieldIsValid;
            ifAng.InputFieldIsValid += IfAng_InputFieldIsValid;
        }

        private void IfSens_InputFieldIsValid(object? sender, EventArgs e)
        {
            SerialCommunicator.Instance.setSensitivity(ifSens.InputFieldPitch.Value, ifSens.InputFieldYaw.Value, ifSens.InputFieldRoll.Value);
        }

        private void IfExp_InputFieldIsValid(object? sender, EventArgs e)
        {
            SerialCommunicator.Instance.setSensitivity(ifExp.InputFieldPitch.Value, ifExp.InputFieldYaw.Value, ifExp.InputFieldRoll.Value);
        }

        private void IfOff_InputFieldIsValid(object? sender, EventArgs e)
        {
            //Console.WriteLine("ucPYR: {0}", "event recived");
            SerialCommunicator.Instance.setSensitivity(ifOff.InputFieldPitch.Value, ifOff.InputFieldYaw.Value, ifOff.InputFieldRoll.Value);
        }

        private void IfAng_InputFieldIsValid(object? sender, EventArgs e)
        {
            SerialCommunicator.Instance.setSensitivity(ifAng.InputFieldPitch.Value, ifAng.InputFieldYaw.Value, ifAng.InputFieldRoll.Value);
        }

    }
}
