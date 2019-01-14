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
    public partial class frmDDLInfo : Form
    {
        public frmDDLInfo(string DDLInfo)
        {
            InitializeComponent();
            lblDDLInfo.Text = DDLInfo;
        }

        private void lblDDLInfo_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmDDLInfo_Deactivate(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
