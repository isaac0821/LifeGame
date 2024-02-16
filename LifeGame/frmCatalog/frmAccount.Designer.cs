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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("(Root)");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccount));
            this.stsAccount = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnsAccount = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCurrencyRate = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReportRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trvAccount = new System.Windows.Forms.TreeView();
            this.cmsAccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRenameAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBelongTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIndependent = new System.Windows.Forms.ToolStripMenuItem();
            this.iglAccount = new System.Windows.Forms.ImageList(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFutureDebitEnding = new System.Windows.Forms.Label();
            this.lblFutureCreditEnding = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStatementPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.dtpStatementPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.chkShowBalance = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpEndOfPredictPeriod = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.lblFutureBalance = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFutureDebitAmount = new System.Windows.Forms.Label();
            this.lblFutureCreditAmount = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOppositeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebitOrCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquivalentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picDebit = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picCredit = new System.Windows.Forms.PictureBox();
            this.stsAccount.SuspendLayout();
            this.mnsAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsAccount.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDebit)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.stsAccount.Size = new System.Drawing.Size(1155, 22);
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
            this.filesFToolStripMenuItem,
            this.settingSToolStripMenuItem,
            this.statisticsDToolStripMenuItem});
            this.mnsAccount.Location = new System.Drawing.Point(0, 0);
            this.mnsAccount.Name = "mnsAccount";
            this.mnsAccount.Size = new System.Drawing.Size(1155, 24);
            this.mnsAccount.TabIndex = 1;
            this.mnsAccount.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // settingSToolStripMenuItem
            // 
            this.settingSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCurrencyRate,
            this.modeToolStripMenuItem});
            this.settingSToolStripMenuItem.Name = "settingSToolStripMenuItem";
            this.settingSToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.settingSToolStripMenuItem.Text = "Setting(&S)";
            // 
            // tsmCurrencyRate
            // 
            this.tsmCurrencyRate.Name = "tsmCurrencyRate";
            this.tsmCurrencyRate.Size = new System.Drawing.Size(148, 22);
            this.tsmCurrencyRate.Text = "Currency Rate";
            this.tsmCurrencyRate.Click += new System.EventHandler(this.tsmCurrencyRate_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkModeToolStripMenuItem,
            this.lightModeToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.darkModeToolStripMenuItem.Text = "Dark Mode";
            // 
            // lightModeToolStripMenuItem
            // 
            this.lightModeToolStripMenuItem.Name = "lightModeToolStripMenuItem";
            this.lightModeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.lightModeToolStripMenuItem.Text = "Light Mode";
            // 
            // statisticsDToolStripMenuItem
            // 
            this.statisticsDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateReportRToolStripMenuItem,
            this.analysisAToolStripMenuItem});
            this.statisticsDToolStripMenuItem.Name = "statisticsDToolStripMenuItem";
            this.statisticsDToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.statisticsDToolStripMenuItem.Text = "Statistics(&D)";
            // 
            // generateReportRToolStripMenuItem
            // 
            this.generateReportRToolStripMenuItem.Name = "generateReportRToolStripMenuItem";
            this.generateReportRToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.generateReportRToolStripMenuItem.Text = "Generate Report(&R)";
            // 
            // analysisAToolStripMenuItem
            // 
            this.analysisAToolStripMenuItem.Name = "analysisAToolStripMenuItem";
            this.analysisAToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.analysisAToolStripMenuItem.Text = "Analysis(&A)";
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
            this.splitContainer1.Size = new System.Drawing.Size(1155, 555);
            this.splitContainer1.SplitterDistance = 262;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 555);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvAccount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 296);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Tree";
            // 
            // trvAccount
            // 
            this.trvAccount.BackColor = System.Drawing.SystemColors.Control;
            this.trvAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvAccount.ContextMenuStrip = this.cmsAccount;
            this.trvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvAccount.ImageIndex = 0;
            this.trvAccount.ImageList = this.iglAccount;
            this.trvAccount.Location = new System.Drawing.Point(3, 16);
            this.trvAccount.Name = "trvAccount";
            treeNode1.Name = "(Root)";
            treeNode1.Text = "(Root)";
            this.trvAccount.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvAccount.SelectedImageIndex = 0;
            this.trvAccount.Size = new System.Drawing.Size(246, 235);
            this.trvAccount.TabIndex = 0;
            this.trvAccount.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvAccount_AfterSelect);
            // 
            // cmsAccount
            // 
            this.cmsAccount.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddAccount,
            this.tsmRenameAccount,
            this.tsmDeleteAccount,
            this.toolStripSeparator1,
            this.tsmUp,
            this.tsmDown,
            this.toolStripSeparator2,
            this.tsmBelongTo,
            this.tsmIndependent});
            this.cmsAccount.Name = "cmsAccount";
            this.cmsAccount.Size = new System.Drawing.Size(166, 170);
            // 
            // tsmAddAccount
            // 
            this.tsmAddAccount.Name = "tsmAddAccount";
            this.tsmAddAccount.Size = new System.Drawing.Size(165, 22);
            this.tsmAddAccount.Text = "Add Account";
            this.tsmAddAccount.Click += new System.EventHandler(this.tsmAddAccount_Click);
            // 
            // tsmRenameAccount
            // 
            this.tsmRenameAccount.Name = "tsmRenameAccount";
            this.tsmRenameAccount.Size = new System.Drawing.Size(165, 22);
            this.tsmRenameAccount.Text = "Rename Account";
            this.tsmRenameAccount.Click += new System.EventHandler(this.tsmRenameAccount_Click);
            // 
            // tsmDeleteAccount
            // 
            this.tsmDeleteAccount.Name = "tsmDeleteAccount";
            this.tsmDeleteAccount.Size = new System.Drawing.Size(165, 22);
            this.tsmDeleteAccount.Text = "Delete Account";
            this.tsmDeleteAccount.Click += new System.EventHandler(this.tsmDeleteAccount_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmUp
            // 
            this.tsmUp.Name = "tsmUp";
            this.tsmUp.Size = new System.Drawing.Size(165, 22);
            this.tsmUp.Text = "Up";
            this.tsmUp.Click += new System.EventHandler(this.tsmUp_Click);
            // 
            // tsmDown
            // 
            this.tsmDown.Name = "tsmDown";
            this.tsmDown.Size = new System.Drawing.Size(165, 22);
            this.tsmDown.Text = "Down";
            this.tsmDown.Click += new System.EventHandler(this.tsmDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmBelongTo
            // 
            this.tsmBelongTo.Name = "tsmBelongTo";
            this.tsmBelongTo.Size = new System.Drawing.Size(165, 22);
            this.tsmBelongTo.Text = "Belong To";
            this.tsmBelongTo.Click += new System.EventHandler(this.tsmBelongTo_Click);
            // 
            // tsmIndependent
            // 
            this.tsmIndependent.Name = "tsmIndependent";
            this.tsmIndependent.Size = new System.Drawing.Size(165, 22);
            this.tsmIndependent.Text = "Independent";
            this.tsmIndependent.Click += new System.EventHandler(this.tsmIndependent_Click);
            // 
            // iglAccount
            // 
            this.iglAccount.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglAccount.ImageStream")));
            this.iglAccount.TransparentColor = System.Drawing.Color.Transparent;
            this.iglAccount.Images.SetKeyName(0, "iconWW.png");
            this.iglAccount.Images.SetKeyName(1, "iconIn.png");
            this.iglAccount.Images.SetKeyName(2, "iconInAndOut.png");
            this.iglAccount.Images.SetKeyName(3, "iconOut.png");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel3);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(5, 5);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(252, 281);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Balance";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel9, 0, 10);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel11, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel12, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel13, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel14, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel15, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel8, 0, 9);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 11;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091001F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090092F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(246, 262);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel9.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblFutureDebitEnding, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblFutureCreditEnding, 2, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 230);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(246, 32);
            this.tableLayoutPanel9.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(2, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 32);
            this.label10.TabIndex = 0;
            this.label10.Text = "Predict Ending";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFutureDebitEnding
            // 
            this.lblFutureDebitEnding.AutoSize = true;
            this.lblFutureDebitEnding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFutureDebitEnding.Location = new System.Drawing.Point(100, 0);
            this.lblFutureDebitEnding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFutureDebitEnding.Name = "lblFutureDebitEnding";
            this.lblFutureDebitEnding.Size = new System.Drawing.Size(69, 32);
            this.lblFutureDebitEnding.TabIndex = 1;
            this.lblFutureDebitEnding.Text = "-";
            this.lblFutureDebitEnding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFutureCreditEnding
            // 
            this.lblFutureCreditEnding.AutoSize = true;
            this.lblFutureCreditEnding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFutureCreditEnding.Location = new System.Drawing.Point(173, 0);
            this.lblFutureCreditEnding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFutureCreditEnding.Name = "lblFutureCreditEnding";
            this.lblFutureCreditEnding.Size = new System.Drawing.Size(71, 32);
            this.lblFutureCreditEnding.TabIndex = 2;
            this.lblFutureCreditEnding.Text = "-";
            this.lblFutureCreditEnding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Controls.Add(this.lblAccountName, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblCurrency, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccountName.Location = new System.Drawing.Point(3, 0);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(166, 23);
            this.lblAccountName.TabIndex = 0;
            this.lblAccountName.Text = "---";
            this.lblAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrency.Location = new System.Drawing.Point(175, 0);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(68, 23);
            this.lblCurrency.TabIndex = 1;
            this.lblCurrency.Text = "USD";
            this.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel10.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.dtpStatementPeriodStart, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.dtpStatementPeriodEnd, 2, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(104, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 23);
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
            this.dtpStatementPeriodStart.Size = new System.Drawing.Size(95, 20);
            this.dtpStatementPeriodStart.TabIndex = 1;
            // 
            // dtpStatementPeriodEnd
            // 
            this.dtpStatementPeriodEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStatementPeriodEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStatementPeriodEnd.Location = new System.Drawing.Point(148, 3);
            this.dtpStatementPeriodEnd.Name = "dtpStatementPeriodEnd";
            this.dtpStatementPeriodEnd.Size = new System.Drawing.Size(95, 20);
            this.dtpStatementPeriodEnd.TabIndex = 2;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 4;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel11.Controls.Add(this.chkShowBalance, 3, 0);
            this.tableLayoutPanel11.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.lblBalance, 1, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel11.TabIndex = 2;
            // 
            // chkShowBalance
            // 
            this.chkShowBalance.AutoSize = true;
            this.chkShowBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowBalance.Location = new System.Drawing.Point(146, 3);
            this.chkShowBalance.Name = "chkShowBalance";
            this.chkShowBalance.Size = new System.Drawing.Size(97, 17);
            this.chkShowBalance.TabIndex = 0;
            this.chkShowBalance.Text = "Show Balance";
            this.chkShowBalance.UseVisualStyleBackColor = true;
            this.chkShowBalance.CheckedChanged += new System.EventHandler(this.chkShowBalance_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 23);
            this.label11.TabIndex = 1;
            this.label11.Text = "Balance";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBalance.Location = new System.Drawing.Point(69, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(60, 23);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "-";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 3;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel12.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel12.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 69);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel12.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(174, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Credit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(101, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Debit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 3;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel13.Controls.Add(this.lblDebitOpening, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.lblCreditOpening, 2, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 92);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel13.TabIndex = 4;
            // 
            // lblDebitOpening
            // 
            this.lblDebitOpening.AutoSize = true;
            this.lblDebitOpening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebitOpening.Location = new System.Drawing.Point(101, 0);
            this.lblDebitOpening.Name = "lblDebitOpening";
            this.lblDebitOpening.Size = new System.Drawing.Size(67, 23);
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
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Opening";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreditOpening
            // 
            this.lblCreditOpening.AutoSize = true;
            this.lblCreditOpening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreditOpening.Location = new System.Drawing.Point(174, 0);
            this.lblCreditOpening.Name = "lblCreditOpening";
            this.lblCreditOpening.Size = new System.Drawing.Size(69, 23);
            this.lblCreditOpening.TabIndex = 8;
            this.lblCreditOpening.Text = "-";
            this.lblCreditOpening.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 3;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel14.Controls.Add(this.lblDebitAmount, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.lblCreditAmount, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 115);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel14.TabIndex = 5;
            // 
            // lblDebitAmount
            // 
            this.lblDebitAmount.AutoSize = true;
            this.lblDebitAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebitAmount.Location = new System.Drawing.Point(101, 0);
            this.lblDebitAmount.Name = "lblDebitAmount";
            this.lblDebitAmount.Size = new System.Drawing.Size(67, 23);
            this.lblDebitAmount.TabIndex = 6;
            this.lblDebitAmount.Text = "-";
            this.lblDebitAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreditAmount
            // 
            this.lblCreditAmount.AutoSize = true;
            this.lblCreditAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreditAmount.Location = new System.Drawing.Point(174, 0);
            this.lblCreditAmount.Name = "lblCreditAmount";
            this.lblCreditAmount.Size = new System.Drawing.Size(69, 23);
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
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Amount";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel15.Controls.Add(this.lblCreditEnding, 2, 0);
            this.tableLayoutPanel15.Controls.Add(this.lblDebitEnding, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 138);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel15.TabIndex = 6;
            // 
            // lblCreditEnding
            // 
            this.lblCreditEnding.AutoSize = true;
            this.lblCreditEnding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreditEnding.Location = new System.Drawing.Point(174, 0);
            this.lblCreditEnding.Name = "lblCreditEnding";
            this.lblCreditEnding.Size = new System.Drawing.Size(69, 23);
            this.lblCreditEnding.TabIndex = 10;
            this.lblCreditEnding.Text = "-";
            this.lblCreditEnding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDebitEnding
            // 
            this.lblDebitEnding.AutoSize = true;
            this.lblDebitEnding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebitEnding.Location = new System.Drawing.Point(101, 0);
            this.lblDebitEnding.Name = "lblDebitEnding";
            this.lblDebitEnding.Size = new System.Drawing.Size(67, 23);
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
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ending";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel4.Controls.Add(this.dtpEndOfPredictPeriod, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblFutureBalance, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 161);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // dtpEndOfPredictPeriod
            // 
            this.dtpEndOfPredictPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEndOfPredictPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndOfPredictPeriod.Location = new System.Drawing.Point(148, 3);
            this.dtpEndOfPredictPeriod.Name = "dtpEndOfPredictPeriod";
            this.dtpEndOfPredictPeriod.Size = new System.Drawing.Size(95, 20);
            this.dtpEndOfPredictPeriod.TabIndex = 2;
            this.dtpEndOfPredictPeriod.ValueChanged += new System.EventHandler(this.dtpEndOfPredictPeriod_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 23);
            this.label13.TabIndex = 3;
            this.label13.Text = "Balance";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFutureBalance
            // 
            this.lblFutureBalance.AutoSize = true;
            this.lblFutureBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFutureBalance.Location = new System.Drawing.Point(69, 0);
            this.lblFutureBalance.Name = "lblFutureBalance";
            this.lblFutureBalance.Size = new System.Drawing.Size(60, 23);
            this.lblFutureBalance.TabIndex = 4;
            this.lblFutureBalance.Text = "-";
            this.lblFutureBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 184);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel7.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(100, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Debit";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(173, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Credit";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel8.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lblFutureDebitAmount, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.lblFutureCreditAmount, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 207);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel8.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(2, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Predict Amount";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFutureDebitAmount
            // 
            this.lblFutureDebitAmount.AutoSize = true;
            this.lblFutureDebitAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFutureDebitAmount.Location = new System.Drawing.Point(100, 0);
            this.lblFutureDebitAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFutureDebitAmount.Name = "lblFutureDebitAmount";
            this.lblFutureDebitAmount.Size = new System.Drawing.Size(69, 23);
            this.lblFutureDebitAmount.TabIndex = 1;
            this.lblFutureDebitAmount.Text = "-";
            this.lblFutureDebitAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFutureCreditAmount
            // 
            this.lblFutureCreditAmount.AutoSize = true;
            this.lblFutureCreditAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFutureCreditAmount.Location = new System.Drawing.Point(173, 0);
            this.lblFutureCreditAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFutureCreditAmount.Name = "lblFutureCreditAmount";
            this.lblFutureCreditAmount.Size = new System.Drawing.Size(71, 23);
            this.lblFutureCreditAmount.TabIndex = 2;
            this.lblFutureCreditAmount.Text = "-";
            this.lblFutureCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 889F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(889, 555);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox7, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(889, 555);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dgvDetail);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(6, 206);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(877, 343);
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
            this.colDate,
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
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(871, 324);
            this.dgvDetail.TabIndex = 0;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;
            // 
            // colSummary
            // 
            this.colSummary.HeaderText = "Summary";
            this.colSummary.Name = "colSummary";
            this.colSummary.ReadOnly = true;
            this.colSummary.Width = 72;
            // 
            // colAccount
            // 
            this.colAccount.HeaderText = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            this.colAccount.Width = 72;
            // 
            // colOppositeAccount
            // 
            this.colOppositeAccount.HeaderText = "Opposite Account";
            this.colOppositeAccount.Name = "colOppositeAccount";
            this.colOppositeAccount.ReadOnly = true;
            this.colOppositeAccount.Width = 178;
            // 
            // colDebitOrCredit
            // 
            this.colDebitOrCredit.HeaderText = "D/C";
            this.colDebitOrCredit.Name = "colDebitOrCredit";
            this.colDebitOrCredit.ReadOnly = true;
            this.colDebitOrCredit.Width = 48;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 66;
            // 
            // colCurrency
            // 
            this.colCurrency.HeaderText = "Currency/Unit";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            this.colCurrency.Width = 78;
            // 
            // colEquivalentAmount
            // 
            this.colEquivalentAmount.HeaderText = "Equivalent Amount";
            this.colEquivalentAmount.Name = "colEquivalentAmount";
            this.colEquivalentAmount.ReadOnly = true;
            this.colEquivalentAmount.Width = 180;
            // 
            // colCurrencyRate
            // 
            this.colCurrencyRate.HeaderText = "Currency/Unit Exchange Rate";
            this.colCurrencyRate.Name = "colCurrencyRate";
            this.colCurrencyRate.ReadOnly = true;
            this.colCurrencyRate.Width = 230;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picDebit);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(883, 94);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Debit";
            // 
            // picDebit
            // 
            this.picDebit.BackColor = System.Drawing.Color.White;
            this.picDebit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDebit.Location = new System.Drawing.Point(3, 16);
            this.picDebit.Name = "picDebit";
            this.picDebit.Size = new System.Drawing.Size(877, 75);
            this.picDebit.TabIndex = 0;
            this.picDebit.TabStop = false;
            this.picDebit.Click += new System.EventHandler(this.picDebit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picCredit);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(883, 94);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Credit";
            // 
            // picCredit
            // 
            this.picCredit.BackColor = System.Drawing.Color.White;
            this.picCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCredit.Location = new System.Drawing.Point(3, 16);
            this.picCredit.Name = "picCredit";
            this.picCredit.Size = new System.Drawing.Size(877, 75);
            this.picCredit.TabIndex = 0;
            this.picCredit.TabStop = false;
            this.picCredit.Click += new System.EventHandler(this.picCredit_Click);
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 601);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.stsAccount);
            this.Controls.Add(this.mnsAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsAccount;
            this.Name = "frmAccount";
            this.Text = "LifeGame - Account";
            this.Load += new System.EventHandler(this.frmAccount_Load);
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
            this.cmsAccount.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDebit)).EndInit();
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.ImageList iglAccount;
        private System.Windows.Forms.TreeView trvAccount;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblAccountName;
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
        private System.Windows.Forms.ContextMenuStrip cmsAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmAddAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmRenameAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmUp;
        private System.Windows.Forms.ToolStripMenuItem tsmDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmBelongTo;
        private System.Windows.Forms.ToolStripMenuItem tsmIndependent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpStatementPeriodStart;
        private System.Windows.Forms.DateTimePicker dtpStatementPeriodEnd;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ToolStripMenuItem settingSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmCurrencyRate;
        private System.Windows.Forms.ToolStripMenuItem statisticsDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisAToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DateTimePicker dtpEndOfPredictPeriod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFutureDebitEnding;
        private System.Windows.Forms.Label lblFutureCreditEnding;
        private System.Windows.Forms.Label lblFutureDebitAmount;
        private System.Windows.Forms.Label lblFutureCreditAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblFutureBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOppositeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebitOrCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquivalentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyRate;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightModeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picDebit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox picCredit;
    }
}