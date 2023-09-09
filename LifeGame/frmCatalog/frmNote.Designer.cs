namespace LifeGame.frmCatalog
{
    partial class frmNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNote));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lsbNoteTag = new System.Windows.Forms.ListBox();
            this.picNote = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNote)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lsbNoteTag);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picNote);
            this.splitContainer1.Size = new System.Drawing.Size(1253, 716);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 0;
            // 
            // lsbNoteTag
            // 
            this.lsbNoteTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbNoteTag.FormattingEnabled = true;
            this.lsbNoteTag.ItemHeight = 12;
            this.lsbNoteTag.Location = new System.Drawing.Point(0, 0);
            this.lsbNoteTag.Name = "lsbNoteTag";
            this.lsbNoteTag.Size = new System.Drawing.Size(184, 716);
            this.lsbNoteTag.TabIndex = 0;
            // 
            // picNote
            // 
            this.picNote.BackColor = System.Drawing.Color.White;
            this.picNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picNote.Location = new System.Drawing.Point(0, 0);
            this.picNote.Name = "picNote";
            this.picNote.Size = new System.Drawing.Size(1065, 716);
            this.picNote.TabIndex = 0;
            this.picNote.TabStop = false;
            // 
            // frmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 716);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNote";
            this.Text = "LifeGame - Note";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lsbNoteTag;
        private System.Windows.Forms.PictureBox picNote;
    }
}