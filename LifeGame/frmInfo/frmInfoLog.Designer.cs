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
            this.lblTimePeriod = new System.Windows.Forms.Label();
            this.lblLogName = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblWithWho = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLogInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLogInfo
            // 
            this.tlpLogInfo.BackColor = System.Drawing.Color.Transparent;
            this.tlpLogInfo.ColumnCount = 1;
            this.tlpLogInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogInfo.Controls.Add(this.lblTimePeriod, 0, 0);
            this.tlpLogInfo.Controls.Add(this.lblLogName, 0, 1);
            this.tlpLogInfo.Controls.Add(this.lblLocation, 0, 2);
            this.tlpLogInfo.Controls.Add(this.lblWithWho, 0, 3);
            this.tlpLogInfo.Controls.Add(this.lblTask, 0, 4);
            this.tlpLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogInfo.Location = new System.Drawing.Point(10, 10);
            this.tlpLogInfo.Margin = new System.Windows.Forms.Padding(10);
            this.tlpLogInfo.Name = "tlpLogInfo";
            this.tlpLogInfo.RowCount = 5;
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogInfo.Size = new System.Drawing.Size(560, 210);
            this.tlpLogInfo.TabIndex = 0;
            // 
            // lblTimePeriod
            // 
            this.lblTimePeriod.AutoSize = true;
            this.lblTimePeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimePeriod.Location = new System.Drawing.Point(3, 0);
            this.lblTimePeriod.Name = "lblTimePeriod";
            this.lblTimePeriod.Size = new System.Drawing.Size(554, 42);
            this.lblTimePeriod.TabIndex = 0;
            this.lblTimePeriod.Text = "label1";
            this.lblTimePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimePeriod.Click += new System.EventHandler(this.lblTimePeriod_Click);
            // 
            // lblLogName
            // 
            this.lblLogName.AutoSize = true;
            this.lblLogName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogName.Location = new System.Drawing.Point(3, 42);
            this.lblLogName.Name = "lblLogName";
            this.lblLogName.Size = new System.Drawing.Size(554, 42);
            this.lblLogName.TabIndex = 1;
            this.lblLogName.Text = "label2";
            this.lblLogName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogName.Click += new System.EventHandler(this.lblLogName_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Location = new System.Drawing.Point(3, 84);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(554, 42);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "label3";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLocation.Click += new System.EventHandler(this.lblLocation_Click);
            // 
            // lblWithWho
            // 
            this.lblWithWho.AutoSize = true;
            this.lblWithWho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWithWho.Location = new System.Drawing.Point(3, 126);
            this.lblWithWho.Name = "lblWithWho";
            this.lblWithWho.Size = new System.Drawing.Size(554, 42);
            this.lblWithWho.TabIndex = 3;
            this.lblWithWho.Text = "label4";
            this.lblWithWho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWithWho.Click += new System.EventHandler(this.lblWithWho_Click);
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTask.Location = new System.Drawing.Point(3, 168);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(554, 42);
            this.lblTask.TabIndex = 4;
            this.lblTask.Text = "label1";
            this.lblTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(580, 230);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // frmInfoLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 230);
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
        private System.Windows.Forms.Label lblTask;
    }
}