namespace LifeGame
{
    partial class frmDelInfoMine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDelInfoMine));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lsbEvent = new System.Windows.Forms.ListBox();
            this.cmsDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lsbTransaction = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lsbTransactionDue = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lsbWorkOut = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lsbMedicine = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cmsDelete.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 444);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.Controls.Add(this.dtpDate, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(539, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(408, 4);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(127, 22);
            this.dtpDate.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(4, 41);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 399);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lsbEvent);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(531, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Event";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lsbEvent
            // 
            this.lsbEvent.ContextMenuStrip = this.cmsDelete;
            this.lsbEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbEvent.FormattingEnabled = true;
            this.lsbEvent.ItemHeight = 16;
            this.lsbEvent.Location = new System.Drawing.Point(4, 4);
            this.lsbEvent.Margin = new System.Windows.Forms.Padding(4);
            this.lsbEvent.Name = "lsbEvent";
            this.lsbEvent.Size = new System.Drawing.Size(523, 362);
            this.lsbEvent.TabIndex = 1;
            // 
            // cmsDelete
            // 
            this.cmsDelete.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(123, 28);
            this.cmsDelete.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDelete_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lsbTransaction);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(531, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transaction";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lsbTransaction
            // 
            this.lsbTransaction.ContextMenuStrip = this.cmsDelete;
            this.lsbTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbTransaction.FormattingEnabled = true;
            this.lsbTransaction.ItemHeight = 16;
            this.lsbTransaction.Location = new System.Drawing.Point(4, 4);
            this.lsbTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.lsbTransaction.Name = "lsbTransaction";
            this.lsbTransaction.Size = new System.Drawing.Size(523, 362);
            this.lsbTransaction.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lsbTransactionDue);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(531, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Transaction Due";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lsbTransactionDue
            // 
            this.lsbTransactionDue.ContextMenuStrip = this.cmsDelete;
            this.lsbTransactionDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbTransactionDue.FormattingEnabled = true;
            this.lsbTransactionDue.ItemHeight = 16;
            this.lsbTransactionDue.Location = new System.Drawing.Point(4, 4);
            this.lsbTransactionDue.Margin = new System.Windows.Forms.Padding(4);
            this.lsbTransactionDue.Name = "lsbTransactionDue";
            this.lsbTransactionDue.Size = new System.Drawing.Size(523, 362);
            this.lsbTransactionDue.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lsbWorkOut);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(531, 370);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Work Out";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lsbWorkOut
            // 
            this.lsbWorkOut.ContextMenuStrip = this.cmsDelete;
            this.lsbWorkOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbWorkOut.FormattingEnabled = true;
            this.lsbWorkOut.ItemHeight = 16;
            this.lsbWorkOut.Location = new System.Drawing.Point(4, 4);
            this.lsbWorkOut.Margin = new System.Windows.Forms.Padding(4);
            this.lsbWorkOut.Name = "lsbWorkOut";
            this.lsbWorkOut.Size = new System.Drawing.Size(523, 362);
            this.lsbWorkOut.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lsbMedicine);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(531, 370);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Medicine";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lsbMedicine
            // 
            this.lsbMedicine.ContextMenuStrip = this.cmsDelete;
            this.lsbMedicine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbMedicine.FormattingEnabled = true;
            this.lsbMedicine.ItemHeight = 16;
            this.lsbMedicine.Location = new System.Drawing.Point(4, 4);
            this.lsbMedicine.Margin = new System.Windows.Forms.Padding(4);
            this.lsbMedicine.Name = "lsbMedicine";
            this.lsbMedicine.Size = new System.Drawing.Size(523, 362);
            this.lsbMedicine.TabIndex = 0;
            // 
            // frmDelInfoMine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 444);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDelInfoMine";
            this.Text = "LifeGame - Delete Info Mine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDelInfoMine_FormClosing);
            this.Load += new System.EventHandler(this.frmDelInfoMine_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.cmsDelete.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lsbEvent;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListBox lsbTransaction;
        private System.Windows.Forms.ListBox lsbTransactionDue;
        private System.Windows.Forms.ListBox lsbWorkOut;
        private System.Windows.Forms.ListBox lsbMedicine;
        private System.Windows.Forms.ContextMenuStrip cmsDelete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}