namespace LifeGame
{
    partial class frmSurvey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSurvey));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSurveyEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbSurvey = new System.Windows.Forms.ListBox();
            this.cmsSurvey = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddSurvey = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditSurvey = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveSurvey = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSurvey = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trvSurveyTag = new System.Windows.Forms.TreeView();
            this.cmsTagTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRenameTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmString2SingleOption = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSingleOption2String = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveTag = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUpTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDownTag = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBelongToTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIndependentTag = new System.Windows.Forms.ToolStripMenuItem();
            this.iglTag = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbOption = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTagName = new System.Windows.Forms.Label();
            this.lblTagType = new System.Windows.Forms.Label();
            this.dgvSurvey = new System.Windows.Forms.DataGridView();
            this.colLiterature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsSurveyLit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmViewLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewSurvey = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmRemoveLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsOption = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddTagOption = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditTagOption = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveTagOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.upToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsSurvey.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmsTagTree.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurvey)).BeginInit();
            this.cmsSurveyLit.SuspendLayout();
            this.cmsOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1033, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSurveyEToolStripMenuItem});
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // exportSurveyEToolStripMenuItem
            // 
            this.exportSurveyEToolStripMenuItem.Name = "exportSurveyEToolStripMenuItem";
            this.exportSurveyEToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exportSurveyEToolStripMenuItem.Text = "Export Survey (&E)";
            this.exportSurveyEToolStripMenuItem.Click += new System.EventHandler(this.exportSurveyEToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbSurvey);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 533);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Survey List";
            // 
            // lsbSurvey
            // 
            this.lsbSurvey.ContextMenuStrip = this.cmsSurvey;
            this.lsbSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbSurvey.FormattingEnabled = true;
            this.lsbSurvey.ItemHeight = 12;
            this.lsbSurvey.Location = new System.Drawing.Point(3, 17);
            this.lsbSurvey.Name = "lsbSurvey";
            this.lsbSurvey.Size = new System.Drawing.Size(124, 513);
            this.lsbSurvey.TabIndex = 0;
            this.lsbSurvey.SelectedIndexChanged += new System.EventHandler(this.lsbSurvey_SelectedIndexChanged);
            // 
            // cmsSurvey
            // 
            this.cmsSurvey.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddSurvey,
            this.cmsEditSurvey,
            this.cmsRemoveSurvey});
            this.cmsSurvey.Name = "cmsSurvey";
            this.cmsSurvey.Size = new System.Drawing.Size(124, 70);
            // 
            // cmsAddSurvey
            // 
            this.cmsAddSurvey.Name = "cmsAddSurvey";
            this.cmsAddSurvey.Size = new System.Drawing.Size(123, 22);
            this.cmsAddSurvey.Text = "Add";
            this.cmsAddSurvey.Click += new System.EventHandler(this.cmsAddSurvey_Click);
            // 
            // cmsEditSurvey
            // 
            this.cmsEditSurvey.Name = "cmsEditSurvey";
            this.cmsEditSurvey.Size = new System.Drawing.Size(123, 22);
            this.cmsEditSurvey.Text = "Rename";
            this.cmsEditSurvey.Click += new System.EventHandler(this.cmsEditSurvey_Click);
            // 
            // cmsRemoveSurvey
            // 
            this.cmsRemoveSurvey.Name = "cmsRemoveSurvey";
            this.cmsRemoveSurvey.Size = new System.Drawing.Size(123, 22);
            this.cmsRemoveSurvey.Text = "Remove";
            this.cmsRemoveSurvey.Click += new System.EventHandler(this.cmsRemoveSurvey_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.splitContainer2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(899, 533);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(893, 39);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Survey";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblSurvey, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(887, 19);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblSurvey
            // 
            this.lblSurvey.AutoSize = true;
            this.lblSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSurvey.Location = new System.Drawing.Point(3, 0);
            this.lblSurvey.Name = "lblSurvey";
            this.lblSurvey.Size = new System.Drawing.Size(881, 19);
            this.lblSurvey.TabIndex = 1;
            this.lblSurvey.Text = "(Survey Name)";
            this.lblSurvey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 48);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvSurvey);
            this.splitContainer2.Size = new System.Drawing.Size(893, 482);
            this.splitContainer2.SplitterDistance = 187;
            this.splitContainer2.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.6403F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.3597F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(187, 482);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trvSurveyTag);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 286);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Survey Tags";
            // 
            // trvSurveyTag
            // 
            this.trvSurveyTag.BackColor = System.Drawing.SystemColors.Control;
            this.trvSurveyTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvSurveyTag.ContextMenuStrip = this.cmsTagTree;
            this.trvSurveyTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvSurveyTag.ImageIndex = 0;
            this.trvSurveyTag.ImageList = this.iglTag;
            this.trvSurveyTag.Location = new System.Drawing.Point(3, 17);
            this.trvSurveyTag.Name = "trvSurveyTag";
            treeNode1.Name = "(Root)";
            treeNode1.Text = "(Root)";
            this.trvSurveyTag.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvSurveyTag.SelectedImageIndex = 0;
            this.trvSurveyTag.Size = new System.Drawing.Size(175, 266);
            this.trvSurveyTag.TabIndex = 1;
            this.trvSurveyTag.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvSurveyTag_AfterSelect);
            // 
            // cmsTagTree
            // 
            this.cmsTagTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddTag,
            this.tsmRenameTag,
            this.tsmString2SingleOption,
            this.tsmSingleOption2String,
            this.tsmRemoveTag,
            this.toolStripSeparator1,
            this.tsmUpTag,
            this.tsmDownTag,
            this.toolStripSeparator2,
            this.tsmBelongToTag,
            this.tsmIndependentTag});
            this.cmsTagTree.Name = "cmsTagTree";
            this.cmsTagTree.Size = new System.Drawing.Size(193, 214);
            // 
            // tsmAddTag
            // 
            this.tsmAddTag.Name = "tsmAddTag";
            this.tsmAddTag.Size = new System.Drawing.Size(192, 22);
            this.tsmAddTag.Text = "Add";
            this.tsmAddTag.Click += new System.EventHandler(this.cmsAddTag_Click);
            // 
            // tsmRenameTag
            // 
            this.tsmRenameTag.Name = "tsmRenameTag";
            this.tsmRenameTag.Size = new System.Drawing.Size(192, 22);
            this.tsmRenameTag.Text = "Rename";
            this.tsmRenameTag.Click += new System.EventHandler(this.tsmRenameTag_Click);
            // 
            // tsmString2SingleOption
            // 
            this.tsmString2SingleOption.Name = "tsmString2SingleOption";
            this.tsmString2SingleOption.Size = new System.Drawing.Size(192, 22);
            this.tsmString2SingleOption.Text = "String2SingleOption";
            this.tsmString2SingleOption.Click += new System.EventHandler(this.tsmString2SingleOption_Click);
            // 
            // tsmSingleOption2String
            // 
            this.tsmSingleOption2String.Name = "tsmSingleOption2String";
            this.tsmSingleOption2String.Size = new System.Drawing.Size(192, 22);
            this.tsmSingleOption2String.Text = "SingleOption2String";
            this.tsmSingleOption2String.Click += new System.EventHandler(this.tsmSingleOption2String_Click);
            // 
            // tsmRemoveTag
            // 
            this.tsmRemoveTag.Name = "tsmRemoveTag";
            this.tsmRemoveTag.Size = new System.Drawing.Size(192, 22);
            this.tsmRemoveTag.Text = "Remove";
            this.tsmRemoveTag.Click += new System.EventHandler(this.cmsTagRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // tsmUpTag
            // 
            this.tsmUpTag.Name = "tsmUpTag";
            this.tsmUpTag.Size = new System.Drawing.Size(192, 22);
            this.tsmUpTag.Text = "Up";
            this.tsmUpTag.Click += new System.EventHandler(this.cmsTagUp_Click);
            // 
            // tsmDownTag
            // 
            this.tsmDownTag.Name = "tsmDownTag";
            this.tsmDownTag.Size = new System.Drawing.Size(192, 22);
            this.tsmDownTag.Text = "Down";
            this.tsmDownTag.Click += new System.EventHandler(this.cmsTagDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // tsmBelongToTag
            // 
            this.tsmBelongToTag.Name = "tsmBelongToTag";
            this.tsmBelongToTag.Size = new System.Drawing.Size(192, 22);
            this.tsmBelongToTag.Text = "Belong To";
            this.tsmBelongToTag.Click += new System.EventHandler(this.cmsTagBelongTo_Click);
            // 
            // tsmIndependentTag
            // 
            this.tsmIndependentTag.Name = "tsmIndependentTag";
            this.tsmIndependentTag.Size = new System.Drawing.Size(192, 22);
            this.tsmIndependentTag.Text = "Independent";
            this.tsmIndependentTag.Click += new System.EventHandler(this.cmsTagIndependent_Click);
            // 
            // iglTag
            // 
            this.iglTag.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglTag.ImageStream")));
            this.iglTag.TransparentColor = System.Drawing.Color.Transparent;
            this.iglTag.Images.SetKeyName(0, "iconWW.png");
            this.iglTag.Images.SetKeyName(1, "iconSurveyTagNonBottom.png");
            this.iglTag.Images.SetKeyName(2, "iconSurveyTagBoolean.png");
            this.iglTag.Images.SetKeyName(3, "iconSurveyTagSingleOption.png");
            this.iglTag.Images.SetKeyName(4, "iconSurveyTagStrings.png");
            this.iglTag.Images.SetKeyName(5, "iconSurveyTagInteger.png");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 184);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tag Info";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.lsbOption, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblTagName, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblTagType, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(175, 164);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 116);
            this.label2.TabIndex = 7;
            this.label2.Text = "Options";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsbOption
            // 
            this.lsbOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbOption.FormattingEnabled = true;
            this.lsbOption.ItemHeight = 12;
            this.lsbOption.Location = new System.Drawing.Point(76, 51);
            this.lsbOption.Name = "lsbOption";
            this.lsbOption.Size = new System.Drawing.Size(96, 110);
            this.lsbOption.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTagName.Location = new System.Drawing.Point(76, 0);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(96, 24);
            this.lblTagName.TabIndex = 11;
            this.lblTagName.Text = "(Tag Name)";
            this.lblTagName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTagType
            // 
            this.lblTagType.AutoSize = true;
            this.lblTagType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTagType.Location = new System.Drawing.Point(76, 24);
            this.lblTagType.Name = "lblTagType";
            this.lblTagType.Size = new System.Drawing.Size(96, 24);
            this.lblTagType.TabIndex = 12;
            this.lblTagType.Text = "(Tag Type)";
            this.lblTagType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSurvey
            // 
            this.dgvSurvey.AllowUserToAddRows = false;
            this.dgvSurvey.AllowUserToDeleteRows = false;
            this.dgvSurvey.AllowUserToOrderColumns = true;
            this.dgvSurvey.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSurvey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSurvey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurvey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLiterature});
            this.dgvSurvey.ContextMenuStrip = this.cmsSurveyLit;
            this.dgvSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSurvey.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSurvey.Location = new System.Drawing.Point(0, 0);
            this.dgvSurvey.MultiSelect = false;
            this.dgvSurvey.Name = "dgvSurvey";
            this.dgvSurvey.ReadOnly = true;
            this.dgvSurvey.Size = new System.Drawing.Size(702, 482);
            this.dgvSurvey.TabIndex = 3;
            this.dgvSurvey.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurvey_CellContentClick);
            // 
            // colLiterature
            // 
            this.colLiterature.HeaderText = "Literature";
            this.colLiterature.Name = "colLiterature";
            this.colLiterature.ReadOnly = true;
            // 
            // cmsSurveyLit
            // 
            this.cmsSurveyLit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmViewLiterature,
            this.tsmViewSurvey,
            this.toolStripSeparator4,
            this.tsmRemoveLiterature});
            this.cmsSurveyLit.Name = "cmsSurveyLit";
            this.cmsSurveyLit.Size = new System.Drawing.Size(205, 76);
            // 
            // tsmViewLiterature
            // 
            this.tsmViewLiterature.Name = "tsmViewLiterature";
            this.tsmViewLiterature.Size = new System.Drawing.Size(204, 22);
            this.tsmViewLiterature.Text = "View Literature";
            this.tsmViewLiterature.Click += new System.EventHandler(this.tsmViewLiterature_Click);
            // 
            // tsmViewSurvey
            // 
            this.tsmViewSurvey.Name = "tsmViewSurvey";
            this.tsmViewSurvey.Size = new System.Drawing.Size(204, 22);
            this.tsmViewSurvey.Text = "View Literature Survey";
            this.tsmViewSurvey.Click += new System.EventHandler(this.tsmViewSurvey_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
            // 
            // tsmRemoveLiterature
            // 
            this.tsmRemoveLiterature.Name = "tsmRemoveLiterature";
            this.tsmRemoveLiterature.Size = new System.Drawing.Size(204, 22);
            this.tsmRemoveLiterature.Text = "Remove";
            this.tsmRemoveLiterature.Click += new System.EventHandler(this.tsmRemoveLiterature_Click);
            // 
            // cmsOption
            // 
            this.cmsOption.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddTagOption,
            this.cmsEditTagOption,
            this.cmsRemoveTagOption,
            this.toolStripSeparator3,
            this.upToolStripMenuItem1,
            this.downToolStripMenuItem1});
            this.cmsOption.Name = "cmsOption";
            this.cmsOption.Size = new System.Drawing.Size(124, 120);
            // 
            // cmsAddTagOption
            // 
            this.cmsAddTagOption.Name = "cmsAddTagOption";
            this.cmsAddTagOption.Size = new System.Drawing.Size(123, 22);
            this.cmsAddTagOption.Text = "Add";
            // 
            // cmsEditTagOption
            // 
            this.cmsEditTagOption.Name = "cmsEditTagOption";
            this.cmsEditTagOption.Size = new System.Drawing.Size(123, 22);
            this.cmsEditTagOption.Text = "Rename";
            // 
            // cmsRemoveTagOption
            // 
            this.cmsRemoveTagOption.Name = "cmsRemoveTagOption";
            this.cmsRemoveTagOption.Size = new System.Drawing.Size(123, 22);
            this.cmsRemoveTagOption.Text = "Remove";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(120, 6);
            // 
            // upToolStripMenuItem1
            // 
            this.upToolStripMenuItem1.Name = "upToolStripMenuItem1";
            this.upToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.upToolStripMenuItem1.Text = "Up";
            // 
            // downToolStripMenuItem1
            // 
            this.downToolStripMenuItem1.Name = "downToolStripMenuItem1";
            this.downToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.downToolStripMenuItem1.Text = "Down";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(1033, 533);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 4;
            // 
            // frmSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 558);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSurvey";
            this.Text = "LifeGame - Survey";
            this.Load += new System.EventHandler(this.frmSurvey_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.cmsSurvey.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.cmsTagTree.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurvey)).EndInit();
            this.cmsSurveyLit.ResumeLayout(false);
            this.cmsOption.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ContextMenuStrip cmsTagTree;
        private System.Windows.Forms.ListBox lsbSurvey;
        private System.Windows.Forms.ContextMenuStrip cmsSurvey;
        private System.Windows.Forms.ToolStripMenuItem cmsAddSurvey;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoveSurvey;
        private System.Windows.Forms.ToolStripMenuItem tsmAddTag;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveTag;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmUpTag;
        private System.Windows.Forms.ToolStripMenuItem tsmDownTag;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmBelongToTag;
        private System.Windows.Forms.ToolStripMenuItem tsmIndependentTag;
        private System.Windows.Forms.ToolStripMenuItem cmsEditSurvey;
        private System.Windows.Forms.ImageList iglTag;
        private System.Windows.Forms.TreeView trvSurveyTag;
        private System.Windows.Forms.Label lblSurvey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsOption;
        private System.Windows.Forms.ToolStripMenuItem cmsAddTagOption;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoveTagOption;
        private System.Windows.Forms.ToolStripMenuItem cmsEditTagOption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem1;
        private System.Windows.Forms.Label lblTagName;
        private System.Windows.Forms.ToolStripMenuItem exportSurveyEToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvSurvey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiterature;
        private System.Windows.Forms.ContextMenuStrip cmsSurveyLit;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveLiterature;
        private System.Windows.Forms.ListBox lsbOption;
        private System.Windows.Forms.Label lblTagType;
        private System.Windows.Forms.ToolStripMenuItem tsmRenameTag;
        private System.Windows.Forms.ToolStripMenuItem tsmString2SingleOption;
        private System.Windows.Forms.ToolStripMenuItem tsmSingleOption2String;
        private System.Windows.Forms.ToolStripMenuItem tsmViewLiterature;
        private System.Windows.Forms.ToolStripMenuItem tsmViewSurvey;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}