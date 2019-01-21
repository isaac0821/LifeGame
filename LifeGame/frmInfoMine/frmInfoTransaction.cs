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
    public partial class frmInfoTransaction : Form
    {
        CTransaction transaction = new CTransaction();
        Timer timer = new Timer();
        public frmInfoTransaction(CTransaction info)
        {
            transaction = info;
            InitializeComponent();
            lblSummary.Text = transaction.Summary;
            lblCreditAccount.Text = transaction.CreditAccount;
            lblDebitAccount.Text = transaction.DebitAccount;
            lblAmount.Text = 
                transaction.CreditAmount == transaction.DebitAmount ? 
                transaction.DebitAmount.ToString() + " " + transaction.DebitCurrency 
                : transaction.CreditAmount + " " + transaction.CreditCurrency + 
                "(" + transaction.DebitAmount + " " + transaction.DebitCurrency + ")";
            switch (transaction.IconType)
            {
                case EMoneyFlowState.WithinSystem:
                    tlpTransaction.BackColor = Color.Orange;
                    break;
                case EMoneyFlowState.FlowIn:
                    tlpTransaction.BackColor = Color.Green;
                    break;
                case EMoneyFlowState.FlowOut:
                    tlpTransaction.BackColor = Color.Red;
                    break;
                default:
                    break;
            }
            timer.Interval = 10000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblSummary_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblCreditAccount_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblAmount_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblDebitAccount_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmInfoTransaction_Deactivate(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
