namespace POR
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserNameValue = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblDisplayNameValue = new System.Windows.Forms.Label();
            this.dgvPO = new System.Windows.Forms.DataGridView();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnPickPO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 605);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(713, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserName.Location = new System.Drawing.Point(12, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(41, 20);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "帳號";
            // 
            // lblUserNameValue
            // 
            this.lblUserNameValue.AutoSize = true;
            this.lblUserNameValue.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserNameValue.Location = new System.Drawing.Point(59, 9);
            this.lblUserNameValue.Name = "lblUserNameValue";
            this.lblUserNameValue.Size = new System.Drawing.Size(54, 20);
            this.lblUserNameValue.TabIndex = 2;
            this.lblUserNameValue.Text = "00575";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDisplayName.Location = new System.Drawing.Point(119, 9);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(41, 20);
            this.lblDisplayName.TabIndex = 3;
            this.lblDisplayName.Text = "姓名";
            // 
            // lblDisplayNameValue
            // 
            this.lblDisplayNameValue.AutoSize = true;
            this.lblDisplayNameValue.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDisplayNameValue.Location = new System.Drawing.Point(163, 9);
            this.lblDisplayNameValue.Name = "lblDisplayNameValue";
            this.lblDisplayNameValue.Size = new System.Drawing.Size(57, 20);
            this.lblDisplayNameValue.TabIndex = 4;
            this.lblDisplayNameValue.Text = "一二三";
            // 
            // dgvPO
            // 
            this.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPO.Location = new System.Drawing.Point(16, 260);
            this.dgvPO.Name = "dgvPO";
            this.dgvPO.RowTemplate.Height = 24;
            this.dgvPO.Size = new System.Drawing.Size(685, 201);
            this.dgvPO.TabIndex = 6;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMsg.Location = new System.Drawing.Point(12, 237);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(57, 20);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "一二三";
            // 
            // btnPickPO
            // 
            this.btnPickPO.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnPickPO.Location = new System.Drawing.Point(16, 46);
            this.btnPickPO.Name = "btnPickPO";
            this.btnPickPO.Size = new System.Drawing.Size(104, 23);
            this.btnPickPO.TabIndex = 8;
            this.btnPickPO.Text = " 選取採購單";
            this.btnPickPO.UseVisualStyleBackColor = true;
            this.btnPickPO.Click += new System.EventHandler(this.btnPickPO_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 627);
            this.Controls.Add(this.btnPickPO);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.dgvPO);
            this.Controls.Add(this.lblDisplayNameValue);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.lblUserNameValue);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "收料程式 POR";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserNameValue;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblDisplayNameValue;
        private System.Windows.Forms.DataGridView dgvPO;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnPickPO;
    }
}

