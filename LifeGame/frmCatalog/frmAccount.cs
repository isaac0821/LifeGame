using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LifeGame
{
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            dtpStatementPeriodStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpStatementPeriodEnd.Value = DateTime.Today.Date;
            DateTime lastDayOfThisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            lastDayOfThisMonth = lastDayOfThisMonth.AddMonths(1);
            lastDayOfThisMonth = lastDayOfThisMonth.AddDays(-1);
            dtpEndOfPredictPeriod.Value = lastDayOfThisMonth;
            LoadTrvAccount();
        }

        private void LoadTrvAccount()
        {
            trvAccount.Nodes.Clear();
            TreeNode rootNode = new TreeNode("(Root)", 0, 0);
            rootNode.Name = "(Root)";
            LoadChildAccountNode(rootNode);
            trvAccount.Nodes.Add(rootNode);
        }

        private void LoadChildAccountNode(TreeNode treeNode)
        {
            if (G.glb.lstSubAccount.Exists(o => o.Account == treeNode.Text))
            {
                List<RSubAccount> subAccounts = G.glb.lstSubAccount.FindAll(o => o.Account == treeNode.Text);
                subAccounts = subAccounts.OrderBy(o => o.index).ToList();
                foreach (RSubAccount subAccount in subAccounts)
                {
                    int iconIndex = 0;
                    if (G.glb.lstAccount.Exists(o => o.AccountName == subAccount.SubAccount))
                    {
                        switch (G.glb.lstAccount.Find(o => o.AccountName == subAccount.SubAccount).AccountType)
                        {
                            case EAccountType.Assets:
                                iconIndex = 2;
                                break;
                            case EAccountType.Expense:
                                iconIndex = 3;
                                break;
                            case EAccountType.Liability:
                                iconIndex = 2;
                                break;
                            case EAccountType.Equity:
                                iconIndex = 2;
                                break;
                            case EAccountType.Income:
                                iconIndex = 1;
                                break;
                            default:
                                break;
                        }
                    }
                    TreeNode childNode = new TreeNode(subAccount.SubAccount, iconIndex, iconIndex);
                    childNode.Name = subAccount.SubAccount;
                    LoadChildAccountNode(childNode);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void LoadAccount(string accountName)
        {
            calculate C = new calculate();

            double curAssetsBalance = 0;
            double curLiabilitiesBalance = 0;
            calculate.SBalance currentAssets = C.CalBalance(
                "(Assets)",
                G.glb.lstAccount,
                G.glb.lstSubAccount,
                G.glb.lstTransaction,
                G.glb.lstCurrencyRate,
                dtpStatementPeriodStart.Value.Date,
                dtpStatementPeriodEnd.Value.Date);
            curAssetsBalance = currentAssets.EndingBalanceDebit - currentAssets.EndingBalanceCredit;
            calculate.SBalance currentLiabilities = C.CalBalance(
                "(Liability)",
                G.glb.lstAccount,
                G.glb.lstSubAccount,
                G.glb.lstTransaction,
                G.glb.lstCurrencyRate,
                dtpStatementPeriodStart.Value.Date,
                dtpStatementPeriodEnd.Value.Date);
            curLiabilitiesBalance = currentLiabilities.EndingBalanceDebit - currentLiabilities.EndingBalanceCredit;
            lblBalance.Text = Math.Round(curAssetsBalance + curLiabilitiesBalance, 2).ToString();

            CAccount account = G.glb.lstAccount.Find(o => o.AccountName == accountName);
            lblAccountName.Text = account.AccountName;
            lblCurrency.Text = account.Currency;
            
            calculate.SBalance balance = C.CalBalance(
                accountName,
                G.glb.lstAccount,
                G.glb.lstSubAccount,
                G.glb.lstTransaction,
                G.glb.lstCurrencyRate,
                dtpStatementPeriodStart.Value.Date,
                dtpStatementPeriodEnd.Value.Date);
            lblDebitOpening.Text = Math.Round(balance.OpeningBalanceDebit,2).ToString();
            lblCreditOpening.Text = Math.Round(balance.OpeningBalanceCredit, 2).ToString();
            lblDebitAmount.Text = Math.Round(balance.AmountDebit, 2).ToString();
            lblCreditAmount.Text = Math.Round(balance.AmountCredit, 2).ToString();
            lblDebitEnding.Text = Math.Round(balance.EndingBalanceDebit, 2).ToString();
            lblCreditEnding.Text = Math.Round(balance.EndingBalanceCredit, 2).ToString();

            double futureAssetsBalance = 0;
            double futureLiabilitiesBalance = 0;
            calculate.SBalance futureAssets = C.CalFutureBalance(
                "(Assets)",
                G.glb.lstAccount,
                G.glb.lstSubAccount,
                G.glb.lstTransaction,
                G.glb.lstBudget,
                G.glb.lstCurrencyRate,
                dtpStatementPeriodStart.Value.Date,
                dtpEndOfPredictPeriod.Value.Date);
            futureAssetsBalance = futureAssets.EndingBalanceDebit - futureAssets.EndingBalanceCredit;
            calculate.SBalance futureLiabilities = C.CalFutureBalance(
                "(Liability)",
                G.glb.lstAccount,
                G.glb.lstSubAccount,
                G.glb.lstTransaction,
                G.glb.lstBudget,
                G.glb.lstCurrencyRate,
                dtpStatementPeriodStart.Value.Date,
                dtpEndOfPredictPeriod.Value.Date);
            futureLiabilitiesBalance = futureLiabilities.EndingBalanceDebit - futureLiabilities.EndingBalanceCredit;
            lblFutureBalance.Text = Math.Round(futureAssetsBalance + futureLiabilitiesBalance, 2).ToString();

            calculate.SBalance futureBalance = C.CalFutureBalance(
                accountName,
                G.glb.lstAccount,
                G.glb.lstSubAccount,
                G.glb.lstTransaction,
                G.glb.lstBudget,
                G.glb.lstCurrencyRate,
                dtpStatementPeriodStart.Value.Date,
                dtpEndOfPredictPeriod.Value.Date);
            lblFutureDebitAmount.Text = Math.Round(futureBalance.AmountDebit, 2).ToString();
            lblFutureCreditAmount.Text = Math.Round(futureBalance.AmountCredit, 2).ToString();
            lblFutureDebitEnding.Text = Math.Round(futureBalance.EndingBalanceDebit, 2).ToString();
            lblFutureCreditEnding.Text = Math.Round(futureBalance.EndingBalanceCredit, 2).ToString();
            LoadAccountTransaction(accountName);
        }

        private void LoadAccountInFlowChart(string accountName)
        {

        }

        private void LoadAccountOutFlowChart(string accountName)
        {

        }

        private void LoadAccountTransaction(string accountName)
        {
            dgvDetail.Rows.Clear();
            calculate C = new calculate();
            List<string> heirAccounts = C.FindAllHeirAccount(accountName, G.glb.lstSubAccount);
            List<CTransaction> transactions = G.glb.lstTransaction.FindAll(
                o => (heirAccounts.Exists(p => p == o.CreditAccount) || heirAccounts.Exists(p => p == o.DebitAccount))
                && o.TagTime >= dtpStatementPeriodStart.Value.Date && o.TagTime <= dtpStatementPeriodEnd.Value.Date);
            foreach (CTransaction trans in transactions)
            {
                if (heirAccounts.Exists(o => o == trans.DebitAccount))
                {
                    if (trans.DebitCurrency == G.glb.lstAccount.Find(o => o.AccountName == accountName).Currency)
                    {
                        dgvDetail.Rows.Add(
                            trans.TagTime.Date.ToString("MM/dd/yyyy"),
                            trans.Summary,
                            trans.DebitAccount,
                            trans.CreditAccount,
                            "D",
                            trans.DebitAmount,
                            trans.DebitCurrency,
                            trans.DebitAmount,
                            1);
                    }
                    else if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyA == trans.DebitCurrency && o.CurrencyB == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency))
                    {
                        dgvDetail.Rows.Add(
                            trans.TagTime.Date.ToString("MM/dd/yyyy"),
                            trans.Summary,
                            trans.DebitAccount,
                            trans.CreditAccount,
                            "D",
                            trans.DebitAmount,
                            trans.DebitCurrency,
                            trans.DebitAmount * G.glb.lstCurrencyRate.Find(o => o.CurrencyA == trans.DebitCurrency && o.CurrencyB == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency).Rate,
                            G.glb.lstCurrencyRate.Find(o => o.CurrencyA == trans.DebitCurrency && o.CurrencyB == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency).Rate);
                    }
                    else if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyB == trans.DebitCurrency && o.CurrencyA == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency))
                    {
                        dgvDetail.Rows.Add(
                            trans.TagTime.Date.ToString("MM/dd/yyyy"),
                            trans.Summary,
                            trans.DebitAccount,
                            trans.CreditAccount,
                            "D",
                            trans.DebitAmount,
                            trans.DebitCurrency,
                            trans.DebitAmount / G.glb.lstCurrencyRate.Find(o => o.CurrencyB == trans.DebitCurrency && o.CurrencyA == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency).Rate,
                            1 / G.glb.lstCurrencyRate.Find(o => o.CurrencyB == trans.DebitCurrency && o.CurrencyA == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency).Rate);
                    }
                    else
                    {
                        MessageBox.Show("Lack of exchange rate of " + trans.CreditCurrency + " → " + G.glb.lstAccount.Find(o => o.AccountName == accountName).Currency);
                    }
                }
                if (heirAccounts.Exists(o => o == trans.CreditAccount))
                {
                    if (trans.CreditCurrency == G.glb.lstAccount.Find(o => o.AccountName == accountName).Currency)
                    {
                        dgvDetail.Rows.Add(
                            trans.TagTime.Date.ToString("MM/dd/yyyy"),
                            trans.Summary,
                            trans.CreditAccount,
                            trans.DebitAccount,
                            "C",
                            trans.CreditAmount,
                            trans.CreditCurrency,
                            trans.CreditAmount,
                            1);
                    }
                    else if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyA == trans.CreditCurrency && o.CurrencyB == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency))
                    {
                        dgvDetail.Rows.Add(
                            trans.TagTime.Date.ToString("MM/dd/yyyy"),
                            trans.Summary,
                            trans.CreditAccount,
                            trans.DebitAccount,
                            "C",
                            trans.CreditAmount,
                            trans.CreditCurrency,
                            trans.CreditAmount * G.glb.lstCurrencyRate.Find(o => o.CurrencyA == trans.CreditCurrency && o.CurrencyB == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency).Rate,
                            G.glb.lstCurrencyRate.Find(o => o.CurrencyA == trans.CreditCurrency && o.CurrencyB == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency).Rate);
                    }
                    else if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyB == trans.CreditCurrency && o.CurrencyA == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency))
                    {
                        dgvDetail.Rows.Add(
                            trans.TagTime.Date.ToString("MM/dd/yyyy"),
                            trans.Summary,
                            trans.CreditAccount,
                            trans.DebitAccount,
                            "C",
                            trans.CreditAmount,
                            trans.CreditCurrency,
                            trans.CreditAmount / G.glb.lstCurrencyRate.Find(o => o.CurrencyB == trans.CreditCurrency && o.CurrencyA == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency).Rate,
                            1 / G.glb.lstCurrencyRate.Find(o => o.CurrencyB == trans.CreditCurrency && o.CurrencyA == G.glb.lstAccount.Find(p => p.AccountName == accountName).Currency).Rate);
                    }
                    else
                    {
                        MessageBox.Show("Lack of exchange rate of " + trans.CreditCurrency + " → " + G.glb.lstAccount.Find(o => o.AccountName == accountName).Currency);
                    }
                }
            }
        }


        private void tsmAddAccount_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                if (!G.glb.lstAccount.Exists(o => o.AccountName == trvAccount.SelectedNode.Text) && trvAccount.SelectedNode.Text != "(Root)")
                {
                    MessageBox.Show("Cannot find the account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (trvAccount.SelectedNode.Text == "(Root)")
                    {
                        TreeNode node = trvAccount.SelectedNode;
                        frmAddAccount frmAddAccount = new frmAddAccount(trvAccount.SelectedNode.Text);
                        frmAddAccount.AddChildNode += new frmAddAccount.DrawLogHandler(AddChildNode);
                        frmAddAccount.Show();
                    }
                    else
                    {
                        TreeNode node = trvAccount.SelectedNode;
                        frmAddAccount frmAddAccount = new frmAddAccount(trvAccount.SelectedNode.Text);
                        frmAddAccount.AddChildNode += new frmAddAccount.DrawLogHandler(AddChildNode);
                        frmAddAccount.Show();
                    }
                }
            }
        }

        private void AddChildNode(string nodeName, int iconIndex)
        {
            if (trvAccount.SelectedNode != null)
            {
                TreeNode node = trvAccount.SelectedNode;
                TreeNode newNode = new TreeNode(nodeName, iconIndex, iconIndex);
                newNode.Name = nodeName;
                node.Nodes.Add(newNode);
            }
        }

        private void ReIndex(string UpperAccount)
        {
            List<RSubAccount> sameLevel = G.glb.lstSubAccount.FindAll(o => o.Account == UpperAccount);
            foreach (RSubAccount subAccount in sameLevel)
            {
                G.glb.lstSubAccount.Find(o => o.Account == UpperAccount && o.SubAccount == subAccount.SubAccount).index = trvAccount.Nodes.Find(subAccount.SubAccount, true).FirstOrDefault().Index;
            }
        }

        private void tsmRenameAccount_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                if (trvAccount.SelectedNode.Text != "(Root)"
                    && G.glb.lstAccount.Find(o => o.AccountName == trvAccount.SelectedNode.Text).ProtectedAccount == false)
                {
                    string PreviousName = trvAccount.SelectedNode.Text;
                    string NewName = Interaction.InputBox("Input New Account Name", "Rename", trvAccount.SelectedNode.Text, 300, 300);
                    if (G.glb.lstAccount.Exists(o => o.AccountName == NewName))
                    {
                        MessageBox.Show("New task name already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        G.glb.lstAccount.Find(o => o.AccountName == PreviousName).AccountName = NewName;
                        List<RSubAccount> rSubAccounts = G.glb.lstSubAccount.FindAll(o => o.Account == PreviousName);
                        foreach (RSubAccount subAccount in rSubAccounts)
                        {
                            subAccount.Account = NewName;
                        }
                        G.glb.lstSubAccount.Find(o => o.SubAccount == PreviousName).SubAccount = NewName;
                        List<CTransaction> creditTransaction = G.glb.lstTransaction.FindAll(o => o.CreditAccount == PreviousName);
                        foreach (CTransaction transaction in creditTransaction)
                        {
                            transaction.CreditAccount = NewName;
                        }
                        List<CTransaction> debitTransaction = G.glb.lstTransaction.FindAll(o => o.DebitAccount == PreviousName);
                        foreach (CTransaction transaction in debitTransaction)
                        {
                            transaction.DebitAccount = NewName;
                        }
                        List<CTransaction> creditBudget = G.glb.lstBudget.FindAll(o => o.CreditAccount == PreviousName);
                        foreach (CTransaction transaction in creditBudget)
                        {
                            transaction.CreditAccount = NewName;
                        }
                        List<CTransaction> debitBudget = G.glb.lstBudget.FindAll(o => o.DebitAccount == PreviousName);
                        foreach (CTransaction transaction in debitBudget)
                        {
                            transaction.DebitAccount = NewName;
                        }
                        trvAccount.SelectedNode.Text = NewName;
                        trvAccount.SelectedNode.Name = NewName;
                    }
                }
            }
        }

        private void tsmDeleteAccount_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                if (trvAccount.SelectedNode.Text == "(Root)"
                     && G.glb.lstAccount.Find(o => o.AccountName == trvAccount.SelectedNode.Text).ProtectedAccount == false)
                {
                    MessageBox.Show("Cannot remove the root.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (G.glb.lstAccount.Exists(o => o.AccountName == trvAccount.SelectedNode.Text))
                {
                    string UpperAccount = trvAccount.SelectedNode.Parent.Text;
                    calculate C = new calculate();
                    bool CanDeleteFlag = C.DeleteAccount(trvAccount.SelectedNode.Text, G.glb.lstSubAccount, G.glb.lstAccount, G.glb.lstTransaction, G.glb.lstBudget);
                    if (CanDeleteFlag)
                    {
                        trvAccount.Nodes.Remove(trvAccount.SelectedNode);
                        ReIndex(UpperAccount);
                    }
                }
            }
        }

        private void tsmUp_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                if (trvAccount.SelectedNode.Text != "(Root)")
                {
                    string UpperAccount = trvAccount.SelectedNode.Parent.Text;
                    TreeNode node = trvAccount.SelectedNode;
                    TreeNode preNode = node.PrevNode;
                    if (preNode != null)
                    {
                        TreeNode newNode = (TreeNode)node.Clone();
                        if (node.Parent == null)
                        {
                            trvAccount.Nodes.Insert(preNode.Index, newNode);
                        }
                        else
                        {
                            node.Parent.Nodes.Insert(preNode.Index, newNode);
                        }
                        node.Remove();
                        trvAccount.SelectedNode = newNode;
                        ReIndex(UpperAccount);
                    }
                }
            }
        }

        private void tsmDown_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                if (trvAccount.SelectedNode.Text != "(Root)")
                {
                    string UpperAccount = trvAccount.SelectedNode.Parent.Text;
                    TreeNode node = trvAccount.SelectedNode;
                    TreeNode nextNode = node.NextNode;
                    if (nextNode != null)
                    {
                        TreeNode newNode = (TreeNode)node.Clone();
                        if (node.Parent == null)
                        {
                            trvAccount.Nodes.Insert(nextNode.Index + 1, newNode);
                        }
                        else
                        {
                            node.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                        }
                        node.Remove();
                        trvAccount.SelectedNode = newNode;
                        ReIndex(UpperAccount);
                    }
                }
            }
        }

        private void tsmBelongTo_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                TreeNode node = trvAccount.SelectedNode;
                TreeNode preNode = node.PrevNode;
                TreeNode parentNode = node.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.PrevNode != null)
                {
                    string preNodeName = preNode.Text;
                    string parentNodeName = parentNode.Text;
                    G.glb.lstSubAccount.RemoveAll(o => o.Account == parentNode.Text && o.SubAccount == node.Text);
                    RSubAccount newSub = new RSubAccount();
                    newSub.Account = preNode.Text;
                    newSub.SubAccount = node.Text;
                    newSub.index = preNode.Nodes.Count;
                    G.glb.lstSubAccount.Add(newSub);
                    preNode.Nodes.Insert(preNode.Nodes.Count, newNode);
                    node.Remove();
                    trvAccount.SelectedNode = newNode;
                    ReIndex(parentNodeName);
                    ReIndex(preNodeName);
                }
            }
        }

        private void tsmIndependent_Click(object sender, EventArgs e)
        {
            if (trvAccount.SelectedNode != null)
            {
                TreeNode node = trvAccount.SelectedNode;
                TreeNode parentNode = node.Parent;
                TreeNode grandparentNode = node.Parent.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.Parent.Parent != null)
                {
                    string parentNodeName = parentNode.Text;
                    string grandparentNodeName = grandparentNode.Text;
                    G.glb.lstSubAccount.RemoveAll(o => o.Account == parentNode.Text && o.SubAccount == node.Text);
                    RSubAccount newSub = new RSubAccount();
                    newSub.Account = grandparentNode.Text;
                    newSub.SubAccount = node.Text;
                    newSub.index = grandparentNode.Nodes.Count;
                    G.glb.lstSubAccount.Add(newSub);
                    grandparentNode.Nodes.Insert(parentNode.Index + 1, newNode);
                    node.Remove();
                    trvAccount.SelectedNode = newNode;
                    ReIndex(grandparentNodeName);
                    ReIndex(parentNodeName);
                }
            }
        }

        private void tsmCurrencyRate_Click(object sender, EventArgs e)
        {
            frmCurrencyRate frmCurrencyRate = new frmCurrencyRate();
            frmCurrencyRate.Show();
        }

        private void trvAccount_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvAccount.SelectedNode != null && trvAccount.SelectedNode.Text != "(Root)")
            {
                LoadAccount(trvAccount.SelectedNode.Text);
            }
        }

        private void chkShowBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowBalance.Checked)
            {
                lblDebitOpening.Visible = false;
                lblCreditOpening.Visible = false;
                lblDebitEnding.Visible = false;
                lblCreditEnding.Visible = false;
            }
            else
            {
                lblDebitOpening.Visible = true;
                lblCreditOpening.Visible = true;
                lblDebitEnding.Visible = true;
                lblCreditEnding.Visible = true;
            }
        }

        private void dtpEndOfPredictPeriod_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndOfPredictPeriod.Value.Date < dtpStatementPeriodEnd.Value.Date)
            {
                dtpEndOfPredictPeriod.Value = dtpStatementPeriodEnd.Value;
            }
        }
    }
}
