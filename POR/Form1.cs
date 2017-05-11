using System;
using System.Windows.Forms;
using connDB;
using ADAuth;
using System.Data;

namespace POR
{
    public partial class Form1 : Form
    {
        string formVersion, formName, domainUserName, currentUserID;
        bool isTesting, isActive, isInGroup;
    
        Form2 poForm = new Form2();

        public void btnReadDt_Click(object sender, EventArgs e)
        {
            dgvPO.DataSource = dtStack;
            autosizeCol(dgvPO);
        }

        private void btnHelpMvt_Click(object sender, EventArgs e)
        {            
            MessageBox.Show("101 直收" + Environment.NewLine + "102 取消直收" + Environment.NewLine +
                "103 暫收" + Environment.NewLine + "104 取消暫收" + Environment.NewLine +
                "105 驗收" + Environment.NewLine + "106 取消驗收" + Environment.NewLine +
                "122 退貨" + Environment.NewLine + "123 取消退貨" + Environment.NewLine 
                ,"說明");
        }

        private void autosizeCol(DataGridView dgv)
        {
            for (int i = 0; i <= dgv.ColumnCount - 1; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public static DataTable dtStack { get; internal set; }

        private void btnPickPO_Click(object sender, EventArgs e)
        {
            poForm.Show();
            this.Hide();
            toolStripStatusLabel1.Text = "測試123456, 物料文件號碼 543293827";
        }

        public Form1()
        {
            //開發資訊
            formName = "POR";
            isTesting = true;
            formVersion = "0.10";
            poForm.connClient = "620";            

            //檢查程式的啟用狀態
            chkFormStatusClass chkForm = new chkFormStatusClass();
            isActive = chkForm.isFormActive(formName);

            //取得使用者資訊
            Auth auth = new Auth();
            domainUserName = auth.GetDomainUserName();
            currentUserID = auth.GetUserID(domainUserName);
            var groupAllowedList = auth.GetGroupLists(currentUserID);
            isInGroup = auth.SearchInGroups(groupAllowedList);

            if (isActive && isInGroup) InitializeComponent();
            else MessageBox.Show("目前程式停用中，可能是特定時間或缺乏使用權限，請連絡資訊組");

            Form2.MvT = txtMvt.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (isTesting) this.Text += formVersion + " 測試版 " + " / SAP資料環境: " + poForm.connClient;
            else this.Text += formVersion;

            lblUserAccountValue.Text = domainUserName;
            lblDisplayNameValue.Text = currentUserID;

        }
    }
}
