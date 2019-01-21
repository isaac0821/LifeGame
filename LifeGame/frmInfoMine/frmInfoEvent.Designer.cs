namespace LifeGame
{
    partial class frmInfoEvent
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEvent = new System.Windows.Forms.TableLayoutPanel();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblSucceed = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tlpEvent, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(580, 190);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tlpEvent
            // 
            this.tlpEvent.BackColor = System.Drawing.Color.Silver;
            this.tlpEvent.ColumnCount = 1;
            this.tlpEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEvent.Controls.Add(this.lblEventName, 0, 1);
            this.tlpEvent.Controls.Add(this.lblSucceed, 0, 2);
            this.tlpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEvent.Location = new System.Drawing.Point(10, 10);
            this.tlpEvent.Margin = new System.Windows.Forms.Padding(10);
            this.tlpEvent.Name = "tlpEvent";
            this.tlpEvent.RowCount = 4;
            this.tlpEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEvent.Size = new System.Drawing.Size(560, 170);
            this.tlpEvent.TabIndex = 0;
            this.tlpEvent.Click += new System.EventHandler(this.tlpEvent_Click);
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEventName.Location = new System.Drawing.Point(3, 45);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(554, 40);
            this.lblEventName.TabIndex = 0;
            this.lblEventName.Text = "label1";
            this.lblEventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEventName.Click += new System.EventHandler(this.lblEventName_Click);
            // 
            // lblSucceed
            // 
            this.lblSucceed.AutoSize = true;
            this.lblSucceed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSucceed.Location = new System.Drawing.Point(3, 85);
            this.lblSucceed.Name = "lblSucceed";
            this.lblSucceed.Size = new System.Drawing.Size(554, 40);
            this.lblSucceed.TabIndex = 1;
            this.lblSucceed.Text = "label2";
            this.lblSucceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSucceed.Click += new System.EventHandler(this.lblSucceed_Click);
            // 
            // frmInfoEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 190);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInfoEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEvent";
            this.Deactivate += new System.EventHandler(this.frmInfoEvent_Deactivate);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpEvent.ResumeLayout(false);
            this.tlpEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpEvent;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblSucceed;
    }
}