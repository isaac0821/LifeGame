
namespace LifeGame
{
    partial class frmInfoLiteratureSurvey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoLiteratureSurvey));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLiterature = new System.Windows.Forms.Label();
            this.lblSurvey = new System.Windows.Forms.Label();
            this.dgvLiteratureSurvey = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiteratureSurvey)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.79928F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.20072F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLiterature, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSurvey, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvLiteratureSurvey, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(558, 260);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Literature";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Survey";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 182);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tags";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLiterature
            // 
            this.lblLiterature.AutoSize = true;
            this.lblLiterature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLiterature.Location = new System.Drawing.Point(79, 0);
            this.lblLiterature.Name = "lblLiterature";
            this.lblLiterature.Size = new System.Drawing.Size(476, 52);
            this.lblLiterature.TabIndex = 3;
            this.lblLiterature.Text = "(Literature Title)";
            this.lblLiterature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSurvey
            // 
            this.lblSurvey.AutoSize = true;
            this.lblSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSurvey.Location = new System.Drawing.Point(79, 52);
            this.lblSurvey.Name = "lblSurvey";
            this.lblSurvey.Size = new System.Drawing.Size(476, 26);
            this.lblSurvey.TabIndex = 4;
            this.lblSurvey.Text = "(Survey Name)";
            this.lblSurvey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLiteratureSurvey
            // 
            this.dgvLiteratureSurvey.AllowUserToAddRows = false;
            this.dgvLiteratureSurvey.AllowUserToDeleteRows = false;
            this.dgvLiteratureSurvey.AllowUserToOrderColumns = true;
            this.dgvLiteratureSurvey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiteratureSurvey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colName,
            this.colValue});
            this.dgvLiteratureSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLiteratureSurvey.Location = new System.Drawing.Point(79, 81);
            this.dgvLiteratureSurvey.Name = "dgvLiteratureSurvey";
            this.dgvLiteratureSurvey.ReadOnly = true;
            this.dgvLiteratureSurvey.Size = new System.Drawing.Size(476, 176);
            this.dgvLiteratureSurvey.TabIndex = 5;
            this.dgvLiteratureSurvey.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLiteratureSurvey_CellContentClick);
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colType.Width = 80;
            // 
            // colName
            // 
            this.colName.HeaderText = "Tag Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colName.Width = 150;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.Width = 200;
            // 
            // frmInfoLiteratureSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 260);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfoLiteratureSurvey";
            this.Text = "LifeGame - Literature/Survey - Info";
            this.Load += new System.EventHandler(this.frmInfoLiteratureSurvey_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiteratureSurvey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLiterature;
        private System.Windows.Forms.Label lblSurvey;
        private System.Windows.Forms.DataGridView dgvLiteratureSurvey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
    }
}