﻿using System;
using System.Windows.Forms;
using connDB;
using ADAuth;
using System.Data;
using SAP.Middleware.Connector;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            dgvPO.AllowUserToAddRows = false;
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
            IRfcTable itab = iFunc.GetTable("POITEM"); 
            var dt = (DataTable)dgvPO.DataSource;
            dt.AcceptChanges();
            IRfcTable fItab = fillItab(itab, dt);            

            var po = fItab[0].GetString(0);
            iFunc.SetValue("PURCHASEORDER", po);
            iFunc.SetValue("POITEM", fItab);
            iFunc.SetValue("MOVE_TYPE", txtMvt.Text);
            iFunc.SetValue("MD_MEMO", txtMdMemo.Text);
            iFunc.SetValue("ZRFCTYPE", "M");
            iFunc.Invoke(rfcDest);
            var zflag = iFunc.GetString("ZFLAG");
            var twZflag = mapFlag(zflag);
            var zmsg = iFunc.GetString("ZMSG");
            toolStripStatusLabel1.Text = twZflag + " : " + zmsg;

            if (zflag=="S" || zflag=="W") btnRestart.PerformClick();
        }

        private void validateUserInput()
        {
            var materilCategory = "";

            mvT = txtMvt.Text;

            needBatch = false;

            if (! string.IsNullOrEmpty(matnr)) materilCategory = matnr.Substring(11, 1);

            if (mvT == "102" || mvT == "106" || mvT == "161" || mvT == "162" || mvT == "122" || mvT == "123") 
            {
                if (materilCategory == "1" || materilCategory == "2" || materilCategory == "3")
                    needBatch = true;
            }

            if (needBatch)
            {
                if (string.IsNullOrEmpty(sLoc))
                {
                    MessageBox.Show("儲存地點沒有填，無法決定批次");
                }

                if (string.IsNullOrEmpty(entryQty))
                {
                    MessageBox.Show("未輸入收料數量，無法決定批次");
                }                 
            }
        }

        public string mapFlag(string v)
        {
            string twFlag = "";
            switch(v.ToUpper())
            {
                case "S":
                    twFlag = "成功";
                    break;
                case "E":
                    twFlag = "錯誤";
                    break;
                case "W":
                    twFlag = "警告";
                    break;
            }
            return twFlag;
        }

        private IRfcTable fillItab(IRfcTable itab, DataTable dt)
        {
            var refArray = poForm.keepPoItemArray;
            sapConnClass sc = new sapConnClass();
            var colCount = refArray.GetLength(0);
            var rowCount = dt.Rows.Count;
            var dtCol = dt.Columns.GetEnumerator();
            var dtEnPo = sc.chgColName(dt, refArray, "en");
            poForm.resetColOrder(dtEnPo, refArray, "en");

            string col = "";
            string val = "";
            int r = 0;

            foreach (DataRow dtEnPORow in dtEnPo.Rows)
            {
                itab.Append();

                for (int i = 0; i < colCount - 1; i++) 
                {
                    col = refArray[i, 0].ToString();
                    val = dtEnPORow[i].ToString().Trim();
                        
                    if (!string.IsNullOrEmpty(val))
                    {
                        itab[r].SetValue(col, val);
                        detectCol(col, val);
                    }
                }

                var lastItabDt = sc.GetDataTableFromRFCTable(itab);

                validateUserInput();

                if (needBatch)
                {
                    var batchNumGroup = searchBatch(matnr, sLoc, entryQty);
                    var iEntryQty = Convert.ToInt32(entryQty);
                    int remainQty = iEntryQty;

                    if (batchNumGroup != null)
                    {
                        do
                        {
                            foreach (DataRow bRow in batchNumGroup.Rows)
                            {
                                var batchQty = Convert.ToInt32(bRow[0]); //CLABS
                                var batchNum = bRow[1].ToString(); //CHARG

                                itab[r].SetValue("BATCH", batchNum);

                                if (remainQty > batchQty)
                                {
                                    remainQty -= batchQty;
                                    itab[r].SetValue("ENTRY_QNT", batchQty);
                                }
                                else
                                {
                                    itab[r].SetValue("ENTRY_QNT", remainQty);
                                    remainQty -= remainQty;
                                    break; //剩餘數量=0，可以跳出迴圈了
                                }
                                r++;
                                itab.Append();

                                for (int i = 0; i < colCount - 1; i++)
                                {
                                    col = refArray[i, 0].ToString();
                                    val = dtEnPORow[i].ToString().Trim();

                                    if (!string.IsNullOrEmpty(val))
                                    {
                                        itab[r].SetValue(col, val);
                                        detectCol(col, val);
                                    }
                                }
                            }
                        } while (remainQty != 0);                       
                    }   
                }
            }
            return itab;
        }

        private DataTable searchBatch(string matnr, string sLoc, string entryQty)
        {
            sapInitDB = poForm.detectDBName(connClient);
            var sql = "select CLABS, CHARG from " + sapInitDB + ".ZMMV002 where MANDT = '" 
                + connClient + "' and MATNR = '" + matnr + "' and LGORT = '" + sLoc + "'";
            DataTable batchNumGroup = new DataTable();

            batchNumGroup = execQuery(sql);

            return batchNumGroup;
        }

        private DataTable execQuery(string sql)
        {
            mssqlConnClass msc = new mssqlConnClass();
            string connString = msc.toSAPDB(connClient);
            DataTable result = new DataTable();
            var sqlConn = new SqlConnection(connString);
            try
            {
                sqlConn.Open();
                SqlCommand sCmd = new SqlCommand(sql, sqlConn);
                var value = sCmd.ExecuteReader();
                result.Load(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error when execQuery()");
            }
            finally
            {
                sqlConn.Close();
            }
            return result; ;
        }

        private void detectCol(string col, string val)
        {
            switch (col)
            {
                case "STGE_LOC":
                    sLoc = val;
                    break;
                case "MATERIAL":
                    matnr = "00000000000" + val;
                    break;
                case "ENTRY_QNT":
                    entryQty = val;
                    break;
            }
        }

        private void autosizeCol(DataGridView dgv)
        {
            for (int i = 0; i <= dgv.ColumnCount - 1; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            poForm.Close();
            txtMvt.Text = "";
            txtMdMemo.Text = "";
            dgvPO.DataSource = null;
            dgvPO.Refresh();
        }

        public static DataTable dtStack { get; internal set; }
        public string connClient { get; set; }
        public string sLoc { get; set; }
        public string mvT { get; set; }
        public string matnr { get; set; }
        public bool needBatch { get; set; }
        public string entryQty { get; set; }
        public object sapInitDB { get; private set; }

        private void btnPickPO_Click(object sender, EventArgs e)
        {
            Form2.MvT = txtMvt.Text;
            toolStripStatusLabel1.Text = "";
            if (poForm.IsAccessible ) poForm.Show();
            else
            {
                Form2 poForm = new Form2();
                poForm.connClient = connClient;
                poForm.Show();
            }

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
