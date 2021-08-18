﻿namespace LifeGame
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trvSurveyTag = new System.Windows.Forms.TreeView();
            this.cmsTagTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddTag = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditTag = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveTag = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsTagUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTagDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsTagBelongTo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTagIndependent = new System.Windows.Forms.ToolStripMenuItem();
            this.iglTag = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbOption = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTagType = new System.Windows.Forms.ComboBox();
            this.chkBottom = new System.Windows.Forms.CheckBox();
            this.lblTagName = new System.Windows.Forms.Label();
            this.dgvSurvey = new System.Windows.Forms.DataGridView();
            this.colLiterature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsSurveyLit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsOption = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddTagOption = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditTagOption = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveTagOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.upToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsSurvey.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmsTagTree.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurvey)).BeginInit();
            this.cmsSurveyLit.SuspendLayout();
            this.cmsOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1202, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSurveyEToolStripMenuItem});
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // exportSurveyEToolStripMenuItem
            // 
            this.exportSurveyEToolStripMenuItem.Name = "exportSurveyEToolStripMenuItem";
            this.exportSurveyEToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exportSurveyEToolStripMenuItem.Text = "Export Survey (&E)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1202, 580);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbSurvey);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 574);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Survey List";
            // 
            // lsbSurvey
            // 
            this.lsbSurvey.ContextMenuStrip = this.cmsSurvey;
            this.lsbSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbSurvey.FormattingEnabled = true;
            this.lsbSurvey.Location = new System.Drawing.Point(3, 16);
            this.lsbSurvey.Name = "lsbSurvey";
            this.lsbSurvey.Size = new System.Drawing.Size(151, 555);
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
            this.cmsSurvey.Size = new System.Drawing.Size(118, 70);
            // 
            // cmsAddSurvey
            // 
            this.cmsAddSurvey.Name = "cmsAddSurvey";
            this.cmsAddSurvey.Size = new System.Drawing.Size(117, 22);
            this.cmsAddSurvey.Text = "Add";
            this.cmsAddSurvey.Click += new System.EventHandler(this.cmsAddSurvey_Click);
            // 
            // cmsEditSurvey
            // 
            this.cmsEditSurvey.Name = "cmsEditSurvey";
            this.cmsEditSurvey.Size = new System.Drawing.Size(117, 22);
            this.cmsEditSurvey.Text = "Rename";
            this.cmsEditSurvey.Click += new System.EventHandler(this.cmsEditSurvey_Click);
            // 
            // cmsRemoveSurvey
            // 
            this.cmsRemoveSurvey.Name = "cmsRemoveSurvey";
            this.cmsRemoveSurvey.Size = new System.Drawing.Size(117, 22);
            this.cmsRemoveSurvey.Text = "Remove";
            this.cmsRemoveSurvey.Click += new System.EventHandler(this.cmsRemoveSurvey_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(163, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1039, 580);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1033, 43);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1027, 24);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblSurvey
            // 
            this.lblSurvey.AutoSize = true;
            this.lblSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSurvey.Location = new System.Drawing.Point(3, 0);
            this.lblSurvey.Name = "lblSurvey";
            this.lblSurvey.Size = new System.Drawing.Size(1021, 24);
            this.lblSurvey.TabIndex = 1;
            this.lblSurvey.Text = "(Survey Name)";
            this.lblSurvey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.21174F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.78826F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.dgvSurvey, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1039, 531);
            this.tableLayoutPanel6.TabIndex = 1;
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
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.91793F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.08207F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(209, 531);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trvSurveyTag);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(203, 328);
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
            this.trvSurveyTag.Location = new System.Drawing.Point(3, 16);
            this.trvSurveyTag.Name = "trvSurveyTag";
            treeNode1.Name = "(Root)";
            treeNode1.Text = "(Root)";
            this.trvSurveyTag.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvSurveyTag.SelectedImageIndex = 0;
            this.trvSurveyTag.Size = new System.Drawing.Size(197, 309);
            this.trvSurveyTag.TabIndex = 1;
            this.trvSurveyTag.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvSurveyTag_AfterSelect);
            // 
            // cmsTagTree
            // 
            this.cmsTagTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddTag,
            this.cmsEditTag,
            this.cmsRemoveTag,
            this.toolStripSeparator1,
            this.cmsTagUp,
            this.cmsTagDown,
            this.toolStripSeparator2,
            this.cmsTagBelongTo,
            this.cmsTagIndependent});
            this.cmsTagTree.Name = "cmsTagTree";
            this.cmsTagTree.Size = new System.Drawing.Size(142, 170);
            // 
            // cmsAddTag
            // 
            this.cmsAddTag.Name = "cmsAddTag";
            this.cmsAddTag.Size = new System.Drawing.Size(141, 22);
            this.cmsAddTag.Text = "Add";
            this.cmsAddTag.Click += new System.EventHandler(this.cmsAddTag_Click);
            // 
            // cmsEditTag
            // 
            this.cmsEditTag.Name = "cmsEditTag";
            this.cmsEditTag.Size = new System.Drawing.Size(141, 22);
            this.cmsEditTag.Text = "Rename";
            this.cmsEditTag.Click += new System.EventHandler(this.cmsEditTag_Click);
            // 
            // cmsRemoveTag
            // 
            this.cmsRemoveTag.Name = "cmsRemoveTag";
            this.cmsRemoveTag.Size = new System.Drawing.Size(141, 22);
            this.cmsRemoveTag.Text = "Remove";
            this.cmsRemoveTag.Click += new System.EventHandler(this.cmsTagRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // cmsTagUp
            // 
            this.cmsTagUp.Name = "cmsTagUp";
            this.cmsTagUp.Size = new System.Drawing.Size(141, 22);
            this.cmsTagUp.Text = "Up";
            this.cmsTagUp.Click += new System.EventHandler(this.cmsTagUp_Click);
            // 
            // cmsTagDown
            // 
            this.cmsTagDown.Name = "cmsTagDown";
            this.cmsTagDown.Size = new System.Drawing.Size(141, 22);
            this.cmsTagDown.Text = "Down";
            this.cmsTagDown.Click += new System.EventHandler(this.cmsTagDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // cmsTagBelongTo
            // 
            this.cmsTagBelongTo.Name = "cmsTagBelongTo";
            this.cmsTagBelongTo.Size = new System.Drawing.Size(141, 22);
            this.cmsTagBelongTo.Text = "Belong To";
            this.cmsTagBelongTo.Click += new System.EventHandler(this.cmsTagBelongTo_Click);
            // 
            // cmsTagIndependent
            // 
            this.cmsTagIndependent.Name = "cmsTagIndependent";
            this.cmsTagIndependent.Size = new System.Drawing.Size(141, 22);
            this.cmsTagIndependent.Text = "Independent";
            this.cmsTagIndependent.Click += new System.EventHandler(this.cmsTagIndependent_Click);
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
            this.groupBox4.Location = new System.Drawing.Point(3, 337);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 191);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tag Info";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.lsbOption, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cmbTagType, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.chkBottom, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblTagName, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(197, 172);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 92);
            this.label2.TabIndex = 7;
            this.label2.Text = "Options";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsbOption
            // 
            this.lsbOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbOption.FormattingEnabled = true;
            this.lsbOption.Location = new System.Drawing.Point(55, 83);
            this.lsbOption.Name = "lsbOption";
            this.lsbOption.Size = new System.Drawing.Size(139, 86);
            this.lsbOption.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTagType
            // 
            this.cmbTagType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTagType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTagType.FormattingEnabled = true;
            this.cmbTagType.Items.AddRange(new object[] {
            "NonBottom",
            "Boolean",
            "SingleOption",
            "String",
            "Number"});
            this.cmbTagType.Location = new System.Drawing.Point(55, 29);
            this.cmbTagType.Name = "cmbTagType";
            this.cmbTagType.Size = new System.Drawing.Size(139, 21);
            this.cmbTagType.TabIndex = 10;
            // 
            // chkBottom
            // 
            this.chkBottom.AutoSize = true;
            this.chkBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBottom.Enabled = false;
            this.chkBottom.Location = new System.Drawing.Point(55, 55);
            this.chkBottom.Name = "chkBottom";
            this.chkBottom.Size = new System.Drawing.Size(139, 22);
            this.chkBottom.TabIndex = 4;
            this.chkBottom.Text = "Bottom";
            this.chkBottom.UseVisualStyleBackColor = true;
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTagName.Location = new System.Drawing.Point(55, 0);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(139, 26);
            this.lblTagName.TabIndex = 11;
            this.lblTagName.Text = "(Tag Name)";
            this.lblTagName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dgvSurvey.Location = new System.Drawing.Point(212, 3);
            this.dgvSurvey.MultiSelect = false;
            this.dgvSurvey.Name = "dgvSurvey";
            this.dgvSurvey.Size = new System.Drawing.Size(824, 525);
            this.dgvSurvey.TabIndex = 3;
            this.dgvSurvey.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurvey_CellValueChanged);
            // 
            // colLiterature
            // 
            this.colLiterature.HeaderText = "Literature";
            this.colLiterature.Name = "colLiterature";
            // 
            // cmsSurveyLit
            // 
            this.cmsSurveyLit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddLiterature,
            this.cmsRemoveLiterature});
            this.cmsSurveyLit.Name = "cmsSurveyLit";
            this.cmsSurveyLit.Size = new System.Drawing.Size(171, 48);
            // 
            // cmsAddLiterature
            // 
            this.cmsAddLiterature.Name = "cmsAddLiterature";
            this.cmsAddLiterature.Size = new System.Drawing.Size(170, 22);
            this.cmsAddLiterature.Text = "Add Literature";
            // 
            // cmsRemoveLiterature
            // 
            this.cmsRemoveLiterature.Name = "cmsRemoveLiterature";
            this.cmsRemoveLiterature.Size = new System.Drawing.Size(170, 22);
            this.cmsRemoveLiterature.Text = "Remove Literature";
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
            this.cmsOption.Size = new System.Drawing.Size(118, 120);
            // 
            // cmsAddTagOption
            // 
            this.cmsAddTagOption.Name = "cmsAddTagOption";
            this.cmsAddTagOption.Size = new System.Drawing.Size(117, 22);
            this.cmsAddTagOption.Text = "Add";
            // 
            // cmsEditTagOption
            // 
            this.cmsEditTagOption.Name = "cmsEditTagOption";
            this.cmsEditTagOption.Size = new System.Drawing.Size(117, 22);
            this.cmsEditTagOption.Text = "Rename";
            // 
            // cmsRemoveTagOption
            // 
            this.cmsRemoveTagOption.Name = "cmsRemoveTagOption";
            this.cmsRemoveTagOption.Size = new System.Drawing.Size(117, 22);
            this.cmsRemoveTagOption.Text = "Remove";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(114, 6);
            // 
            // upToolStripMenuItem1
            // 
            this.upToolStripMenuItem1.Name = "upToolStripMenuItem1";
            this.upToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.upToolStripMenuItem1.Text = "Up";
            // 
            // downToolStripMenuItem1
            // 
            this.downToolStripMenuItem1.Name = "downToolStripMenuItem1";
            this.downToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.downToolStripMenuItem1.Text = "Down";
            // 
            // frmSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSurvey";
            this.Text = "LifeGame - Survey";
            this.Load += new System.EventHandler(this.frmSurvey_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.cmsSurvey.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.cmsTagTree.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurvey)).EndInit();
            this.cmsSurveyLit.ResumeLayout(false);
            this.cmsOption.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ContextMenuStrip cmsTagTree;
        private System.Windows.Forms.ListBox lsbSurvey;
        private System.Windows.Forms.ContextMenuStrip cmsSurvey;
        private System.Windows.Forms.ToolStripMenuItem cmsAddSurvey;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoveSurvey;
        private System.Windows.Forms.ToolStripMenuItem cmsAddTag;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoveTag;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsTagUp;
        private System.Windows.Forms.ToolStripMenuItem cmsTagDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsTagBelongTo;
        private System.Windows.Forms.ToolStripMenuItem cmsTagIndependent;
        private System.Windows.Forms.ToolStripMenuItem cmsEditSurvey;
        private System.Windows.Forms.ImageList iglTag;
        private System.Windows.Forms.TreeView trvSurveyTag;
        private System.Windows.Forms.Label lblSurvey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBottom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbOption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTagType;
        private System.Windows.Forms.ContextMenuStrip cmsOption;
        private System.Windows.Forms.ToolStripMenuItem cmsAddTagOption;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoveTagOption;
        private System.Windows.Forms.ToolStripMenuItem cmsEditTagOption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsEditTag;
        private System.Windows.Forms.Label lblTagName;
        private System.Windows.Forms.ToolStripMenuItem exportSurveyEToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DataGridView dgvSurvey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiterature;
        private System.Windows.Forms.ContextMenuStrip cmsSurveyLit;
        private System.Windows.Forms.ToolStripMenuItem cmsAddLiterature;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoveLiterature;
    }
}