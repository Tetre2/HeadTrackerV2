using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadTrackerV2.Utils
{
    public class ProfileArgs : EventArgs
    {
        public UserProfile profile { get;}

        public ProfileArgs(UserProfile profile)
        {
            this.profile = profile;
        }
    }
}
