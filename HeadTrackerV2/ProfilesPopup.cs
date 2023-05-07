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

        private void profileList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                profileList.SelectedIndex = profileList.IndexFromPoint(e.Location);
                if (profileList.SelectedIndex != -1)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void gfdfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
        }
    }
}
