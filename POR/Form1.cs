using System;
using System.Windows.Forms;
using connDB;
using ADAuth;
using System.Data;
using SAP.Middleware.Connector;
using SAPLogonCtrl;

namespace POR
{
    public partial class Form1 : Form
    {
        string formVersion, formName, domainUserName, currentUserID;
        bool isTesting, isActive, isInGroup;

        private void btnPickPO_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.Show();
        }

        public Form1()
        {
            //開發資訊
            formName = "POR";
            isTesting = true;
            formVersion = "0.10";

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

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (isTesting) this.Text += formVersion + " 測試版 " + " / SAP資料環境: ";
            else this.Text += formVersion;

            lblUserNameValue.Text = domainUserName;
            lblDisplayNameValue.Text = currentUserID;

        }
    }
}
