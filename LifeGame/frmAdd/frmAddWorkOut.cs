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
    public partial class frmAddWorkOut : Form
    {
        private DateTime curDate;
        public frmAddWorkOut(DateTime selectedDate)
        {
            curDate = selectedDate;
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool CanAddFlag = true;
            if (CanAddFlag)
            {
                CWorkOut newWorkOut = new CWorkOut();
                newWorkOut.TagTime = curDate;
                newWorkOut.WorkOutType = txtWorkOutName.Text;
                newWorkOut.WorkOutQty = Convert.ToDouble(txtQty.Text);
                newWorkOut.WorkOutUnit = txtUnit.Text;
                newWorkOut.Location = txtLocation.Text;
                G.glb.lstWorkOut.Add(newWorkOut);
                DrawLog();
                Dispose();
            }
        }

        private void frmAddWorkOut_Load(object sender, EventArgs e)
        {
            dtpDate.Value = curDate.Date;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            curDate = dtpDate.Value.Date;
        }
    }
}
