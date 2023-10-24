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
            this.cmsNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsNote
            // 
            this.cmsNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen});
            this.cmsNote.Name = "cmsNote";
            this.cmsNote.Size = new System.Drawing.Size(109, 26);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(108, 22);
            this.tsmOpen.Text = "Open";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // lsbNote
            // 
            this.lsbNote.ContextMenuStrip = this.cmsNote;
            this.lsbNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbNote.FormattingEnabled = true;
            this.lsbNote.ItemHeight = 12;
            this.lsbNote.Location = new System.Drawing.Point(0, 0);
            this.lsbNote.Name = "lsbNote";
            this.lsbNote.Size = new System.Drawing.Size(307, 287);
            this.lsbNote.TabIndex = 2;
            // 
            // frmSearchNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 287);
            this.Controls.Add(this.lsbNote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchNote";
            this.Text = "LifeGame - Search Notes";
            this.Load += new System.EventHandler(this.frmSearchNote_Load);
            this.cmsNote.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsNote;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ListBox lsbNote;
    }
}