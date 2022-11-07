using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class frmReplaceNote : Form
    {
        public frmReplaceNote()
        {
            InitializeComponent();
        }

        public delegate void ReplaceString(string oldString, string newString);
        public event ReplaceString SendReplace;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SendReplace != null)
            {
                SendReplace(txtOldString.Text, txtNewString.Text);
                Dispose();
            }
        }
    }
}
