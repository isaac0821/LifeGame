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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgTag = new System.Windows.Forms.TabPage();
            this.clbTag = new System.Windows.Forms.CheckedListBox();
            this.tpgAuthor = new System.Windows.Forms.TabPage();
            this.clbAuthor = new System.Windows.Forms.CheckedListBox();
            this.tpgYear = new System.Windows.Forms.TabPage();
            this.clbYear = new System.Windows.Forms.CheckedListBox();
            this.tpgInstitution = new System.Windows.Forms.TabPage();
            this.clbInstitution = new System.Windows.Forms.CheckedListBox();
            this.dgvLiterature = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoOr = new System.Windows.Forms.RadioButton();
            this.rdoAnd = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpgTag.SuspendLayout();
            this.tpgAuthor.SuspendLayout();
            this.tpgYear.SuspendLayout();
            this.tpgInstitution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiterature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.dgvLiterature);
            this.splitContainer1.Size = new System.Drawing.Size(800, 426);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgTag);
            this.tabControl1.Controls.Add(this.tpgAuthor);
            this.tabControl1.Controls.Add(this.tpgYear);
            this.tabControl1.Controls.Add(this.tpgInstitution);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(241, 389);
            this.tabControl1.TabIndex = 0;
            // 
            // tpgTag
            // 
            this.tpgTag.Controls.Add(this.clbTag);
            this.tpgTag.Location = new System.Drawing.Point(4, 22);
            this.tpgTag.Name = "tpgTag";
            this.tpgTag.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTag.Size = new System.Drawing.Size(239, 400);
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
            this.clbTag.Size = new System.Drawing.Size(233, 394);
            this.clbTag.TabIndex = 0;
            // 
            // tpgAuthor
            // 
            this.tpgAuthor.Controls.Add(this.clbAuthor);
            this.tpgAuthor.Location = new System.Drawing.Point(4, 22);
            this.tpgAuthor.Name = "tpgAuthor";
            this.tpgAuthor.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAuthor.Size = new System.Drawing.Size(239, 400);
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
            this.clbAuthor.Size = new System.Drawing.Size(233, 394);
            this.clbAuthor.TabIndex = 0;
            // 
            // tpgYear
            // 
            this.tpgYear.Controls.Add(this.clbYear);
            this.tpgYear.Location = new System.Drawing.Point(4, 22);
            this.tpgYear.Name = "tpgYear";
            this.tpgYear.Padding = new System.Windows.Forms.Padding(3);
            this.tpgYear.Size = new System.Drawing.Size(239, 400);
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
            this.clbYear.Size = new System.Drawing.Size(233, 394);
            this.clbYear.TabIndex = 0;
            // 
            // tpgInstitution
            // 
            this.tpgInstitution.Controls.Add(this.clbInstitution);
            this.tpgInstitution.Location = new System.Drawing.Point(4, 22);
            this.tpgInstitution.Name = "tpgInstitution";
            this.tpgInstitution.Padding = new System.Windows.Forms.Padding(3);
            this.tpgInstitution.Size = new System.Drawing.Size(233, 363);
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
            this.clbInstitution.Size = new System.Drawing.Size(227, 357);
            this.clbInstitution.TabIndex = 0;
            // 
            // dgvLiterature
            // 
            this.dgvLiterature.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLiterature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLiterature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiterature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLiterature.Location = new System.Drawing.Point(0, 0);
            this.dgvLiterature.Name = "dgvLiterature";
            this.dgvLiterature.Size = new System.Drawing.Size(549, 426);
            this.dgvLiterature.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitle,
            this.colAuthor});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(549, 426);
            this.dataGridView1.TabIndex = 1;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colAuthor
            // 
            this.colAuthor.HeaderText = "Author";
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 426);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.Controls.Add(this.rdoOr, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdoAnd, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(241, 25);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // rdoOr
            // 
            this.rdoOr.AutoSize = true;
            this.rdoOr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoOr.Location = new System.Drawing.Point(197, 3);
            this.rdoOr.Name = "rdoOr";
            this.rdoOr.Size = new System.Drawing.Size(41, 19);
            this.rdoOr.TabIndex = 0;
            this.rdoOr.TabStop = true;
            this.rdoOr.Text = "OR";
            this.rdoOr.UseVisualStyleBackColor = true;
            // 
            // rdoAnd
            // 
            this.rdoAnd.AutoSize = true;
            this.rdoAnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnd.Location = new System.Drawing.Point(140, 3);
            this.rdoAnd.Name = "rdoAnd";
            this.rdoAnd.Size = new System.Drawing.Size(51, 19);
            this.rdoAnd.TabIndex = 1;
            this.rdoAnd.TabStop = true;
            this.rdoAnd.Text = "AND";
            this.rdoAnd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Mode:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLiterature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmLiterature";
            this.Text = "frmLiterature";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpgTag.ResumeLayout(false);
            this.tpgAuthor.ResumeLayout(false);
            this.tpgYear.ResumeLayout(false);
            this.tpgInstitution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiterature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvLiterature;
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthor;
    }
}