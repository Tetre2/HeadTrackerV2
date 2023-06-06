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

namespace HeadTrackerV2
{
    public partial class ProfilesPopup : Form
    {

        public event EventHandler ProfileSelected;

        protected virtual void OnProfileSelected(ProfileArgs e)
        {
            ProfileSelected?.Invoke(this, e);
        }
        public ProfilesPopup()
        {
            InitializeComponent();
        }

        private void ProfilesPopup_Load(object sender, EventArgs e)
        {
            foreach (UserProfile profile in UserPersistence.Instance.Profiles)
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
                    ucpyr1.Profile = ((UserProfile)profileList.SelectedItem);

                }
            }
        }

        private void gfdfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (profileList.SelectedIndex != -1)
            {
                Console.WriteLine(((UserProfile)profileList.SelectedItem).id);

            }
        }

        private void ProfilesPopup_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void selectProfile_Click(object sender, EventArgs e)
        {
            //TODO
            if (profileList.SelectedIndex != -1)
            {
                OnProfileSelected(new ProfileArgs((UserProfile)profileList.SelectedItem));

            }




        }

        private void newProfile_Click(object sender, EventArgs e)
        {
            UserProfile newProfile = UserPersistence.Instance.EmptyProfile;
            ucpyr1.Profile = newProfile;
            UserPersistence.Instance.Profiles.Add(newProfile);
        }

        private void removeProfile_Click(object sender, EventArgs e)
        {
            //TODO

            /*
             if (profileList.SelectedIndex != -1)
            {
                UserPersistence.Instance.Profiles.Add(((UserPersistence.Profile)profileList.SelectedItem));

            }

            Console.WriteLine(UserPersistence.Instance.Profiles.Count);
             */
        }
    }
}
