namespace LifeGame
{
    partial class frmAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Asset");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Equity");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Expenses");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Income");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Liability");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("(Root)", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.stsAccount = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnsAccount = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trvAccount = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.cbxAccountCurrency = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStatementPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.dtpStatementPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.chkShowBalance = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDebitOpening = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreditOpening = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDebitAmount = new System.Windows.Forms.Label();
            this.lblCreditAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCreditEnding = new System.Windows.Forms.Label();
            this.lblDebitEnding = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lsbDebit = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lsbCredit = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOppositeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebitOrCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquivalentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iglAccount = new System.Windows.Forms.ImageList(this.components);
            this.cmsAccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAccountToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.belongToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.independentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picDebit = new System.Windows.Forms.PictureBox();
            this.picCredit = new System.Windows.Forms.PictureBox();
            this.stsAccount.SuspendLayout();
            this.mnsAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.cmsAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDebit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCredit)).BeginInit();
            this.SuspendLayout();
            // 
            // stsAccount
            // 
            this.stsAccount.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.stsAccount.Location = new System.Drawing.Point(0, 579);
            this.stsAccount.Name = "stsAccount";
            this.stsAccount.Size = new System.Drawing.Size(1068, 22);
            this.stsAccount.TabIndex = 0;
            this.stsAccount.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "Version: 0.0.0";
            // 
            // mnsAccount
            // 
            this.mnsAccount.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.mnsAccount.Location = new System.Drawing.Point(0, 0);
            this.mnsAccount.Name = "mnsAccount";
            this.mnsAccount.Size = new System.Drawing.Size(1068, 24);
            this.mnsAccount.TabIndex = 1;
            this.mnsAccount.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1068, 555);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 555);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvAccount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 203);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Tree";
            // 
            // trvAccount
            // 
            this.trvAccount.BackColor = System.Drawing.SystemColors.Control;
            this.trvAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvAccount.Location = new System.Drawing.Point(3, 16);
            this.trvAccount.Name = "trvAccount";
            treeNode1.Name = "Asset";
            treeNode1.Text = "Asset";
            treeNode2.Name = "Equity";
            treeNode2.Text = "Equity";
            treeNode3.Name = "Expenses";
            treeNode3.Text = "Expenses";
            treeNode4.Name = "Income";
            treeNode4.Text = "Income";
            treeNode5.Name = "Liability";
            treeNode5.Text = "Liability";
            treeNode6.Name = "(Root)";
            treeNode6.Text = "(Root)";
            this.trvAccount.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.trvAccount.Size = new System.Drawing.Size(228, 328);
            this.trvAccount.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel3);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(5, 5);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(234, 188);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Balance";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel11, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel12, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel13, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel14, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel15, 0, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.60947F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.7929F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(228, 169);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Controls.Add(this.lblAccountName, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxAccountCurrency, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(228, 24);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccountName.Location = new System.Drawing.Point(3, 0);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(153, 24);
            this.lblAccountName.TabIndex = 0;
            this.lblAccountName.Text = "---";
            this.lblAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxAccountCurrency
            // 
            this.cbxAccountCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAccountCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccountCurrency.FormattingEnabled = true;
            this.cbxAccountCurrency.Location = new System.Drawing.Point(162, 3);
            this.cbxAccountCurrency.Name = "cbxAccountCurrency";
            this.cbxAccountCurrency.Size = new System.Drawing.Size(63, 21);
            this.cbxAccountCurrency.TabIndex = 1;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.dtpStatementPeriodStart, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.dtpStatementPeriodEnd, 2, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(228, 24);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(106, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStatementPeriodStart
            // 
            this.dtpStatementPeriodStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStatementPeriodStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStatementPeriodStart.Location = new System.Drawing.Point(3, 3);
            this.dtpStatementPeriodStart.Name = "dtpStatementPeriodStart";
            this.dtpStatementPeriodStart.Size = new System.Drawing.Size(97, 20);
            this.dtpStatementPeriodStart.TabIndex = 1;
            // 
            // dtpStatementPeriodEnd
            // 
            this.dtpStatementPeriodEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStatementPeriodEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStatementPeriodEnd.Location = new System.Drawing.Point(127, 3);
            this.dtpStatementPeriodEnd.Name = "dtpStatementPeriodEnd";
            this.dtpStatementPeriodEnd.Size = new System.Drawing.Size(98, 20);
            this.dtpStatementPeriodEnd.TabIndex = 2;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.chkShowBalance, 1, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(228, 24);
            this.tableLayoutPanel11.TabIndex = 2;
            // 
            // chkShowBalance
            // 
            this.chkShowBalance.AutoSize = true;
            this.chkShowBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowBalance.Location = new System.Drawing.Point(128, 3);
            this.chkShowBalance.Name = "chkShowBalance";
            this.chkShowBalance.Size = new System.Drawing.Size(97, 18);
            this.chkShowBalance.TabIndex = 0;
            this.chkShowBalance.Text = "Show Balance";
            this.chkShowBalance.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 3;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel12.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel12.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 72);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(228, 23);
            this.tableLayoutPanel12.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(155, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Credit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(79, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Debit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 3;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel13.Controls.Add(this.lblDebitOpening, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.lblCreditOpening, 2, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 95);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(228, 25);
            this.tableLayoutPanel13.TabIndex = 4;
            // 
            // lblDebitOpening
            // 
            this.lblDebitOpening.AutoSize = true;
            this.lblDebitOpening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebitOpening.Location = new System.Drawing.Point(79, 0);
            this.lblDebitOpening.Name = "lblDebitOpening";
            this.lblDebitOpening.Size = new System.Drawing.Size(70, 25);
            this.lblDebitOpening.TabIndex = 5;
            this.lblDebitOpening.Text = "-";
            this.lblDebitOpening.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Opening";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreditOpening
            // 
            this.lblCreditOpening.AutoSize = true;
            this.lblCreditOpening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreditOpening.Location = new System.Drawing.Point(155, 0);
            this.lblCreditOpening.Name = "lblCreditOpening";
            this.lblCreditOpening.Size = new System.Drawing.Size(70, 25);
            this.lblCreditOpening.TabIndex = 8;
            this.lblCreditOpening.Text = "-";
            this.lblCreditOpening.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 3;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel14.Controls.Add(this.lblDebitAmount, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.lblCreditAmount, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 120);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(228, 24);
            this.tableLayoutPanel14.TabIndex = 5;
            // 
            // lblDebitAmount
            // 
            this.lblDebitAmount.AutoSize = true;
            this.lblDebitAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebitAmount.Location = new System.Drawing.Point(79, 0);
            this.lblDebitAmount.Name = "lblDebitAmount";
            this.lblDebitAmount.Size = new System.Drawing.Size(70, 24);
            this.lblDebitAmount.TabIndex = 6;
            this.lblDebitAmount.Text = "-";
            this.lblDebitAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreditAmount
            // 
            this.lblCreditAmount.AutoSize = true;
            this.lblCreditAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreditAmount.Location = new System.Drawing.Point(155, 0);
            this.lblCreditAmount.Name = "lblCreditAmount";
            this.lblCreditAmount.Size = new System.Drawing.Size(70, 24);
            this.lblCreditAmount.TabIndex = 9;
            this.lblCreditAmount.Text = "-";
            this.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Amount";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel15.Controls.Add(this.lblCreditEnding, 2, 0);
            this.tableLayoutPanel15.Controls.Add(this.lblDebitEnding, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 144);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(228, 25);
            this.tableLayoutPanel15.TabIndex = 6;
            // 
            // lblCreditEnding
            // 
            this.lblCreditEnding.AutoSize = true;
            this.lblCreditEnding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreditEnding.Location = new System.Drawing.Point(155, 0);
            this.lblCreditEnding.Name = "lblCreditEnding";
            this.lblCreditEnding.Size = new System.Drawing.Size(70, 25);
            this.lblCreditEnding.TabIndex = 10;
            this.lblCreditEnding.Text = "-";
            this.lblCreditEnding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDebitEnding
            // 
            this.lblDebitEnding.AutoSize = true;
            this.lblDebitEnding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebitEnding.Location = new System.Drawing.Point(79, 0);
            this.lblDebitEnding.Name = "lblDebitEnding";
            this.lblDebitEnding.Size = new System.Drawing.Size(70, 25);
            this.lblDebitEnding.TabIndex = 7;
            this.lblDebitEnding.Text = "-";
            this.lblDebitEnding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ending";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 820F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(820, 555);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.44454F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.44454F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(820, 280);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(5, 5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 270);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "In-flow Pie Chart";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 251F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.picDebit, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lsbDebit, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(394, 251);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // lsbDebit
            // 
            this.lsbDebit.BackColor = System.Drawing.SystemColors.Control;
            this.lsbDebit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsbDebit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbDebit.FormattingEnabled = true;
            this.lsbDebit.Location = new System.Drawing.Point(254, 3);
            this.lsbDebit.Name = "lsbDebit";
            this.lsbDebit.Size = new System.Drawing.Size(137, 245);
            this.lsbDebit.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(415, 5);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 270);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Out-flow Pie Chart";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 251F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.picCredit, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.lsbCredit, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(394, 251);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // lsbCredit
            // 
            this.lsbCredit.BackColor = System.Drawing.SystemColors.Control;
            this.lsbCredit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsbCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbCredit.FormattingEnabled = true;
            this.lsbCredit.Location = new System.Drawing.Point(254, 3);
            this.lsbCredit.Name = "lsbCredit";
            this.lsbCredit.Size = new System.Drawing.Size(137, 245);
            this.lsbCredit.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox7, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 280);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(820, 275);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dgvDetail);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(808, 263);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Details";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colYear,
            this.colMonth,
            this.colDay,
            this.colSummary,
            this.colAccount,
            this.colOppositeAccount,
            this.colDebitOrCredit,
            this.colAmount,
            this.colCurrency,
            this.colEquivalentAmount,
            this.colCurrencyRate});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 16);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(802, 244);
            this.dgvDetail.TabIndex = 0;
            // 
            // colYear
            // 
            this.colYear.HeaderText = "Year";
            this.colYear.Name = "colYear";
            this.colYear.Width = 54;
            // 
            // colMonth
            // 
            this.colMonth.HeaderText = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.Width = 60;
            // 
            // colDay
            // 
            this.colDay.HeaderText = "Day";
            this.colDay.Name = "colDay";
            this.colDay.Width = 48;
            // 
            // colSummary
            // 
            this.colSummary.HeaderText = "Summary";
            this.colSummary.Name = "colSummary";
            this.colSummary.Width = 72;
            // 
            // colAccount
            // 
            this.colAccount.HeaderText = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.Width = 72;
            // 
            // colOppositeAccount
            // 
            this.colOppositeAccount.HeaderText = "Opposite Account";
            this.colOppositeAccount.Name = "colOppositeAccount";
            this.colOppositeAccount.Width = 178;
            // 
            // colDebitOrCredit
            // 
            this.colDebitOrCredit.HeaderText = "D/C";
            this.colDebitOrCredit.Name = "colDebitOrCredit";
            this.colDebitOrCredit.Width = 48;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 66;
            // 
            // colCurrency
            // 
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.Width = 78;
            // 
            // colEquivalentAmount
            // 
            this.colEquivalentAmount.HeaderText = "Equivalent Amount";
            this.colEquivalentAmount.Name = "colEquivalentAmount";
            this.colEquivalentAmount.Width = 180;
            // 
            // colCurrencyRate
            // 
            this.colCurrencyRate.HeaderText = "Currency Rate";
            this.colCurrencyRate.Name = "colCurrencyRate";
            this.colCurrencyRate.Width = 160;
            // 
            // iglAccount
            // 
            this.iglAccount.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iglAccount.ImageSize = new System.Drawing.Size(16, 16);
            this.iglAccount.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmsAccount
            // 
            this.cmsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountToolStripMenuItem,
            this.deleteAccountToolStripMenuItem,
            this.deleteAccountToolStripMenuItem1,
            this.toolStripSeparator1,
            this.upToolStripMenuItem,
            this.downToolStripMenuItem,
            this.toolStripSeparator2,
            this.belongToToolStripMenuItem,
            this.independentToolStripMenuItem});
            this.cmsAccount.Name = "cmsAccount";
            this.cmsAccount.Size = new System.Drawing.Size(166, 170);
            // 
            // addAccountToolStripMenuItem
            // 
            this.addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            this.addAccountToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addAccountToolStripMenuItem.Text = "Add Account";
            // 
            // deleteAccountToolStripMenuItem
            // 
            this.deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
            this.deleteAccountToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.deleteAccountToolStripMenuItem.Text = "Rename Account";
            // 
            // deleteAccountToolStripMenuItem1
            // 
            this.deleteAccountToolStripMenuItem1.Name = "deleteAccountToolStripMenuItem1";
            this.deleteAccountToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.deleteAccountToolStripMenuItem1.Text = "Delete Account";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.upToolStripMenuItem.Text = "Up";
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.downToolStripMenuItem.Text = "Down";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // belongToToolStripMenuItem
            // 
            this.belongToToolStripMenuItem.Name = "belongToToolStripMenuItem";
            this.belongToToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.belongToToolStripMenuItem.Text = "Belong To";
            // 
            // independentToolStripMenuItem
            // 
            this.independentToolStripMenuItem.Name = "independentToolStripMenuItem";
            this.independentToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.independentToolStripMenuItem.Text = "Independent";
            // 
            // picDebit
            // 
            this.picDebit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDebit.Location = new System.Drawing.Point(3, 3);
            this.picDebit.Name = "picDebit";
            this.picDebit.Size = new System.Drawing.Size(245, 245);
            this.picDebit.TabIndex = 0;
            this.picDebit.TabStop = false;
            // 
            // picCredit
            // 
            this.picCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCredit.Location = new System.Drawing.Point(3, 3);
            this.picCredit.Name = "picCredit";
            this.picCredit.Size = new System.Drawing.Size(245, 245);
            this.picCredit.TabIndex = 0;
            this.picCredit.TabStop = false;
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 601);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.stsAccount);
            this.Controls.Add(this.mnsAccount);
            this.MainMenuStrip = this.mnsAccount;
            this.Name = "frmAccount";
            this.Text = "frmAccount";
            this.stsAccount.ResumeLayout(false);
            this.stsAccount.PerformLayout();
            this.mnsAccount.ResumeLayout(false);
            this.mnsAccount.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.cmsAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDebit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsAccount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip mnsAccount;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOppositeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebitOrCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquivalentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyRate;
        private System.Windows.Forms.ImageList iglAccount;
        private System.Windows.Forms.TreeView trvAccount;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.ComboBox cbxAccountCurrency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.CheckBox chkShowBalance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label lblDebitOpening;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCreditOpening;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Label lblDebitAmount;
        private System.Windows.Forms.Label lblCreditAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label lblCreditEnding;
        private System.Windows.Forms.Label lblDebitEnding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.PictureBox picDebit;
        private System.Windows.Forms.ListBox lsbDebit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.PictureBox picCredit;
        private System.Windows.Forms.ListBox lsbCredit;
        private System.Windows.Forms.ContextMenuStrip cmsAccount;
        private System.Windows.Forms.ToolStripMenuItem addAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAccountToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem belongToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem independentToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpStatementPeriodStart;
        private System.Windows.Forms.DateTimePicker dtpStatementPeriodEnd;
    }
}