using HeadTrackerV2.Properties;
using System.Globalization;
using gma.System.Windows;
using HeadTrackerV2.Utils;

namespace HeadTrackerV2
{
    public partial class Form1 : Form
    {
        public static ProfilesPopup ProfilePopup = new ProfilesPopup();
        UserActivityHook actHook;
        public Form1()
        {
            InitializeComponent();
            ucpyr1.actOnEvents = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            actHook = new UserActivityHook();
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            _ = UserPersistence.Instance; // create the signleton

            ProfilePopup.ProfileSelected += ProfilePopup_ProfileSelected;

            ucpyr1.Profile = UserPersistence.Instance.GetCurrentUserProfile();

        }

        private void ProfilePopup_ProfileSelected(object? sender, EventArgs e)
        {
            ucpyr1.Profile = (e as ProfileArgs).profile;
            Console.WriteLine("Form1: recived Event!");
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SerialCommunicator.Instance.resetView();
            }
            //if (zeroHotkey.SelectedItem == null) return;
            //if (e.KeyCode == ((ComboboxItem) zeroHotkey.SelectedItem).key)
            //{
            //    SerialCommunicator.Instance.resetView();

            //}

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SerialCommunicator.Instance.close();
            Settings.Default.Save();
            UserPersistence.Instance.Close();
            Application.Exit();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //remove focus
                //ActiveControl = label1;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            //f.Show(this);
        }
    }
    
}