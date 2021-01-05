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
    public partial class frmAddBudget : Form
    {
        private DateTime curDate = new DateTime();
        public frmAddBudget(DateTime selectDate)
        {
            curDate = selectDate;
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool CanSaveFlag = true;
            if (dtpPeriodEnd.Value < dtpPeriodStart.Value)
            {
                MessageBox.Show("End date can not earlier than start date");
                CanSaveFlag = false;
            }
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
                DateTime startDate = dtpPeriodStart.Value.Date;
                DateTime endDate = dtpPeriodEnd.Value.Date;
                for (DateTime day = startDate; day <= endDate; day = day.AddDays(1))
                {
                    bool IsSaveBudget = false;
                    switch (day.DayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                            if (chkSu.Checked)
                            {
                                IsSaveBudget = true;
                            }
                            break;
                        case DayOfWeek.Monday:
                            if (chkMo.Checked)
                            {
                                IsSaveBudget = true;
                            }
                            break;
                        case DayOfWeek.Tuesday:
                            if (chkTu.Checked)
                            {
                                IsSaveBudget = true;
                            }
                            break;
                        case DayOfWeek.Wednesday:
                            if (chkWe.Checked)
                            {
                                IsSaveBudget = true;
                            }
                            break;
                        case DayOfWeek.Thursday:
                            if (chkTh.Checked)
                            {
                                IsSaveBudget = true;
                            }
                            break;
                        case DayOfWeek.Friday:
                            if (chkFr.Checked)
                            {
                                IsSaveBudget = true;
                            }
                            break;
                        case DayOfWeek.Saturday:
                            if (chkSa.Checked)
                            {
                                IsSaveBudget = true;
                            }
                            break;
                        default:
                            break;
                    }
                    if (IsSaveBudget)
                    {
                        CTransaction newBudget = new CTransaction();
                        newBudget.TagTime = day;
                        newBudget.Summary = txtSummary.Text;
                        newBudget.CreditAccount = cbxCredit.Text;
                        newBudget.CreditAmount = Convert.ToDouble(txtCreditAmount.Text);
                        newBudget.CreditCurrency = lblCreditCurrency.Text;
                        newBudget.DebitAccount = cbxDebit.Text;
                        newBudget.DebitAmount = Convert.ToDouble(txtDebitAmount.Text);
                        newBudget.DebitCurrency = lblDebitCurrency.Text;
                        calculate C = new calculate();
                        newBudget.IconType = C.MoneyInOrOut(
                            G.glb.lstAccount.Find(o => o.AccountName == cbxDebit.Text).AccountType,
                            G.glb.lstAccount.Find(o => o.AccountName == cbxCredit.Text).AccountType);
                        G.glb.lstBudget.Add(newBudget);
                    }
                }
                DrawLog();
                Dispose();
            }
        }

        private void frmAddBudget_Load(object sender, EventArgs e)
        {
            List<CAccount> accountsChoics = G.glb.lstAccount.FindAll(o => o.ProtectedAccount == false).ToList();
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
            if (G.glb.lstAccount.Exists(o => o.AccountName == cbxDebit.Text))
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
