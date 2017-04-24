using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connDB;
using ADAuth;

namespace POR
{
    public partial class Form1 : Form
    {
        string winFormVersion, formName, domainUserName, currentUserID;
        bool TESTING, isActive, isInGroup;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (TESTING) this.Text += winFormVersion + " 測試版 " + " / SAP資料環境: " ;
            else this.Text += winFormVersion;

            //取得使用者資訊
            Auth auth = new Auth();
            domainUserName = auth.GetDomainUserName();
            currentUserID = auth.GetUserID(domainUserName);
            var groupList = auth.GetGroupLists(currentUserID);
            isInGroup = auth.SearchInGroups(groupList);

            lblUserNameValue.Text = domainUserName;
            lblDisplayNameValue.Text = currentUserID;
        }

        public Form1()
        {
            //開發資訊
            formName = "POR";
            TESTING = true;
            winFormVersion = "1.00";

            chkFormStatusClass chkForm = new chkFormStatusClass();

            isActive = chkForm.isFormActive(formName);

            if (isActive || isInGroup) InitializeComponent();
            else MessageBox.Show("目前程式停用中，請連絡資訊組");

        }
    }
}
