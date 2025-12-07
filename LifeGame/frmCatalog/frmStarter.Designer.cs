namespace LifeGame
{
    partial class frmStarter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStarter));
            this.nfiMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTool = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmToday = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmToolNewNote = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFindNote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmToolLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // nfiMain
            // 
            this.nfiMain.ContextMenuStrip = this.cmsTool;
            this.nfiMain.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiMain.Icon")));
            this.nfiMain.Text = "Life Game";
            this.nfiMain.Visible = true;
            this.nfiMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfiMain_MouseDoubleClick);
            // 
            // cmsTool
            // 
            this.cmsTool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmToday,
            this.toolStripSeparator1,
            this.tsmToolNewNote,
            this.tsmFindNote,
            this.toolStripSeparator6,
            this.tsmToolLiterature,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.cmsTool.Name = "cmsTool";
            this.cmsTool.Size = new System.Drawing.Size(136, 132);
            // 
            // tsmToday
            // 
            this.tsmToday.Name = "tsmToday";
            this.tsmToday.Size = new System.Drawing.Size(135, 22);
            this.tsmToday.Text = "Today";
            this.tsmToday.Click += new System.EventHandler(this.tsmToday_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // tsmToolNewNote
            // 
            this.tsmToolNewNote.Name = "tsmToolNewNote";
            this.tsmToolNewNote.Size = new System.Drawing.Size(135, 22);
            this.tsmToolNewNote.Text = "New Note";
            this.tsmToolNewNote.Click += new System.EventHandler(this.tsmToolNewNote_Click);
            // 
            // tsmFindNote
            // 
            this.tsmFindNote.Name = "tsmFindNote";
            this.tsmFindNote.Size = new System.Drawing.Size(135, 22);
            this.tsmFindNote.Text = "Find Note...";
            this.tsmFindNote.Click += new System.EventHandler(this.tsmFindNote_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(132, 6);
            // 
            // tsmToolLiterature
            // 
            this.tsmToolLiterature.Name = "tsmToolLiterature";
            this.tsmToolLiterature.Size = new System.Drawing.Size(135, 22);
            this.tsmToolLiterature.Text = "Literature";
            this.tsmToolLiterature.Click += new System.EventHandler(this.tsmToolLiterature_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(132, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 27);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStarter";
            this.Text = "frmStarter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStarter_FormClosing);
            this.Load += new System.EventHandler(this.frmStarter_Load);
            this.Resize += new System.EventHandler(this.frmStarter_Resize);
            this.cmsTool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfiMain;
        private System.Windows.Forms.ContextMenuStrip cmsTool;
        private System.Windows.Forms.ToolStripMenuItem tsmToday;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmToolNewNote;
        private System.Windows.Forms.ToolStripMenuItem tsmFindNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmToolLiterature;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}