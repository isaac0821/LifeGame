namespace LifeGame
{
    partial class frmLiterature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiterature));
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExportBib = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trvTag = new System.Windows.Forms.TreeView();
            this.cmsTags = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmFold = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTagSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTagClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEditTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveTag = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmIndependent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBelongTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmCreateNote = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartYear = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtEndYear = new System.Windows.Forms.TextBox();
            this.btnAuthorAndJournal = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxMode = new System.Windows.Forms.ComboBox();
            this.btnSearchInResult = new System.Windows.Forms.Button();
            this.txtSearchInRes = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.chkNoBad = new System.Windows.Forms.CheckBox();
            this.chkOnlyGood = new System.Windows.Forms.CheckBox();
            this.lblNumFound = new System.Windows.Forms.Label();
            this.chkHightlight = new System.Windows.Forms.CheckBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLiterature = new System.Windows.Forms.DataGridView();
            this.Star = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Publisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoodJournal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPredatory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsLiterature = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmViewLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAddLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.addTag2Multi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveTagFromMulti = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAddToTempLitsArea = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddToAreaA = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddToAreaB = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tblTempArea = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clbAuthor = new System.Windows.Forms.CheckedListBox();
            this.cmsAuthor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.clbJournalConference = new System.Windows.Forms.CheckedListBox();
            this.cmsJournal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allJournalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allConferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTempLitsArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmTempSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTempClearSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTempSort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTempClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveDupsA = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveDupsB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIntersectAwithB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIntersectBwithA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmReplaceMainLitsArea = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddToMainLitsArea = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddSelectedToMainLitsArea = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmH2V = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsTags.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiterature)).BeginInit();
            this.cmsLiterature.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmsAuthor.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.cmsJournal.SuspendLayout();
            this.cmsTempLitsArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.BackColor = System.Drawing.SystemColors.Control;
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(1022, 24);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.filesFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExportBib});
            this.filesFToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // tsmExportBib
            // 
            this.tsmExportBib.Name = "tsmExportBib";
            this.tsmExportBib.Size = new System.Drawing.Size(180, 22);
            this.tsmExportBib.Text = "Export bib";
            this.tsmExportBib.Click += new System.EventHandler(this.tsmExportBib_Click);
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
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(1022, 648);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 642);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSearch, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(279, 25);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(228, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(228, 20);
            this.txtSearch.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvTag);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 543);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tags";
            // 
            // trvTag
            // 
            this.trvTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvTag.CheckBoxes = true;
            this.trvTag.ContextMenuStrip = this.cmsTags;
            this.trvTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTag.Location = new System.Drawing.Point(3, 16);
            this.trvTag.Name = "trvTag";
            treeNode1.Name = "rootNode";
            treeNode1.Text = "(Root)";
            this.trvTag.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvTag.Size = new System.Drawing.Size(273, 524);
            this.trvTag.TabIndex = 2;
            this.trvTag.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvTag_AfterCheck);
            this.trvTag.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTag_AfterSelect);
            this.trvTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trvTag_KeyDown);
            this.trvTag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trvTag_KeyPress);
            // 
            // cmsTags
            // 
            this.cmsTags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.toolStripSeparator4,
            this.tsmFold,
            this.tsmExpand,
            this.toolStripSeparator2,
            this.tsmTagSelectAll,
            this.tsmTagClear,
            this.toolStripSeparator11,
            this.tsmSort,
            this.toolStripSeparator3,
            this.tsmEditTag,
            this.tsmRemoveTag,
            this.toolStripSeparator6,
            this.tsmUp,
            this.tsmDown,
            this.toolStripSeparator7,
            this.tsmIndependent,
            this.tsmBelongTo,
            this.toolStripSeparator8,
            this.tsmCreateNote});
            this.cmsTags.Name = "cmsTags";
            this.cmsTags.Size = new System.Drawing.Size(154, 332);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(153, 22);
            this.tsmAdd.Text = "Add(&A)...";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmFold
            // 
            this.tsmFold.Name = "tsmFold";
            this.tsmFold.Size = new System.Drawing.Size(153, 22);
            this.tsmFold.Text = "Fold(&N)";
            this.tsmFold.Click += new System.EventHandler(this.tsmFold_Click);
            // 
            // tsmExpand
            // 
            this.tsmExpand.Name = "tsmExpand";
            this.tsmExpand.Size = new System.Drawing.Size(153, 22);
            this.tsmExpand.Text = "Expand(&M)";
            this.tsmExpand.Click += new System.EventHandler(this.tsmExpand_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmTagSelectAll
            // 
            this.tsmTagSelectAll.Name = "tsmTagSelectAll";
            this.tsmTagSelectAll.Size = new System.Drawing.Size(153, 22);
            this.tsmTagSelectAll.Text = "Select All";
            this.tsmTagSelectAll.Visible = false;
            // 
            // tsmTagClear
            // 
            this.tsmTagClear.Name = "tsmTagClear";
            this.tsmTagClear.Size = new System.Drawing.Size(153, 22);
            this.tsmTagClear.Text = "Clear";
            this.tsmTagClear.Visible = false;
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(150, 6);
            this.toolStripSeparator11.Visible = false;
            // 
            // tsmSort
            // 
            this.tsmSort.Name = "tsmSort";
            this.tsmSort.Size = new System.Drawing.Size(153, 22);
            this.tsmSort.Text = "Sort";
            this.tsmSort.Click += new System.EventHandler(this.tsmSort_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmEditTag
            // 
            this.tsmEditTag.Name = "tsmEditTag";
            this.tsmEditTag.Size = new System.Drawing.Size(153, 22);
            this.tsmEditTag.Text = "Edit(&E)...";
            this.tsmEditTag.Click += new System.EventHandler(this.tsmEditTag_Click);
            // 
            // tsmRemoveTag
            // 
            this.tsmRemoveTag.Name = "tsmRemoveTag";
            this.tsmRemoveTag.Size = new System.Drawing.Size(153, 22);
            this.tsmRemoveTag.Text = "Remove(&D)...";
            this.tsmRemoveTag.Click += new System.EventHandler(this.tsmRemoveTag_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmUp
            // 
            this.tsmUp.Name = "tsmUp";
            this.tsmUp.Size = new System.Drawing.Size(153, 22);
            this.tsmUp.Text = "Up(&I)";
            this.tsmUp.Click += new System.EventHandler(this.tsmUp_Click);
            // 
            // tsmDown
            // 
            this.tsmDown.Name = "tsmDown";
            this.tsmDown.Size = new System.Drawing.Size(153, 22);
            this.tsmDown.Text = "Down(&K)";
            this.tsmDown.Click += new System.EventHandler(this.tsmDown_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmIndependent
            // 
            this.tsmIndependent.Name = "tsmIndependent";
            this.tsmIndependent.Size = new System.Drawing.Size(153, 22);
            this.tsmIndependent.Text = "Independent(&J)";
            this.tsmIndependent.Click += new System.EventHandler(this.tsmIndependent_Click);
            // 
            // tsmBelongTo
            // 
            this.tsmBelongTo.Name = "tsmBelongTo";
            this.tsmBelongTo.Size = new System.Drawing.Size(153, 22);
            this.tsmBelongTo.Text = "Belong To(&L)";
            this.tsmBelongTo.Click += new System.EventHandler(this.tsmBelongTo_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmCreateNote
            // 
            this.tsmCreateNote.Name = "tsmCreateNote";
            this.tsmCreateNote.Size = new System.Drawing.Size(153, 22);
            this.tsmCreateNote.Text = "Create Note(&C)";
            this.tsmCreateNote.Click += new System.EventHandler(this.tsmCreateNote_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtStartYear, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnFilter, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtEndYear, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnAuthorAndJournal, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(279, 25);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(89, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStartYear
            // 
            this.txtStartYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStartYear.Location = new System.Drawing.Point(51, 3);
            this.txtStartYear.Name = "txtStartYear";
            this.txtStartYear.Size = new System.Drawing.Size(32, 20);
            this.txtStartYear.TabIndex = 2;
            this.txtStartYear.Text = "1900";
            // 
            // btnFilter
            // 
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilter.Location = new System.Drawing.Point(239, 0);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(0);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(40, 25);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtEndYear
            // 
            this.txtEndYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEndYear.Location = new System.Drawing.Point(104, 3);
            this.txtEndYear.Name = "txtEndYear";
            this.txtEndYear.Size = new System.Drawing.Size(32, 20);
            this.txtEndYear.TabIndex = 3;
            this.txtEndYear.Text = "9999";
            // 
            // btnAuthorAndJournal
            // 
            this.btnAuthorAndJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAuthorAndJournal.Location = new System.Drawing.Point(139, 0);
            this.btnAuthorAndJournal.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuthorAndJournal.Name = "btnAuthorAndJournal";
            this.btnAuthorAndJournal.Size = new System.Drawing.Size(100, 25);
            this.btnAuthorAndJournal.TabIndex = 4;
            this.btnAuthorAndJournal.Text = "Authors/Journal";
            this.btnAuthorAndJournal.UseVisualStyleBackColor = true;
            this.btnAuthorAndJournal.Click += new System.EventHandler(this.btnAuthorAndJournal_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel6.Controls.Add(this.cbxMode, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnSearchInResult, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.txtSearchInRes, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(279, 25);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // cbxMode
            // 
            this.cbxMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMode.FormattingEnabled = true;
            this.cbxMode.Items.AddRange(new object[] {
            "AND",
            "NOT",
            "OR"});
            this.cbxMode.Location = new System.Drawing.Point(3, 3);
            this.cbxMode.Name = "cbxMode";
            this.cbxMode.Size = new System.Drawing.Size(53, 21);
            this.cbxMode.TabIndex = 0;
            // 
            // btnSearchInResult
            // 
            this.btnSearchInResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchInResult.Location = new System.Drawing.Point(182, 0);
            this.btnSearchInResult.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchInResult.Name = "btnSearchInResult";
            this.btnSearchInResult.Size = new System.Drawing.Size(97, 25);
            this.btnSearchInResult.TabIndex = 1;
            this.btnSearchInResult.Text = "Search In Res.";
            this.btnSearchInResult.UseVisualStyleBackColor = true;
            this.btnSearchInResult.Click += new System.EventHandler(this.btnSearchInResult_Click);
            // 
            // txtSearchInRes
            // 
            this.txtSearchInRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchInRes.Location = new System.Drawing.Point(62, 3);
            this.txtSearchInRes.Name = "txtSearchInRes";
            this.txtSearchInRes.Size = new System.Drawing.Size(117, 20);
            this.txtSearchInRes.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel16, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.splitContainer3, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(727, 648);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 4;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel16.Controls.Add(this.chkNoBad, 2, 0);
            this.tableLayoutPanel16.Controls.Add(this.chkOnlyGood, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.lblNumFound, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.chkHightlight, 3, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(721, 26);
            this.tableLayoutPanel16.TabIndex = 4;
            // 
            // chkNoBad
            // 
            this.chkNoBad.AutoSize = true;
            this.chkNoBad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkNoBad.Location = new System.Drawing.Point(457, 3);
            this.chkNoBad.Name = "chkNoBad";
            this.chkNoBad.Size = new System.Drawing.Size(150, 20);
            this.chkNoBad.TabIndex = 0;
            this.chkNoBad.Text = "Exclude low quality paper";
            this.chkNoBad.UseVisualStyleBackColor = true;
            this.chkNoBad.CheckedChanged += new System.EventHandler(this.chkNoBad_CheckedChanged);
            // 
            // chkOnlyGood
            // 
            this.chkOnlyGood.AutoSize = true;
            this.chkOnlyGood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkOnlyGood.Location = new System.Drawing.Point(299, 3);
            this.chkOnlyGood.Name = "chkOnlyGood";
            this.chkOnlyGood.Size = new System.Drawing.Size(152, 20);
            this.chkOnlyGood.TabIndex = 1;
            this.chkOnlyGood.Text = "Only show reliable journal";
            this.chkOnlyGood.UseVisualStyleBackColor = true;
            this.chkOnlyGood.CheckedChanged += new System.EventHandler(this.chkOnlyGood_CheckedChanged);
            // 
            // lblNumFound
            // 
            this.lblNumFound.AutoSize = true;
            this.lblNumFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumFound.Location = new System.Drawing.Point(3, 0);
            this.lblNumFound.Name = "lblNumFound";
            this.lblNumFound.Size = new System.Drawing.Size(290, 26);
            this.lblNumFound.TabIndex = 2;
            this.lblNumFound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkHightlight
            // 
            this.chkHightlight.AutoSize = true;
            this.chkHightlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkHightlight.Location = new System.Drawing.Point(613, 3);
            this.chkHightlight.Name = "chkHightlight";
            this.chkHightlight.Size = new System.Drawing.Size(105, 20);
            this.chkHightlight.TabIndex = 3;
            this.chkHightlight.Text = "Highlight Notes";
            this.chkHightlight.UseVisualStyleBackColor = true;
            this.chkHightlight.CheckedChanged += new System.EventHandler(this.chkHightlight_CheckedChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 35);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(721, 610);
            this.splitContainer3.SplitterDistance = 424;
            this.splitContainer3.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer2.Size = new System.Drawing.Size(721, 424);
            this.splitContainer2.SplitterDistance = 462;
            this.splitContainer2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLiterature);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 424);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main Lits Area";
            // 
            // dgvLiterature
            // 
            this.dgvLiterature.AllowUserToAddRows = false;
            this.dgvLiterature.AllowUserToDeleteRows = false;
            this.dgvLiterature.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLiterature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLiterature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiterature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Star,
            this.colTitle,
            this.Abbr,
            this.Publisher,
            this.colYear,
            this.colLitType,
            this.colGoodJournal,
            this.colPredatory,
            this.addDate,
            this.lastModifyDate});
            this.dgvLiterature.ContextMenuStrip = this.cmsLiterature;
            this.dgvLiterature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLiterature.Location = new System.Drawing.Point(3, 16);
            this.dgvLiterature.Name = "dgvLiterature";
            this.dgvLiterature.ReadOnly = true;
            this.dgvLiterature.Size = new System.Drawing.Size(456, 405);
            this.dgvLiterature.TabIndex = 1;
            this.dgvLiterature.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvLiterature_SortCompare);
            this.dgvLiterature.Sorted += new System.EventHandler(this.dgvLiterature_Sorted);
            // 
            // Star
            // 
            this.Star.HeaderText = "Star";
            this.Star.Name = "Star";
            this.Star.ReadOnly = true;
            this.Star.Width = 40;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 600;
            // 
            // Abbr
            // 
            this.Abbr.HeaderText = "Abbr";
            this.Abbr.Name = "Abbr";
            this.Abbr.ReadOnly = true;
            this.Abbr.Width = 45;
            // 
            // Publisher
            // 
            this.Publisher.HeaderText = "Publisher";
            this.Publisher.Name = "Publisher";
            this.Publisher.ReadOnly = true;
            // 
            // colYear
            // 
            this.colYear.HeaderText = "Year";
            this.colYear.Name = "colYear";
            this.colYear.ReadOnly = true;
            this.colYear.Width = 45;
            // 
            // colLitType
            // 
            this.colLitType.HeaderText = "Type";
            this.colLitType.Name = "colLitType";
            this.colLitType.ReadOnly = true;
            this.colLitType.Width = 45;
            // 
            // colGoodJournal
            // 
            this.colGoodJournal.HeaderText = "Reliable";
            this.colGoodJournal.Name = "colGoodJournal";
            this.colGoodJournal.ReadOnly = true;
            this.colGoodJournal.Width = 95;
            // 
            // colPredatory
            // 
            this.colPredatory.HeaderText = "Garbage";
            this.colPredatory.Name = "colPredatory";
            this.colPredatory.ReadOnly = true;
            this.colPredatory.Width = 95;
            // 
            // addDate
            // 
            this.addDate.HeaderText = "Added Date";
            this.addDate.Name = "addDate";
            this.addDate.ReadOnly = true;
            this.addDate.Width = 120;
            // 
            // lastModifyDate
            // 
            this.lastModifyDate.HeaderText = "Latest Modification";
            this.lastModifyDate.Name = "lastModifyDate";
            this.lastModifyDate.ReadOnly = true;
            this.lastModifyDate.Width = 120;
            // 
            // cmsLiterature
            // 
            this.cmsLiterature.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLiterature.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmViewLiterature,
            this.toolStripSeparator1,
            this.tsmAddLiterature,
            this.tsmRemoveLiterature,
            this.toolStripSeparator5,
            this.addTag2Multi,
            this.tsmRemoveTagFromMulti,
            this.toolStripSeparator12,
            this.tsmAddToTempLitsArea,
            this.copyToNoteToolStripMenuItem});
            this.cmsLiterature.Name = "cmsLiterature";
            this.cmsLiterature.Size = new System.Drawing.Size(146, 176);
            // 
            // tsmViewLiterature
            // 
            this.tsmViewLiterature.Name = "tsmViewLiterature";
            this.tsmViewLiterature.Size = new System.Drawing.Size(145, 22);
            this.tsmViewLiterature.Text = "View";
            this.tsmViewLiterature.Click += new System.EventHandler(this.tsmViewLiterature_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // tsmAddLiterature
            // 
            this.tsmAddLiterature.Name = "tsmAddLiterature";
            this.tsmAddLiterature.Size = new System.Drawing.Size(145, 22);
            this.tsmAddLiterature.Text = "Add";
            this.tsmAddLiterature.Click += new System.EventHandler(this.tsmAddLiterature_Click);
            // 
            // tsmRemoveLiterature
            // 
            this.tsmRemoveLiterature.Name = "tsmRemoveLiterature";
            this.tsmRemoveLiterature.Size = new System.Drawing.Size(145, 22);
            this.tsmRemoveLiterature.Text = "Remove";
            this.tsmRemoveLiterature.Click += new System.EventHandler(this.tsmRemoveLiterature_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(142, 6);
            // 
            // addTag2Multi
            // 
            this.addTag2Multi.Name = "addTag2Multi";
            this.addTag2Multi.Size = new System.Drawing.Size(145, 22);
            this.addTag2Multi.Text = "Add Tag";
            this.addTag2Multi.Click += new System.EventHandler(this.addTag2Multi_Click);
            // 
            // tsmRemoveTagFromMulti
            // 
            this.tsmRemoveTagFromMulti.Name = "tsmRemoveTagFromMulti";
            this.tsmRemoveTagFromMulti.Size = new System.Drawing.Size(145, 22);
            this.tsmRemoveTagFromMulti.Text = "Remove Tag";
            this.tsmRemoveTagFromMulti.Click += new System.EventHandler(this.tsmRemoveTagFromMulti_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(142, 6);
            // 
            // tsmAddToTempLitsArea
            // 
            this.tsmAddToTempLitsArea.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddToAreaA,
            this.tsmAddToAreaB});
            this.tsmAddToTempLitsArea.Name = "tsmAddToTempLitsArea";
            this.tsmAddToTempLitsArea.Size = new System.Drawing.Size(145, 22);
            this.tsmAddToTempLitsArea.Text = "Add to Temp";
            // 
            // tsmAddToAreaA
            // 
            this.tsmAddToAreaA.Name = "tsmAddToAreaA";
            this.tsmAddToAreaA.Size = new System.Drawing.Size(109, 22);
            this.tsmAddToAreaA.Text = "Area A";
            this.tsmAddToAreaA.Click += new System.EventHandler(this.tsmAddToAreaA_Click);
            // 
            // tsmAddToAreaB
            // 
            this.tsmAddToAreaB.Name = "tsmAddToAreaB";
            this.tsmAddToAreaB.Size = new System.Drawing.Size(109, 22);
            this.tsmAddToAreaB.Text = "Area B";
            this.tsmAddToAreaB.Click += new System.EventHandler(this.tsmAddToAreaB_Click);
            // 
            // copyToNoteToolStripMenuItem
            // 
            this.copyToNoteToolStripMenuItem.Name = "copyToNoteToolStripMenuItem";
            this.copyToNoteToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.copyToNoteToolStripMenuItem.Text = "Copy to Note";
            this.copyToNoteToolStripMenuItem.Click += new System.EventHandler(this.tsmCopyToNote);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tblTempArea);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 424);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Temp Lits Area";
            // 
            // tblTempArea
            // 
            this.tblTempArea.ColumnCount = 1;
            this.tblTempArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTempArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTempArea.Location = new System.Drawing.Point(3, 16);
            this.tblTempArea.Name = "tblTempArea";
            this.tblTempArea.RowCount = 2;
            this.tblTempArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTempArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTempArea.Size = new System.Drawing.Size(249, 405);
            this.tblTempArea.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer4.Size = new System.Drawing.Size(721, 182);
            this.splitContainer4.SplitterDistance = 348;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clbAuthor);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 182);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Authors";
            // 
            // clbAuthor
            // 
            this.clbAuthor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbAuthor.ContextMenuStrip = this.cmsAuthor;
            this.clbAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAuthor.FormattingEnabled = true;
            this.clbAuthor.Location = new System.Drawing.Point(3, 16);
            this.clbAuthor.MultiColumn = true;
            this.clbAuthor.Name = "clbAuthor";
            this.clbAuthor.Size = new System.Drawing.Size(342, 163);
            this.clbAuthor.TabIndex = 0;
            // 
            // cmsAuthor
            // 
            this.cmsAuthor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator10,
            this.clearToolStripMenuItem});
            this.cmsAuthor.Name = "cmsAuthor";
            this.cmsAuthor.Size = new System.Drawing.Size(123, 54);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(119, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.clbJournalConference);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(369, 182);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Journals/Conferences";
            // 
            // clbJournalConference
            // 
            this.clbJournalConference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbJournalConference.ContextMenuStrip = this.cmsJournal;
            this.clbJournalConference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbJournalConference.FormattingEnabled = true;
            this.clbJournalConference.Location = new System.Drawing.Point(3, 16);
            this.clbJournalConference.Name = "clbJournalConference";
            this.clbJournalConference.Size = new System.Drawing.Size(363, 163);
            this.clbJournalConference.TabIndex = 0;
            // 
            // cmsJournal
            // 
            this.cmsJournal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.allJournalToolStripMenuItem,
            this.allConferencesToolStripMenuItem,
            this.toolStripSeparator9,
            this.clearToolStripMenuItem1});
            this.cmsJournal.Name = "cmsJournal";
            this.cmsJournal.Size = new System.Drawing.Size(192, 98);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.allToolStripMenuItem.Text = "Select All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // allJournalToolStripMenuItem
            // 
            this.allJournalToolStripMenuItem.Name = "allJournalToolStripMenuItem";
            this.allJournalToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.allJournalToolStripMenuItem.Text = "Select All Journals";
            // 
            // allConferencesToolStripMenuItem
            // 
            this.allConferencesToolStripMenuItem.Name = "allConferencesToolStripMenuItem";
            this.allConferencesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.allConferencesToolStripMenuItem.Text = "Select All Conferences";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(188, 6);
            // 
            // clearToolStripMenuItem1
            // 
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            this.clearToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.clearToolStripMenuItem1.Text = "Clear";
            this.clearToolStripMenuItem1.Click += new System.EventHandler(this.clearToolStripMenuItem1_Click);
            // 
            // cmsTempLitsArea
            // 
            this.cmsTempLitsArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTempSelectAll,
            this.tsmTempClearSelection,
            this.toolStripSeparator15,
            this.tsmTempSort,
            this.toolStripSeparator14,
            this.tsmTempClear,
            this.tsmRemoveSelected,
            this.tsmRemoveDupsA,
            this.tsmRemoveDupsB,
            this.tsmIntersectAwithB,
            this.tsmIntersectBwithA,
            this.toolStripSeparator13,
            this.tsmReplaceMainLitsArea,
            this.tsmAddToMainLitsArea,
            this.tsmAddSelectedToMainLitsArea,
            this.toolStripSeparator16,
            this.tsmH2V});
            this.cmsTempLitsArea.Name = "cmsTempLitsArea";
            this.cmsTempLitsArea.Size = new System.Drawing.Size(236, 314);
            this.cmsTempLitsArea.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTempLitsArea_Opening);
            // 
            // tsmTempSelectAll
            // 
            this.tsmTempSelectAll.Name = "tsmTempSelectAll";
            this.tsmTempSelectAll.Size = new System.Drawing.Size(235, 22);
            this.tsmTempSelectAll.Text = "Select All";
            this.tsmTempSelectAll.Click += new System.EventHandler(this.tsmTempSelectAll_Click);
            // 
            // tsmTempClearSelection
            // 
            this.tsmTempClearSelection.Name = "tsmTempClearSelection";
            this.tsmTempClearSelection.Size = new System.Drawing.Size(235, 22);
            this.tsmTempClearSelection.Text = "Clear Selection";
            this.tsmTempClearSelection.Click += new System.EventHandler(this.tsmTempClearSelection_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(232, 6);
            // 
            // tsmTempSort
            // 
            this.tsmTempSort.Name = "tsmTempSort";
            this.tsmTempSort.Size = new System.Drawing.Size(235, 22);
            this.tsmTempSort.Text = "Sort";
            this.tsmTempSort.Click += new System.EventHandler(this.tsmTempSort_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(232, 6);
            // 
            // tsmTempClear
            // 
            this.tsmTempClear.Name = "tsmTempClear";
            this.tsmTempClear.Size = new System.Drawing.Size(235, 22);
            this.tsmTempClear.Text = "Clear";
            this.tsmTempClear.Click += new System.EventHandler(this.tsmTempClear_Click);
            // 
            // tsmRemoveSelected
            // 
            this.tsmRemoveSelected.Name = "tsmRemoveSelected";
            this.tsmRemoveSelected.Size = new System.Drawing.Size(235, 22);
            this.tsmRemoveSelected.Text = "Remove Selected";
            this.tsmRemoveSelected.Click += new System.EventHandler(this.tsmRemoveSelected_Click);
            // 
            // tsmRemoveDupsA
            // 
            this.tsmRemoveDupsA.Name = "tsmRemoveDupsA";
            this.tsmRemoveDupsA.Size = new System.Drawing.Size(235, 22);
            this.tsmRemoveDupsA.Text = "Remove Dups in Area B";
            this.tsmRemoveDupsA.Click += new System.EventHandler(this.removeDupsInAreaAToolStripMenuItem_Click);
            // 
            // tsmRemoveDupsB
            // 
            this.tsmRemoveDupsB.Name = "tsmRemoveDupsB";
            this.tsmRemoveDupsB.Size = new System.Drawing.Size(235, 22);
            this.tsmRemoveDupsB.Text = "Remove Dups in Area A";
            this.tsmRemoveDupsB.Click += new System.EventHandler(this.removeDupsInAreaBToolStripMenuItem_Click);
            // 
            // tsmIntersectAwithB
            // 
            this.tsmIntersectAwithB.Name = "tsmIntersectAwithB";
            this.tsmIntersectAwithB.Size = new System.Drawing.Size(235, 22);
            this.tsmIntersectAwithB.Text = "Intersect with Area B";
            this.tsmIntersectAwithB.Click += new System.EventHandler(this.tmsIntersectAwithB_Click);
            // 
            // tsmIntersectBwithA
            // 
            this.tsmIntersectBwithA.Name = "tsmIntersectBwithA";
            this.tsmIntersectBwithA.Size = new System.Drawing.Size(235, 22);
            this.tsmIntersectBwithA.Text = "Intersect with Area A";
            this.tsmIntersectBwithA.Click += new System.EventHandler(this.tsmIntersectBwithA_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(232, 6);
            // 
            // tsmReplaceMainLitsArea
            // 
            this.tsmReplaceMainLitsArea.Name = "tsmReplaceMainLitsArea";
            this.tsmReplaceMainLitsArea.Size = new System.Drawing.Size(235, 22);
            this.tsmReplaceMainLitsArea.Text = "Replace Main Lits Area";
            this.tsmReplaceMainLitsArea.Click += new System.EventHandler(this.tsmReplaceMainLitsArea_Click);
            // 
            // tsmAddToMainLitsArea
            // 
            this.tsmAddToMainLitsArea.Name = "tsmAddToMainLitsArea";
            this.tsmAddToMainLitsArea.Size = new System.Drawing.Size(235, 22);
            this.tsmAddToMainLitsArea.Text = "Add All to Main Lits Area";
            this.tsmAddToMainLitsArea.Click += new System.EventHandler(this.tsmAddToMainLitsArea_Click);
            // 
            // tsmAddSelectedToMainLitsArea
            // 
            this.tsmAddSelectedToMainLitsArea.Name = "tsmAddSelectedToMainLitsArea";
            this.tsmAddSelectedToMainLitsArea.Size = new System.Drawing.Size(235, 22);
            this.tsmAddSelectedToMainLitsArea.Text = "Add Selected to Main Lits Area";
            this.tsmAddSelectedToMainLitsArea.Click += new System.EventHandler(this.tsmAddSelectedToMainLitsArea_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(232, 6);
            // 
            // tsmH2V
            // 
            this.tsmH2V.Name = "tsmH2V";
            this.tsmH2V.Size = new System.Drawing.Size(235, 22);
            this.tsmH2V.Text = "Horizontal <-> Vertical";
            this.tsmH2V.Click += new System.EventHandler(this.tsmH2V_Click);
            // 
            // frmLiterature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 672);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmLiterature";
            this.Text = "LifeGame - Literature";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLiterature_FormClosing);
            this.Load += new System.EventHandler(this.frmLiterature_Load);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.cmsTags.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiterature)).EndInit();
            this.cmsLiterature.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.cmsAuthor.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.cmsJournal.ResumeLayout(false);
            this.cmsTempLitsArea.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvLiterature;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip cmsLiterature;
        private System.Windows.Forms.ToolStripMenuItem tsmAddLiterature;
        private System.Windows.Forms.ToolStripMenuItem tsmViewLiterature;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveLiterature;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmExportBib;
        private System.Windows.Forms.ContextMenuStrip cmsTags;
        private System.Windows.Forms.ToolStripMenuItem tsmEditTag;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveTag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.CheckBox chkNoBad;
        private System.Windows.Forms.CheckBox chkOnlyGood;
        private System.Windows.Forms.Label lblNumFound;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmCreateNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem addTag2Multi;
        private System.Windows.Forms.TreeView trvTag;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmFold;
        private System.Windows.Forms.ToolStripMenuItem tsmExpand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmUp;
        private System.Windows.Forms.ToolStripMenuItem tsmDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmIndependent;
        private System.Windows.Forms.ToolStripMenuItem tsmBelongTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartYear;
        private System.Windows.Forms.TextBox txtEndYear;
        private System.Windows.Forms.CheckedListBox clbAuthor;
        private System.Windows.Forms.CheckedListBox clbJournalConference;
        private System.Windows.Forms.ContextMenuStrip cmsAuthor;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsJournal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allJournalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allConferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmTagSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmTagClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.Button btnAuthorAndJournal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ComboBox cbxMode;
        private System.Windows.Forms.Button btnSearchInResult;
        private System.Windows.Forms.TextBox txtSearchInRes;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox5;
        //private System.Windows.Forms.CheckedListBox clbTempLitsAreaA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem tsmAddToTempLitsArea;
        private System.Windows.Forms.ContextMenuStrip cmsTempLitsArea;
        private System.Windows.Forms.ToolStripMenuItem tsmTempSort;
        private System.Windows.Forms.ToolStripMenuItem tsmTempSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem tsmTempClearSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem tsmTempClear;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem tsmReplaceMainLitsArea;
        private System.Windows.Forms.ToolStripMenuItem tsmAddToMainLitsArea;
        private System.Windows.Forms.ToolStripMenuItem tsmAddSelectedToMainLitsArea;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveTagFromMulti;
        private System.Windows.Forms.TableLayoutPanel tblTempArea;
        //private System.Windows.Forms.CheckedListBox clbTempLitsAreaB;
        private System.Windows.Forms.ToolStripMenuItem tsmAddToAreaA;
        private System.Windows.Forms.ToolStripMenuItem tsmAddToAreaB;
        private System.Windows.Forms.ToolStripMenuItem copyToNoteToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem tsmH2V;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveDupsA;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveDupsB;
        private System.Windows.Forms.ToolStripMenuItem tsmIntersectAwithB;
        private System.Windows.Forms.ToolStripMenuItem tsmIntersectBwithA;
        private System.Windows.Forms.CheckBox chkHightlight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Star;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Publisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLitType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoodJournal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPredatory;
        private System.Windows.Forms.DataGridViewTextBoxColumn addDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifyDate;
    }
}