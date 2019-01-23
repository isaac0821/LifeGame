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
    public partial class frmAddTransaction : Form
    {
        private DateTime curDate = new DateTime();
        public frmAddTransaction(DateTime selectDate)
        {
            curDate = selectDate;
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool CanSaveFlag = true;
            if (txtSummary.Text == "")
            {
                MessageBox.Show("Need a summary name");
                CanSaveFlag = false;
                            }
            if (txtCreditAmount.Text == "" || txtDebitAmount.Text == "")
            {
                MessageBox.Show("Amount incomplete");
                CanSaveFlag = false;
            }

            if (CanSaveFlag)
            {
                CTransaction newTransaction = new CTransaction();
                newTransaction.TagTime = curDate;
                newTransaction.Summary = txtSummary.Text;
                newTransaction.CreditAccount = cbxCredit.Text;
                newTransaction.CreditAmount = Convert.ToDouble(txtCreditAmount.Text);
                newTransaction.CreditCurrency = lblCreditCurrency.Text;
                newTransaction.DebitAccount = cbxDebit.Text;
                newTransaction.DebitAmount = Convert.ToDouble(txtDebitAmount.Text);
                newTransaction.DebitCurrency = lblDebitCurrency.Text;
                CalAndFind C = new CalAndFind();
                newTransaction.IconType = C.MoneyInOrOut(
                    G.glb.lstAccount.Find(o => o.AccountName == cbxDebit.Text).AccountType,
                    G.glb.lstAccount.Find(o => o.AccountName == cbxCredit.Text).AccountType);
                G.glb.lstTransaction.Add(newTransaction);
                DrawLog();
                Dispose();
            }
        }

        private void frmAddTransaction_Load(object sender, EventArgs e)
        {
            List<CAccount> accountsChoics = G.glb.lstAccount.FindAll(o=>o.ProtectedAccount==false).ToList();
            accountsChoics = accountsChoics.OrderBy(o => o.AccountName).ToList();
            List<string> choices = new List<string>();
            foreach (CAccount account in accountsChoics)
            {
                choices.Add(account.AccountName);
            }
            cbxCredit.DataSource = choices.ToList();
            cbxDebit.DataSource = choices.ToList();
            dtpDate.Value = curDate.Date;
        }

        private void cbxDebit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G.glb.lstAccount.Exists(o=>o.AccountName==cbxDebit.Text))
            {
                lblDebitCurrency.Text = G.glb.lstAccount.Find(o => o.AccountName == cbxDebit.Text).Currency;
            }
            else
            {
                lblDebitCurrency.Text = "---";
            }
        }

        private void cbxCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G.glb.lstAccount.Exists(o => o.AccountName == cbxCredit.Text))
            {
                lblCreditCurrency.Text = G.glb.lstAccount.Find(o => o.AccountName == cbxCredit.Text).Currency;
            }
            else
            {
                lblCreditCurrency.Text = "---";
            }
        }

        private void txtDebitAmount_TextChanged(object sender, EventArgs e)
        {
            if (lblCreditCurrency.Text == lblDebitCurrency.Text)
            {
                txtCreditAmount.Text = txtDebitAmount.Text;
            }
        }

        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {
            if (lblCreditCurrency.Text == lblDebitCurrency.Text)
            {
                txtDebitAmount.Text = txtCreditAmount.Text;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            curDate = dtpDate.Value.Date;
        }
    }
}
