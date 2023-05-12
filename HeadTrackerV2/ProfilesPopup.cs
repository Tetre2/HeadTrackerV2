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
            foreach (UserPersistence.Profile profile in UserPersistence.Instance.Profiles)
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
                if (profileList.SelectedIndex != -1)
                {
                    ucpyr1.Profile = ((UserPersistence.Profile)profileList.SelectedItem);

                }
            }
        }

        private void gfdfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (profileList.SelectedIndex != -1)
            {
                Console.WriteLine(((UserPersistence.Profile)profileList.SelectedItem).id);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (profileList.SelectedIndex != -1)
            {
                UserPersistence.Instance.Profiles.Add(((UserPersistence.Profile)profileList.SelectedItem));

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserPersistence.Profile newProfile = UserPersistence.Instance.EmptyProfile;
            ucpyr1.Profile = newProfile;
            UserPersistence.Instance.Profiles.Add(newProfile);
        }

        private void ProfilesPopup_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(UserPersistence.Instance.Profiles.Count);
        }
    }
}
