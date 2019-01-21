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
    public partial class frmInfoDDL : Form
    {
        public frmInfoDDL(string infos)
        {
            InitializeComponent();
            string[] lstInfo = infos.Split('\n');
            foreach (string info in lstInfo)
            {
                lsbInfo.Items.Add(info);
            }
        }

        private void txtDDLInfo_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmDDLInfo_Deactivate(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
