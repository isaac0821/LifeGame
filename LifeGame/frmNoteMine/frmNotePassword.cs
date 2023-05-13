using System;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class frmNotePassword : Form
    {
        public frmNotePassword()
        {
            InitializeComponent();
        }

        public delegate void GetPassword(string Password);
        public event GetPassword SendPassword;

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (SendPassword != null)
            {
                SendPassword(txtPassword.Text);
                Dispose();
            }
        }
    }
}
