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

        public bool useAutoUpdate = false;
        public Utils.UpdatableProperty<bool> checkboxUseExp = new Utils.UpdatableProperty<bool>();
        public Utils.UpdatableProperty<bool> checkboxUseSmoothness = new Utils.UpdatableProperty<bool>();
        public ucPYR()
        {
            InitializeComponent();

            useExp.DataBindings.Add(nameof(useExp.Checked), checkboxUseExp, "Value", true);
            smoothness.DataBindings.Add(nameof(smoothness.Checked), checkboxUseSmoothness, "Value", true);

            ifSens.SetPlaceholderText("Sens");
            ifExp.SetPlaceholderText("Eep");
            ifOff.SetPlaceholderText("Offset");
            ifAng.SetPlaceholderText("Limit");

            ifSens.InputFieldIsValid += IfSens_InputFieldIsValid;
            ifExp.InputFieldIsValid += IfExp_InputFieldIsValid;
            ifOff.InputFieldIsValid += IfOff_InputFieldIsValid;
            ifAng.InputFieldIsValid += IfAng_InputFieldIsValid;
        }

        public void setSens(float pitch, float yaw, float roll, float common)
        {
            ifSens.SetValues(pitch, yaw, roll, common, false);
        }

        public void setExp(float pitch, float yaw, float roll, float common)
        {
            ifExp.SetValues(pitch, yaw, roll, common, false);
        }

        public void setOffset(float pitch, float yaw, float roll)
        {
            ifOff.SetValues(pitch, yaw, roll, false);
        }

        public void setLimit(float pitch, float yaw, float roll)
        {
            ifAng.SetValues(pitch, yaw, roll, false);
        }

        private void IfSens_InputFieldIsValid(object? sender, EventArgs e)
        {
            if (useAutoUpdate)
            {
                SerialCommunicator.Instance.setSensitivity(ifSens.InputFieldPitch.Value, ifSens.InputFieldYaw.Value, ifSens.InputFieldRoll.Value);
            }
        }

        private void IfExp_InputFieldIsValid(object? sender, EventArgs e)
        {
            if (useAutoUpdate)
            {
                SerialCommunicator.Instance.setExponentialView(ifExp.InputFieldPitch.Value, ifExp.InputFieldYaw.Value, ifExp.InputFieldRoll.Value);
            }
        }

        private void IfOff_InputFieldIsValid(object? sender, EventArgs e)
        {
            if (useAutoUpdate)
            {
                //Console.WriteLine("ucPYR: {0}", "event recived");
                SerialCommunicator.Instance.setOffset(ifOff.InputFieldPitch.Value, ifOff.InputFieldYaw.Value, ifOff.InputFieldRoll.Value);
            }
        }

        private void IfAng_InputFieldIsValid(object? sender, EventArgs e)
        {
            if (useAutoUpdate)
            {
                SerialCommunicator.Instance.setLimit(ifAng.InputFieldPitch.Value, ifAng.InputFieldYaw.Value, ifAng.InputFieldRoll.Value);
            }
        }

        private void useExp_CheckedChanged(object sender, EventArgs e)
        {
            if (useAutoUpdate)
            {
                SerialCommunicator.Instance.setExponentialMode(checkboxUseExp.Value);
            }
        }

        private void smoothness_CheckedChanged(object sender, EventArgs e)
        {
            if (useAutoUpdate)
            {
                SerialCommunicator.Instance.setSmoothness(checkboxUseSmoothness.Value);
            }
        }
    }
}
