namespace LifeGame
{
    partial class frmClearSchedule
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
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.chkPlusOneDay = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.chkMo = new System.Windows.Forms.CheckBox();
            this.chkTu = new System.Windows.Forms.CheckBox();
            this.chkWe = new System.Windows.Forms.CheckBox();
            this.chkTh = new System.Windows.Forms.CheckBox();
            this.chkFr = new System.Windows.Forms.CheckBox();
            this.chkSa = new System.Windows.Forms.CheckBox();
            this.chkSu = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 94);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "By Period";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Controls.Add(this.dtpPeriodStart, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpPeriodEnd, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(63, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(344, 18);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // dtpPeriodStart
            // 
            this.dtpPeriodStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPeriodStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodStart.Location = new System.Drawing.Point(47, 0);
            this.dtpPeriodStart.Margin = new System.Windows.Forms.Padding(0);
            this.dtpPeriodStart.Name = "dtpPeriodStart";
            this.dtpPeriodStart.Size = new System.Drawing.Size(101, 21);
            this.dtpPeriodStart.TabIndex = 0;
            // 
            // dtpPeriodEnd
            // 
            this.dtpPeriodEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPeriodEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodEnd.Location = new System.Drawing.Point(168, 0);
            this.dtpPeriodEnd.Margin = new System.Windows.Forms.Padding(0);
            this.dtpPeriodEnd.Name = "dtpPeriodEnd";
            this.dtpPeriodEnd.Size = new System.Drawing.Size(101, 21);
            this.dtpPeriodEnd.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel3.Controls.Add(this.dtpTimeStart, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpTimeEnd, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkPlusOneDay, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(63, 51);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(344, 18);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeStart.Location = new System.Drawing.Point(47, 0);
            this.dtpTimeStart.Margin = new System.Windows.Forms.Padding(0);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.Size = new System.Drawing.Size(101, 21);
            this.dtpTimeStart.TabIndex = 0;
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeEnd.Location = new System.Drawing.Point(168, 0);
            this.dtpTimeEnd.Margin = new System.Windows.Forms.Padding(0);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.Size = new System.Drawing.Size(101, 21);
            this.dtpTimeEnd.TabIndex = 1;
            // 
            // chkPlusOneDay
            // 
            this.chkPlusOneDay.AutoSize = true;
            this.chkPlusOneDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPlusOneDay.Location = new System.Drawing.Point(279, 0);
            this.chkPlusOneDay.Margin = new System.Windows.Forms.Padding(0);
            this.chkPlusOneDay.Name = "chkPlusOneDay";
            this.chkPlusOneDay.Size = new System.Drawing.Size(65, 18);
            this.chkPlusOneDay.TabIndex = 2;
            this.chkPlusOneDay.Text = "+1 day";
            this.chkPlusOneDay.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.Controls.Add(this.chkMo, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkTu, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkWe, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkTh, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkFr, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkSa, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkSu, 6, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(60, 24);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(350, 24);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // chkMo
            // 
            this.chkMo.AutoSize = true;
            this.chkMo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMo.Location = new System.Drawing.Point(3, 3);
            this.chkMo.Name = "chkMo";
            this.chkMo.Size = new System.Drawing.Size(43, 18);
            this.chkMo.TabIndex = 0;
            this.chkMo.Text = "Mo";
            this.chkMo.UseVisualStyleBackColor = true;
            // 
            // chkTu
            // 
            this.chkTu.AutoSize = true;
            this.chkTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTu.Location = new System.Drawing.Point(52, 3);
            this.chkTu.Name = "chkTu";
            this.chkTu.Size = new System.Drawing.Size(43, 18);
            this.chkTu.TabIndex = 1;
            this.chkTu.Text = "Tu";
            this.chkTu.UseVisualStyleBackColor = true;
            // 
            // chkWe
            // 
            this.chkWe.AutoSize = true;
            this.chkWe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWe.Location = new System.Drawing.Point(101, 3);
            this.chkWe.Name = "chkWe";
            this.chkWe.Size = new System.Drawing.Size(43, 18);
            this.chkWe.TabIndex = 2;
            this.chkWe.Text = "We";
            this.chkWe.UseVisualStyleBackColor = true;
            // 
            // chkTh
            // 
            this.chkTh.AutoSize = true;
            this.chkTh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTh.Location = new System.Drawing.Point(150, 3);
            this.chkTh.Name = "chkTh";
            this.chkTh.Size = new System.Drawing.Size(43, 18);
            this.chkTh.TabIndex = 3;
            this.chkTh.Text = "Th";
            this.chkTh.UseVisualStyleBackColor = true;
            // 
            // chkFr
            // 
            this.chkFr.AutoSize = true;
            this.chkFr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFr.Location = new System.Drawing.Point(199, 3);
            this.chkFr.Name = "chkFr";
            this.chkFr.Size = new System.Drawing.Size(43, 18);
            this.chkFr.TabIndex = 4;
            this.chkFr.Text = "Fr";
            this.chkFr.UseVisualStyleBackColor = true;
            // 
            // chkSa
            // 
            this.chkSa.AutoSize = true;
            this.chkSa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSa.Location = new System.Drawing.Point(248, 3);
            this.chkSa.Name = "chkSa";
            this.chkSa.Size = new System.Drawing.Size(43, 18);
            this.chkSa.TabIndex = 5;
            this.chkSa.Text = "Sa";
            this.chkSa.UseVisualStyleBackColor = true;
            // 
            // chkSu
            // 
            this.chkSu.AutoSize = true;
            this.chkSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSu.Location = new System.Drawing.Point(297, 3);
            this.chkSu.Name = "chkSu";
            this.chkSu.Size = new System.Drawing.Size(50, 18);
            this.chkSu.TabIndex = 6;
            this.chkSu.Text = "Su";
            this.chkSu.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.Controls.Add(this.btnClear, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(60, 72);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(350, 24);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(293, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 18);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Add";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmClearSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 94);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClearSchedule";
            this.Text = "LifeGame - Clear Schedule";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtpPeriodStart;
        private System.Windows.Forms.DateTimePicker dtpPeriodEnd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.CheckBox chkPlusOneDay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox chkMo;
        private System.Windows.Forms.CheckBox chkTu;
        private System.Windows.Forms.CheckBox chkWe;
        private System.Windows.Forms.CheckBox chkTh;
        private System.Windows.Forms.CheckBox chkFr;
        private System.Windows.Forms.CheckBox chkSa;
        private System.Windows.Forms.CheckBox chkSu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnClear;
    }
}