namespace iTrack
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.filesFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moneyMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.achievementAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.tslVersionNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMon = new System.Windows.Forms.Label();
            this.lblTue = new System.Windows.Forms.Label();
            this.lblWed = new System.Windows.Forms.Label();
            this.lblThu = new System.Windows.Forms.Label();
            this.lblFri = new System.Windows.Forms.Label();
            this.lblSat = new System.Windows.Forms.Label();
            this.lblSun = new System.Windows.Forms.Label();
            this.picMon = new System.Windows.Forms.PictureBox();
            this.picTue = new System.Windows.Forms.PictureBox();
            this.picWed = new System.Windows.Forms.PictureBox();
            this.picThu = new System.Windows.Forms.PictureBox();
            this.picFri = new System.Windows.Forms.PictureBox();
            this.picSat = new System.Windows.Forms.PictureBox();
            this.picSun = new System.Windows.Forms.PictureBox();
            this.lblMonday = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPreDate = new System.Windows.Forms.Button();
            this.btnNextDate = new System.Windows.Forms.Button();
            this.chkShowSchedule = new System.Windows.Forms.CheckBox();
            this.chkShowLog = new System.Windows.Forms.CheckBox();
            this.loadLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSun)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesFToolStripMenuItem,
            this.viewVToolStripMenuItem,
            this.reportRToolStripMenuItem,
            this.helpHToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(1184, 25);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // filesFToolStripMenuItem
            // 
            this.filesFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLToolStripMenuItem});
            this.filesFToolStripMenuItem.Name = "filesFToolStripMenuItem";
            this.filesFToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.filesFToolStripMenuItem.Text = "Files(&F)";
            // 
            // viewVToolStripMenuItem
            // 
            this.viewVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskTToolStripMenuItem,
            this.moneyMToolStripMenuItem,
            this.achievementAToolStripMenuItem,
            this.statisticsSToolStripMenuItem});
            this.viewVToolStripMenuItem.Name = "viewVToolStripMenuItem";
            this.viewVToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.viewVToolStripMenuItem.Text = "View(&V)";
            // 
            // taskTToolStripMenuItem
            // 
            this.taskTToolStripMenuItem.Name = "taskTToolStripMenuItem";
            this.taskTToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.taskTToolStripMenuItem.Text = "Task(&T)";
            this.taskTToolStripMenuItem.Click += new System.EventHandler(this.taskTToolStripMenuItem_Click);
            // 
            // moneyMToolStripMenuItem
            // 
            this.moneyMToolStripMenuItem.Name = "moneyMToolStripMenuItem";
            this.moneyMToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.moneyMToolStripMenuItem.Text = "Money(&M)";
            this.moneyMToolStripMenuItem.Click += new System.EventHandler(this.moneyMToolStripMenuItem_Click);
            // 
            // achievementAToolStripMenuItem
            // 
            this.achievementAToolStripMenuItem.Name = "achievementAToolStripMenuItem";
            this.achievementAToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.achievementAToolStripMenuItem.Text = "Achievement(&A)";
            // 
            // statisticsSToolStripMenuItem
            // 
            this.statisticsSToolStripMenuItem.Name = "statisticsSToolStripMenuItem";
            this.statisticsSToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.statisticsSToolStripMenuItem.Text = "Statistics(&S)";
            // 
            // reportRToolStripMenuItem
            // 
            this.reportRToolStripMenuItem.Name = "reportRToolStripMenuItem";
            this.reportRToolStripMenuItem.Size = new System.Drawing.Size(76, 21);
            this.reportRToolStripMenuItem.Text = "Report(&R)";
            // 
            // helpHToolStripMenuItem
            // 
            this.helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
            this.helpHToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.helpHToolStripMenuItem.Text = "Help(&H)";
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslVersionNumber});
            this.stsMain.Location = new System.Drawing.Point(0, 779);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(1184, 22);
            this.stsMain.TabIndex = 1;
            this.stsMain.Text = "statusStrip1";
            // 
            // tslVersionNumber
            // 
            this.tslVersionNumber.Name = "tslVersionNumber";
            this.tslVersionNumber.Size = new System.Drawing.Size(86, 17);
            this.tslVersionNumber.Text = "Version: 0.0.0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 754);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel2.Controls.Add(this.lblMon, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTue, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblWed, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblThu, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblFri, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSat, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSun, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.picMon, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.picTue, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.picWed, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.picThu, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.picFri, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.picSat, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.picSun, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblMonday, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1178, 715);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.BackColor = System.Drawing.Color.LightGray;
            this.lblMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMon.Location = new System.Drawing.Point(3, 33);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(162, 33);
            this.lblMon.TabIndex = 0;
            this.lblMon.Text = "Monday";
            this.lblMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTue
            // 
            this.lblTue.AutoSize = true;
            this.lblTue.BackColor = System.Drawing.Color.LightGray;
            this.lblTue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTue.Location = new System.Drawing.Point(171, 33);
            this.lblTue.Name = "lblTue";
            this.lblTue.Size = new System.Drawing.Size(162, 33);
            this.lblTue.TabIndex = 1;
            this.lblTue.Text = "Tuesday";
            this.lblTue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWed
            // 
            this.lblWed.AutoSize = true;
            this.lblWed.BackColor = System.Drawing.Color.LightGray;
            this.lblWed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWed.Location = new System.Drawing.Point(339, 33);
            this.lblWed.Name = "lblWed";
            this.lblWed.Size = new System.Drawing.Size(162, 33);
            this.lblWed.TabIndex = 2;
            this.lblWed.Text = "Wednesday";
            this.lblWed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThu
            // 
            this.lblThu.AutoSize = true;
            this.lblThu.BackColor = System.Drawing.Color.LightGray;
            this.lblThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThu.Location = new System.Drawing.Point(507, 33);
            this.lblThu.Name = "lblThu";
            this.lblThu.Size = new System.Drawing.Size(162, 33);
            this.lblThu.TabIndex = 3;
            this.lblThu.Text = "Thursday";
            this.lblThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFri
            // 
            this.lblFri.AutoSize = true;
            this.lblFri.BackColor = System.Drawing.Color.LightGray;
            this.lblFri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFri.Location = new System.Drawing.Point(675, 33);
            this.lblFri.Name = "lblFri";
            this.lblFri.Size = new System.Drawing.Size(162, 33);
            this.lblFri.TabIndex = 4;
            this.lblFri.Text = "Friday";
            this.lblFri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSat
            // 
            this.lblSat.AutoSize = true;
            this.lblSat.BackColor = System.Drawing.Color.LightGray;
            this.lblSat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSat.Location = new System.Drawing.Point(843, 33);
            this.lblSat.Name = "lblSat";
            this.lblSat.Size = new System.Drawing.Size(162, 33);
            this.lblSat.TabIndex = 5;
            this.lblSat.Text = "Saturday";
            this.lblSat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSun
            // 
            this.lblSun.AutoSize = true;
            this.lblSun.BackColor = System.Drawing.Color.LightGray;
            this.lblSun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSun.Location = new System.Drawing.Point(1011, 33);
            this.lblSun.Name = "lblSun";
            this.lblSun.Size = new System.Drawing.Size(164, 33);
            this.lblSun.TabIndex = 6;
            this.lblSun.Text = "Sunday";
            this.lblSun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picMon
            // 
            this.picMon.BackColor = System.Drawing.Color.White;
            this.picMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMon.Location = new System.Drawing.Point(3, 69);
            this.picMon.Name = "picMon";
            this.picMon.Size = new System.Drawing.Size(162, 643);
            this.picMon.TabIndex = 7;
            this.picMon.TabStop = false;
            // 
            // picTue
            // 
            this.picTue.BackColor = System.Drawing.Color.White;
            this.picTue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTue.Location = new System.Drawing.Point(171, 69);
            this.picTue.Name = "picTue";
            this.picTue.Size = new System.Drawing.Size(162, 643);
            this.picTue.TabIndex = 8;
            this.picTue.TabStop = false;
            // 
            // picWed
            // 
            this.picWed.BackColor = System.Drawing.Color.White;
            this.picWed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picWed.Location = new System.Drawing.Point(339, 69);
            this.picWed.Name = "picWed";
            this.picWed.Size = new System.Drawing.Size(162, 643);
            this.picWed.TabIndex = 9;
            this.picWed.TabStop = false;
            // 
            // picThu
            // 
            this.picThu.BackColor = System.Drawing.Color.White;
            this.picThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picThu.Location = new System.Drawing.Point(507, 69);
            this.picThu.Name = "picThu";
            this.picThu.Size = new System.Drawing.Size(162, 643);
            this.picThu.TabIndex = 10;
            this.picThu.TabStop = false;
            // 
            // picFri
            // 
            this.picFri.BackColor = System.Drawing.Color.White;
            this.picFri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFri.Location = new System.Drawing.Point(675, 69);
            this.picFri.Name = "picFri";
            this.picFri.Size = new System.Drawing.Size(162, 643);
            this.picFri.TabIndex = 11;
            this.picFri.TabStop = false;
            // 
            // picSat
            // 
            this.picSat.BackColor = System.Drawing.Color.White;
            this.picSat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSat.Location = new System.Drawing.Point(843, 69);
            this.picSat.Name = "picSat";
            this.picSat.Size = new System.Drawing.Size(162, 643);
            this.picSat.TabIndex = 12;
            this.picSat.TabStop = false;
            // 
            // picSun
            // 
            this.picSun.BackColor = System.Drawing.Color.White;
            this.picSun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSun.Location = new System.Drawing.Point(1011, 69);
            this.picSun.Name = "picSun";
            this.picSun.Size = new System.Drawing.Size(164, 643);
            this.picSun.TabIndex = 13;
            this.picSun.TabStop = false;
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.BackColor = System.Drawing.Color.Silver;
            this.lblMonday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMonday.Location = new System.Drawing.Point(3, 0);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(162, 33);
            this.lblMonday.TabIndex = 14;
            this.lblMonday.Text = "Day 1";
            this.lblMonday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(171, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 33);
            this.label2.TabIndex = 15;
            this.label2.Text = "Day 2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(339, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 33);
            this.label3.TabIndex = 16;
            this.label3.Text = "Day 3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(507, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 33);
            this.label4.TabIndex = 17;
            this.label4.Text = "Day 4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(675, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 33);
            this.label5.TabIndex = 18;
            this.label5.Text = "Day 5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(843, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 33);
            this.label6.TabIndex = 19;
            this.label6.Text = "Day 6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(1011, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 33);
            this.label7.TabIndex = 20;
            this.label7.Text = "Day 7";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.dtpDate, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPreDate, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNextDate, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkShowSchedule, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkShowLog, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1178, 27);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Location = new System.Drawing.Point(1053, 3);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(102, 21);
            this.dtpDate.TabIndex = 0;
            // 
            // btnPreDate
            // 
            this.btnPreDate.Location = new System.Drawing.Point(1033, 3);
            this.btnPreDate.Name = "btnPreDate";
            this.btnPreDate.Size = new System.Drawing.Size(14, 21);
            this.btnPreDate.TabIndex = 1;
            this.btnPreDate.Text = "<";
            this.btnPreDate.UseVisualStyleBackColor = true;
            // 
            // btnNextDate
            // 
            this.btnNextDate.Location = new System.Drawing.Point(1161, 3);
            this.btnNextDate.Name = "btnNextDate";
            this.btnNextDate.Size = new System.Drawing.Size(14, 21);
            this.btnNextDate.TabIndex = 2;
            this.btnNextDate.Text = ">";
            this.btnNextDate.UseVisualStyleBackColor = true;
            // 
            // chkShowSchedule
            // 
            this.chkShowSchedule.AutoSize = true;
            this.chkShowSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowSchedule.Location = new System.Drawing.Point(3, 3);
            this.chkShowSchedule.Name = "chkShowSchedule";
            this.chkShowSchedule.Size = new System.Drawing.Size(107, 21);
            this.chkShowSchedule.TabIndex = 3;
            this.chkShowSchedule.Text = "Show Schedule";
            this.chkShowSchedule.UseVisualStyleBackColor = true;
            // 
            // chkShowLog
            // 
            this.chkShowLog.AutoSize = true;
            this.chkShowLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowLog.Location = new System.Drawing.Point(116, 3);
            this.chkShowLog.Name = "chkShowLog";
            this.chkShowLog.Size = new System.Drawing.Size(81, 21);
            this.chkShowLog.TabIndex = 4;
            this.chkShowLog.Text = "Show Log";
            this.chkShowLog.UseVisualStyleBackColor = true;
            // 
            // loadLToolStripMenuItem
            // 
            this.loadLToolStripMenuItem.Name = "loadLToolStripMenuItem";
            this.loadLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadLToolStripMenuItem.Text = "Load(&L)";
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScheduleToolStripMenuItem});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(157, 26);
            // 
            // addScheduleToolStripMenuItem
            // 
            this.addScheduleToolStripMenuItem.Name = "addScheduleToolStripMenuItem";
            this.addScheduleToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addScheduleToolStripMenuItem.Text = "Add Schedule";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 801);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmMain";
            this.Text = "LifeGame";
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSun)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem filesFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportRToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel tslVersionNumber;
        private System.Windows.Forms.ToolStripMenuItem viewVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpHToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblTue;
        private System.Windows.Forms.Label lblWed;
        private System.Windows.Forms.Label lblThu;
        private System.Windows.Forms.Label lblFri;
        private System.Windows.Forms.Label lblSat;
        private System.Windows.Forms.Label lblSun;
        private System.Windows.Forms.PictureBox picMon;
        private System.Windows.Forms.PictureBox picTue;
        private System.Windows.Forms.PictureBox picWed;
        private System.Windows.Forms.PictureBox picThu;
        private System.Windows.Forms.PictureBox picFri;
        private System.Windows.Forms.PictureBox picSat;
        private System.Windows.Forms.PictureBox picSun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnPreDate;
        private System.Windows.Forms.Button btnNextDate;
        private System.Windows.Forms.ToolStripMenuItem taskTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moneyMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem achievementAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsSToolStripMenuItem;
        private System.Windows.Forms.Label lblMonday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkShowSchedule;
        private System.Windows.Forms.CheckBox chkShowLog;
        private System.Windows.Forms.ToolStripMenuItem loadLToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem addScheduleToolStripMenuItem;
    }
}

