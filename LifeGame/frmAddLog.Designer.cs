namespace LifeGame
{
    partial class frmAddLog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.chkPlusOneDay = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cbxTask = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLog, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxTask, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 104);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Period";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Task";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 8;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.Controls.Add(this.cbxColor, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtPercent, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnAdd, 7, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(64, 78);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(346, 26);
            this.tableLayoutPanel5.TabIndex = 11;
            // 
            // cbxColor
            // 
            this.cbxColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxColor.FormattingEnabled = true;
            this.cbxColor.Items.AddRange(new object[] {
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Cyan",
            "Blue",
            "Purple",
            "Brown",
            "Gray"});
            this.cbxColor.Location = new System.Drawing.Point(212, 3);
            this.cbxColor.Name = "cbxColor";
            this.cbxColor.Size = new System.Drawing.Size(61, 21);
            this.cbxColor.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(40, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "percent";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(161, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "Color";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(139, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "%";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPercent
            // 
            this.txtPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPercent.Location = new System.Drawing.Point(104, 3);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(29, 20);
            this.txtPercent.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(289, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 20);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(67, 29);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(340, 20);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeStart.Location = new System.Drawing.Point(43, 0);
            this.dtpTimeStart.Margin = new System.Windows.Forms.Padding(0);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.Size = new System.Drawing.Size(101, 20);
            this.dtpTimeStart.TabIndex = 0;
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeEnd.Location = new System.Drawing.Point(164, 0);
            this.dtpTimeEnd.Margin = new System.Windows.Forms.Padding(0);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.Size = new System.Drawing.Size(101, 20);
            this.dtpTimeEnd.TabIndex = 1;
            // 
            // chkPlusOneDay
            // 
            this.chkPlusOneDay.AutoSize = true;
            this.chkPlusOneDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPlusOneDay.Location = new System.Drawing.Point(275, 0);
            this.chkPlusOneDay.Margin = new System.Windows.Forms.Padding(0);
            this.chkPlusOneDay.Name = "chkPlusOneDay";
            this.chkPlusOneDay.Size = new System.Drawing.Size(65, 20);
            this.chkPlusOneDay.TabIndex = 2;
            this.chkPlusOneDay.Text = "+1 day";
            this.chkPlusOneDay.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(67, 3);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(340, 20);
            this.txtLog.TabIndex = 13;
            // 
            // cbxTask
            // 
            this.cbxTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTask.FormattingEnabled = true;
            this.cbxTask.Location = new System.Drawing.Point(67, 55);
            this.cbxTask.Name = "cbxTask";
            this.cbxTask.Size = new System.Drawing.Size(340, 21);
            this.cbxTask.TabIndex = 14;
            // 
            // frmAddLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 104);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAddLog";
            this.Text = "Add Log";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.CheckBox chkPlusOneDay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ComboBox cbxColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ComboBox cbxTask;
    }
}