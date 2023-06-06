using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeadTrackerV2.Utils;

namespace HeadTrackerV2.Usercontrolls
{
    public partial class ucPYR : UserControl
    {

        public bool actOnEvents = false;

        private UserProfile profile;

        public UserProfile Profile
        {
            get { return profile; }
            set { 
                profile = value;
                if (profile != null)
                {
                    Console.WriteLine("ucPYR: updated Profile");
                    ifSens.SetValues(profile.sensitivityPitch, profile.sensitivityYaw, profile.sensitivityRoll, profile.commonSensitivity, false);
                    ifSens.SetToggleCommon(profile.useIndividualSensitivity, false);
                    ifExp.SetValues(profile.exponentialPitch, profile.exponentialYaw, profile.exponentialRoll, profile.commonExponential, false);
                    ifExp.SetToggleCommon(profile.useIndividualExponential, false);
                    ifOff.SetValues(profile.offsetPitch, profile.offsetYaw, profile.offsetRoll, false);
                    ifAng.SetValues(profile.viewLimitPitch, profile.viewLimitYaw, profile.viewLimitRoll, false);
                    useExp.Checked = profile.useExponential;
                    smoothness.Checked = profile.useSmoothness;
                }
            }
        }


        public ucPYR()
        {
            InitializeComponent();

            ifSens.SetPlaceholderText("Sens");
            ifExp.SetPlaceholderText("Eep");
            ifOff.SetPlaceholderText("Offset");
            ifAng.SetPlaceholderText("Limit");

            ifSens.InputFieldIsValid += IfSens_InputFieldIsValid;
            ifSens.InputFieldToggled += IfSens_InputFieldToggled;
            ifExp.InputFieldIsValid += IfExp_InputFieldIsValid;
            ifExp.InputFieldToggled += IfExp_InputFieldToggled;
            ifOff.InputFieldIsValid += IfOff_InputFieldIsValid;
            ifAng.InputFieldIsValid += IfAng_InputFieldIsValid;
        }



        private void IfSens_InputFieldToggled(object? sender, EventArgs e)
        {
            Profile.useIndividualSensitivity = ifSens.ToggleCommon.Value;
        }

        private void IfExp_InputFieldToggled(object? sender, EventArgs e)
        {
            Profile.useIndividualExponential = ifExp.ToggleCommon.Value;
        }


        private void IfSens_InputFieldIsValid(object? sender, EventArgs e)
        {
            Profile.sensitivityPitch = ifSens.InputFieldPitch.Value;
            Profile.sensitivityYaw = ifSens.InputFieldYaw.Value;
            Profile.sensitivityRoll = ifSens.InputFieldRoll.Value;
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setSensitivity(ifSens.InputFieldPitch.Value, ifSens.InputFieldYaw.Value, ifSens.InputFieldRoll.Value);
            }
        }

        private void IfExp_InputFieldIsValid(object? sender, EventArgs e)
        {
            Profile.exponentialPitch = ifExp.InputFieldPitch.Value;
            Profile.exponentialYaw = ifExp.InputFieldYaw.Value;
            Profile.exponentialRoll = ifExp.InputFieldRoll.Value;
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setExponentialView(ifExp.InputFieldPitch.Value, ifExp.InputFieldYaw.Value, ifExp.InputFieldRoll.Value);
            }
        }

        private void IfOff_InputFieldIsValid(object? sender, EventArgs e)
        {
            Profile.offsetPitch = ifOff.InputFieldPitch.Value;
            Profile.offsetYaw = ifOff.InputFieldYaw.Value;
            Profile.offsetRoll = ifOff.InputFieldRoll.Value;
            Console.WriteLine("ucPYR: offset {0}, {1}, {2}", ifOff.InputFieldPitch.Value, ifOff.InputFieldYaw.Value, ifOff.InputFieldRoll.Value);
            if (actOnEvents)
            {
                //Console.WriteLine("ucPYR: {0}", "event recived");
                SerialCommunicator.Instance.setOffset(ifOff.InputFieldPitch.Value, ifOff.InputFieldYaw.Value, ifOff.InputFieldRoll.Value);
            }
        }

        private void IfAng_InputFieldIsValid(object? sender, EventArgs e)
        {
            Profile.viewLimitPitch = ifAng.InputFieldPitch.Value;
            Profile.viewLimitYaw = ifAng.InputFieldYaw.Value;
            Profile.viewLimitRoll = ifAng.InputFieldRoll.Value;
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setLimit(ifAng.InputFieldPitch.Value, ifAng.InputFieldYaw.Value, ifAng.InputFieldRoll.Value);
            }
        }

        private void useExp_CheckedChanged(object sender, EventArgs e)
        {
            Profile.useExponential = useExp.Checked;
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setExponentialMode(useExp.Checked);
            }
        }

        private void smoothness_CheckedChanged(object sender, EventArgs e)
        {
            Profile.useSmoothness = smoothness.Checked;
            if (actOnEvents)
            {
                SerialCommunicator.Instance.setSmoothness(smoothness.Checked);
            }
        }
    }
}
