﻿using System;
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
    public partial class frmAddLog : Form
    {
        private DateTime curDate;
        public frmAddLog(DateTime date)
        {
            curDate = date;
            InitializeComponent();
        }
    }
}
