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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgTag = new System.Windows.Forms.TabPage();
            this.clbTag = new System.Windows.Forms.CheckedListBox();
            this.tpgAuthor = new System.Windows.Forms.TabPage();
            this.clbAuthor = new System.Windows.Forms.CheckedListBox();
            this.tpgYear = new System.Windows.Forms.TabPage();
            this.clbYear = new System.Windows.Forms.CheckedListBox();
            this.tpgInstitution = new System.Windows.Forms.TabPage();
            this.clbInstitution = new System.Windows.Forms.CheckedListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.clbJournalConference = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoOr = new System.Windows.Forms.RadioButton();
            this.rdoAnd = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLiterature = new System.Windows.Forms.DataGridView();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsLiterature = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApply = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpgTag.SuspendLayout();
            this.tpgAuthor.SuspendLayout();
            this.tpgYear.SuspendLayout();
            this.tpgInstitution.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiterature)).BeginInit();
            this.cmsLiterature.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1093, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(1093, 646);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(309, 640);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 627);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tpgTag);
            this.tabControl1.Controls.Add(this.tpgAuthor);
            this.tabControl1.Controls.Add(this.tpgYear);
            this.tabControl1.Controls.Add(this.tpgInstitution);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 34);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(303, 590);
            this.tabControl1.TabIndex = 0;
            // 
            // tpgTag
            // 
            this.tpgTag.Controls.Add(this.clbTag);
            this.tpgTag.Location = new System.Drawing.Point(23, 4);
            this.tpgTag.Name = "tpgTag";
            this.tpgTag.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTag.Size = new System.Drawing.Size(276, 582);
            this.tpgTag.TabIndex = 0;
            this.tpgTag.Text = "Tag";
            this.tpgTag.UseVisualStyleBackColor = true;
            // 
            // clbTag
            // 
            this.clbTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbTag.FormattingEnabled = true;
            this.clbTag.Location = new System.Drawing.Point(3, 3);
            this.clbTag.Name = "clbTag";
            this.clbTag.Size = new System.Drawing.Size(270, 576);
            this.clbTag.TabIndex = 0;
            this.clbTag.SelectedIndexChanged += new System.EventHandler(this.clbTag_SelectedIndexChanged);
            // 
            // tpgAuthor
            // 
            this.tpgAuthor.Controls.Add(this.clbAuthor);
            this.tpgAuthor.Location = new System.Drawing.Point(23, 4);
            this.tpgAuthor.Name = "tpgAuthor";
            this.tpgAuthor.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAuthor.Size = new System.Drawing.Size(276, 582);
            this.tpgAuthor.TabIndex = 1;
            this.tpgAuthor.Text = "Author";
            this.tpgAuthor.UseVisualStyleBackColor = true;
            // 
            // clbAuthor
            // 
            this.clbAuthor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAuthor.FormattingEnabled = true;
            this.clbAuthor.Location = new System.Drawing.Point(3, 3);
            this.clbAuthor.Name = "clbAuthor";
            this.clbAuthor.Size = new System.Drawing.Size(270, 576);
            this.clbAuthor.TabIndex = 0;
            this.clbAuthor.SelectedIndexChanged += new System.EventHandler(this.clbAuthor_SelectedIndexChanged);
            // 
            // tpgYear
            // 
            this.tpgYear.Controls.Add(this.clbYear);
            this.tpgYear.Location = new System.Drawing.Point(23, 4);
            this.tpgYear.Name = "tpgYear";
            this.tpgYear.Padding = new System.Windows.Forms.Padding(3);
            this.tpgYear.Size = new System.Drawing.Size(276, 582);
            this.tpgYear.TabIndex = 2;
            this.tpgYear.Text = "Year";
            this.tpgYear.UseVisualStyleBackColor = true;
            // 
            // clbYear
            // 
            this.clbYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbYear.FormattingEnabled = true;
            this.clbYear.Location = new System.Drawing.Point(3, 3);
            this.clbYear.Name = "clbYear";
            this.clbYear.Size = new System.Drawing.Size(270, 576);
            this.clbYear.TabIndex = 0;
            this.clbYear.SelectedIndexChanged += new System.EventHandler(this.clbYear_SelectedIndexChanged);
            // 
            // tpgInstitution
            // 
            this.tpgInstitution.Controls.Add(this.clbInstitution);
            this.tpgInstitution.Location = new System.Drawing.Point(23, 4);
            this.tpgInstitution.Name = "tpgInstitution";
            this.tpgInstitution.Padding = new System.Windows.Forms.Padding(3);
            this.tpgInstitution.Size = new System.Drawing.Size(276, 582);
            this.tpgInstitution.TabIndex = 3;
            this.tpgInstitution.Text = "Institution";
            this.tpgInstitution.UseVisualStyleBackColor = true;
            // 
            // clbInstitution
            // 
            this.clbInstitution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbInstitution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbInstitution.FormattingEnabled = true;
            this.clbInstitution.Location = new System.Drawing.Point(3, 3);
            this.clbInstitution.Name = "clbInstitution";
            this.clbInstitution.Size = new System.Drawing.Size(270, 576);
            this.clbInstitution.TabIndex = 0;
            this.clbInstitution.SelectedIndexChanged += new System.EventHandler(this.clbInstitution_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.clbJournalConference);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 582);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Journal/Conference";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // clbJournalConference
            // 
            this.clbJournalConference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbJournalConference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbJournalConference.FormattingEnabled = true;
            this.clbJournalConference.Location = new System.Drawing.Point(3, 3);
            this.clbJournalConference.Name = "clbJournalConference";
            this.clbJournalConference.Size = new System.Drawing.Size(270, 576);
            this.clbJournalConference.TabIndex = 0;
            this.clbJournalConference.SelectedIndexChanged += new System.EventHandler(this.clbJournalConference_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.Controls.Add(this.rdoOr, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdoAnd, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnApply, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(303, 25);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // rdoOr
            // 
            this.rdoOr.AutoSize = true;
            this.rdoOr.Checked = true;
            this.rdoOr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoOr.Location = new System.Drawing.Point(204, 3);
            this.rdoOr.Name = "rdoOr";
            this.rdoOr.Size = new System.Drawing.Size(45, 19);
            this.rdoOr.TabIndex = 0;
            this.rdoOr.TabStop = true;
            this.rdoOr.Text = "OR";
            this.rdoOr.UseVisualStyleBackColor = true;
            this.rdoOr.CheckedChanged += new System.EventHandler(this.rdoOr_CheckedChanged);
            // 
            // rdoAnd
            // 
            this.rdoAnd.AutoSize = true;
            this.rdoAnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnd.Location = new System.Drawing.Point(150, 3);
            this.rdoAnd.Name = "rdoAnd";
            this.rdoAnd.Size = new System.Drawing.Size(48, 19);
            this.rdoAnd.TabIndex = 1;
            this.rdoAnd.Text = "AND";
            this.rdoAnd.UseVisualStyleBackColor = true;
            this.rdoAnd.CheckedChanged += new System.EventHandler(this.rdoAnd_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Mode:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.27864F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(774, 646);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLiterature);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 640);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Literature List";
            // 
            // dgvLiterature
            // 
            this.dgvLiterature.AllowUserToAddRows = false;
            this.dgvLiterature.AllowUserToDeleteRows = false;
            this.dgvLiterature.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLiterature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLiterature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiterature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitle});
            this.dgvLiterature.ContextMenuStrip = this.cmsLiterature;
            this.dgvLiterature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLiterature.Location = new System.Drawing.Point(3, 16);
            this.dgvLiterature.Name = "dgvLiterature";
            this.dgvLiterature.ReadOnly = true;
            this.dgvLiterature.Size = new System.Drawing.Size(762, 621);
            this.dgvLiterature.TabIndex = 1;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 600;
            // 
            // cmsLiterature
            // 
            this.cmsLiterature.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddLiterature,
            this.tsmViewLiterature,
            this.tsmRemoveLiterature});
            this.cmsLiterature.Name = "cmsLiterature";
            this.cmsLiterature.Size = new System.Drawing.Size(118, 70);
            // 
            // tsmAddLiterature
            // 
            this.tsmAddLiterature.Name = "tsmAddLiterature";
            this.tsmAddLiterature.Size = new System.Drawing.Size(117, 22);
            this.tsmAddLiterature.Text = "Add";
            this.tsmAddLiterature.Click += new System.EventHandler(this.tsmAddLiterature_Click);
            // 
            // tsmViewLiterature
            // 
            this.tsmViewLiterature.Name = "tsmViewLiterature";
            this.tsmViewLiterature.Size = new System.Drawing.Size(117, 22);
            this.tsmViewLiterature.Text = "View";
            this.tsmViewLiterature.Click += new System.EventHandler(this.tsmViewLiterature_Click);
            // 
            // tsmRemoveLiterature
            // 
            this.tsmRemoveLiterature.Name = "tsmRemoveLiterature";
            this.tsmRemoveLiterature.Size = new System.Drawing.Size(117, 22);
            this.tsmRemoveLiterature.Text = "Remove";
            this.tsmRemoveLiterature.Click += new System.EventHandler(this.tsmRemoveLiterature_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(252, 0);
            this.btnApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(51, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmLiterature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 670);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmLiterature";
            this.Text = "frmLiterature";
            this.Load += new System.EventHandler(this.frmLiterature_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpgTag.ResumeLayout(false);
            this.tpgAuthor.ResumeLayout(false);
            this.tpgYear.ResumeLayout(false);
            this.tpgInstitution.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiterature)).EndInit();
            this.cmsLiterature.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgTag;
        private System.Windows.Forms.TabPage tpgAuthor;
        private System.Windows.Forms.TabPage tpgYear;
        private System.Windows.Forms.TabPage tpgInstitution;
        private System.Windows.Forms.CheckedListBox clbTag;
        private System.Windows.Forms.CheckedListBox clbAuthor;
        private System.Windows.Forms.CheckedListBox clbYear;
        private System.Windows.Forms.CheckedListBox clbInstitution;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rdoOr;
        private System.Windows.Forms.RadioButton rdoAnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLiterature;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox clbJournalConference;
        private System.Windows.Forms.ContextMenuStrip cmsLiterature;
        private System.Windows.Forms.ToolStripMenuItem tsmAddLiterature;
        private System.Windows.Forms.ToolStripMenuItem tsmViewLiterature;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveLiterature;
        private System.Windows.Forms.Button btnApply;
    }
}