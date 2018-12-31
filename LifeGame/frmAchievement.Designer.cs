namespace LifeGame
{
    partial class frmAchievement
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAchievementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAchievementMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picAchievement = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAchievement)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 779);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAchievementToolStripMenuItem,
            this.saveAchievementMapToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // addAchievementToolStripMenuItem
            // 
            this.addAchievementToolStripMenuItem.Name = "addAchievementToolStripMenuItem";
            this.addAchievementToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addAchievementToolStripMenuItem.Text = "Add Achievement";
            // 
            // saveAchievementMapToolStripMenuItem
            // 
            this.saveAchievementMapToolStripMenuItem.Name = "saveAchievementMapToolStripMenuItem";
            this.saveAchievementMapToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.saveAchievementMapToolStripMenuItem.Text = "Save Achievement Map";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picAchievement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 754);
            this.panel1.TabIndex = 4;
            // 
            // picAchievement
            // 
            this.picAchievement.BackColor = System.Drawing.Color.White;
            this.picAchievement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAchievement.Location = new System.Drawing.Point(0, 0);
            this.picAchievement.Name = "picAchievement";
            this.picAchievement.Size = new System.Drawing.Size(1184, 754);
            this.picAchievement.TabIndex = 0;
            this.picAchievement.TabStop = false;
            // 
            // frmAchievement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 801);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAchievement";
            this.Text = "frmAchievement";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAchievement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAchievementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAchievementMapToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picAchievement;

    }
}