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

        public bool actOnEvents = false;
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

        public void setProfile(UserPersistence.Profile profile)
        {
            ifSens.SetValues(profile.sensitivityPitch, profile.sensitivityYaw, profile.sensitivityRoll, profile.commonSensitivity, false);
            ifSens.ToggleCommon.Value = profile.useIndividualSensitivity;
            ifExp.SetValues(profile.exponentialPitch, profile.exponentialYaw, profile.exponentialRoll, profile.commonExponential, false);
            ifExp.ToggleCommon.Value = profile.useIndividualExponential;
            ifOff.SetValues(profile.offsetPitch, profile.offsetYaw, profile.offsetRoll, false);
            ifAng.SetValues(profile.viewLimitPitch, profile.viewLimitYaw, profile.viewLimitRoll, false);
            useExp.Checked = profile.useExponential;
            smoothness.Checked = profile.useSmoothness;
        }



        private void IfSens_InputFieldIsValid(object? sender, EventArgs e)
        {
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setSensitivity(ifSens.InputFieldPitch.Value, ifSens.InputFieldYaw.Value, ifSens.InputFieldRoll.Value);
            }
        }

        private void IfExp_InputFieldIsValid(object? sender, EventArgs e)
        {
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setExponentialView(ifExp.InputFieldPitch.Value, ifExp.InputFieldYaw.Value, ifExp.InputFieldRoll.Value);
            }
        }

        private void IfOff_InputFieldIsValid(object? sender, EventArgs e)
        {
            if (actOnEvents)
            {
                //Console.WriteLine("ucPYR: {0}", "event recived");
                SerialCommunicator.Instance.setOffset(ifOff.InputFieldPitch.Value, ifOff.InputFieldYaw.Value, ifOff.InputFieldRoll.Value);
            }
        }

        private void IfAng_InputFieldIsValid(object? sender, EventArgs e)
        {
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setLimit(ifAng.InputFieldPitch.Value, ifAng.InputFieldYaw.Value, ifAng.InputFieldRoll.Value);
            }
        }

        private void useExp_CheckedChanged(object sender, EventArgs e)
        {
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setExponentialMode(useExp.Checked);
            }
        }

        private void smoothness_CheckedChanged(object sender, EventArgs e)
        {
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setSmoothness(smoothness.Checked);
            }
        }
    }
}
