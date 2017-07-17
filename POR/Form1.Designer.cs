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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserAccount = new System.Windows.Forms.Label();
            this.lblUserAccountValue = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblDisplayNameValue = new System.Windows.Forms.Label();
            this.dgvPO = new System.Windows.Forms.DataGridView();
            this.btnPickPO = new System.Windows.Forms.Button();
            this.btnReadDt = new System.Windows.Forms.Button();
            this.btnToSap = new System.Windows.Forms.Button();
            this.lblMbt = new System.Windows.Forms.Label();
            this.btnHelpMvt = new System.Windows.Forms.Button();
            this.lblMdMemo = new System.Windows.Forms.Label();
            this.txtMdMemo = new System.Windows.Forms.TextBox();
            this.txtMvt = new System.Windows.Forms.TextBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft JhengHei", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 482);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1073, 29);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 24);
            this.toolStripStatusLabel1.Text = "123456789";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserAccount
            // 
            this.lblUserAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserAccount.AutoSize = true;
            this.lblUserAccount.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserAccount.Location = new System.Drawing.Point(809, 10);
            this.lblUserAccount.Name = "lblUserAccount";
            this.lblUserAccount.Size = new System.Drawing.Size(57, 20);
            this.lblUserAccount.TabIndex = 1;
            this.lblUserAccount.Text = "帳號：";
            // 
            // lblUserAccountValue
            // 
            this.lblUserAccountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserAccountValue.AutoSize = true;
            this.lblUserAccountValue.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserAccountValue.Location = new System.Drawing.Point(872, 9);
            this.lblUserAccountValue.Name = "lblUserAccountValue";
            this.lblUserAccountValue.Size = new System.Drawing.Size(54, 20);
            this.lblUserAccountValue.TabIndex = 2;
            this.lblUserAccountValue.Text = "00575";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDisplayName.Location = new System.Drawing.Point(943, 10);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(57, 20);
            this.lblDisplayName.TabIndex = 3;
            this.lblDisplayName.Text = "姓名：";
            // 
            // lblDisplayNameValue
            // 
            this.lblDisplayNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisplayNameValue.AutoSize = true;
            this.lblDisplayNameValue.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDisplayNameValue.Location = new System.Drawing.Point(994, 10);
            this.lblDisplayNameValue.Name = "lblDisplayNameValue";
            this.lblDisplayNameValue.Size = new System.Drawing.Size(57, 20);
            this.lblDisplayNameValue.TabIndex = 4;
            this.lblDisplayNameValue.Text = "一二三";
            // 
            // dgvPO
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvPO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPO.Location = new System.Drawing.Point(5, 90);
            this.dgvPO.Name = "dgvPO";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvPO.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPO.RowTemplate.Height = 24;
            this.dgvPO.Size = new System.Drawing.Size(1062, 365);
            this.dgvPO.TabIndex = 5;
            // 
            // btnPickPO
            // 
            this.btnPickPO.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnPickPO.Image = ((System.Drawing.Image)(resources.GetObject("btnPickPO.Image")));
            this.btnPickPO.Location = new System.Drawing.Point(6, 45);
            this.btnPickPO.Name = "btnPickPO";
            this.btnPickPO.Size = new System.Drawing.Size(40, 26);
            this.btnPickPO.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnPickPO, " 選取採購單 [Shift + F5]");
            this.btnPickPO.UseVisualStyleBackColor = true;
            this.btnPickPO.Click += new System.EventHandler(this.btnPickPO_Click);
            // 
            // btnReadDt
            // 
            this.btnReadDt.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnReadDt.Image = ((System.Drawing.Image)(resources.GetObject("btnReadDt.Image")));
            this.btnReadDt.Location = new System.Drawing.Point(52, 45);
            this.btnReadDt.Name = "btnReadDt";
            this.btnReadDt.Size = new System.Drawing.Size(45, 26);
            this.btnReadDt.TabIndex = 4;
            this.btnReadDt.TabStop = false;
            this.toolTip1.SetToolTip(this.btnReadDt, "取得資料 [Shift + F6]");
            this.btnReadDt.UseVisualStyleBackColor = true;
            this.btnReadDt.Visible = false;
            this.btnReadDt.Click += new System.EventHandler(this.btnReadDt_Click);
            // 
            // btnToSap
            // 
            this.btnToSap.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnToSap.Image = ((System.Drawing.Image)(resources.GetObject("btnToSap.Image")));
            this.btnToSap.Location = new System.Drawing.Point(108, 45);
            this.btnToSap.Name = "btnToSap";
            this.btnToSap.Size = new System.Drawing.Size(42, 27);
            this.btnToSap.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnToSap, "將資料送到SAP [F8]");
            this.btnToSap.UseVisualStyleBackColor = true;
            this.btnToSap.Click += new System.EventHandler(this.btnToSap_Click);
            // 
            // lblMbt
            // 
            this.lblMbt.AutoSize = true;
            this.lblMbt.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMbt.Location = new System.Drawing.Point(2, 11);
            this.lblMbt.Name = "lblMbt";
            this.lblMbt.Size = new System.Drawing.Size(121, 20);
            this.lblMbt.TabIndex = 12;
            this.lblMbt.Text = "輸入異動類型：";
            // 
            // btnHelpMvt
            // 
            this.btnHelpMvt.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnHelpMvt.Location = new System.Drawing.Point(537, 10);
            this.btnHelpMvt.Name = "btnHelpMvt";
            this.btnHelpMvt.Size = new System.Drawing.Size(104, 26);
            this.btnHelpMvt.TabIndex = 13;
            this.btnHelpMvt.TabStop = false;
            this.btnHelpMvt.Text = "異動類型？";
            this.btnHelpMvt.UseVisualStyleBackColor = true;
            this.btnHelpMvt.Visible = false;
            this.btnHelpMvt.Click += new System.EventHandler(this.btnHelpMvt_Click);
            // 
            // lblMdMemo
            // 
            this.lblMdMemo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMdMemo.AutoSize = true;
            this.lblMdMemo.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMdMemo.Location = new System.Drawing.Point(175, 12);
            this.lblMdMemo.Name = "lblMdMemo";
            this.lblMdMemo.Size = new System.Drawing.Size(57, 20);
            this.lblMdMemo.TabIndex = 14;
            this.lblMdMemo.Text = "備註：";
            // 
            // txtMdMemo
            // 
            this.txtMdMemo.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.txtMdMemo.Location = new System.Drawing.Point(238, 10);
            this.txtMdMemo.MaxLength = 20;
            this.txtMdMemo.Name = "txtMdMemo";
            this.txtMdMemo.Size = new System.Drawing.Size(298, 27);
            this.txtMdMemo.TabIndex = 2;
            this.txtMdMemo.TabStop = false;
            this.toolTip1.SetToolTip(this.txtMdMemo, "最多20個中文字");
            // 
            // txtMvt
            // 
            this.txtMvt.AutoCompleteCustomSource.AddRange(new string[] {
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "122",
            "123"});
            this.txtMvt.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.txtMvt.Location = new System.Drawing.Point(129, 9);
            this.txtMvt.MaxLength = 3;
            this.txtMvt.Name = "txtMvt";
            this.txtMvt.Size = new System.Drawing.Size(33, 27);
            this.txtMvt.TabIndex = 1;
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRestart.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
            this.btnRestart.Location = new System.Drawing.Point(610, 44);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(31, 27);
            this.btnRestart.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnRestart, "清除所有資料，重新開始 [F12]");
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 511);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.txtMdMemo);
            this.Controls.Add(this.lblMdMemo);
            this.Controls.Add(this.btnHelpMvt);
            this.Controls.Add(this.lblMbt);
            this.Controls.Add(this.txtMvt);
            this.Controls.Add(this.btnToSap);
            this.Controls.Add(this.btnReadDt);
            this.Controls.Add(this.btnPickPO);
            this.Controls.Add(this.dgvPO);
            this.Controls.Add(this.lblDisplayNameValue);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.lblUserAccountValue);
            this.Controls.Add(this.lblUserAccount);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "收料程式 POR ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblUserAccount;
        private System.Windows.Forms.Label lblUserAccountValue;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblDisplayNameValue;
        private System.Windows.Forms.DataGridView dgvPO;
        private System.Windows.Forms.Button btnPickPO;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnReadDt;
        private System.Windows.Forms.Button btnToSap;
        private System.Windows.Forms.Label lblMbt;
        private System.Windows.Forms.Button btnHelpMvt;
        private System.Windows.Forms.Label lblMdMemo;
        private System.Windows.Forms.TextBox txtMdMemo;
        private System.Windows.Forms.TextBox txtMvt;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

