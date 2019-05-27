namespace LifeGame
{
    partial class frmAddSleepSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSleepSchedule));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.chkMinusOneDay = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.chkMo = new System.Windows.Forms.CheckBox();
            this.chkTu = new System.Windows.Forms.CheckBox();
            this.chkWe = new System.Windows.Forms.CheckBox();
            this.cheTh = new System.Windows.Forms.CheckBox();
            this.chkFr = new System.Windows.Forms.CheckBox();
            this.chkSa = new System.Windows.Forms.CheckBox();
            this.chkSu = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 129);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "By Period";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Controls.Add(this.dtpPeriodStart, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpPeriodEnd, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(84, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(459, 24);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // dtpPeriodStart
            // 
            this.dtpPeriodStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPeriodStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodStart.Location = new System.Drawing.Point(135, 0);
            this.dtpPeriodStart.Margin = new System.Windows.Forms.Padding(0);
            this.dtpPeriodStart.Name = "dtpPeriodStart";
            this.dtpPeriodStart.Size = new System.Drawing.Size(135, 22);
            this.dtpPeriodStart.TabIndex = 0;
            // 
            // dtpPeriodEnd
            // 
            this.dtpPeriodEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPeriodEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodEnd.Location = new System.Drawing.Point(297, 0);
            this.dtpPeriodEnd.Margin = new System.Windows.Forms.Padding(0);
            this.dtpPeriodEnd.Name = "dtpPeriodEnd";
            this.dtpPeriodEnd.Size = new System.Drawing.Size(135, 22);
            this.dtpPeriodEnd.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Controls.Add(this.dtpTimeStart, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpTimeEnd, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkMinusOneDay, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(84, 68);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(459, 24);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeStart.Location = new System.Drawing.Point(135, 0);
            this.dtpTimeStart.Margin = new System.Windows.Forms.Padding(0);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.Size = new System.Drawing.Size(135, 22);
            this.dtpTimeStart.TabIndex = 0;
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeEnd.Location = new System.Drawing.Point(297, 0);
            this.dtpTimeEnd.Margin = new System.Windows.Forms.Padding(0);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.Size = new System.Drawing.Size(135, 22);
            this.dtpTimeEnd.TabIndex = 1;
            // 
            // chkMinusOneDay
            // 
            this.chkMinusOneDay.AutoSize = true;
            this.chkMinusOneDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMinusOneDay.Location = new System.Drawing.Point(51, 0);
            this.chkMinusOneDay.Margin = new System.Windows.Forms.Padding(0);
            this.chkMinusOneDay.Name = "chkMinusOneDay";
            this.chkMinusOneDay.Size = new System.Drawing.Size(84, 24);
            this.chkMinusOneDay.TabIndex = 2;
            this.chkMinusOneDay.Text = "-1 day";
            this.chkMinusOneDay.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel4.Controls.Add(this.cheTh, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkFr, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkSa, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkSu, 6, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(80, 32);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(467, 32);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // chkMo
            // 
            this.chkMo.AutoSize = true;
            this.chkMo.Checked = true;
            this.chkMo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMo.Location = new System.Drawing.Point(4, 4);
            this.chkMo.Margin = new System.Windows.Forms.Padding(4);
            this.chkMo.Name = "chkMo";
            this.chkMo.Size = new System.Drawing.Size(58, 24);
            this.chkMo.TabIndex = 0;
            this.chkMo.Text = "Mo";
            this.chkMo.UseVisualStyleBackColor = true;
            // 
            // chkTu
            // 
            this.chkTu.AutoSize = true;
            this.chkTu.Checked = true;
            this.chkTu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTu.Location = new System.Drawing.Point(70, 4);
            this.chkTu.Margin = new System.Windows.Forms.Padding(4);
            this.chkTu.Name = "chkTu";
            this.chkTu.Size = new System.Drawing.Size(58, 24);
            this.chkTu.TabIndex = 1;
            this.chkTu.Text = "Tu";
            this.chkTu.UseVisualStyleBackColor = true;
            // 
            // chkWe
            // 
            this.chkWe.AutoSize = true;
            this.chkWe.Checked = true;
            this.chkWe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWe.Location = new System.Drawing.Point(136, 4);
            this.chkWe.Margin = new System.Windows.Forms.Padding(4);
            this.chkWe.Name = "chkWe";
            this.chkWe.Size = new System.Drawing.Size(58, 24);
            this.chkWe.TabIndex = 2;
            this.chkWe.Text = "We";
            this.chkWe.UseVisualStyleBackColor = true;
            // 
            // cheTh
            // 
            this.cheTh.AutoSize = true;
            this.cheTh.Checked = true;
            this.cheTh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cheTh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cheTh.Location = new System.Drawing.Point(202, 4);
            this.cheTh.Margin = new System.Windows.Forms.Padding(4);
            this.cheTh.Name = "cheTh";
            this.cheTh.Size = new System.Drawing.Size(58, 24);
            this.cheTh.TabIndex = 3;
            this.cheTh.Text = "Th";
            this.cheTh.UseVisualStyleBackColor = true;
            // 
            // chkFr
            // 
            this.chkFr.AutoSize = true;
            this.chkFr.Checked = true;
            this.chkFr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFr.Location = new System.Drawing.Point(268, 4);
            this.chkFr.Margin = new System.Windows.Forms.Padding(4);
            this.chkFr.Name = "chkFr";
            this.chkFr.Size = new System.Drawing.Size(58, 24);
            this.chkFr.TabIndex = 4;
            this.chkFr.Text = "Fr";
            this.chkFr.UseVisualStyleBackColor = true;
            // 
            // chkSa
            // 
            this.chkSa.AutoSize = true;
            this.chkSa.Checked = true;
            this.chkSa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSa.Location = new System.Drawing.Point(334, 4);
            this.chkSa.Margin = new System.Windows.Forms.Padding(4);
            this.chkSa.Name = "chkSa";
            this.chkSa.Size = new System.Drawing.Size(58, 24);
            this.chkSa.TabIndex = 5;
            this.chkSa.Text = "Sa";
            this.chkSa.UseVisualStyleBackColor = true;
            // 
            // chkSu
            // 
            this.chkSu.AutoSize = true;
            this.chkSu.Checked = true;
            this.chkSu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSu.Location = new System.Drawing.Point(400, 4);
            this.chkSu.Margin = new System.Windows.Forms.Padding(4);
            this.chkSu.Name = "chkSu";
            this.chkSu.Size = new System.Drawing.Size(63, 24);
            this.chkSu.TabIndex = 6;
            this.chkSu.Text = "Su";
            this.chkSu.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btnAdd, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(80, 96);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(467, 33);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(391, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 25);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmAddSleepSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 129);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddSleepSchedule";
            this.Text = "LifeGame - Add Sleep Schedule";
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox chkMo;
        private System.Windows.Forms.CheckBox chkTu;
        private System.Windows.Forms.CheckBox chkWe;
        private System.Windows.Forms.CheckBox cheTh;
        private System.Windows.Forms.CheckBox chkFr;
        private System.Windows.Forms.CheckBox chkSa;
        private System.Windows.Forms.CheckBox chkSu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkMinusOneDay;
    }
}