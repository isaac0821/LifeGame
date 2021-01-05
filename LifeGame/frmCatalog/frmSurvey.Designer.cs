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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbSurvey = new System.Windows.Forms.ListBox();
            this.cmsSurvey = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRenameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trvSurveyTag = new System.Windows.Forms.TreeView();
            this.cmsTagTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.booleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.belongToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.independentFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iglTag = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSurvey = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Literature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsSurvey.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmsTagTree.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1183, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1183, 538);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbSurvey);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 532);
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
            this.lsbSurvey.Size = new System.Drawing.Size(127, 513);
            this.lsbSurvey.TabIndex = 0;
            // 
            // cmsSurvey
            // 
            this.cmsSurvey.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSurveyToolStripMenuItem,
            this.editRenameToolStripMenuItem1,
            this.deleteSurveyToolStripMenuItem});
            this.cmsSurvey.Name = "cmsSurvey";
            this.cmsSurvey.Size = new System.Drawing.Size(149, 70);
            // 
            // addSurveyToolStripMenuItem
            // 
            this.addSurveyToolStripMenuItem.Name = "addSurveyToolStripMenuItem";
            this.addSurveyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addSurveyToolStripMenuItem.Text = "Add";
            this.addSurveyToolStripMenuItem.Click += new System.EventHandler(this.addSurveyToolStripMenuItem_Click);
            // 
            // editRenameToolStripMenuItem1
            // 
            this.editRenameToolStripMenuItem1.Name = "editRenameToolStripMenuItem1";
            this.editRenameToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.editRenameToolStripMenuItem1.Text = "Edit (Rename)";
            this.editRenameToolStripMenuItem1.Click += new System.EventHandler(this.editRenameToolStripMenuItem1_Click);
            // 
            // deleteSurveyToolStripMenuItem
            // 
            this.deleteSurveyToolStripMenuItem.Name = "deleteSurveyToolStripMenuItem";
            this.deleteSurveyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteSurveyToolStripMenuItem.Text = "Delete";
            this.deleteSurveyToolStripMenuItem.Click += new System.EventHandler(this.deleteSurveyToolStripMenuItem_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(139, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(235, 538);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 43);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Survey";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trvSurveyTag);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 483);
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
            this.trvSurveyTag.Location = new System.Drawing.Point(3, 16);
            this.trvSurveyTag.Name = "trvSurveyTag";
            treeNode1.Name = "(Root)";
            treeNode1.Text = "(Root)";
            this.trvSurveyTag.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvSurveyTag.Size = new System.Drawing.Size(223, 464);
            this.trvSurveyTag.TabIndex = 1;
            // 
            // cmsTagTree
            // 
            this.cmsTagTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTagToolStripMenuItem,
            this.editRenameToolStripMenuItem,
            this.deleteTagToolStripMenuItem,
            this.toolStripSeparator1,
            this.upToolStripMenuItem,
            this.downToolStripMenuItem,
            this.toolStripSeparator2,
            this.belongToToolStripMenuItem,
            this.independentFromToolStripMenuItem});
            this.cmsTagTree.Name = "cmsTagTree";
            this.cmsTagTree.Size = new System.Drawing.Size(181, 192);
            // 
            // addTagToolStripMenuItem
            // 
            this.addTagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nonBottomToolStripMenuItem,
            this.toolStripSeparator3,
            this.booleanToolStripMenuItem,
            this.singleOptionToolStripMenuItem,
            this.stringToolStripMenuItem,
            this.integerToolStripMenuItem});
            this.addTagToolStripMenuItem.Name = "addTagToolStripMenuItem";
            this.addTagToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addTagToolStripMenuItem.Text = "Add";
            // 
            // nonBottomToolStripMenuItem
            // 
            this.nonBottomToolStripMenuItem.Name = "nonBottomToolStripMenuItem";
            this.nonBottomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nonBottomToolStripMenuItem.Text = "Non-Bottom";
            this.nonBottomToolStripMenuItem.Click += new System.EventHandler(this.nonBottomToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // booleanToolStripMenuItem
            // 
            this.booleanToolStripMenuItem.Name = "booleanToolStripMenuItem";
            this.booleanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.booleanToolStripMenuItem.Text = "Boolean";
            this.booleanToolStripMenuItem.Click += new System.EventHandler(this.booleanToolStripMenuItem_Click);
            // 
            // singleOptionToolStripMenuItem
            // 
            this.singleOptionToolStripMenuItem.Name = "singleOptionToolStripMenuItem";
            this.singleOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.singleOptionToolStripMenuItem.Text = "Single Option";
            this.singleOptionToolStripMenuItem.Click += new System.EventHandler(this.singleOptionToolStripMenuItem_Click);
            // 
            // stringToolStripMenuItem
            // 
            this.stringToolStripMenuItem.Name = "stringToolStripMenuItem";
            this.stringToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stringToolStripMenuItem.Text = "String";
            this.stringToolStripMenuItem.Click += new System.EventHandler(this.stringToolStripMenuItem_Click);
            // 
            // integerToolStripMenuItem
            // 
            this.integerToolStripMenuItem.Name = "integerToolStripMenuItem";
            this.integerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.integerToolStripMenuItem.Text = "Number";
            this.integerToolStripMenuItem.Click += new System.EventHandler(this.integerToolStripMenuItem_Click);
            // 
            // editRenameToolStripMenuItem
            // 
            this.editRenameToolStripMenuItem.Name = "editRenameToolStripMenuItem";
            this.editRenameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editRenameToolStripMenuItem.Text = "Edit(Rename)";
            // 
            // deleteTagToolStripMenuItem
            // 
            this.deleteTagToolStripMenuItem.Name = "deleteTagToolStripMenuItem";
            this.deleteTagToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteTagToolStripMenuItem.Text = "Remove";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.upToolStripMenuItem.Text = "Up";
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downToolStripMenuItem.Text = "Down";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // belongToToolStripMenuItem
            // 
            this.belongToToolStripMenuItem.Name = "belongToToolStripMenuItem";
            this.belongToToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.belongToToolStripMenuItem.Text = "Belong To";
            // 
            // independentFromToolStripMenuItem
            // 
            this.independentFromToolStripMenuItem.Name = "independentFromToolStripMenuItem";
            this.independentFromToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.independentFromToolStripMenuItem.Text = "Independent";
            // 
            // iglTag
            // 
            this.iglTag.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglTag.ImageStream")));
            this.iglTag.TransparentColor = System.Drawing.Color.Transparent;
            this.iglTag.Images.SetKeyName(0, "iconWW.png");
            this.iglTag.Images.SetKeyName(1, "iconSurveyTagBoolean.png");
            this.iglTag.Images.SetKeyName(2, "iconSurveyTagSingleOption.png");
            this.iglTag.Images.SetKeyName(3, "iconSurveyTagStrings.png");
            this.iglTag.Images.SetKeyName(4, "iconSurveyTagInteger.png");
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.26531F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.7347F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSurvey, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(223, 24);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSurvey
            // 
            this.lblSurvey.AutoSize = true;
            this.lblSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSurvey.Location = new System.Drawing.Point(54, 0);
            this.lblSurvey.Name = "lblSurvey";
            this.lblSurvey.Size = new System.Drawing.Size(166, 24);
            this.lblSurvey.TabIndex = 1;
            this.lblSurvey.Text = "(Survey Name)";
            this.lblSurvey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(377, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(803, 532);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Literature List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Literature});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(797, 513);
            this.dataGridView1.TabIndex = 0;
            // 
            // Literature
            // 
            this.Literature.HeaderText = "Literature";
            this.Literature.Name = "Literature";
            this.Literature.ReadOnly = true;
            this.Literature.Width = 500;
            // 
            // frmSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 562);
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
            this.groupBox3.ResumeLayout(false);
            this.cmsTagTree.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ContextMenuStrip cmsTagTree;
        private System.Windows.Forms.ListBox lsbSurvey;
        private System.Windows.Forms.ContextMenuStrip cmsSurvey;
        private System.Windows.Forms.ToolStripMenuItem addSurveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSurveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem belongToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem independentFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRenameToolStripMenuItem1;
        private System.Windows.Forms.ImageList iglTag;
        private System.Windows.Forms.ToolStripMenuItem booleanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem integerToolStripMenuItem;
        private System.Windows.Forms.TreeView trvSurveyTag;
        private System.Windows.Forms.ToolStripMenuItem nonBottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSurvey;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Literature;
    }
}