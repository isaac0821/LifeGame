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
    public partial class frmDaily : Form
    {
        private DateTime curDate;
        public frmDaily(DateTime date)
        {
            curDate = date;
            InitializeComponent();
        }

        private void frmDaily_Load(object sender, EventArgs e)
        {
            dtpToday.Value = curDate;
        }

        private void LoadDaily(DateTime date)
        {

        }
    }
}
