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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPoItem = new System.Windows.Forms.DataGridView();
            this.lblInputPO = new System.Windows.Forms.Label();
            this.txtPONum = new System.Windows.Forms.TextBox();
            this.btnPoSubmit = new System.Windows.Forms.Button();
            this.dgvStack = new System.Windows.Forms.DataGridView();
            this.btnSelected = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblPoDocType = new System.Windows.Forms.Label();
            this.lblPoNum = new System.Windows.Forms.Label();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.lblPoDate = new System.Windows.Forms.Label();
            this.lblPoGrp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStack)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPoItem
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)), true);
            this.dgvPoItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPoItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoItem.Location = new System.Drawing.Point(12, 105);
            this.dgvPoItem.Name = "dgvPoItem";
            this.dgvPoItem.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvPoItem.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPoItem.RowTemplate.Height = 24;
            this.dgvPoItem.Size = new System.Drawing.Size(831, 262);
            this.dgvPoItem.TabIndex = 1;
            this.dgvPoItem.TabStop = false;
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
            // dgvStack
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)), true);
            this.dgvStack.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStack.Location = new System.Drawing.Point(12, 406);
            this.dgvStack.Name = "dgvStack";
            this.dgvStack.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvStack.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStack.RowTemplate.Height = 24;
            this.dgvStack.Size = new System.Drawing.Size(831, 234);
            this.dgvStack.TabIndex = 4;
            this.dgvStack.TabStop = false;
            // 
            // btnSelected
            // 
            this.btnSelected.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnSelected.Location = new System.Drawing.Point(12, 373);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(37, 27);
            this.btnSelected.TabIndex = 5;
            this.btnSelected.TabStop = false;
            this.btnSelected.Text = "︾";
            this.btnSelected.UseVisualStyleBackColor = true;
            this.btnSelected.Click += new System.EventHandler(this.btnSelected_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnComplete.Location = new System.Drawing.Point(12, 646);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(86, 30);
            this.btnComplete.TabIndex = 6;
            this.btnComplete.TabStop = false;
            this.btnComplete.Text = "選取完畢";
            this.btnComplete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnClear.Location = new System.Drawing.Point(321, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 26);
            this.btnClear.TabIndex = 7;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnRestart.Location = new System.Drawing.Point(757, 646);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(86, 30);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.TabStop = false;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // lblPoDocType
            // 
            this.lblPoDocType.AutoSize = true;
            this.lblPoDocType.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.lblPoDocType.Location = new System.Drawing.Point(12, 83);
            this.lblPoDocType.Name = "lblPoDocType";
            this.lblPoDocType.Size = new System.Drawing.Size(104, 19);
            this.lblPoDocType.TabIndex = 9;
            this.lblPoDocType.Text = "採單類型：";
            // 
            // lblPoNum
            // 
            this.lblPoNum.AutoSize = true;
            this.lblPoNum.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.lblPoNum.Location = new System.Drawing.Point(12, 55);
            this.lblPoNum.Name = "lblPoNum";
            this.lblPoNum.Size = new System.Drawing.Size(104, 19);
            this.lblPoNum.TabIndex = 10;
            this.lblPoNum.Text = "採單號碼：";
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.lblVendorName.Location = new System.Drawing.Point(259, 83);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(66, 19);
            this.lblVendorName.TabIndex = 11;
            this.lblVendorName.Text = "廠商：";
            // 
            // lblPoDate
            // 
            this.lblPoDate.AutoSize = true;
            this.lblPoDate.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.lblPoDate.Location = new System.Drawing.Point(259, 55);
            this.lblPoDate.Name = "lblPoDate";
            this.lblPoDate.Size = new System.Drawing.Size(104, 19);
            this.lblPoDate.TabIndex = 12;
            this.lblPoDate.Text = "採單日期：";
            // 
            // lblPoGrp
            // 
            this.lblPoGrp.AutoSize = true;
            this.lblPoGrp.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.lblPoGrp.Location = new System.Drawing.Point(480, 55);
            this.lblPoGrp.Name = "lblPoGrp";
            this.lblPoGrp.Size = new System.Drawing.Size(104, 19);
            this.lblPoGrp.TabIndex = 13;
            this.lblPoGrp.Text = "採購群組：";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 688);
            this.Controls.Add(this.lblPoGrp);
            this.Controls.Add(this.lblPoDate);
            this.Controls.Add(this.lblVendorName);
            this.Controls.Add(this.lblPoNum);
            this.Controls.Add(this.lblPoDocType);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnSelected);
            this.Controls.Add(this.dgvStack);
            this.Controls.Add(this.btnPoSubmit);
            this.Controls.Add(this.txtPONum);
            this.Controls.Add(this.lblInputPO);
            this.Controls.Add(this.dgvPoItem);
            this.Name = "Form2";
            this.Text = "選取採購單";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPoItem;
        private System.Windows.Forms.Label lblInputPO;
        private System.Windows.Forms.TextBox txtPONum;
        private System.Windows.Forms.Button btnPoSubmit;
        private System.Windows.Forms.DataGridView dgvStack;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblPoDocType;
        private System.Windows.Forms.Label lblPoNum;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.Label lblPoDate;
        private System.Windows.Forms.Label lblPoGrp;
    }
}