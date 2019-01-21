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
    public partial class frmInfoWorkOut : Form
    {
        CWorkOut workOut = new CWorkOut();
        Timer timer = new Timer();
        public frmInfoWorkOut(CWorkOut info)
        {
                       InitializeComponent();
            workOut = info;
            lblWorkOutType.Text = workOut.WorkOutType;
            lblDescription.Text = workOut.WorkOutQty.ToString() + " " + workOut.WorkOutUnit + " @ " + workOut.Location;
            timer.Interval = 10000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblWorkOutType_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmInfoWorkOut_Deactivate(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tableLayoutPanel2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
