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
            this.lblVendorName = new System.Windows.Forms.Label();
            this.lblPoDate = new System.Windows.Forms.Label();
            this.lblPoGrp = new System.Windows.Forms.Label();
            this.lblPoDocTypeVal = new System.Windows.Forms.Label();
            this.lblVendorNameVal = new System.Windows.Forms.Label();
            this.lblPoDateVal = new System.Windows.Forms.Label();
            this.lblPoGrpVal = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStack)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPoItem
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)), true);
            this.dgvPoItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPoItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPoItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoItem.Location = new System.Drawing.Point(13, 116);
            this.dgvPoItem.Name = "dgvPoItem";
            this.dgvPoItem.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvPoItem.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPoItem.RowTemplate.Height = 24;
            this.dgvPoItem.Size = new System.Drawing.Size(831, 260);
            this.dgvPoItem.TabIndex = 1;
            this.dgvPoItem.TabStop = false;
            // 
            // lblInputPO
            // 
            this.lblInputPO.AutoSize = true;
            this.lblInputPO.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblInputPO.Location = new System.Drawing.Point(12, 18);
            this.lblInputPO.Name = "lblInputPO";
            this.lblInputPO.Size = new System.Drawing.Size(104, 16);
            this.lblInputPO.TabIndex = 3;
            this.lblInputPO.Text = "輸入採購單號";
            // 
            // txtPONum
            // 
            this.txtPONum.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.txtPONum.Location = new System.Drawing.Point(122, 15);
            this.txtPONum.Name = "txtPONum";
            this.txtPONum.Size = new System.Drawing.Size(134, 27);
            this.txtPONum.TabIndex = 1;
            // 
            // btnPoSubmit
            // 
            this.btnPoSubmit.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnPoSubmit.Location = new System.Drawing.Point(262, 14);
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
            this.dgvStack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvStack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStack.Location = new System.Drawing.Point(13, 395);
            this.dgvStack.Name = "dgvStack";
            this.dgvStack.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvStack.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStack.RowTemplate.Height = 24;
            this.dgvStack.Size = new System.Drawing.Size(831, 241);
            this.dgvStack.TabIndex = 4;
            this.dgvStack.TabStop = false;
            // 
            // btnSelected
            // 
            this.btnSelected.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnSelected.Location = new System.Drawing.Point(12, 71);
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
            this.btnComplete.Location = new System.Drawing.Point(122, 68);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(86, 30);
            this.btnComplete.TabIndex = 6;
            this.btnComplete.TabStop = false;
            this.btnComplete.Text = "選取完畢";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnClear.Location = new System.Drawing.Point(320, 13);
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
            this.btnRestart.Location = new System.Drawing.Point(286, 68);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(86, 30);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.TabStop = false;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // lblPoDocType
            // 
            this.lblPoDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoDocType.AutoSize = true;
            this.lblPoDocType.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblPoDocType.Location = new System.Drawing.Point(617, 15);
            this.lblPoDocType.Name = "lblPoDocType";
            this.lblPoDocType.Size = new System.Drawing.Size(88, 16);
            this.lblPoDocType.TabIndex = 9;
            this.lblPoDocType.Text = "採單類型：";
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblVendorName.Location = new System.Drawing.Point(12, 46);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(56, 16);
            this.lblVendorName.TabIndex = 11;
            this.lblVendorName.Text = "廠商：";
            // 
            // lblPoDate
            // 
            this.lblPoDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPoDate.AutoSize = true;
            this.lblPoDate.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblPoDate.Location = new System.Drawing.Point(379, 18);
            this.lblPoDate.Name = "lblPoDate";
            this.lblPoDate.Size = new System.Drawing.Size(88, 16);
            this.lblPoDate.TabIndex = 12;
            this.lblPoDate.Text = "採單日期：";
            // 
            // lblPoGrp
            // 
            this.lblPoGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoGrp.AutoSize = true;
            this.lblPoGrp.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblPoGrp.Location = new System.Drawing.Point(617, 46);
            this.lblPoGrp.Name = "lblPoGrp";
            this.lblPoGrp.Size = new System.Drawing.Size(88, 16);
            this.lblPoGrp.TabIndex = 13;
            this.lblPoGrp.Text = "採購群組：";
            // 
            // lblPoDocTypeVal
            // 
            this.lblPoDocTypeVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoDocTypeVal.AutoSize = true;
            this.lblPoDocTypeVal.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblPoDocTypeVal.Location = new System.Drawing.Point(698, 15);
            this.lblPoDocTypeVal.Name = "lblPoDocTypeVal";
            this.lblPoDocTypeVal.Size = new System.Drawing.Size(0, 16);
            this.lblPoDocTypeVal.TabIndex = 15;
            // 
            // lblVendorNameVal
            // 
            this.lblVendorNameVal.AutoSize = true;
            this.lblVendorNameVal.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblVendorNameVal.Location = new System.Drawing.Point(60, 46);
            this.lblVendorNameVal.Name = "lblVendorNameVal";
            this.lblVendorNameVal.Size = new System.Drawing.Size(0, 16);
            this.lblVendorNameVal.TabIndex = 16;
            // 
            // lblPoDateVal
            // 
            this.lblPoDateVal.AutoSize = true;
            this.lblPoDateVal.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblPoDateVal.Location = new System.Drawing.Point(462, 18);
            this.lblPoDateVal.Name = "lblPoDateVal";
            this.lblPoDateVal.Size = new System.Drawing.Size(0, 16);
            this.lblPoDateVal.TabIndex = 17;
            // 
            // lblPoGrpVal
            // 
            this.lblPoGrpVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoGrpVal.AutoSize = true;
            this.lblPoGrpVal.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblPoGrpVal.Location = new System.Drawing.Point(698, 46);
            this.lblPoGrpVal.Name = "lblPoGrpVal";
            this.lblPoGrpVal.Size = new System.Drawing.Size(0, 16);
            this.lblPoGrpVal.TabIndex = 18;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip2.Location = new System.Drawing.Point(0, 653);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(857, 22);
            this.statusStrip2.TabIndex = 19;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 675);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.lblPoGrpVal);
            this.Controls.Add(this.lblPoDateVal);
            this.Controls.Add(this.lblVendorNameVal);
            this.Controls.Add(this.lblPoDocTypeVal);
            this.Controls.Add(this.lblPoGrp);
            this.Controls.Add(this.lblPoDate);
            this.Controls.Add(this.lblVendorName);
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
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
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
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.Label lblPoDate;
        private System.Windows.Forms.Label lblPoGrp;
        private System.Windows.Forms.Label lblPoDocTypeVal;
        private System.Windows.Forms.Label lblVendorNameVal;
        private System.Windows.Forms.Label lblPoDateVal;
        private System.Windows.Forms.Label lblPoGrpVal;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}