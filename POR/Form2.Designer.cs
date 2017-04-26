namespace POR
{
    partial class Form2
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
            this.dgvPoHeader = new System.Windows.Forms.DataGridView();
            this.dgvPoItem = new System.Windows.Forms.DataGridView();
            this.dgvPoAccount = new System.Windows.Forms.DataGridView();
            this.lblInputPO = new System.Windows.Forms.Label();
            this.txtPONum = new System.Windows.Forms.TextBox();
            this.btnPoSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPoHeader
            // 
            this.dgvPoHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoHeader.Location = new System.Drawing.Point(12, 204);
            this.dgvPoHeader.Name = "dgvPoHeader";
            this.dgvPoHeader.RowTemplate.Height = 24;
            this.dgvPoHeader.Size = new System.Drawing.Size(685, 150);
            this.dgvPoHeader.TabIndex = 0;
            // 
            // dgvPoItem
            // 
            this.dgvPoItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoItem.Location = new System.Drawing.Point(12, 360);
            this.dgvPoItem.Name = "dgvPoItem";
            this.dgvPoItem.RowTemplate.Height = 24;
            this.dgvPoItem.Size = new System.Drawing.Size(685, 150);
            this.dgvPoItem.TabIndex = 1;
            // 
            // dgvPoAccount
            // 
            this.dgvPoAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoAccount.Location = new System.Drawing.Point(12, 516);
            this.dgvPoAccount.Name = "dgvPoAccount";
            this.dgvPoAccount.RowTemplate.Height = 24;
            this.dgvPoAccount.Size = new System.Drawing.Size(685, 150);
            this.dgvPoAccount.TabIndex = 2;
            // 
            // lblInputPO
            // 
            this.lblInputPO.AutoSize = true;
            this.lblInputPO.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblInputPO.Location = new System.Drawing.Point(12, 16);
            this.lblInputPO.Name = "lblInputPO";
            this.lblInputPO.Size = new System.Drawing.Size(104, 16);
            this.lblInputPO.TabIndex = 3;
            this.lblInputPO.Text = "輸入採購單號";
            // 
            // txtPONum
            // 
            this.txtPONum.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.txtPONum.Location = new System.Drawing.Point(122, 13);
            this.txtPONum.Name = "txtPONum";
            this.txtPONum.Size = new System.Drawing.Size(134, 27);
            this.txtPONum.TabIndex = 1;
            // 
            // btnPoSubmit
            // 
            this.btnPoSubmit.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnPoSubmit.Location = new System.Drawing.Point(263, 16);
            this.btnPoSubmit.Name = "btnPoSubmit";
            this.btnPoSubmit.Size = new System.Drawing.Size(52, 26);
            this.btnPoSubmit.TabIndex = 2;
            this.btnPoSubmit.Text = "送出";
            this.btnPoSubmit.UseVisualStyleBackColor = true;
            this.btnPoSubmit.Click += new System.EventHandler(this.btnPoSubmit_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 678);
            this.Controls.Add(this.btnPoSubmit);
            this.Controls.Add(this.txtPONum);
            this.Controls.Add(this.lblInputPO);
            this.Controls.Add(this.dgvPoAccount);
            this.Controls.Add(this.dgvPoItem);
            this.Controls.Add(this.dgvPoHeader);
            this.Name = "Form2";
            this.Text = "選取採購單";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPoHeader;
        private System.Windows.Forms.DataGridView dgvPoItem;
        private System.Windows.Forms.DataGridView dgvPoAccount;
        private System.Windows.Forms.Label lblInputPO;
        private System.Windows.Forms.TextBox txtPONum;
        private System.Windows.Forms.Button btnPoSubmit;
    }
}