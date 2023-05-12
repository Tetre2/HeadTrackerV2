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
    public partial class ProfilesPopup : Form
    {
        public ProfilesPopup()
        {
            InitializeComponent();
            
        }

        private void ProfilesPopup_Load(object sender, EventArgs e)
        {
            List<UserPersistence.Profile> profiles = UserPersistence.Instance.Profiles;
            foreach (UserPersistence.Profile profile in profiles)
            {
                profileList.Items.Add(profile);
            }
        }

        private void profileList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                profileList.SelectedIndex = profileList.IndexFromPoint(e.Location);
                if (profileList.SelectedIndex != -1)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }else if (e.Button == MouseButtons.Left)
            {
                UserPersistence.Profile p = (UserPersistence.Profile) profileList.SelectedItem;
                ucpyr1.setSens(p.sensitivityPitch, p.sensitivityYaw, p.sensitivityRoll, p.commonSensitivity);
                ucpyr1.setExp(p.exponentialPitch, p.exponentialYaw, p.exponentialRoll, p.commonExponential);
                ucpyr1.setOffset(p.offsetPitch, p.offsetYaw, p.offsetRoll);
                ucpyr1.setLimit(p.viewLimitPitch, p.viewLimitYaw, p.viewLimitRoll);

            }
        }

        private void gfdfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((UserPersistence.Profile) profileList.SelectedItem).id);
        }

        
    }
}
