namespace LifeGame
{
    partial class frmTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTask));
            this.stsTask = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnsTask = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trvTask = new System.Windows.Forms.TreeView();
            this.cmsTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBelongTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIndependent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmFinished = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbort = new System.Windows.Forms.ToolStripMenuItem();
            this.iglTask = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkBottom = new System.Windows.Forms.CheckBox();
            this.chkInfinite = new System.Windows.Forms.CheckBox();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.dtpNextTimeMarker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTaskTimeSpent = new System.Windows.Forms.Label();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.chkFinished = new System.Windows.Forms.CheckBox();
            this.stsTask.SuspendLayout();
            this.mnsTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsTask.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsTask
            // 
            this.stsTask.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.stsTask.Location = new System.Drawing.Point(0, 494);
            this.stsTask.Name = "stsTask";
            this.stsTask.Size = new System.Drawing.Size(993, 22);
            this.stsTask.TabIndex = 1;
            this.stsTask.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "Version: 0.0.0";
            // 
            // mnsTask
            // 
            this.mnsTask.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem});
            this.mnsTask.Location = new System.Drawing.Point(0, 0);
            this.mnsTask.Name = "mnsTask";
            this.mnsTask.Size = new System.Drawing.Size(993, 24);
            this.mnsTask.TabIndex = 2;
            this.mnsTask.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLogToolStripMenuItem});
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // addLogToolStripMenuItem
            // 
            this.addLogToolStripMenuItem.Name = "addLogToolStripMenuItem";
            this.addLogToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.addLogToolStripMenuItem.Text = "Add Log";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel7);
            this.splitContainer1.Size = new System.Drawing.Size(993, 470);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(232, 470);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvTask);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 460);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task Tree";
            // 
            // trvTask
            // 
            this.trvTask.BackColor = System.Drawing.SystemColors.Control;
            this.trvTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvTask.ContextMenuStrip = this.cmsTask;
            this.trvTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTask.ImageIndex = 0;
            this.trvTask.ImageList = this.iglTask;
            this.trvTask.Location = new System.Drawing.Point(3, 16);
            this.trvTask.Name = "trvTask";
            this.trvTask.SelectedImageIndex = 0;
            this.trvTask.Size = new System.Drawing.Size(216, 441);
            this.trvTask.TabIndex = 0;
            this.trvTask.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTask_AfterSelect);
            // 
            // cmsTask
            // 
            this.cmsTask.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmRename,
            this.tsmRemove,
            this.toolStripSeparator1,
            this.tsmUp,
            this.tsmDown,
            this.toolStripSeparator2,
            this.tsmBelongTo,
            this.tsmIndependent,
            this.toolStripSeparator3,
            this.tsmFinished,
            this.tsmAbort});
            this.cmsTask.Name = "cmsTask";
            this.cmsTask.Size = new System.Drawing.Size(165, 220);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(164, 22);
            this.tsmAdd.Text = "Add";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmRename
            // 
            this.tsmRename.Name = "tsmRename";
            this.tsmRename.Size = new System.Drawing.Size(164, 22);
            this.tsmRename.Text = "Edit(Rename)";
            this.tsmRename.Click += new System.EventHandler(this.tsmRename_Click);
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(164, 22);
            this.tsmRemove.Text = "Remove";
            this.tsmRemove.Click += new System.EventHandler(this.tsmRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // tsmUp
            // 
            this.tsmUp.Name = "tsmUp";
            this.tsmUp.Size = new System.Drawing.Size(164, 22);
            this.tsmUp.Text = "Up";
            this.tsmUp.Click += new System.EventHandler(this.tsmUp_Click);
            // 
            // tsmDown
            // 
            this.tsmDown.Name = "tsmDown";
            this.tsmDown.Size = new System.Drawing.Size(164, 22);
            this.tsmDown.Text = "Down";
            this.tsmDown.Click += new System.EventHandler(this.tsmDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // tsmBelongTo
            // 
            this.tsmBelongTo.Name = "tsmBelongTo";
            this.tsmBelongTo.Size = new System.Drawing.Size(164, 22);
            this.tsmBelongTo.Text = "Belong To";
            this.tsmBelongTo.Click += new System.EventHandler(this.tsmBelongTo_Click);
            // 
            // tsmIndependent
            // 
            this.tsmIndependent.Name = "tsmIndependent";
            this.tsmIndependent.Size = new System.Drawing.Size(164, 22);
            this.tsmIndependent.Text = "Independent";
            this.tsmIndependent.Click += new System.EventHandler(this.tsmIndependent_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // tsmFinished
            // 
            this.tsmFinished.Name = "tsmFinished";
            this.tsmFinished.Size = new System.Drawing.Size(164, 22);
            this.tsmFinished.Text = "Mark As Finished";
            this.tsmFinished.Click += new System.EventHandler(this.tsmFinished_Click);
            // 
            // tsmAbort
            // 
            this.tsmAbort.Name = "tsmAbort";
            this.tsmAbort.Size = new System.Drawing.Size(164, 22);
            this.tsmAbort.Text = "Mark As Abort";
            this.tsmAbort.Click += new System.EventHandler(this.tsmAbort_Click);
            // 
            // iglTask
            // 
            this.iglTask.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglTask.ImageStream")));
            this.iglTask.TransparentColor = System.Drawing.Color.Transparent;
            this.iglTask.Images.SetKeyName(0, "iconWW.png");
            this.iglTask.Images.SetKeyName(1, "iconUnFinished.png");
            this.iglTask.Images.SetKeyName(2, "iconFinished.png");
            this.iglTask.Images.SetKeyName(3, "iconAbort.png");
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(757, 470);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 460);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task Details";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvLog, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToOrderColumns = true;
            this.dgvLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colYear,
            this.colMonth,
            this.colDay,
            this.colTask,
            this.colLog,
            this.colDuration});
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(3, 65);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowTemplate.Height = 23;
            this.dgvLog.Size = new System.Drawing.Size(735, 373);
            this.dgvLog.TabIndex = 0;
            // 
            // colYear
            // 
            this.colYear.HeaderText = "Year";
            this.colYear.Name = "colYear";
            this.colYear.ReadOnly = true;
            // 
            // colMonth
            // 
            this.colMonth.HeaderText = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.ReadOnly = true;
            // 
            // colDay
            // 
            this.colDay.HeaderText = "Day";
            this.colDay.Name = "colDay";
            this.colDay.ReadOnly = true;
            // 
            // colTask
            // 
            this.colTask.HeaderText = "Task";
            this.colTask.Name = "colTask";
            this.colTask.ReadOnly = true;
            // 
            // colLog
            // 
            this.colLog.HeaderText = "Log";
            this.colLog.Name = "colLog";
            this.colLog.ReadOnly = true;
            // 
            // colDuration
            // 
            this.colDuration.HeaderText = "Duration(h)";
            this.colDuration.Name = "colDuration";
            this.colDuration.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblTaskName, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Enabled = false;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(735, 26);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel3.Controls.Add(this.chkBottom, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkInfinite, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpDeadline, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpNextTimeMarker, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTaskTimeSpent, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkFinished, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(735, 24);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // chkBottom
            // 
            this.chkBottom.AutoSize = true;
            this.chkBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBottom.Enabled = false;
            this.chkBottom.Location = new System.Drawing.Point(3, 3);
            this.chkBottom.Name = "chkBottom";
            this.chkBottom.Size = new System.Drawing.Size(60, 18);
            this.chkBottom.TabIndex = 0;
            this.chkBottom.Text = "Bottom";
            this.chkBottom.UseVisualStyleBackColor = true;
            // 
            // chkInfinite
            // 
            this.chkInfinite.AutoSize = true;
            this.chkInfinite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkInfinite.Enabled = false;
            this.chkInfinite.Location = new System.Drawing.Point(673, 3);
            this.chkInfinite.Name = "chkInfinite";
            this.chkInfinite.Size = new System.Drawing.Size(59, 18);
            this.chkInfinite.TabIndex = 1;
            this.chkInfinite.Text = "Infinite";
            this.chkInfinite.UseVisualStyleBackColor = true;
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDeadline.Enabled = false;
            this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeadline.Location = new System.Drawing.Point(572, 3);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(95, 20);
            this.dtpDeadline.TabIndex = 2;
            // 
            // dtpNextTimeMarker
            // 
            this.dtpNextTimeMarker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNextTimeMarker.Enabled = false;
            this.dtpNextTimeMarker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNextTimeMarker.Location = new System.Drawing.Point(406, 3);
            this.dtpNextTimeMarker.Name = "dtpNextTimeMarker";
            this.dtpNextTimeMarker.Size = new System.Drawing.Size(95, 20);
            this.dtpNextTimeMarker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(306, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Next Time Marker: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(507, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Deadline: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(140, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Time Spent: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTaskTimeSpent
            // 
            this.lblTaskTimeSpent.AutoSize = true;
            this.lblTaskTimeSpent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTaskTimeSpent.Location = new System.Drawing.Point(239, 0);
            this.lblTaskTimeSpent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaskTimeSpent.Name = "lblTaskTimeSpent";
            this.lblTaskTimeSpent.Size = new System.Drawing.Size(43, 24);
            this.lblTaskTimeSpent.TabIndex = 7;
            this.lblTaskTimeSpent.Text = "999h";
            this.lblTaskTimeSpent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTaskName.Location = new System.Drawing.Point(3, 0);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(729, 26);
            this.lblTaskName.TabIndex = 0;
            this.lblTaskName.Text = "---";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkFinished
            // 
            this.chkFinished.AutoSize = true;
            this.chkFinished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFinished.Location = new System.Drawing.Point(69, 3);
            this.chkFinished.Name = "chkFinished";
            this.chkFinished.Size = new System.Drawing.Size(66, 18);
            this.chkFinished.TabIndex = 8;
            this.chkFinished.Text = "Finished";
            this.chkFinished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFinished.UseVisualStyleBackColor = true;
            // 
            // frmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 516);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.stsTask);
            this.Controls.Add(this.mnsTask);
            this.MainMenuStrip = this.mnsTask;
            this.Name = "frmTask";
            this.Text = "frmTask";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTask_FormClosing);
            this.Load += new System.EventHandler(this.frmTask_Load);
            this.stsTask.ResumeLayout(false);
            this.stsTask.PerformLayout();
            this.mnsTask.ResumeLayout(false);
            this.mnsTask.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.cmsTask.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsTask;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip mnsTask;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvTask;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ContextMenuStrip cmsTask;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmUp;
        private System.Windows.Forms.ToolStripMenuItem tsmDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmBelongTo;
        private System.Windows.Forms.ToolStripMenuItem tsmIndependent;
        private System.Windows.Forms.CheckBox chkBottom;
        private System.Windows.Forms.CheckBox chkInfinite;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.DateTimePicker dtpNextTimeMarker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmFinished;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTaskTimeSpent;
        private System.Windows.Forms.ImageList iglTask;
        private System.Windows.Forms.ToolStripMenuItem tsmAbort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.ToolStripMenuItem addLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmRename;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.CheckBox chkFinished;
    }
}