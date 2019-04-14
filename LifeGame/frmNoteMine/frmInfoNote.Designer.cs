namespace LifeGame
{
    partial class frmInfoNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoNote));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.trvNote = new System.Windows.Forms.TreeView();
            this.cmsTrvNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBelongTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIndependent = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbOutsource = new System.Windows.Forms.ListBox();
            this.cmsOutsource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpenOutsource = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAddOutsource = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteOutsource = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.chkFinished = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLiteratureTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTask = new System.Windows.Forms.ComboBox();
            this.iglIcon = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.cmsTrvNote.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.cmsOutsource.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.trvNote, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 668);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // trvNote
            // 
            this.trvNote.ContextMenuStrip = this.cmsTrvNote;
            this.trvNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvNote.Location = new System.Drawing.Point(4, 227);
            this.trvNote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trvNote.Name = "trvNote";
            this.trvNote.Size = new System.Drawing.Size(605, 437);
            this.trvNote.TabIndex = 0;
            // 
            // cmsTrvNote
            // 
            this.cmsTrvNote.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTrvNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmEdit,
            this.tsmRemove,
            this.toolStripSeparator1,
            this.tsmUp,
            this.tsmDown,
            this.toolStripSeparator2,
            this.tsmBelongTo,
            this.tsmIndependent});
            this.cmsTrvNote.Name = "cmsTrvNote";
            this.cmsTrvNote.Size = new System.Drawing.Size(163, 184);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(162, 24);
            this.tsmAdd.Text = "Add";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(162, 24);
            this.tsmEdit.Text = "Edit";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(162, 24);
            this.tsmRemove.Text = "Remove";
            this.tsmRemove.Click += new System.EventHandler(this.tsmRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmUp
            // 
            this.tsmUp.Name = "tsmUp";
            this.tsmUp.Size = new System.Drawing.Size(162, 24);
            this.tsmUp.Text = "Up";
            this.tsmUp.Click += new System.EventHandler(this.tsmUp_Click);
            // 
            // tsmDown
            // 
            this.tsmDown.Name = "tsmDown";
            this.tsmDown.Size = new System.Drawing.Size(162, 24);
            this.tsmDown.Text = "Down";
            this.tsmDown.Click += new System.EventHandler(this.tsmDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmBelongTo
            // 
            this.tsmBelongTo.Name = "tsmBelongTo";
            this.tsmBelongTo.Size = new System.Drawing.Size(162, 24);
            this.tsmBelongTo.Text = "Belong To";
            this.tsmBelongTo.Click += new System.EventHandler(this.tsmBelongTo_Click);
            // 
            // tsmIndependent
            // 
            this.tsmIndependent.Name = "tsmIndependent";
            this.tsmIndependent.Size = new System.Drawing.Size(162, 24);
            this.tsmIndependent.Text = "Independent";
            this.tsmIndependent.Click += new System.EventHandler(this.tsmIndependent_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel2.Controls.Add(this.dtpDate, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(613, 32);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(478, 4);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(131, 22);
            this.dtpDate.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lsbOutsource, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtLiteratureTitle, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cbxTask, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 32);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(613, 191);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Topic";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 95);
            this.label2.TabIndex = 2;
            this.label2.Text = "Outsources";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsbOutsource
            // 
            this.lsbOutsource.ContextMenuStrip = this.cmsOutsource;
            this.lsbOutsource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbOutsource.FormattingEnabled = true;
            this.lsbOutsource.ItemHeight = 16;
            this.lsbOutsource.Location = new System.Drawing.Point(97, 100);
            this.lsbOutsource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsbOutsource.Name = "lsbOutsource";
            this.lsbOutsource.Size = new System.Drawing.Size(512, 87);
            this.lsbOutsource.TabIndex = 3;
            // 
            // cmsOutsource
            // 
            this.cmsOutsource.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOutsource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenOutsource,
            this.toolStripSeparator4,
            this.tsmAddOutsource,
            this.tsmDeleteOutsource});
            this.cmsOutsource.Name = "cmsOutsource";
            this.cmsOutsource.Size = new System.Drawing.Size(211, 110);
            // 
            // tsmOpenOutsource
            // 
            this.tsmOpenOutsource.Name = "tsmOpenOutsource";
            this.tsmOpenOutsource.Size = new System.Drawing.Size(210, 24);
            this.tsmOpenOutsource.Text = "Open";
            this.tsmOpenOutsource.Click += new System.EventHandler(this.tsmOpenOutsource_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmAddOutsource
            // 
            this.tsmAddOutsource.Name = "tsmAddOutsource";
            this.tsmAddOutsource.Size = new System.Drawing.Size(210, 24);
            this.tsmAddOutsource.Text = "Add";
            this.tsmAddOutsource.Click += new System.EventHandler(this.tsmAddOutsource_Click);
            // 
            // tsmDeleteOutsource
            // 
            this.tsmDeleteOutsource.Name = "tsmDeleteOutsource";
            this.tsmDeleteOutsource.Size = new System.Drawing.Size(210, 24);
            this.tsmDeleteOutsource.Text = "Delete";
            this.tsmDeleteOutsource.Click += new System.EventHandler(this.tsmDeleteOutsource_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel4.Controls.Add(this.txtTopic, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkFinished, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(93, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(520, 32);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // txtTopic
            // 
            this.txtTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTopic.Location = new System.Drawing.Point(4, 4);
            this.txtTopic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(415, 22);
            this.txtTopic.TabIndex = 0;
            this.txtTopic.TextChanged += new System.EventHandler(this.txtTopic_TextChanged);
            // 
            // chkFinished
            // 
            this.chkFinished.AutoSize = true;
            this.chkFinished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFinished.Location = new System.Drawing.Point(426, 2);
            this.chkFinished.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkFinished.Name = "chkFinished";
            this.chkFinished.Size = new System.Drawing.Size(91, 28);
            this.chkFinished.TabIndex = 1;
            this.chkFinished.Text = "Finished";
            this.chkFinished.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Literature";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLiteratureTitle
            // 
            this.txtLiteratureTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLiteratureTitle.Location = new System.Drawing.Point(97, 68);
            this.txtLiteratureTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLiteratureTitle.Name = "txtLiteratureTitle";
            this.txtLiteratureTitle.Size = new System.Drawing.Size(512, 22);
            this.txtLiteratureTitle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Task";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxTask
            // 
            this.cbxTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTask.FormattingEnabled = true;
            this.cbxTask.Location = new System.Drawing.Point(97, 36);
            this.cbxTask.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTask.Name = "cbxTask";
            this.cbxTask.Size = new System.Drawing.Size(512, 24);
            this.cbxTask.TabIndex = 8;
            // 
            // iglIcon
            // 
            this.iglIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglIcon.ImageStream")));
            this.iglIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.iglIcon.Images.SetKeyName(0, "iconNoteLogo0.png");
            this.iglIcon.Images.SetKeyName(1, "iconNoteLogo1.png");
            this.iglIcon.Images.SetKeyName(2, "iconNoteLogo2.png");
            this.iglIcon.Images.SetKeyName(3, "iconNoteLogo3.png");
            this.iglIcon.Images.SetKeyName(4, "iconNoteLogo4.png");
            this.iglIcon.Images.SetKeyName(5, "iconNoteLogo5.png");
            this.iglIcon.Images.SetKeyName(6, "iconNoteLogo6.png");
            this.iglIcon.Images.SetKeyName(7, "iconNoteLogo7.png");
            this.iglIcon.Images.SetKeyName(8, "iconNoteLogo8.png");
            this.iglIcon.Images.SetKeyName(9, "iconNoteLogo9.png");
            this.iglIcon.Images.SetKeyName(10, "iconNoteLogo10.png");
            this.iglIcon.Images.SetKeyName(11, "iconNoteLogo11.png");
            this.iglIcon.Images.SetKeyName(12, "iconNoteLogo12.png");
            // 
            // frmInfoNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 668);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmInfoNote";
            this.Text = "LifeGame - Note";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInfoNote_FormClosing);
            this.Load += new System.EventHandler(this.frmInfoNote_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.cmsTrvNote.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.cmsOutsource.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView trvNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsTrvNote;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmUp;
        private System.Windows.Forms.ToolStripMenuItem tsmDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmBelongTo;
        private System.Windows.Forms.ToolStripMenuItem tsmIndependent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbOutsource;
        private System.Windows.Forms.ContextMenuStrip cmsOutsource;
        private System.Windows.Forms.ToolStripMenuItem tsmAddOutsource;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteOutsource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenOutsource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox chkFinished;
        private System.Windows.Forms.ImageList iglIcon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLiteratureTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTask;
    }
}