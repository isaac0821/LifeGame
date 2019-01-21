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
            if (G.glb.lstSubAccount.Exists(o=>o.Account==treeNode.Text))
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
            CalAndFind C = new CalAndFind();
            List<string> heirAccounts = C.FindAllHeirAccount(accountName, G.glb.lstSubAccount);
            List<CTransaction> transactions = G.glb.lstTransaction.FindAll(o => heirAccounts.Exists(p => p == o.CreditAccount) || heirAccounts.Exists(p => p == o.DebitAccount));
            dgvDetail.Rows.Add();

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
                if (trvAccount.SelectedNode.Text != "(Root)")
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
                        List<CTransactionDue> transactionDues = G.glb.lstTransactionDue.FindAll(o => o.Account == PreviousName);
                        foreach (CTransactionDue due in transactionDues)
                        {
                            due.Account = NewName;
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
                if (trvAccount.SelectedNode.Text == "(Root)")
                {
                    MessageBox.Show("Cannot remove the root.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (G.glb.lstAccount.Exists(o => o.AccountName == trvAccount.SelectedNode.Text))
                {
                    string UpperAccount = trvAccount.SelectedNode.Parent.Text;
                    CalAndFind C = new CalAndFind();
                    bool CanDeleteFlag = C.DeleteAccount(trvAccount.SelectedNode.Text, G.glb.lstSubAccount, G.glb.lstAccount, G.glb.lstTransaction, G.glb.lstTransactionDue);
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
    }
}
