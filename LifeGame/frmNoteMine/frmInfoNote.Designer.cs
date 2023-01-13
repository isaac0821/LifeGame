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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.trvNote = new System.Windows.Forms.TreeView();
            this.cmsTrvNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddLink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddNoteOutsource = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddNoteLiterature = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNote = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGoto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrepend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAppend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangeLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.removeChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBelongTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIndependent = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvColor = new System.Windows.Forms.ListView();
            this.cmsNoteColor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label5 = new System.Windows.Forms.Label();
            this.iglIcon = new System.Windows.Forms.ImageList(this.components);
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.cmsTrvNote.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.cmsNoteColor.SuspendLayout();
            this.cmsOutsource.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.trvNote, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(470, 543);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.Controls.Add(this.dtpDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnWrite, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRead, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(470, 26);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(203, 3);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(99, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(418, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 20);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // trvNote
            // 
            this.trvNote.ContextMenuStrip = this.cmsTrvNote;
            this.trvNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvNote.Location = new System.Drawing.Point(3, 203);
            this.trvNote.Name = "trvNote";
            this.trvNote.Size = new System.Drawing.Size(464, 337);
            this.trvNote.TabIndex = 0;
            this.trvNote.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvNote_AfterSelect);
            // 
            // cmsTrvNote
            // 
            this.cmsTrvNote.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTrvNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmAddLink,
            this.tsmAddBatch,
            this.toolStripSeparator3,
            this.tsmGoto,
            this.toolStripSeparator6,
            this.tsmEdit,
            this.tsmPrepend,
            this.tsmAppend,
            this.tsmReplace,
            this.tsmChangeLabel,
            this.toolStripSeparator5,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator8,
            this.tsmRemove,
            this.removeChildrenToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsmUp,
            this.tsmDown,
            this.toolStripSeparator2,
            this.tsmBelongTo,
            this.tsmIndependent});
            this.cmsTrvNote.Name = "cmsTrvNote";
            this.cmsTrvNote.Size = new System.Drawing.Size(166, 414);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(165, 22);
            this.tsmAdd.Text = "Add";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmAddLink
            // 
            this.tsmAddLink.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddNoteOutsource,
            this.tsmAddNoteLiterature,
            this.tsmNote});
            this.tsmAddLink.Name = "tsmAddLink";
            this.tsmAddLink.Size = new System.Drawing.Size(165, 22);
            this.tsmAddLink.Text = "Add Link";
            // 
            // tsmAddNoteOutsource
            // 
            this.tsmAddNoteOutsource.Name = "tsmAddNoteOutsource";
            this.tsmAddNoteOutsource.Size = new System.Drawing.Size(129, 22);
            this.tsmAddNoteOutsource.Text = "Outsource";
            this.tsmAddNoteOutsource.Click += new System.EventHandler(this.tsmAddNoteOutsource_Click);
            // 
            // tsmAddNoteLiterature
            // 
            this.tsmAddNoteLiterature.Name = "tsmAddNoteLiterature";
            this.tsmAddNoteLiterature.Size = new System.Drawing.Size(129, 22);
            this.tsmAddNoteLiterature.Text = "Literature";
            this.tsmAddNoteLiterature.Click += new System.EventHandler(this.tsmAddNoteLiterature_Click);
            // 
            // tsmNote
            // 
            this.tsmNote.Name = "tsmNote";
            this.tsmNote.Size = new System.Drawing.Size(129, 22);
            this.tsmNote.Text = "Note";
            this.tsmNote.Click += new System.EventHandler(this.tsmNote_Click);
            // 
            // tsmAddBatch
            // 
            this.tsmAddBatch.Name = "tsmAddBatch";
            this.tsmAddBatch.Size = new System.Drawing.Size(165, 22);
            this.tsmAddBatch.Text = "Add Batch";
            this.tsmAddBatch.Click += new System.EventHandler(this.tsmAddBatch_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmGoto
            // 
            this.tsmGoto.Name = "tsmGoto";
            this.tsmGoto.Size = new System.Drawing.Size(165, 22);
            this.tsmGoto.Text = "Go to";
            this.tsmGoto.Click += new System.EventHandler(this.tsmGoto_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(165, 22);
            this.tsmEdit.Text = "Edit";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmPrepend
            // 
            this.tsmPrepend.Name = "tsmPrepend";
            this.tsmPrepend.Size = new System.Drawing.Size(165, 22);
            this.tsmPrepend.Text = "Prepend";
            this.tsmPrepend.Click += new System.EventHandler(this.tsmPrepend_Click);
            // 
            // tsmAppend
            // 
            this.tsmAppend.Name = "tsmAppend";
            this.tsmAppend.Size = new System.Drawing.Size(165, 22);
            this.tsmAppend.Text = "Append";
            this.tsmAppend.Click += new System.EventHandler(this.tsmAppend_Click);
            // 
            // tsmReplace
            // 
            this.tsmReplace.Name = "tsmReplace";
            this.tsmReplace.Size = new System.Drawing.Size(165, 22);
            this.tsmReplace.Text = "Replace";
            this.tsmReplace.Click += new System.EventHandler(this.tsmReplace_Click);
            // 
            // tsmChangeLabel
            // 
            this.tsmChangeLabel.Name = "tsmChangeLabel";
            this.tsmChangeLabel.Size = new System.Drawing.Size(165, 22);
            this.tsmChangeLabel.Text = "Change Label";
            this.tsmChangeLabel.Click += new System.EventHandler(this.tsmChangeLabel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(162, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(165, 22);
            this.tsmRemove.Text = "Remove";
            this.tsmRemove.Click += new System.EventHandler(this.tsmRemove_Click);
            // 
            // removeChildrenToolStripMenuItem
            // 
            this.removeChildrenToolStripMenuItem.Name = "removeChildrenToolStripMenuItem";
            this.removeChildrenToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.removeChildrenToolStripMenuItem.Text = "Remove Children";
            this.removeChildrenToolStripMenuItem.Click += new System.EventHandler(this.removeChildrenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmUp
            // 
            this.tsmUp.Name = "tsmUp";
            this.tsmUp.Size = new System.Drawing.Size(165, 22);
            this.tsmUp.Text = "Up";
            this.tsmUp.Click += new System.EventHandler(this.tsmUp_Click);
            // 
            // tsmDown
            // 
            this.tsmDown.Name = "tsmDown";
            this.tsmDown.Size = new System.Drawing.Size(165, 22);
            this.tsmDown.Text = "Down";
            this.tsmDown.Click += new System.EventHandler(this.tsmDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmBelongTo
            // 
            this.tsmBelongTo.Name = "tsmBelongTo";
            this.tsmBelongTo.Size = new System.Drawing.Size(165, 22);
            this.tsmBelongTo.Text = "Belong To";
            this.tsmBelongTo.Click += new System.EventHandler(this.tsmBelongTo_Click);
            // 
            // tsmIndependent
            // 
            this.tsmIndependent.Name = "tsmIndependent";
            this.tsmIndependent.Size = new System.Drawing.Size(165, 22);
            this.tsmIndependent.Text = "Independent";
            this.tsmIndependent.Click += new System.EventHandler(this.tsmIndependent_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lsvColor, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lsbOutsource, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtLiteratureTitle, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cbxTask, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(470, 174);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Topic";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsvColor
            // 
            this.lsvColor.ContextMenuStrip = this.cmsNoteColor;
            this.lsvColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvColor.HideSelection = false;
            this.lsvColor.Location = new System.Drawing.Point(73, 107);
            this.lsvColor.Name = "lsvColor";
            this.lsvColor.Size = new System.Drawing.Size(394, 64);
            this.lsvColor.TabIndex = 3;
            this.lsvColor.UseCompatibleStateImageBehavior = false;
            this.lsvColor.View = System.Windows.Forms.View.List;
            // 
            // cmsNoteColor
            // 
            this.cmsNoteColor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.cmsNoteColor.Name = "cmsNoteColor";
            this.cmsNoteColor.Size = new System.Drawing.Size(118, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Outsources";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsbOutsource
            // 
            this.lsbOutsource.ContextMenuStrip = this.cmsOutsource;
            this.lsbOutsource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbOutsource.FormattingEnabled = true;
            this.lsbOutsource.Location = new System.Drawing.Point(73, 81);
            this.lsbOutsource.Name = "lsbOutsource";
            this.lsbOutsource.Size = new System.Drawing.Size(394, 20);
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
            this.cmsOutsource.Size = new System.Drawing.Size(108, 76);
            // 
            // tsmOpenOutsource
            // 
            this.tsmOpenOutsource.Name = "tsmOpenOutsource";
            this.tsmOpenOutsource.Size = new System.Drawing.Size(107, 22);
            this.tsmOpenOutsource.Text = "Open";
            this.tsmOpenOutsource.Click += new System.EventHandler(this.tsmOpenOutsource_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(104, 6);
            // 
            // tsmAddOutsource
            // 
            this.tsmAddOutsource.Name = "tsmAddOutsource";
            this.tsmAddOutsource.Size = new System.Drawing.Size(107, 22);
            this.tsmAddOutsource.Text = "Add";
            this.tsmAddOutsource.Click += new System.EventHandler(this.tsmAddOutsource_Click);
            // 
            // tsmDeleteOutsource
            // 
            this.tsmDeleteOutsource.Name = "tsmDeleteOutsource";
            this.tsmDeleteOutsource.Size = new System.Drawing.Size(107, 22);
            this.tsmDeleteOutsource.Text = "Delete";
            this.tsmDeleteOutsource.Click += new System.EventHandler(this.tsmDeleteOutsource_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel4.Controls.Add(this.txtTopic, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkFinished, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(70, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(400, 26);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // txtTopic
            // 
            this.txtTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTopic.Location = new System.Drawing.Point(3, 3);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(321, 20);
            this.txtTopic.TabIndex = 0;
            this.txtTopic.TextChanged += new System.EventHandler(this.txtTopic_TextChanged);
            // 
            // chkFinished
            // 
            this.chkFinished.AutoSize = true;
            this.chkFinished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFinished.Location = new System.Drawing.Point(329, 2);
            this.chkFinished.Margin = new System.Windows.Forms.Padding(2);
            this.chkFinished.Name = "chkFinished";
            this.chkFinished.Size = new System.Drawing.Size(69, 22);
            this.chkFinished.TabIndex = 1;
            this.chkFinished.Text = "Finished";
            this.chkFinished.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Literature";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLiteratureTitle
            // 
            this.txtLiteratureTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLiteratureTitle.Location = new System.Drawing.Point(73, 55);
            this.txtLiteratureTitle.Name = "txtLiteratureTitle";
            this.txtLiteratureTitle.Size = new System.Drawing.Size(394, 20);
            this.txtLiteratureTitle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Task";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxTask
            // 
            this.cbxTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTask.FormattingEnabled = true;
            this.cbxTask.Location = new System.Drawing.Point(73, 29);
            this.cbxTask.Name = "cbxTask";
            this.cbxTask.Size = new System.Drawing.Size(394, 21);
            this.cbxTask.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 70);
            this.label5.TabIndex = 9;
            this.label5.Text = "Keywords";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iglIcon
            // 
            this.iglIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglIcon.ImageStream")));
            this.iglIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.iglIcon.Images.SetKeyName(0, "iconLink.png");
            // 
            // btnWrite
            // 
            this.btnWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWrite.Location = new System.Drawing.Point(363, 3);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(49, 20);
            this.btnWrite.TabIndex = 2;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRead.Location = new System.Drawing.Point(308, 3);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(49, 20);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // frmInfoNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 543);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInfoNote";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInfoNote_FormClosing);
            this.Load += new System.EventHandler(this.frmInfoNote_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.cmsTrvNote.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.cmsNoteColor.ResumeLayout(false);
            this.cmsOutsource.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView trvNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtpDate;
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
        private System.Windows.Forms.ContextMenuStrip cmsOutsource;
        private System.Windows.Forms.ToolStripMenuItem tsmAddOutsource;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteOutsource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenOutsource;
        private System.Windows.Forms.ImageList iglIcon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip cmsNoteColor;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ListView lsvColor;
        private System.Windows.Forms.ListBox lsbOutsource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.CheckBox chkFinished;
        private System.Windows.Forms.TextBox txtLiteratureTitle;
        private System.Windows.Forms.ComboBox cbxTask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeLabel;
        private System.Windows.Forms.ToolStripMenuItem tsmAddBatch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem removeChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAddLink;
        private System.Windows.Forms.ToolStripMenuItem tsmGoto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsmAddNoteOutsource;
        private System.Windows.Forms.ToolStripMenuItem tsmAddNoteLiterature;
        private System.Windows.Forms.ToolStripMenuItem tsmNote;
        private System.Windows.Forms.ToolStripMenuItem tsmReplace;
        private System.Windows.Forms.ToolStripMenuItem tsmPrepend;
        private System.Windows.Forms.ToolStripMenuItem tsmAppend;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnRead;
    }
}