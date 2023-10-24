namespace LifeGame
{
    partial class frmInfoLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoLog));
            this.tlpLogInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblLogName = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblWithWho = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimePeriod = new System.Windows.Forms.Label();
            this.picClock = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLogInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClock)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLogInfo
            // 
            this.tlpLogInfo.BackColor = System.Drawing.Color.Transparent;
            this.tlpLogInfo.ColumnCount = 1;
            this.tlpLogInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogInfo.Controls.Add(this.lblLogName, 0, 1);
            this.tlpLogInfo.Controls.Add(this.lblLocation, 0, 2);
            this.tlpLogInfo.Controls.Add(this.lblWithWho, 0, 3);
            this.tlpLogInfo.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogInfo.Location = new System.Drawing.Point(10, 9);
            this.tlpLogInfo.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.tlpLogInfo.Name = "tlpLogInfo";
            this.tlpLogInfo.RowCount = 4;
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.Size = new System.Drawing.Size(560, 194);
            this.tlpLogInfo.TabIndex = 0;
            // 
            // lblLogName
            // 
            this.lblLogName.AutoSize = true;
            this.lblLogName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogName.Location = new System.Drawing.Point(3, 48);
            this.lblLogName.Name = "lblLogName";
            this.lblLogName.Size = new System.Drawing.Size(554, 48);
            this.lblLogName.TabIndex = 1;
            this.lblLogName.Text = "Log Name";
            this.lblLogName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogName.Click += new System.EventHandler(this.lblLogName_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Location = new System.Drawing.Point(3, 96);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(554, 48);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLocation.Click += new System.EventHandler(this.lblLocation_Click);
            // 
            // lblWithWho
            // 
            this.lblWithWho.AutoSize = true;
            this.lblWithWho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWithWho.Location = new System.Drawing.Point(3, 144);
            this.lblWithWho.Name = "lblWithWho";
            this.lblWithWho.Size = new System.Drawing.Size(554, 50);
            this.lblWithWho.TabIndex = 3;
            this.lblWithWho.Text = "With Who";
            this.lblWithWho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWithWho.Click += new System.EventHandler(this.lblWithWho_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblTimePeriod, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.picClock, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(554, 42);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lblTimePeriod
            // 
            this.lblTimePeriod.AutoSize = true;
            this.lblTimePeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimePeriod.Location = new System.Drawing.Point(53, 0);
            this.lblTimePeriod.Name = "lblTimePeriod";
            this.lblTimePeriod.Size = new System.Drawing.Size(448, 42);
            this.lblTimePeriod.TabIndex = 0;
            this.lblTimePeriod.Text = "Time Period";
            this.lblTimePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimePeriod.Click += new System.EventHandler(this.lblTimePeriod_Click);
            // 
            // picClock
            // 
            this.picClock.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picClock.Location = new System.Drawing.Point(3, 3);
            this.picClock.Name = "picClock";
            this.picClock.Size = new System.Drawing.Size(44, 36);
            this.picClock.TabIndex = 1;
            this.picClock.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tlpLogInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(580, 212);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // frmInfoLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 212);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfoLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LifeGame - Log Info";
            this.Deactivate += new System.EventHandler(this.frmLogInfo_Deactivate);
            this.Click += new System.EventHandler(this.frmLogInfo_Click);
            this.tlpLogInfo.ResumeLayout(false);
            this.tlpLogInfo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClock)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLogInfo;
        private System.Windows.Forms.Label lblTimePeriod;
        private System.Windows.Forms.Label lblLogName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblWithWho;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox picClock;
    }
}