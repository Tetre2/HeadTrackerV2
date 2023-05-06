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
        public ucPYR()
        {
            InitializeComponent();
            ifSens.SetPlaceholderText("Sens");
            ifExp.SetPlaceholderText("Eep");
            ifOff.SetPlaceholderText("Offset");
            ifAng.SetPlaceholderText("Limit");
        }
    }
}
