namespace LifeGame
{
    partial class frmConvertTransactionDue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertTransactionDue));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lsbTransactionDue = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmsConvert = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.cmsConvert.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lsbTransactionDue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 444);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lsbTransactionDue
            // 
            this.lsbTransactionDue.ContextMenuStrip = this.cmsConvert;
            this.lsbTransactionDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbTransactionDue.FormattingEnabled = true;
            this.lsbTransactionDue.ItemHeight = 16;
            this.lsbTransactionDue.Location = new System.Drawing.Point(4, 41);
            this.lsbTransactionDue.Margin = new System.Windows.Forms.Padding(4);
            this.lsbTransactionDue.Name = "lsbTransactionDue";
            this.lsbTransactionDue.Size = new System.Drawing.Size(539, 399);
            this.lsbTransactionDue.TabIndex = 0;
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
            // cmsConvert
            // 
            this.cmsConvert.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsConvert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConvert});
            this.cmsConvert.Name = "cmsConvert";
            this.cmsConvert.Size = new System.Drawing.Size(130, 28);
            // 
            // tsmConvert
            // 
            this.tsmConvert.Name = "tsmConvert";
            this.tsmConvert.Size = new System.Drawing.Size(129, 24);
            this.tsmConvert.Text = "Convert";
            this.tsmConvert.Click += new System.EventHandler(this.tsmConvert_Click);
            // 
            // frmConvertTransactionDue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 444);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConvertTransactionDue";
            this.Text = "LifeGame - Convert Transaction Due";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConvertTransactionDue_FormClosing);
            this.Load += new System.EventHandler(this.frmConvertTransactionDue_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.cmsConvert.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lsbTransactionDue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ContextMenuStrip cmsConvert;
        private System.Windows.Forms.ToolStripMenuItem tsmConvert;
    }
}