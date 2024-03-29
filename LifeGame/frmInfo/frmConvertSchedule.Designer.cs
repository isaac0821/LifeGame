﻿namespace LifeGame
{
    partial class frmConvertSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertSchedule));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lsbSchedule = new System.Windows.Forms.ListBox();
            this.cmsConvert = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.cmsConvert.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lsbSchedule, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 333);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lsbSchedule
            // 
            this.lsbSchedule.ContextMenuStrip = this.cmsConvert;
            this.lsbSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbSchedule.FormattingEnabled = true;
            this.lsbSchedule.ItemHeight = 12;
            this.lsbSchedule.Location = new System.Drawing.Point(3, 31);
            this.lsbSchedule.Name = "lsbSchedule";
            this.lsbSchedule.Size = new System.Drawing.Size(404, 299);
            this.lsbSchedule.TabIndex = 0;
            // 
            // cmsConvert
            // 
            this.cmsConvert.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsConvert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConvert});
            this.cmsConvert.Name = "cmsConvert";
            this.cmsConvert.Size = new System.Drawing.Size(122, 26);
            // 
            // tsmConvert
            // 
            this.tsmConvert.Name = "tsmConvert";
            this.tsmConvert.Size = new System.Drawing.Size(121, 22);
            this.tsmConvert.Text = "Convert";
            this.tsmConvert.Click += new System.EventHandler(this.tsmConvert_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel2.Controls.Add(this.dtpDate, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(404, 22);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(306, 3);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(95, 21);
            this.dtpDate.TabIndex = 0;
            // 
            // frmConvertSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 333);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConvertSchedule";
            this.Text = "LifeGame - Convert Schedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConvertSchedule_FormClosing);
            this.Load += new System.EventHandler(this.frmConvertSchedule_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.cmsConvert.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lsbSchedule;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ContextMenuStrip cmsConvert;
        private System.Windows.Forms.ToolStripMenuItem tsmConvert;
    }
}