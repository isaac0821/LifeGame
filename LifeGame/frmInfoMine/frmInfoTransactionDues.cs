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
    public partial class frmInfoTransactionDues : Form
    {
        CTransaction transactionDue = new CTransaction();
        Timer timer = new Timer();
        public frmInfoTransactionDues(CTransaction info)
        {
            transactionDue = info;
            InitializeComponent();
            lblSummary.Text = transactionDue.Summary;
            lblCreditAccount.Text = transactionDue.CreditAccount;
            lblDebitAccount.Text = transactionDue.DebitAccount;
            lblAmount.Text =
                transactionDue.CreditAmount == transactionDue.DebitAmount ?
                transactionDue.DebitAmount.ToString() + " " + transactionDue.DebitCurrency
                : transactionDue.CreditAmount + " " + transactionDue.CreditCurrency +
                "(" + transactionDue.DebitAmount + " " + transactionDue.DebitCurrency + ")";
            switch (transactionDue.IconType)
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

        private void lblDebitAccount_Click(object sender, EventArgs e)
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

        private void lblCreditAccount_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tlpTransaction_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tableLayoutPanel3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmInfoTransactionDues_Deactivate(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
