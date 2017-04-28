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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPoHeader = new System.Windows.Forms.DataGridView();
            this.dgvPoItem = new System.Windows.Forms.DataGridView();
            this.lblInputPO = new System.Windows.Forms.Label();
            this.txtPONum = new System.Windows.Forms.TextBox();
            this.btnPoSubmit = new System.Windows.Forms.Button();
            this.dgvStack = new System.Windows.Forms.DataGridView();
            this.btnSelected = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStack)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPoHeader
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)), true);
            this.dgvPoHeader.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPoHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoHeader.Location = new System.Drawing.Point(12, 48);
            this.dgvPoHeader.Name = "dgvPoHeader";
            this.dgvPoHeader.ReadOnly = true;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvPoHeader.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPoHeader.RowTemplate.Height = 24;
            this.dgvPoHeader.Size = new System.Drawing.Size(685, 72);
            this.dgvPoHeader.TabIndex = 0;
            this.dgvPoHeader.TabStop = false;
            // 
            // dgvPoItem
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)), true);
            this.dgvPoItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPoItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoItem.Location = new System.Drawing.Point(12, 126);
            this.dgvPoItem.Name = "dgvPoItem";
            this.dgvPoItem.ReadOnly = true;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvPoItem.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPoItem.RowTemplate.Height = 24;
            this.dgvPoItem.Size = new System.Drawing.Size(685, 150);
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
            dataGridViewCellStyle11.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)), true);
            this.dgvStack.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvStack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStack.Location = new System.Drawing.Point(12, 315);
            this.dgvStack.Name = "dgvStack";
            this.dgvStack.ReadOnly = true;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvStack.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvStack.RowTemplate.Height = 24;
            this.dgvStack.Size = new System.Drawing.Size(685, 160);
            this.dgvStack.TabIndex = 4;
            this.dgvStack.TabStop = false;
            // 
            // btnSelected
            // 
            this.btnSelected.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnSelected.Location = new System.Drawing.Point(330, 282);
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
            this.btnComplete.Location = new System.Drawing.Point(307, 481);
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
            this.btnRestart.Location = new System.Drawing.Point(611, 481);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(86, 30);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.TabStop = false;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 523);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnSelected);
            this.Controls.Add(this.dgvStack);
            this.Controls.Add(this.btnPoSubmit);
            this.Controls.Add(this.txtPONum);
            this.Controls.Add(this.lblInputPO);
            this.Controls.Add(this.dgvPoItem);
            this.Controls.Add(this.dgvPoHeader);
            this.Name = "Form2";
            this.Text = "選取採購單";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPoHeader;
        private System.Windows.Forms.DataGridView dgvPoItem;
        private System.Windows.Forms.Label lblInputPO;
        private System.Windows.Forms.TextBox txtPONum;
        private System.Windows.Forms.Button btnPoSubmit;
        private System.Windows.Forms.DataGridView dgvStack;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRestart;
    }
}