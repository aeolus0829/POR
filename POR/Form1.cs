﻿using System;
using System.Windows.Forms;
using connDB;
using ADAuth;
using System.Data;
using SAP.Middleware.Connector;

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

        private void btnToSap_Click(object sender, EventArgs e)
        {
            sapConnClass sc = new sapConnClass();
            var rfcPara = sc.setParaToConn(connClient);
            var rfcDest = RfcDestinationManager.GetDestination(rfcPara);
            var rfcRepo = rfcDest.Repository;
            IRfcFunction iFunc = null;
            iFunc = rfcRepo.CreateFunction("ZRFC006");
            IRfcTable itab = iFunc.GetTable("POITEM"); //POITEM
            var dt = (DataTable)dgvPO.DataSource;
            IRfcTable fItab = fillItab(itab, dt);

            var po = fItab[0].GetString(0);
            iFunc.SetValue("PURCHASEORDER", po);
            iFunc.SetValue("POITEM", fItab);
            iFunc.SetValue("ZRFCTYPE", "M");
            iFunc.Invoke(rfcDest);
            var zflag = iFunc.GetString("ZFLAG");
            var zmsg = iFunc.GetString("ZMSG");
            toolStripStatusLabel1.Text = zflag + " : " + zmsg;

            MessageBox.Show(zmsg, zflag);

        }

        private IRfcTable fillItab(IRfcTable itab, DataTable dt)
        {
            sapConnClass sc = new sapConnClass();
            var poItemColArray = poForm.poItemColArray;
            var colCount = poItemColArray.Length / 3;
            var rowCount = dt.Rows.Count;
            var dtCol = dt.Columns.GetEnumerator();
            var tempDt = sc.chgColName(dt, poForm.poItemColArray, "en");
            poForm.setPoColOrder(tempDt,poForm.poItemColArray);
            
            string col, val;

            foreach (DataRow row in tempDt.Rows)
            {
                //for (int r=0; r < rowCount; r++)
                int r = 0;
                do
                {
                    for (int i = 0; i < colCount; i++)
                    {
                        col = poItemColArray[i, 0].ToString();
                        val = row[i].ToString();
                        if (col == "QUANTITY") val = "1";
                        itab.Append();
                        if (!string.IsNullOrEmpty(val)) itab[r].SetValue(col, val);
                    }
                    r++;
                } while (r < rowCount);
            }
            return itab;
        }

        private void autosizeCol(DataGridView dgv)
        {
            for (int i = 0; i <= dgv.ColumnCount - 1; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public static DataTable dtStack { get; internal set; }
        public string connClient { get; private set; }

        private void btnPickPO_Click(object sender, EventArgs e)
        {
            poForm.Show();
            this.Hide();
        }

        public Form1()
        {
            //開發資訊
            formName = "POR";
            isTesting = true;
            formVersion = "0.10";
            connClient = "620";
            poForm.connClient = connClient;

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
