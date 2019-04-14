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
    public partial class frmAddPath : Form
    {
        public frmAddPath(string title, string defaultPath)
        {
            lblTitle.Text = title;
            txtPath.Text = defaultPath;
            InitializeComponent();
        }

        public delegate void DrawLogHandler(string Path);
        public event DrawLogHandler AddPath;

        private void frmAddPath_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
