namespace LifeGame
{
    partial class frmInfoSurvey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoSurvey));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSurveyName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvSurveyTag = new System.Windows.Forms.TreeView();
            this.dgvSurvey = new System.Windows.Forms.DataGridView();
            this.colLiterature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsLiterature = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewLiteratureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addLiteratureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoShowLiteratureTitle = new System.Windows.Forms.RadioButton();
            this.rdoShowBibTexKey = new System.Windows.Forms.RadioButton();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurvey)).BeginInit();
            this.cmsLiterature.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblSurveyName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblSurveyName
            // 
            this.lblSurveyName.AutoSize = true;
            this.lblSurveyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSurveyName.Location = new System.Drawing.Point(3, 0);
            this.lblSurveyName.Name = "lblSurveyName";
            this.lblSurveyName.Size = new System.Drawing.Size(794, 33);
            this.lblSurveyName.TabIndex = 0;
            this.lblSurveyName.Text = "(Survey)";
            this.lblSurveyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 69);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvSurveyTag);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvSurvey);
            this.splitContainer1.Size = new System.Drawing.Size(794, 378);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 1;
            // 
            // trvSurveyTag
            // 
            this.trvSurveyTag.BackColor = System.Drawing.SystemColors.Control;
            this.trvSurveyTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvSurveyTag.CheckBoxes = true;
            this.trvSurveyTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvSurveyTag.Location = new System.Drawing.Point(0, 0);
            this.trvSurveyTag.Name = "trvSurveyTag";
            treeNode1.Name = "root";
            treeNode1.Text = "(Root)";
            this.trvSurveyTag.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvSurveyTag.Size = new System.Drawing.Size(177, 378);
            this.trvSurveyTag.TabIndex = 0;
            this.trvSurveyTag.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvSurveyTag_AfterSelect);
            // 
            // dgvSurvey
            // 
            this.dgvSurvey.AllowUserToAddRows = false;
            this.dgvSurvey.AllowUserToDeleteRows = false;
            this.dgvSurvey.AllowUserToOrderColumns = true;
            this.dgvSurvey.AllowUserToResizeRows = false;
            this.dgvSurvey.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSurvey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSurvey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurvey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLiterature});
            this.dgvSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSurvey.Location = new System.Drawing.Point(0, 0);
            this.dgvSurvey.Name = "dgvSurvey";
            this.dgvSurvey.Size = new System.Drawing.Size(613, 378);
            this.dgvSurvey.TabIndex = 0;
            // 
            // colLiterature
            // 
            this.colLiterature.FillWeight = 350F;
            this.colLiterature.HeaderText = "Literature";
            this.colLiterature.Name = "colLiterature";
            this.colLiterature.Width = 350;
            // 
            // cmsLiterature
            // 
            this.cmsLiterature.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLiteratureToolStripMenuItem,
            this.toolStripSeparator1,
            this.addLiteratureToolStripMenuItem});
            this.cmsLiterature.Name = "cmsLiterature";
            this.cmsLiterature.Size = new System.Drawing.Size(153, 54);
            // 
            // viewLiteratureToolStripMenuItem
            // 
            this.viewLiteratureToolStripMenuItem.Name = "viewLiteratureToolStripMenuItem";
            this.viewLiteratureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewLiteratureToolStripMenuItem.Text = "View Literature";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // addLiteratureToolStripMenuItem
            // 
            this.addLiteratureToolStripMenuItem.Name = "addLiteratureToolStripMenuItem";
            this.addLiteratureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addLiteratureToolStripMenuItem.Text = "Add Literature";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel2.Controls.Add(this.rdoShowLiteratureTitle, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdoShowBibTexKey, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportCSV, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 27);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // rdoShowLiteratureTitle
            // 
            this.rdoShowLiteratureTitle.AutoSize = true;
            this.rdoShowLiteratureTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoShowLiteratureTitle.Location = new System.Drawing.Point(474, 3);
            this.rdoShowLiteratureTitle.Name = "rdoShowLiteratureTitle";
            this.rdoShowLiteratureTitle.Size = new System.Drawing.Size(100, 21);
            this.rdoShowLiteratureTitle.TabIndex = 0;
            this.rdoShowLiteratureTitle.TabStop = true;
            this.rdoShowLiteratureTitle.Text = "Literature Title";
            this.rdoShowLiteratureTitle.UseVisualStyleBackColor = true;
            // 
            // rdoShowBibTexKey
            // 
            this.rdoShowBibTexKey.AutoSize = true;
            this.rdoShowBibTexKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoShowBibTexKey.Location = new System.Drawing.Point(580, 3);
            this.rdoShowBibTexKey.Name = "rdoShowBibTexKey";
            this.rdoShowBibTexKey.Size = new System.Drawing.Size(94, 21);
            this.rdoShowBibTexKey.TabIndex = 1;
            this.rdoShowBibTexKey.TabStop = true;
            this.rdoShowBibTexKey.Text = "BibTeX Keys";
            this.rdoShowBibTexKey.UseVisualStyleBackColor = true;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportCSV.Location = new System.Drawing.Point(680, 3);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(111, 21);
            this.btnExportCSV.TabIndex = 2;
            this.btnExportCSV.Text = "Export As CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            // 
            // frmInfoSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInfoSurvey";
            this.Text = "LifeGame - Survey Details";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurvey)).EndInit();
            this.cmsLiterature.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSurveyName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvSurveyTag;
        private System.Windows.Forms.DataGridView dgvSurvey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiterature;
        private System.Windows.Forms.ContextMenuStrip cmsLiterature;
        private System.Windows.Forms.ToolStripMenuItem viewLiteratureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addLiteratureToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        internal System.Windows.Forms.RadioButton rdoShowLiteratureTitle;
        private System.Windows.Forms.RadioButton rdoShowBibTexKey;
        private System.Windows.Forms.Button btnExportCSV;
    }
}