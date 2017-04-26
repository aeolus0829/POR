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

        public DataTable POACCOUNT
        {
            get;
            set;
        }

        public DataTable POHEADER
        {
            get;
            set;
        }

        public DataTable POITEM
        {
            get;
            set;
        }
        private string zmsg;
        private bool zflag;


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

            try
            {
                sapConnClass sc = new sapConnClass();
                var rfcPara = sc.setParaToConn("620");
                var rfcDest = RfcDestinationManager.GetDestination(rfcPara);
                var rfcRp = rfcDest.Repository;
                IRfcFunction iFunc = null;
                iFunc = rfcRp.CreateFunction("ZRFC006");
                iFunc.SetValue("PURCHASEORDER", "4500022337");
                iFunc.SetValue("ZRFCTYPE", "G");
                iFunc.Invoke(rfcDest);

                var POHEADER = iFunc.GetStructure("POHEADER");
                var POITEM = iFunc.GetTable("POITEM");
                var POACCOUNT = iFunc.GetTable("POACCOUNT");
                zmsg = iFunc.GetString("ZMSG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error");
            }

                zflag = true;
                lblMsg.Text = zmsg;
                dgvPO.DataSource = POHEADER;


        }
    }
}
