namespace LifeGame
{
    partial class frmInfoTransactionDues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoTransactionDues));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTransaction = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCreditAccount = new System.Windows.Forms.Label();
            this.lblDebitAccount = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpTransaction.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tlpTransaction, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(773, 234);
            this.tableLayoutPanel3.TabIndex = 2;
            this.tableLayoutPanel3.Click += new System.EventHandler(this.tableLayoutPanel3_Click);
            // 
            // tlpTransaction
            // 
            this.tlpTransaction.ColumnCount = 1;
            this.tlpTransaction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTransaction.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tlpTransaction.Controls.Add(this.lblSummary, 0, 1);
            this.tlpTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTransaction.Location = new System.Drawing.Point(13, 12);
            this.tlpTransaction.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tlpTransaction.Name = "tlpTransaction";
            this.tlpTransaction.RowCount = 4;
            this.tlpTransaction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTransaction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpTransaction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpTransaction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTransaction.Size = new System.Drawing.Size(747, 210);
            this.tlpTransaction.TabIndex = 0;
            this.tlpTransaction.Click += new System.EventHandler(this.tlpTransaction_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Controls.Add(this.lblCreditAccount, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDebitAccount, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 84);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(747, 82);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblCreditAccount
            // 
            this.lblCreditAccount.AutoSize = true;
            this.lblCreditAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreditAccount.Location = new System.Drawing.Point(31, 0);
            this.lblCreditAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreditAccount.Name = "lblCreditAccount";
            this.lblCreditAccount.Size = new System.Drawing.Size(249, 82);
            this.lblCreditAccount.TabIndex = 0;
            this.lblCreditAccount.Text = "label2";
            this.lblCreditAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCreditAccount.Click += new System.EventHandler(this.lblCreditAccount_Click);
            // 
            // lblDebitAccount
            // 
            this.lblDebitAccount.AutoSize = true;
            this.lblDebitAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebitAccount.Location = new System.Drawing.Point(467, 0);
            this.lblDebitAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDebitAccount.Name = "lblDebitAccount";
            this.lblDebitAccount.Size = new System.Drawing.Size(249, 82);
            this.lblDebitAccount.TabIndex = 1;
            this.lblDebitAccount.Text = "label3";
            this.lblDebitAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDebitAccount.Click += new System.EventHandler(this.lblDebitAccount_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblAmount, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(284, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(179, 82);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 41);
            this.label4.TabIndex = 0;
            this.label4.Text = "====>";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmount.Location = new System.Drawing.Point(4, 41);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(171, 41);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "label5";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAmount.Click += new System.EventHandler(this.lblAmount_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSummary.Location = new System.Drawing.Point(4, 43);
            this.lblSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(739, 41);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "label1";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSummary.Click += new System.EventHandler(this.lblSummary_Click);
            // 
            // frmInfoTransactionDues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 234);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInfoTransactionDues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LifeGame - TransactionDues";
            this.Deactivate += new System.EventHandler(this.frmInfoTransactionDues_Deactivate);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tlpTransaction.ResumeLayout(false);
            this.tlpTransaction.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tlpTransaction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCreditAccount;
        private System.Windows.Forms.Label lblDebitAccount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblSummary;
    }
}