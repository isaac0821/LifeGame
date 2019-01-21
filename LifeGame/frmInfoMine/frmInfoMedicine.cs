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
    public partial class frmInfoMedicine : Form
    {
        CMedicine medicine = new CMedicine();
        Timer timer = new Timer();
        public frmInfoMedicine(CMedicine info)
        {
            InitializeComponent();
            medicine = info;
            lblMedicineName.Text = medicine.MedicineName;
            lblDescription.Text = "Take " + medicine.MedicineQty.ToString() + " " + medicine.MedicineUnit + " " + medicine.MedicineTime.ToString();
            timer.Interval = 10000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblMedicineName_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tableLayoutPanel2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmInfoMedicine_Deactivate(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}