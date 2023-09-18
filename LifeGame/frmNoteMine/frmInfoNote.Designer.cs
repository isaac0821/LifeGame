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
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.trvNote = new System.Windows.Forms.TreeView();
            this.cmsTrvNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmFold = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGoto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmConvertToSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConvertToLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConvertToTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrepend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAppend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangeLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.removeChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmIndependent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBelongTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.iglIcon = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.chkFinished = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLiteratureTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTask = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lsvColor = new System.Windows.Forms.ListView();
            this.cmsNoteColor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txtHighlight = new System.Windows.Forms.TextBox();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvTag = new System.Windows.Forms.ListView();
            this.cmsNoteTag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.cmsTrvNote.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.cmsNoteColor.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.cmsNoteTag.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 656);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Controls.Add(this.dtpDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnWrite, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRead, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLock, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(543, 24);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(171, 3);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(113, 21);
            this.dtpDate.TabIndex = 0;
            // 
            // btnWrite
            // 
            this.btnWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWrite.Location = new System.Drawing.Point(350, 3);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(54, 18);
            this.btnWrite.TabIndex = 2;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(410, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 18);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save (&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRead
            // 
            this.btnRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRead.Location = new System.Drawing.Point(290, 3);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(54, 18);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(486, 3);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(54, 18);
            this.btnLock.TabIndex = 4;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // trvNote
            // 
            this.trvNote.ContextMenuStrip = this.cmsTrvNote;
            this.trvNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvNote.Location = new System.Drawing.Point(3, 205);
            this.trvNote.Name = "trvNote";
            this.trvNote.Size = new System.Drawing.Size(537, 448);
            this.trvNote.StateImageList = this.iglIcon;
            this.trvNote.TabIndex = 0;
            this.trvNote.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.trvNote_AfterLabelEdit);
            this.trvNote.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvNote_BeforeSelect);
            this.trvNote.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvNote_AfterSelect);
            this.trvNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trvNote_KeyDown);
            this.trvNote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trvNote_KeyPress);
            // 
            // cmsTrvNote
            // 
            this.cmsTrvNote.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTrvNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmAddBatch,
            this.toolStripSeparator3,
            this.tsmFold,
            this.tsmExpand,
            this.toolStripSeparator7,
            this.tsmGoto,
            this.toolStripSeparator6,
            this.tsmConvertToSchedule,
            this.tsmConvertToLog,
            this.tsmConvertToTransaction,
            this.toolStripSeparator4,
            this.tsmSort,
            this.toolStripSeparator9,
            this.tsmEdit,
            this.tsmPrepend,
            this.tsmAppend,
            this.tsmReplace,
            this.tsmChangeLabel,
            this.toolStripSeparator8,
            this.tsmCopy,
            this.tsmPaste,
            this.tsmRemove,
            this.removeChildrenToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsmUp,
            this.tsmDown,
            this.toolStripSeparator2,
            this.tsmIndependent,
            this.tsmBelongTo,
            this.toolStripSeparator5,
            this.tsmProperties});
            this.cmsTrvNote.Name = "cmsTrvNote";
            this.cmsTrvNote.Size = new System.Drawing.Size(212, 564);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(211, 22);
            this.tsmAdd.Text = "Add (&A)...";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmAddBatch
            // 
            this.tsmAddBatch.Name = "tsmAddBatch";
            this.tsmAddBatch.Size = new System.Drawing.Size(211, 22);
            this.tsmAddBatch.Text = "Add Batch (&B)...";
            this.tsmAddBatch.Click += new System.EventHandler(this.tsmAddBatch_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmFold
            // 
            this.tsmFold.Name = "tsmFold";
            this.tsmFold.Size = new System.Drawing.Size(211, 22);
            this.tsmFold.Text = "Fold (&N)";
            this.tsmFold.Click += new System.EventHandler(this.tsmFold_Click);
            // 
            // tsmExpand
            // 
            this.tsmExpand.Name = "tsmExpand";
            this.tsmExpand.Size = new System.Drawing.Size(211, 22);
            this.tsmExpand.Text = "Expand (&M)";
            this.tsmExpand.Click += new System.EventHandler(this.tsmExpand_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmGoto
            // 
            this.tsmGoto.Name = "tsmGoto";
            this.tsmGoto.Size = new System.Drawing.Size(211, 22);
            this.tsmGoto.Text = "Go to... (&G)";
            this.tsmGoto.Click += new System.EventHandler(this.tsmGoto_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmConvertToSchedule
            // 
            this.tsmConvertToSchedule.Name = "tsmConvertToSchedule";
            this.tsmConvertToSchedule.Size = new System.Drawing.Size(211, 22);
            this.tsmConvertToSchedule.Text = "Convert To Schedule";
            this.tsmConvertToSchedule.Click += new System.EventHandler(this.tsmConvertToSchedule_Click);
            // 
            // tsmConvertToLog
            // 
            this.tsmConvertToLog.Name = "tsmConvertToLog";
            this.tsmConvertToLog.Size = new System.Drawing.Size(211, 22);
            this.tsmConvertToLog.Text = "Convert To Log";
            this.tsmConvertToLog.Click += new System.EventHandler(this.tsmConvertToLog_Click);
            // 
            // tsmConvertToTransaction
            // 
            this.tsmConvertToTransaction.Name = "tsmConvertToTransaction";
            this.tsmConvertToTransaction.Size = new System.Drawing.Size(211, 22);
            this.tsmConvertToTransaction.Text = "Convert To Transaction";
            this.tsmConvertToTransaction.Click += new System.EventHandler(this.tsmConvertToTransaction_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmSort
            // 
            this.tsmSort.Name = "tsmSort";
            this.tsmSort.Size = new System.Drawing.Size(211, 22);
            this.tsmSort.Text = "Sort";
            this.tsmSort.Click += new System.EventHandler(this.tsmSort_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(211, 22);
            this.tsmEdit.Text = "Edit (&E)...";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmPrepend
            // 
            this.tsmPrepend.Name = "tsmPrepend";
            this.tsmPrepend.Size = new System.Drawing.Size(211, 22);
            this.tsmPrepend.Text = "Prepend...";
            this.tsmPrepend.Click += new System.EventHandler(this.tsmPrepend_Click);
            // 
            // tsmAppend
            // 
            this.tsmAppend.Name = "tsmAppend";
            this.tsmAppend.Size = new System.Drawing.Size(211, 22);
            this.tsmAppend.Text = "Append...";
            this.tsmAppend.Click += new System.EventHandler(this.tsmAppend_Click);
            // 
            // tsmReplace
            // 
            this.tsmReplace.Name = "tsmReplace";
            this.tsmReplace.Size = new System.Drawing.Size(211, 22);
            this.tsmReplace.Text = "Replace...";
            this.tsmReplace.Click += new System.EventHandler(this.tsmReplace_Click);
            // 
            // tsmChangeLabel
            // 
            this.tsmChangeLabel.Name = "tsmChangeLabel";
            this.tsmChangeLabel.Size = new System.Drawing.Size(211, 22);
            this.tsmChangeLabel.Text = "Change Label...";
            this.tsmChangeLabel.Click += new System.EventHandler(this.tsmChangeLabel_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmCopy
            // 
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.Size = new System.Drawing.Size(211, 22);
            this.tsmCopy.Text = "Copy (&C)";
            this.tsmCopy.Click += new System.EventHandler(this.tsmCopy_Click);
            // 
            // tsmPaste
            // 
            this.tsmPaste.Enabled = false;
            this.tsmPaste.Name = "tsmPaste";
            this.tsmPaste.Size = new System.Drawing.Size(211, 22);
            this.tsmPaste.Text = "Paste (&V)";
            this.tsmPaste.Click += new System.EventHandler(this.tsmPaste_Click);
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(211, 22);
            this.tsmRemove.Text = "Remove (&D)";
            this.tsmRemove.Click += new System.EventHandler(this.tsmRemove_Click);
            // 
            // removeChildrenToolStripMenuItem
            // 
            this.removeChildrenToolStripMenuItem.Name = "removeChildrenToolStripMenuItem";
            this.removeChildrenToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.removeChildrenToolStripMenuItem.Text = "Remove Children";
            this.removeChildrenToolStripMenuItem.Click += new System.EventHandler(this.removeChildrenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmUp
            // 
            this.tsmUp.Name = "tsmUp";
            this.tsmUp.Size = new System.Drawing.Size(211, 22);
            this.tsmUp.Text = "Up (&I)";
            this.tsmUp.Click += new System.EventHandler(this.tsmUp_Click);
            // 
            // tsmDown
            // 
            this.tsmDown.Name = "tsmDown";
            this.tsmDown.Size = new System.Drawing.Size(211, 22);
            this.tsmDown.Text = "Down (&K)";
            this.tsmDown.Click += new System.EventHandler(this.tsmDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmIndependent
            // 
            this.tsmIndependent.Name = "tsmIndependent";
            this.tsmIndependent.Size = new System.Drawing.Size(211, 22);
            this.tsmIndependent.Text = "Independent (&J)";
            this.tsmIndependent.Click += new System.EventHandler(this.tsmIndependent_Click);
            // 
            // tsmBelongTo
            // 
            this.tsmBelongTo.Name = "tsmBelongTo";
            this.tsmBelongTo.Size = new System.Drawing.Size(211, 22);
            this.tsmBelongTo.Text = "Belong To (&L)";
            this.tsmBelongTo.Click += new System.EventHandler(this.tsmBelongTo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmProperties
            // 
            this.tsmProperties.Name = "tsmProperties";
            this.tsmProperties.Size = new System.Drawing.Size(211, 22);
            this.tsmProperties.Text = "Properties";
            this.tsmProperties.Click += new System.EventHandler(this.tsmProperties_Click);
            // 
            // iglIcon
            // 
            this.iglIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglIcon.ImageStream")));
            this.iglIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.iglIcon.Images.SetKeyName(0, "Link_Link_Avail.png");
            this.iglIcon.Images.SetKeyName(1, "Link_Link_Unavail.png");
            this.iglIcon.Images.SetKeyName(2, "Link_Note_Avail.png");
            this.iglIcon.Images.SetKeyName(3, "Link_Note_Unavail.png");
            this.iglIcon.Images.SetKeyName(4, "Link_Jump_Avail.png");
            this.iglIcon.Images.SetKeyName(5, "Link_Jump_Unavail.png");
            this.iglIcon.Images.SetKeyName(6, "Link_Litr_Avail.png");
            this.iglIcon.Images.SetKeyName(7, "Link_Litr_Unavail.png");
            this.iglIcon.Images.SetKeyName(8, "Link_Schl_Avail.png");
            this.iglIcon.Images.SetKeyName(9, "Link_Schl_Unavail.png");
            this.iglIcon.Images.SetKeyName(10, "Link_Recd_Avail.png");
            this.iglIcon.Images.SetKeyName(11, "Link_Recd_Unavail.png");
            this.iglIcon.Images.SetKeyName(12, "Link_Trsa_Avail.png");
            this.iglIcon.Images.SetKeyName(13, "Link_Trsa_Unavail.png");
            this.iglIcon.Images.SetKeyName(14, "Note_DDL.png");
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtLiteratureTitle, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cbxTask, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lsvTag, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(543, 178);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Topic";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel4.Controls.Add(this.txtTopic, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkFinished, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(89, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(454, 24);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // txtTopic
            // 
            this.txtTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTopic.Location = new System.Drawing.Point(3, 3);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(355, 21);
            this.txtTopic.TabIndex = 0;
            this.txtTopic.TextChanged += new System.EventHandler(this.txtTopic_TextChanged);
            // 
            // chkFinished
            // 
            this.chkFinished.AutoSize = true;
            this.chkFinished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFinished.Location = new System.Drawing.Point(363, 2);
            this.chkFinished.Margin = new System.Windows.Forms.Padding(2);
            this.chkFinished.Name = "chkFinished";
            this.chkFinished.Size = new System.Drawing.Size(89, 20);
            this.chkFinished.TabIndex = 1;
            this.chkFinished.Text = "Finished";
            this.chkFinished.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Literature";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLiteratureTitle
            // 
            this.txtLiteratureTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLiteratureTitle.Location = new System.Drawing.Point(92, 51);
            this.txtLiteratureTitle.Name = "txtLiteratureTitle";
            this.txtLiteratureTitle.Size = new System.Drawing.Size(448, 21);
            this.txtLiteratureTitle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Task";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxTask
            // 
            this.cbxTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTask.FormattingEnabled = true;
            this.cbxTask.Location = new System.Drawing.Point(92, 27);
            this.cbxTask.Name = "cbxTask";
            this.cbxTask.Size = new System.Drawing.Size(448, 20);
            this.cbxTask.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 55);
            this.label5.TabIndex = 9;
            this.label5.Text = "Keywords";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel5.Controls.Add(this.lsvColor, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(89, 123);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(454, 55);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // lsvColor
            // 
            this.lsvColor.ContextMenuStrip = this.cmsNoteColor;
            this.lsvColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvColor.HideSelection = false;
            this.lsvColor.Location = new System.Drawing.Point(3, 3);
            this.lsvColor.Name = "lsvColor";
            this.lsvColor.Size = new System.Drawing.Size(355, 49);
            this.lsvColor.TabIndex = 3;
            this.lsvColor.UseCompatibleStateImageBehavior = false;
            this.lsvColor.View = System.Windows.Forms.View.List;
            // 
            // cmsNoteColor
            // 
            this.cmsNoteColor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddColor,
            this.tsmRemoveColor});
            this.cmsNoteColor.Name = "cmsNoteColor";
            this.cmsNoteColor.Size = new System.Drawing.Size(124, 48);
            // 
            // tsmAddColor
            // 
            this.tsmAddColor.Name = "tsmAddColor";
            this.tsmAddColor.Size = new System.Drawing.Size(123, 22);
            this.tsmAddColor.Text = "Add";
            this.tsmAddColor.Click += new System.EventHandler(this.tsmAddColor_Click);
            // 
            // tsmRemoveColor
            // 
            this.tsmRemoveColor.Name = "tsmRemoveColor";
            this.tsmRemoveColor.Size = new System.Drawing.Size(123, 22);
            this.tsmRemoveColor.Text = "Remove";
            this.tsmRemoveColor.Click += new System.EventHandler(this.tsmRemoveColor_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.txtHighlight, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnHighlight, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(361, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(93, 55);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // txtHighlight
            // 
            this.txtHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHighlight.Location = new System.Drawing.Point(3, 3);
            this.txtHighlight.Name = "txtHighlight";
            this.txtHighlight.Size = new System.Drawing.Size(87, 21);
            this.txtHighlight.TabIndex = 0;
            this.txtHighlight.TextChanged += new System.EventHandler(this.txtHighlight_TextChanged);
            // 
            // btnHighlight
            // 
            this.btnHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHighlight.Location = new System.Drawing.Point(3, 30);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(87, 22);
            this.btnHighlight.TabIndex = 1;
            this.btnHighlight.Text = "Highlight";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 51);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tag";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsvTag
            // 
            this.lsvTag.ContextMenuStrip = this.cmsNoteTag;
            this.lsvTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvTag.HideSelection = false;
            this.lsvTag.Location = new System.Drawing.Point(92, 75);
            this.lsvTag.Name = "lsvTag";
            this.lsvTag.Size = new System.Drawing.Size(448, 45);
            this.lsvTag.TabIndex = 12;
            this.lsvTag.UseCompatibleStateImageBehavior = false;
            this.lsvTag.View = System.Windows.Forms.View.List;
            // 
            // cmsNoteTag
            // 
            this.cmsNoteTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddTag,
            this.tsmRemoveTag});
            this.cmsNoteTag.Name = "cmsNoteTag";
            this.cmsNoteTag.Size = new System.Drawing.Size(124, 48);
            // 
            // tsmAddTag
            // 
            this.tsmAddTag.Name = "tsmAddTag";
            this.tsmAddTag.Size = new System.Drawing.Size(123, 22);
            this.tsmAddTag.Text = "Add";
            this.tsmAddTag.Click += new System.EventHandler(this.tsmAddTag_Click);
            // 
            // tsmRemoveTag
            // 
            this.tsmRemoveTag.Name = "tsmRemoveTag";
            this.tsmRemoveTag.Size = new System.Drawing.Size(123, 22);
            this.tsmRemoveTag.Text = "Remove";
            this.tsmRemoveTag.Click += new System.EventHandler(this.tsmRemoveTag_Click);
            // 
            // frmInfoNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 656);
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.cmsNoteColor.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.cmsNoteTag.ResumeLayout(false);
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
        private System.Windows.Forms.ImageList iglIcon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip cmsNoteColor;
        private System.Windows.Forms.ToolStripMenuItem tsmAddColor;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveColor;
        private System.Windows.Forms.ListView lsvColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.CheckBox chkFinished;
        private System.Windows.Forms.TextBox txtLiteratureTitle;
        private System.Windows.Forms.ComboBox cbxTask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeLabel;
        private System.Windows.Forms.ToolStripMenuItem tsmAddBatch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem removeChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmGoto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsmReplace;
        private System.Windows.Forms.ToolStripMenuItem tsmPrepend;
        private System.Windows.Forms.ToolStripMenuItem tsmAppend;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmProperties;
        private System.Windows.Forms.ToolStripMenuItem tsmFold;
        private System.Windows.Forms.ToolStripMenuItem tsmExpand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox txtHighlight;
        private System.Windows.Forms.Button btnHighlight;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvTag;
        private System.Windows.Forms.ContextMenuStrip cmsNoteTag;
        private System.Windows.Forms.ToolStripMenuItem tsmAddTag;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveTag;
        private System.Windows.Forms.ToolStripMenuItem tsmConvertToSchedule;
        private System.Windows.Forms.ToolStripMenuItem tsmConvertToLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmConvertToTransaction;
    }
}