﻿namespace LifeGame
{
    partial class frmDaily
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
            this.mnsDaily = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stsDaily = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpToday = new System.Windows.Forms.DateTimePicker();
            this.btnPreDay = new System.Windows.Forms.Button();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvMedicine = new System.Windows.Forms.DataGridView();
            this.colMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicineTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicineQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicineUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMedicine = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddMedicine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteMedicine = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colVoucherSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherDebitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherDebitCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherCreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherCreditCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsFinancial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddFinancial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteFinancial = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.colScheduleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScheduleLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScheduleWith = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScheduleMinusOneDay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colScheduleStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScheduleEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSchedulePlusOneDay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colScheduleTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsSchedule = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmConvertToLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAddSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.colLogName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogWithWho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogMinusOneDay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLogStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogPlusOneDay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLogTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteLog = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.chkLogSleepMinusOneDay = new System.Windows.Forms.CheckBox();
            this.chkScheduleSleepMinusOneDay = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvWorkOutSchedule = new System.Windows.Forms.DataGridView();
            this.colWorkOutType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkOutQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkOutUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsWorkOutSchedule = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.convertToLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsWorkOutLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddWorkOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteWorkOut = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvEvent = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.picSchedule = new System.Windows.Forms.PictureBox();
            this.picLog = new System.Windows.Forms.PictureBox();
            this.lblScheduleSleepTime = new System.Windows.Forms.Label();
            this.lblLogSleepTime = new System.Windows.Forms.Label();
            this.lblScheduleSleepGoToBedTime = new System.Windows.Forms.Label();
            this.lblScheduleSleepGetUpTime = new System.Windows.Forms.Label();
            this.lblLogSleepGoToBedTime = new System.Windows.Forms.Label();
            this.lblLogSleepGetUpTime = new System.Windows.Forms.Label();
            this.colEventIsSucceed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsSleep = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddScheduleSleep = new System.Windows.Forms.ToolStripMenuItem();
            this.addLogSleep = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsDaily.SuspendLayout();
            this.stsDaily.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).BeginInit();
            this.cmsMedicine.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsFinancial.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.cmsSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.cmsLog.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOutSchedule)).BeginInit();
            this.cmsWorkOutSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.cmsWorkOutLog.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).BeginInit();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLog)).BeginInit();
            this.cmsSleep.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsDaily
            // 
            this.mnsDaily.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsDaily.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.mnsDaily.Location = new System.Drawing.Point(0, 0);
            this.mnsDaily.Name = "mnsDaily";
            this.mnsDaily.Size = new System.Drawing.Size(810, 24);
            this.mnsDaily.TabIndex = 0;
            this.mnsDaily.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // stsDaily
            // 
            this.stsDaily.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsDaily.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.stsDaily.Location = new System.Drawing.Point(0, 823);
            this.stsDaily.Name = "stsDaily";
            this.stsDaily.Size = new System.Drawing.Size(810, 22);
            this.stsDaily.TabIndex = 1;
            this.stsDaily.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "Version: 0.0.0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 799);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.dtpToday, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnPreDay, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnNextDay, 3, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(804, 25);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // dtpToday
            // 
            this.dtpToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpToday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToday.Location = new System.Drawing.Point(686, 3);
            this.dtpToday.Name = "dtpToday";
            this.dtpToday.Size = new System.Drawing.Size(95, 20);
            this.dtpToday.TabIndex = 0;
            // 
            // btnPreDay
            // 
            this.btnPreDay.Location = new System.Drawing.Point(666, 3);
            this.btnPreDay.Name = "btnPreDay";
            this.btnPreDay.Size = new System.Drawing.Size(14, 18);
            this.btnPreDay.TabIndex = 1;
            this.btnPreDay.Text = "<";
            this.btnPreDay.UseVisualStyleBackColor = true;
            // 
            // btnNextDay
            // 
            this.btnNextDay.Location = new System.Drawing.Point(787, 3);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(14, 18);
            this.btnNextDay.TabIndex = 2;
            this.btnNextDay.Text = ">";
            this.btnNextDay.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvMedicine);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(2, 723);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(806, 74);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Medicine";
            // 
            // dgvMedicine
            // 
            this.dgvMedicine.AllowUserToAddRows = false;
            this.dgvMedicine.AllowUserToDeleteRows = false;
            this.dgvMedicine.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMedicine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMedicineName,
            this.colMedicineTime,
            this.colMedicineQty,
            this.colMedicineUnit});
            this.dgvMedicine.ContextMenuStrip = this.cmsMedicine;
            this.dgvMedicine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicine.Location = new System.Drawing.Point(2, 15);
            this.dgvMedicine.Name = "dgvMedicine";
            this.dgvMedicine.ReadOnly = true;
            this.dgvMedicine.Size = new System.Drawing.Size(802, 57);
            this.dgvMedicine.TabIndex = 4;
            // 
            // colMedicineName
            // 
            this.colMedicineName.HeaderText = "Medicine Name";
            this.colMedicineName.Name = "colMedicineName";
            this.colMedicineName.ReadOnly = true;
            this.colMedicineName.Width = 200;
            // 
            // colMedicineTime
            // 
            this.colMedicineTime.HeaderText = "Taken Time";
            this.colMedicineTime.Name = "colMedicineTime";
            this.colMedicineTime.ReadOnly = true;
            this.colMedicineTime.Width = 200;
            // 
            // colMedicineQty
            // 
            this.colMedicineQty.HeaderText = "Qty";
            this.colMedicineQty.Name = "colMedicineQty";
            this.colMedicineQty.ReadOnly = true;
            // 
            // colMedicineUnit
            // 
            this.colMedicineUnit.HeaderText = "Unit";
            this.colMedicineUnit.Name = "colMedicineUnit";
            this.colMedicineUnit.ReadOnly = true;
            // 
            // cmsMedicine
            // 
            this.cmsMedicine.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMedicine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddMedicine,
            this.tsmDeleteMedicine});
            this.cmsMedicine.Name = "cmsMedicine";
            this.cmsMedicine.Size = new System.Drawing.Size(108, 48);
            // 
            // tsmAddMedicine
            // 
            this.tsmAddMedicine.Name = "tsmAddMedicine";
            this.tsmAddMedicine.Size = new System.Drawing.Size(107, 22);
            this.tsmAddMedicine.Text = "Add";
            // 
            // tsmDeleteMedicine
            // 
            this.tsmDeleteMedicine.Name = "tsmDeleteMedicine";
            this.tsmDeleteMedicine.Size = new System.Drawing.Size(107, 22);
            this.tsmDeleteMedicine.Text = "Delete";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 571);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(804, 147);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Financial";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVoucherSummary,
            this.colVoucherTask,
            this.colVoucherDebit,
            this.colVoucherDebitAmount,
            this.colVoucherDebitCurrency,
            this.colVoucherCredit,
            this.colVoucherCreditAmount,
            this.colVoucherCreditCurrency});
            this.dataGridView1.ContextMenuStrip = this.cmsFinancial;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(798, 128);
            this.dataGridView1.TabIndex = 0;
            // 
            // colVoucherSummary
            // 
            this.colVoucherSummary.HeaderText = "Summary";
            this.colVoucherSummary.Name = "colVoucherSummary";
            this.colVoucherSummary.ReadOnly = true;
            // 
            // colVoucherTask
            // 
            this.colVoucherTask.HeaderText = "Task";
            this.colVoucherTask.Name = "colVoucherTask";
            this.colVoucherTask.ReadOnly = true;
            // 
            // colVoucherDebit
            // 
            this.colVoucherDebit.HeaderText = "Debit";
            this.colVoucherDebit.Name = "colVoucherDebit";
            this.colVoucherDebit.ReadOnly = true;
            // 
            // colVoucherDebitAmount
            // 
            this.colVoucherDebitAmount.HeaderText = "Amount";
            this.colVoucherDebitAmount.Name = "colVoucherDebitAmount";
            this.colVoucherDebitAmount.ReadOnly = true;
            // 
            // colVoucherDebitCurrency
            // 
            this.colVoucherDebitCurrency.HeaderText = "Currency";
            this.colVoucherDebitCurrency.Name = "colVoucherDebitCurrency";
            this.colVoucherDebitCurrency.ReadOnly = true;
            // 
            // colVoucherCredit
            // 
            this.colVoucherCredit.HeaderText = "Credit";
            this.colVoucherCredit.Name = "colVoucherCredit";
            this.colVoucherCredit.ReadOnly = true;
            // 
            // colVoucherCreditAmount
            // 
            this.colVoucherCreditAmount.HeaderText = "Amount";
            this.colVoucherCreditAmount.Name = "colVoucherCreditAmount";
            this.colVoucherCreditAmount.ReadOnly = true;
            // 
            // colVoucherCreditCurrency
            // 
            this.colVoucherCreditCurrency.HeaderText = "Currency";
            this.colVoucherCreditCurrency.Name = "colVoucherCreditCurrency";
            this.colVoucherCreditCurrency.ReadOnly = true;
            // 
            // cmsFinancial
            // 
            this.cmsFinancial.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFinancial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddFinancial,
            this.tsmDeleteFinancial});
            this.cmsFinancial.Name = "cmsFinancial";
            this.cmsFinancial.Size = new System.Drawing.Size(108, 48);
            // 
            // tsmAddFinancial
            // 
            this.tsmAddFinancial.Name = "tsmAddFinancial";
            this.tsmAddFinancial.Size = new System.Drawing.Size(107, 22);
            this.tsmAddFinancial.Text = "Add";
            // 
            // tsmDeleteFinancial
            // 
            this.tsmDeleteFinancial.Name = "tsmDeleteFinancial";
            this.tsmDeleteFinancial.Size = new System.Drawing.Size(107, 22);
            this.tsmDeleteFinancial.Text = "Delete";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.4578F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.54221F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel10, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(810, 537);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(165, 0);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(645, 537);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 287);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedule and Log";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.dgvSchedule, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.dgvLog, 0, 2);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(633, 268);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(627, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "↓";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScheduleName,
            this.colScheduleLocation,
            this.colScheduleWith,
            this.colScheduleMinusOneDay,
            this.colScheduleStartTime,
            this.colScheduleEndTime,
            this.colSchedulePlusOneDay,
            this.colScheduleTask});
            this.dgvSchedule.ContextMenuStrip = this.cmsSchedule;
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.Location = new System.Drawing.Point(3, 3);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.Size = new System.Drawing.Size(627, 119);
            this.dgvSchedule.TabIndex = 3;
            // 
            // colScheduleName
            // 
            this.colScheduleName.HeaderText = "Schedule";
            this.colScheduleName.Name = "colScheduleName";
            this.colScheduleName.ReadOnly = true;
            // 
            // colScheduleLocation
            // 
            this.colScheduleLocation.HeaderText = "Location";
            this.colScheduleLocation.Name = "colScheduleLocation";
            this.colScheduleLocation.ReadOnly = true;
            // 
            // colScheduleWith
            // 
            this.colScheduleWith.HeaderText = "With";
            this.colScheduleWith.Name = "colScheduleWith";
            this.colScheduleWith.ReadOnly = true;
            // 
            // colScheduleMinusOneDay
            // 
            this.colScheduleMinusOneDay.HeaderText = "-1d";
            this.colScheduleMinusOneDay.Name = "colScheduleMinusOneDay";
            this.colScheduleMinusOneDay.ReadOnly = true;
            this.colScheduleMinusOneDay.Width = 40;
            // 
            // colScheduleStartTime
            // 
            this.colScheduleStartTime.HeaderText = "Start Time";
            this.colScheduleStartTime.Name = "colScheduleStartTime";
            this.colScheduleStartTime.ReadOnly = true;
            // 
            // colScheduleEndTime
            // 
            this.colScheduleEndTime.HeaderText = "EndTime";
            this.colScheduleEndTime.Name = "colScheduleEndTime";
            this.colScheduleEndTime.ReadOnly = true;
            // 
            // colSchedulePlusOneDay
            // 
            this.colSchedulePlusOneDay.HeaderText = "+1d";
            this.colSchedulePlusOneDay.Name = "colSchedulePlusOneDay";
            this.colSchedulePlusOneDay.ReadOnly = true;
            this.colSchedulePlusOneDay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSchedulePlusOneDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSchedulePlusOneDay.Width = 40;
            // 
            // colScheduleTask
            // 
            this.colScheduleTask.HeaderText = "Task";
            this.colScheduleTask.Name = "colScheduleTask";
            this.colScheduleTask.ReadOnly = true;
            // 
            // cmsSchedule
            // 
            this.cmsSchedule.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConvertToLog,
            this.toolStripSeparator1,
            this.tsmAddSchedule,
            this.tsmDeleteSchedule});
            this.cmsSchedule.Name = "cmsSchedule";
            this.cmsSchedule.Size = new System.Drawing.Size(181, 98);
            // 
            // tsmConvertToLog
            // 
            this.tsmConvertToLog.Name = "tsmConvertToLog";
            this.tsmConvertToLog.Size = new System.Drawing.Size(180, 22);
            this.tsmConvertToLog.Text = "Convert To Log";
            this.tsmConvertToLog.Click += new System.EventHandler(this.tsmConvertToLog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // tsmAddSchedule
            // 
            this.tsmAddSchedule.Name = "tsmAddSchedule";
            this.tsmAddSchedule.Size = new System.Drawing.Size(180, 22);
            this.tsmAddSchedule.Text = "Add";
            this.tsmAddSchedule.Click += new System.EventHandler(this.tsmAddSchedule_Click);
            // 
            // tsmDeleteSchedule
            // 
            this.tsmDeleteSchedule.Name = "tsmDeleteSchedule";
            this.tsmDeleteSchedule.Size = new System.Drawing.Size(180, 22);
            this.tsmDeleteSchedule.Text = "Delete";
            this.tsmDeleteSchedule.Click += new System.EventHandler(this.tsmDeleteSchedule_Click);
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLogName,
            this.colLogLocation,
            this.colLogWithWho,
            this.colLogMinusOneDay,
            this.colLogStartTime,
            this.colLogEndTime,
            this.colLogPlusOneDay,
            this.colLogTask});
            this.dgvLog.ContextMenuStrip = this.cmsLog;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(3, 146);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.Size = new System.Drawing.Size(627, 119);
            this.dgvLog.TabIndex = 4;
            // 
            // colLogName
            // 
            this.colLogName.HeaderText = "Log";
            this.colLogName.Name = "colLogName";
            this.colLogName.ReadOnly = true;
            // 
            // colLogLocation
            // 
            this.colLogLocation.HeaderText = "Location";
            this.colLogLocation.Name = "colLogLocation";
            this.colLogLocation.ReadOnly = true;
            // 
            // colLogWithWho
            // 
            this.colLogWithWho.HeaderText = "With";
            this.colLogWithWho.Name = "colLogWithWho";
            this.colLogWithWho.ReadOnly = true;
            // 
            // colLogMinusOneDay
            // 
            this.colLogMinusOneDay.HeaderText = "-1d";
            this.colLogMinusOneDay.Name = "colLogMinusOneDay";
            this.colLogMinusOneDay.ReadOnly = true;
            this.colLogMinusOneDay.Width = 40;
            // 
            // colLogStartTime
            // 
            this.colLogStartTime.HeaderText = "Start Time";
            this.colLogStartTime.Name = "colLogStartTime";
            this.colLogStartTime.ReadOnly = true;
            // 
            // colLogEndTime
            // 
            this.colLogEndTime.HeaderText = "End Time";
            this.colLogEndTime.Name = "colLogEndTime";
            this.colLogEndTime.ReadOnly = true;
            // 
            // colLogPlusOneDay
            // 
            this.colLogPlusOneDay.HeaderText = "+1d";
            this.colLogPlusOneDay.Name = "colLogPlusOneDay";
            this.colLogPlusOneDay.ReadOnly = true;
            this.colLogPlusOneDay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLogPlusOneDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLogPlusOneDay.Width = 40;
            // 
            // colLogTask
            // 
            this.colLogTask.HeaderText = "Task";
            this.colLogTask.Name = "colLogTask";
            this.colLogTask.ReadOnly = true;
            // 
            // cmsLog
            // 
            this.cmsLog.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddLog,
            this.tsmDeleteLog});
            this.cmsLog.Name = "cmsLog";
            this.cmsLog.Size = new System.Drawing.Size(108, 48);
            // 
            // tsmAddLog
            // 
            this.tsmAddLog.Name = "tsmAddLog";
            this.tsmAddLog.Size = new System.Drawing.Size(107, 22);
            this.tsmAddLog.Text = "Add";
            this.tsmAddLog.Click += new System.EventHandler(this.tsmAddLog_Click);
            // 
            // tsmDeleteLog
            // 
            this.tsmDeleteLog.Name = "tsmDeleteLog";
            this.tsmDeleteLog.Size = new System.Drawing.Size(107, 22);
            this.tsmDeleteLog.Text = "Delete";
            this.tsmDeleteLog.Click += new System.EventHandler(this.tsmDeleteLog_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.ContextMenuStrip = this.cmsSleep;
            this.groupBox4.Controls.Add(this.tableLayoutPanel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(2, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(641, 64);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sleep";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label20, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkLogSleepMinusOneDay, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkScheduleSleepMinusOneDay, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScheduleSleepTime, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLogSleepTime, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScheduleSleepGoToBedTime, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblScheduleSleepGetUpTime, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLogSleepGoToBedTime, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblLogSleepGetUpTime, 4, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(637, 47);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(527, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "total";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(404, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(9, 24);
            this.label20.TabIndex = 3;
            this.label20.Text = "-";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkLogSleepMinusOneDay
            // 
            this.chkLogSleepMinusOneDay.AutoSize = true;
            this.chkLogSleepMinusOneDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLogSleepMinusOneDay.Enabled = false;
            this.chkLogSleepMinusOneDay.Location = new System.Drawing.Point(247, 26);
            this.chkLogSleepMinusOneDay.Name = "chkLogSleepMinusOneDay";
            this.chkLogSleepMinusOneDay.Size = new System.Drawing.Size(43, 18);
            this.chkLogSleepMinusOneDay.TabIndex = 0;
            this.chkLogSleepMinusOneDay.Text = "-1d";
            this.chkLogSleepMinusOneDay.UseVisualStyleBackColor = true;
            // 
            // chkScheduleSleepMinusOneDay
            // 
            this.chkScheduleSleepMinusOneDay.AutoSize = true;
            this.chkScheduleSleepMinusOneDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkScheduleSleepMinusOneDay.Enabled = false;
            this.chkScheduleSleepMinusOneDay.Location = new System.Drawing.Point(247, 3);
            this.chkScheduleSleepMinusOneDay.Name = "chkScheduleSleepMinusOneDay";
            this.chkScheduleSleepMinusOneDay.Size = new System.Drawing.Size(43, 17);
            this.chkScheduleSleepMinusOneDay.TabIndex = 6;
            this.chkScheduleSleepMinusOneDay.Text = "-1d";
            this.chkScheduleSleepMinusOneDay.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(404, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(9, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(527, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(2, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Schedule";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(2, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 24);
            this.label8.TabIndex = 14;
            this.label8.Text = "Log";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 170);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Work Out";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.dgvWorkOutSchedule, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.dataGridView2, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label11, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(633, 151);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // dgvWorkOutSchedule
            // 
            this.dgvWorkOutSchedule.AllowUserToAddRows = false;
            this.dgvWorkOutSchedule.AllowUserToDeleteRows = false;
            this.dgvWorkOutSchedule.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvWorkOutSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWorkOutSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOutSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkOutType,
            this.colWorkOutQty,
            this.colWorkOutUnit});
            this.dgvWorkOutSchedule.ContextMenuStrip = this.cmsWorkOutSchedule;
            this.dgvWorkOutSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkOutSchedule.Location = new System.Drawing.Point(3, 24);
            this.dgvWorkOutSchedule.Name = "dgvWorkOutSchedule";
            this.dgvWorkOutSchedule.Size = new System.Drawing.Size(303, 124);
            this.dgvWorkOutSchedule.TabIndex = 6;
            // 
            // colWorkOutType
            // 
            this.colWorkOutType.HeaderText = "Type";
            this.colWorkOutType.Name = "colWorkOutType";
            // 
            // colWorkOutQty
            // 
            this.colWorkOutQty.HeaderText = "Qty";
            this.colWorkOutQty.Name = "colWorkOutQty";
            // 
            // colWorkOutUnit
            // 
            this.colWorkOutUnit.HeaderText = "Unit";
            this.colWorkOutUnit.Name = "colWorkOutUnit";
            // 
            // cmsWorkOutSchedule
            // 
            this.cmsWorkOutSchedule.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsWorkOutSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.addScheduleToolStripMenuItem,
            this.addLogToolStripMenuItem});
            this.cmsWorkOutSchedule.Name = "cmsWorkOutSchedule";
            this.cmsWorkOutSchedule.Size = new System.Drawing.Size(156, 76);
            // 
            // convertToLogToolStripMenuItem
            // 
            this.convertToLogToolStripMenuItem.Name = "convertToLogToolStripMenuItem";
            this.convertToLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.convertToLogToolStripMenuItem.Text = "Convert To Log";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // addScheduleToolStripMenuItem
            // 
            this.addScheduleToolStripMenuItem.Name = "addScheduleToolStripMenuItem";
            this.addScheduleToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addScheduleToolStripMenuItem.Text = "Add";
            // 
            // addLogToolStripMenuItem
            // 
            this.addLogToolStripMenuItem.Name = "addLogToolStripMenuItem";
            this.addLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addLogToolStripMenuItem.Text = "Delete";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView2.ContextMenuStrip = this.cmsWorkOutLog;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(327, 24);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(303, 124);
            this.dataGridView2.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // cmsWorkOutLog
            // 
            this.cmsWorkOutLog.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsWorkOutLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddWorkOut,
            this.tsmDeleteWorkOut});
            this.cmsWorkOutLog.Name = "cmsWorkOut";
            this.cmsWorkOutLog.Size = new System.Drawing.Size(108, 48);
            // 
            // tsmAddWorkOut
            // 
            this.tsmAddWorkOut.Name = "tsmAddWorkOut";
            this.tsmAddWorkOut.Size = new System.Drawing.Size(107, 22);
            this.tsmAddWorkOut.Text = "Add";
            // 
            // tsmDeleteWorkOut
            // 
            this.tsmDeleteWorkOut.Name = "tsmDeleteWorkOut";
            this.tsmDeleteWorkOut.Size = new System.Drawing.Size(107, 22);
            this.tsmDeleteWorkOut.Text = "Delete";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(2, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(305, 21);
            this.label9.TabIndex = 8;
            this.label9.Text = "Schedule";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(326, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(305, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "Log";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(311, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 130);
            this.label11.TabIndex = 10;
            this.label11.Text = "→";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox6, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.65363F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.34637F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(165, 537);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvEvent);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 420);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(159, 114);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Event";
            // 
            // dgvEvent
            // 
            this.dgvEvent.AllowUserToAddRows = false;
            this.dgvEvent.AllowUserToDeleteRows = false;
            this.dgvEvent.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEventIsSucceed,
            this.colEventName});
            this.dgvEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvent.Location = new System.Drawing.Point(3, 16);
            this.dgvEvent.Name = "dgvEvent";
            this.dgvEvent.ReadOnly = true;
            this.dgvEvent.Size = new System.Drawing.Size(153, 95);
            this.dgvEvent.TabIndex = 0;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(159, 411);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.picSchedule, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(73, 405);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schedule";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.picLog, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(82, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(74, 405);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Log";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picSchedule
            // 
            this.picSchedule.BackColor = System.Drawing.Color.White;
            this.picSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSchedule.Location = new System.Drawing.Point(3, 29);
            this.picSchedule.Name = "picSchedule";
            this.picSchedule.Size = new System.Drawing.Size(67, 373);
            this.picSchedule.TabIndex = 1;
            this.picSchedule.TabStop = false;
            // 
            // picLog
            // 
            this.picLog.BackColor = System.Drawing.Color.White;
            this.picLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLog.Location = new System.Drawing.Point(3, 29);
            this.picLog.Name = "picLog";
            this.picLog.Size = new System.Drawing.Size(68, 373);
            this.picLog.TabIndex = 1;
            this.picLog.TabStop = false;
            // 
            // lblScheduleSleepTime
            // 
            this.lblScheduleSleepTime.AutoSize = true;
            this.lblScheduleSleepTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScheduleSleepTime.Location = new System.Drawing.Point(560, 0);
            this.lblScheduleSleepTime.Name = "lblScheduleSleepTime";
            this.lblScheduleSleepTime.Size = new System.Drawing.Size(74, 23);
            this.lblScheduleSleepTime.TabIndex = 15;
            this.lblScheduleSleepTime.Text = "---";
            this.lblScheduleSleepTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogSleepTime
            // 
            this.lblLogSleepTime.AutoSize = true;
            this.lblLogSleepTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogSleepTime.Location = new System.Drawing.Point(560, 23);
            this.lblLogSleepTime.Name = "lblLogSleepTime";
            this.lblLogSleepTime.Size = new System.Drawing.Size(74, 24);
            this.lblLogSleepTime.TabIndex = 16;
            this.lblLogSleepTime.Text = "---";
            this.lblLogSleepTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScheduleSleepGoToBedTime
            // 
            this.lblScheduleSleepGoToBedTime.AutoSize = true;
            this.lblScheduleSleepGoToBedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScheduleSleepGoToBedTime.Location = new System.Drawing.Point(296, 0);
            this.lblScheduleSleepGoToBedTime.Name = "lblScheduleSleepGoToBedTime";
            this.lblScheduleSleepGoToBedTime.Size = new System.Drawing.Size(102, 23);
            this.lblScheduleSleepGoToBedTime.TabIndex = 17;
            this.lblScheduleSleepGoToBedTime.Text = "---";
            this.lblScheduleSleepGoToBedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScheduleSleepGetUpTime
            // 
            this.lblScheduleSleepGetUpTime.AutoSize = true;
            this.lblScheduleSleepGetUpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScheduleSleepGetUpTime.Location = new System.Drawing.Point(419, 0);
            this.lblScheduleSleepGetUpTime.Name = "lblScheduleSleepGetUpTime";
            this.lblScheduleSleepGetUpTime.Size = new System.Drawing.Size(102, 23);
            this.lblScheduleSleepGetUpTime.TabIndex = 18;
            this.lblScheduleSleepGetUpTime.Text = "---";
            this.lblScheduleSleepGetUpTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogSleepGoToBedTime
            // 
            this.lblLogSleepGoToBedTime.AutoSize = true;
            this.lblLogSleepGoToBedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogSleepGoToBedTime.Location = new System.Drawing.Point(296, 23);
            this.lblLogSleepGoToBedTime.Name = "lblLogSleepGoToBedTime";
            this.lblLogSleepGoToBedTime.Size = new System.Drawing.Size(102, 24);
            this.lblLogSleepGoToBedTime.TabIndex = 19;
            this.lblLogSleepGoToBedTime.Text = "---";
            this.lblLogSleepGoToBedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogSleepGetUpTime
            // 
            this.lblLogSleepGetUpTime.AutoSize = true;
            this.lblLogSleepGetUpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogSleepGetUpTime.Location = new System.Drawing.Point(419, 23);
            this.lblLogSleepGetUpTime.Name = "lblLogSleepGetUpTime";
            this.lblLogSleepGetUpTime.Size = new System.Drawing.Size(102, 24);
            this.lblLogSleepGetUpTime.TabIndex = 20;
            this.lblLogSleepGetUpTime.Text = "---";
            this.lblLogSleepGetUpTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colEventIsSucceed
            // 
            this.colEventIsSucceed.HeaderText = "√";
            this.colEventIsSucceed.Name = "colEventIsSucceed";
            this.colEventIsSucceed.ReadOnly = true;
            this.colEventIsSucceed.Width = 40;
            // 
            // colEventName
            // 
            this.colEventName.HeaderText = "Event Name";
            this.colEventName.Name = "colEventName";
            this.colEventName.ReadOnly = true;
            // 
            // cmsSleep
            // 
            this.cmsSleep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddScheduleSleep,
            this.addLogSleep});
            this.cmsSleep.Name = "cmsSleep";
            this.cmsSleep.Size = new System.Drawing.Size(204, 48);
            // 
            // tsmAddScheduleSleep
            // 
            this.tsmAddScheduleSleep.Name = "tsmAddScheduleSleep";
            this.tsmAddScheduleSleep.Size = new System.Drawing.Size(203, 22);
            this.tsmAddScheduleSleep.Text = "Add/Edit Schedule Sleep";
            this.tsmAddScheduleSleep.Click += new System.EventHandler(this.tsmAddScheduleSleep_Click);
            // 
            // addLogSleep
            // 
            this.addLogSleep.Name = "addLogSleep";
            this.addLogSleep.Size = new System.Drawing.Size(203, 22);
            this.addLogSleep.Text = "Add/Edit Log Sleep";
            this.addLogSleep.Click += new System.EventHandler(this.addLogSleep_Click);
            // 
            // frmDaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 845);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.stsDaily);
            this.Controls.Add(this.mnsDaily);
            this.MainMenuStrip = this.mnsDaily;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDaily";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDaily_Load);
            this.mnsDaily.ResumeLayout(false);
            this.mnsDaily.PerformLayout();
            this.stsDaily.ResumeLayout(false);
            this.stsDaily.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).EndInit();
            this.cmsMedicine.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsFinancial.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.cmsSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.cmsLog.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOutSchedule)).EndInit();
            this.cmsWorkOutSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.cmsWorkOutLog.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).EndInit();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLog)).EndInit();
            this.cmsSleep.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsDaily;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stsDaily;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvMedicine;
        private System.Windows.Forms.CheckBox chkLogSleepMinusOneDay;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpToday;
        private System.Windows.Forms.Button btnPreDay;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.ContextMenuStrip cmsSchedule;
        private System.Windows.Forms.ToolStripMenuItem tsmConvertToLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmAddSchedule;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteSchedule;
        private System.Windows.Forms.ContextMenuStrip cmsLog;
        private System.Windows.Forms.ToolStripMenuItem tsmAddLog;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteLog;
        private System.Windows.Forms.ContextMenuStrip cmsWorkOutLog;
        private System.Windows.Forms.ToolStripMenuItem tsmAddWorkOut;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteWorkOut;
        private System.Windows.Forms.ContextMenuStrip cmsMedicine;
        private System.Windows.Forms.ToolStripMenuItem tsmAddMedicine;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteMedicine;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmsFinancial;
        private System.Windows.Forms.ToolStripMenuItem tsmAddFinancial;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteFinancial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkScheduleSleepMinusOneDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicineTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicineQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicineUnit;
        private System.Windows.Forms.DataGridView dgvWorkOutSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkOutType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkOutQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkOutUnit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleWith;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colScheduleMinusOneDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleEndTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSchedulePlusOneDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogWithWho;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colLogMinusOneDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogEndTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colLogPlusOneDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogTask;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ContextMenuStrip cmsWorkOutSchedule;
        private System.Windows.Forms.ToolStripMenuItem convertToLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLogToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherDebitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherDebitCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherCreditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherCreditCurrency;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvEvent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblScheduleSleepTime;
        private System.Windows.Forms.Label lblLogSleepTime;
        private System.Windows.Forms.Label lblScheduleSleepGoToBedTime;
        private System.Windows.Forms.Label lblScheduleSleepGetUpTime;
        private System.Windows.Forms.Label lblLogSleepGoToBedTime;
        private System.Windows.Forms.Label lblLogSleepGetUpTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventIsSucceed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventName;
        private System.Windows.Forms.ContextMenuStrip cmsSleep;
        private System.Windows.Forms.ToolStripMenuItem tsmAddScheduleSleep;
        private System.Windows.Forms.ToolStripMenuItem addLogSleep;
    }
}