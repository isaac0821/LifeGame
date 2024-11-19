namespace LifeGame
{
    partial class frmSearchNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchNote));
            this.cmsNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.lsbNote = new System.Windows.Forms.ListBox();
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkLit = new System.Windows.Forms.CheckBox();
            this.chkNote = new System.Windows.Forms.CheckBox();
            this.cmsNote.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsNote
            // 
            this.cmsNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.toolStripSeparator1,
            this.tsmRemove});
            this.cmsNote.Name = "cmsNote";
            this.cmsNote.Size = new System.Drawing.Size(118, 54);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(117, 22);
            this.tsmOpen.Text = "Open";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // lsbNote
            // 
            this.lsbNote.ContextMenuStrip = this.cmsNote;
            this.lsbNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbNote.FormattingEnabled = true;
            this.lsbNote.Location = new System.Drawing.Point(3, 32);
            this.lsbNote.Name = "lsbNote";
            this.lsbNote.Size = new System.Drawing.Size(301, 276);
            this.lsbNote.TabIndex = 2;
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(117, 22);
            this.tsmRemove.Text = "Remove";
            this.tsmRemove.Click += new System.EventHandler(this.tsmRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lsbNote, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.324759F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.67524F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 311);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.Controls.Add(this.chkLit, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkNote, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(301, 23);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // chkLit
            // 
            this.chkLit.AutoSize = true;
            this.chkLit.Checked = true;
            this.chkLit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLit.Location = new System.Drawing.Point(227, 3);
            this.chkLit.Name = "chkLit";
            this.chkLit.Size = new System.Drawing.Size(71, 17);
            this.chkLit.TabIndex = 0;
            this.chkLit.Text = "Literature";
            this.chkLit.UseVisualStyleBackColor = true;
            this.chkLit.CheckedChanged += new System.EventHandler(this.chkLit_CheckedChanged);
            // 
            // chkNote
            // 
            this.chkNote.AutoSize = true;
            this.chkNote.Checked = true;
            this.chkNote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkNote.Location = new System.Drawing.Point(168, 3);
            this.chkNote.Name = "chkNote";
            this.chkNote.Size = new System.Drawing.Size(53, 17);
            this.chkNote.TabIndex = 1;
            this.chkNote.Text = "Note";
            this.chkNote.UseVisualStyleBackColor = true;
            this.chkNote.CheckedChanged += new System.EventHandler(this.chkNote_CheckedChanged);
            // 
            // frmSearchNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchNote";
            this.Text = "LifeGame - Search Notes";
            this.Load += new System.EventHandler(this.frmSearchNote_Load);
            this.cmsNote.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsNote;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ListBox lsbNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkLit;
        private System.Windows.Forms.CheckBox chkNote;
    }
}