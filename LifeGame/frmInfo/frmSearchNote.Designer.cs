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
            this.tsmOpenNote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmRemoveNote = new System.Windows.Forms.ToolStripMenuItem();
            this.lsbLit = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmsLit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lsbNote = new System.Windows.Forms.ListBox();
            this.tsmOpenLit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNote.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.cmsLit.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsNote
            // 
            this.cmsNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenNote,
            this.toolStripSeparator1,
            this.tsmRemoveNote});
            this.cmsNote.Name = "cmsNote";
            this.cmsNote.Size = new System.Drawing.Size(118, 54);
            // 
            // tsmOpenNote
            // 
            this.tsmOpenNote.Name = "tsmOpenNote";
            this.tsmOpenNote.Size = new System.Drawing.Size(117, 22);
            this.tsmOpenNote.Text = "Open";
            this.tsmOpenNote.Click += new System.EventHandler(this.tsmOpenNote_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // tsmRemoveNote
            // 
            this.tsmRemoveNote.Name = "tsmRemoveNote";
            this.tsmRemoveNote.Size = new System.Drawing.Size(117, 22);
            this.tsmRemoveNote.Text = "Remove";
            this.tsmRemoveNote.Click += new System.EventHandler(this.tsmRemoveNote_Click);
            // 
            // lsbLit
            // 
            this.lsbLit.ContextMenuStrip = this.cmsNote;
            this.lsbLit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbLit.FormattingEnabled = true;
            this.lsbLit.Location = new System.Drawing.Point(3, 3);
            this.lsbLit.Name = "lsbLit";
            this.lsbLit.Size = new System.Drawing.Size(535, 330);
            this.lsbLit.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.48454F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(371, 244);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(365, 238);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lsbNote);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(357, 212);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Note";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lsbLit);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(541, 336);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Literature";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmsLit
            // 
            this.cmsLit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenLit});
            this.cmsLit.Name = "cmsLit";
            this.cmsLit.Size = new System.Drawing.Size(181, 48);
            // 
            // lsbNote
            // 
            this.lsbNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbNote.FormattingEnabled = true;
            this.lsbNote.Location = new System.Drawing.Point(3, 3);
            this.lsbNote.Name = "lsbNote";
            this.lsbNote.Size = new System.Drawing.Size(351, 206);
            this.lsbNote.TabIndex = 0;
            // 
            // tsmOpenLit
            // 
            this.tsmOpenLit.Name = "tsmOpenLit";
            this.tsmOpenLit.Size = new System.Drawing.Size(180, 22);
            this.tsmOpenLit.Text = "Open";
            this.tsmOpenLit.Click += new System.EventHandler(this.tsmOpenLit_Click);
            // 
            // frmSearchNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 244);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchNote";
            this.Text = "LifeGame - Search Notes";
            this.Load += new System.EventHandler(this.frmSearchNote_Load);
            this.cmsNote.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.cmsLit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsNote;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenNote;
        private System.Windows.Forms.ListBox lsbLit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip cmsLit;
        private System.Windows.Forms.ListBox lsbNote;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenLit;
    }
}