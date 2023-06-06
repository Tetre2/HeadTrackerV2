using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadTrackerV2.Utils
{
    public class UserProfile
    {
        public string name { get; set; }

        public int id { get; set; }

        public float sensitivityPitch { get; set; }
        public float sensitivityYaw { get; set; }
        public float sensitivityRoll { get; set; }
        public float commonSensitivity { get; set; }
        public bool useIndividualSensitivity { get; set; }

        public float exponentialPitch { get; set; }
        public float exponentialYaw { get; set; }
        public float exponentialRoll { get; set; }
        public float commonExponential { get; set; }
        public bool useIndividualExponential { get; set; }

        public float offsetPitch { get; set; }
        public float offsetYaw { get; set; }
        public float offsetRoll { get; set; }

        public float viewLimitPitch { get; set; }
        public float viewLimitYaw { get; set; }
        public float viewLimitRoll { get; set; }

        public bool enableGyro { get; set; }
        public bool useExponential { get; set; }
        public bool useSmoothness { get; set; }

        public Keys? hotkey { get; set; }
        public String? COMPort { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
