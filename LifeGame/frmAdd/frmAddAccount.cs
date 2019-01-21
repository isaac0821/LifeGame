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
    public partial class frmAddAccount : Form
    {
        private string UpperAccount;
        public frmAddAccount(string UpperAccountName)
        {
            UpperAccount = UpperAccountName;
            InitializeComponent();
        }

        public delegate void DrawLogHandler(string AccountName, int iconIndex);
        public event DrawLogHandler AddChildNode;

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool CanSaveFlag = true;

            if (G.glb.lstAccount.Exists(o=>o.AccountName==txtAccount.Text))
            {
                CanSaveFlag = false;
                MessageBox.Show("Account exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (cbxAccountType.Text == "")
            {
                CanSaveFlag = false;
                MessageBox.Show("Choose The Account Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtCurrency.Text == "")
            {
                CanSaveFlag = false;
                MessageBox.Show("Choose The Currency", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (CanSaveFlag)
            {
                CAccount newAccount = new CAccount();
                newAccount.AccountName = txtAccount.Text;
                int iconIndex = 0;
                switch (cbxAccountType.Text)
                {
                    case "Assets":
                        newAccount.AccountType = EAccountType.Assets;
                        iconIndex = 2;
                        break;
                    case "Expense":
                        newAccount.AccountType = EAccountType.Expense;
                        iconIndex = 3;
                        break;
                    case "Equity":
                        newAccount.AccountType = EAccountType.Equity;
                        iconIndex = 2;
                        break;
                    case "Liability":
                        newAccount.AccountType = EAccountType.Liability;
                        iconIndex = 2;
                        break;
                    case "Income":
                        newAccount.AccountType = EAccountType.Income;
                        iconIndex = 1;
                        break;
                    default:
                        break;
                }
                newAccount.Currency = txtCurrency.Text;
                G.glb.lstAccount.Add(newAccount);
                RSubAccount newRSubAccount = new RSubAccount();
                int maxIndex;
                if (G.glb.lstSubAccount.Exists(o => o.Account == UpperAccount))
                {
                    List<RSubAccount> sameLevel = G.glb.lstSubAccount.FindAll(o => o.Account == UpperAccount).ToList();
                    sameLevel = sameLevel.OrderByDescending(o => o.index).ToList();
                    maxIndex = sameLevel[0].index + 1;
                }
                else
                {
                    maxIndex = 0;
                }
                newRSubAccount.Account = UpperAccount;
                newRSubAccount.SubAccount = txtAccount.Text;
                newRSubAccount.index = maxIndex;
                G.glb.lstSubAccount.Add(newRSubAccount);
                AddChildNode(txtAccount.Text, iconIndex);
                Dispose();
            }
        }

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            if (G.glb.lstAccount.Exists(o=>o.AccountName==UpperAccount))
            {
                switch (G.glb.lstAccount.Find(o => o.AccountName == UpperAccount).AccountType)
                {
                    case EAccountType.Assets:
                        cbxAccountType.Text = "Assets";
                        break;
                    case EAccountType.Expense:
                        cbxAccountType.Text = "Expense";
                        break;
                    case EAccountType.Liability:
                        cbxAccountType.Text = "Liability";
                        break;
                    case EAccountType.Equity:
                        cbxAccountType.Text = "Equity";
                        break;
                    case EAccountType.Income:
                        cbxAccountType.Text = "Income";
                        break;
                    default:
                        break;
                }
                cbxAccountType.Enabled = false;
                txtCurrency.Text = G.glb.lstAccount.Find(o => o.AccountName == UpperAccount).Currency;
            }
        }
    }
}
