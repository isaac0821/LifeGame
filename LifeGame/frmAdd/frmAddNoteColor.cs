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
    public partial class frmAddNoteColor : Form
    {
        public frmAddNoteColor()
        {
            InitializeComponent();
        }

        public delegate void SetColorLabel(string Keyword, string Color);
        public event SetColorLabel SendColorLabel;

        private void frmAddNoteColor_Load(object sender, EventArgs e)
        {
            cbxColor.Text = "Red";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SendColorLabel != null)
            {
                SendColorLabel(txtKeyword.Text, cbxColor.Text);
                Dispose();
            }
        }
    }
}
