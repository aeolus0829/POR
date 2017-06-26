using System;
using System.Windows.Forms;
using connDB;
using ADAuth;
using System.Data;
using SAP.Middleware.Connector;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace POR
{
    public partial class Form1 : Form
    {
        string formVersion, formName, domainUserID, domainUserName;
        bool isTesting, isFormActive, isInGroup;
    
        Form2 poForm = new Form2();
        private bool isAdmin;

        public void btnReadDt_Click(object sender, EventArgs e)
        {
            dgvPO.DataSource = dtStack;
            dgvPO.AllowUserToAddRows = false;

            // 將欄位鎖上，不讓使用者修改
            foreach (DataGridViewColumn column in dgvPO.Columns)
            {
                column.ReadOnly = true;
            }

            var materialNum = getMaterialNumFromDt(dgvPO);

            checkSLoc(materialNum);

            // 開放部份欄位供使用者修改，並以醒目顏色標示
            if (needSLoc)
            {
                dgvPO.Columns["儲存地點"].Visible = true;
                dgvPO.Columns["儲存地點"].ReadOnly = false;
                dgvPO.Columns["儲存地點"].DefaultCellStyle.BackColor = Color.LightYellow;
            }
            else
            {
                dgvPO.Columns["儲存地點"].Visible = false;
            }

            dgvPO.Columns["輸入數量"].ReadOnly = false;
            dgvPO.Columns["輸入數量"].DefaultCellStyle.BackColor = Color.LightYellow;

            autosizeCol(dgvPO);
        }

        private void checkSLoc(string materialNum)
        {
            if (mvT == "105" || mvT == "106" || mvT == "161" || mvT == "162")
            {
                if (!string.IsNullOrEmpty(materialNum)) needSLoc = true;
                else needSLoc = false;
            }
        }

        private string getMaterialNumFromDt(DataGridView dgv)
        {
            var materialNum = "";
            var dt = (DataTable)dgv.DataSource;

            foreach (DataRow row in dt.Rows)
            {
                if (!string.IsNullOrEmpty(row[0].ToString())) materialNum = row[0].ToString();
            }

            return materialNum;
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
            btnToSap.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

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
            iFunc.SetValue("MD_MEMO", domainUserName + ": " + txtMdMemo.Text);
            iFunc.SetValue("ZRFCTYPE", "M");
            iFunc.Invoke(rfcDest);
            var zflag = iFunc.GetString("ZFLAG");
            var twZflag = mapFlag(zflag);
            var zmsg = iFunc.GetString("ZMSG");
            toolStripStatusLabel1.Text = twZflag + " : " + zmsg;

            if (zflag=="S" || zflag=="W") btnRestart.PerformClick();
            btnToSap.Enabled = true;
            Cursor.Current = Cursors.Default;

        }

        private void validateUserInput()
        {
            var materilCategory = "";

            needBatch = false;

            if (! string.IsNullOrEmpty(matnr)) materilCategory = matnr.Substring(11, 1);

            if (mvT == "102" || mvT == "106" || mvT == "161" || mvT == "162" || mvT == "122" || mvT == "123") 
            {
                if (materilCategory == "1" || materilCategory == "2" || materilCategory == "3")
                    needBatch = true;
            }

            if (needBatch)
            {
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

            // 將 datatable -> itab
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
                    var batchNumGroup = listBatchQty(matnr, sLoc, entryQty);
                    var iEntryQty = Convert.ToInt32(entryQty);
                    int remainQty = iEntryQty;

                    if (batchNumGroup != null)
                    {
                        do //處理批次，不同批次就新增一筆 itab, 直到批次數量用完或指派完為止
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

                                //產生一筆新的 itab，用來處理批次分割數量
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

        private DataTable listBatchQty(string matnr, string sLoc, string entryQty)
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
                MessageBox.Show(ex.ToString(), "執行 execQuery() 出現問題");
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
        public bool isQAperson { get; private set; }
        public bool isIMperson { get; private set; }
        public List<string> userGroups { get; private set; }
        public List<string> allowMvT { get; private set; }
        public bool needSLoc { get; private set; }

        private void btnPickPO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMvt.Text)) MessageBox.Show("異動類型必須輸入");
            else
            {
                mvT = txtMvt.Text;

                var isMvTAllow = checkPermission(mvT);

                if (isMvTAllow)
                {
                    Form2.MvT = mvT;
                    toolStripStatusLabel1.Text = "";
                    if (poForm.IsAccessible) poForm.Show();
                    else
                    {
                        Form2 poForm = new Form2();
                        poForm.ReturnValueCallback += new Form2.ReturnValueDelegate(this.SetReturnValueCallbackFun);
                        poForm.connClient = connClient;
                        poForm.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("你沒有這個異動類型的權限", "錯誤");
                }
            }
        }

        private bool checkPermission(string inputMvt)
        {
            bool isMvTAllow = false;    

            foreach (string a in allowMvT)
            {
                if (inputMvt == a) isMvTAllow = true;
            }

            return isMvTAllow;            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Shift | Keys.F5))
            {
                btnPickPO.PerformClick();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.F6))
            {
                btnReadDt.PerformClick();
                return true;
            }

            if (keyData == (Keys.F8))
            {
                btnToSap.PerformClick();
                return true;
            }

            if (keyData == (Keys.F12))
            {
                btnRestart.PerformClick();
                return true;
            }


            return false;
        }

        public Form1()
        {
            //開發資訊
            formName = "POR";
            isTesting = true;
            formVersion = "0.20";
            connClient = "620";
            poForm.connClient = connClient;

            this.KeyPreview = true;

            string[] qaList = 
            {
                "12300品保課",
                "12301檢驗組"
            };

            string[] imList = 
            {
                "13200物管課",
                "13202倉管組"
            };

            string[] adminList =
            {
                "Domain Admins"
            };

            string[] allowADGroups = {
                "Domain Admins",
                "13200物管課",
                "13202倉管組",
                "12300品保課",
                "12301檢驗組"
            };

            allowMvT = new List<string>();

            //檢查程式是否停用
            chkFormStatusClass chkForm = new chkFormStatusClass();
            isFormActive = chkForm.isFormActive(formName);

            //取得使用者資訊
            Auth auth = new Auth();
            auth.allowADGroups = allowADGroups;
            domainUserID = auth.GetDomainUserName();
            domainUserName = auth.GetUserID(domainUserID);
            userGroups = auth.GetGroupLists(domainUserName);

            //判斷使用者群組
            isInGroup = auth.SearchInGroups(userGroups);
            isQAperson = auth.checkInGroups(userGroups, qaList);
            isIMperson = auth.checkInGroups(userGroups, imList);
            isAdmin = auth.checkInGroups(userGroups, adminList);

            //設定異動類型的權限
            if (isQAperson) setPermission("qa");
            if (isIMperson) setPermission("im");
            if (isAdmin) setPermission("admin");

            //檢查程式是否可以啟動
            if (isFormActive && isInGroup) InitializeComponent();
            else MessageBox.Show("目前程式停用中，可能是特定時間或缺乏使用權限，請連絡資訊組");
        }

        private void setPermission(string userRole)
        {
            switch (userRole)
            {
                case "qa":
                    allowMvT.Add("105");
                    allowMvT.Add("106");
                    break;
                case "im":
                    allowMvT.Add("103");
                    allowMvT.Add("104");
                    break;
                case "admin":
                    allowMvT.Add("103");
                    allowMvT.Add("104");
                    allowMvT.Add("105");
                    allowMvT.Add("106");
                    break;
            }
        }

        private void SetReturnValueCallbackFun(DataTable dt)
        {
            dgvPO.DataSource = dt;

            dgvPO.AllowUserToAddRows = false;

            // 將欄位鎖上，不讓使用者修改
            foreach (DataGridViewColumn column in dgvPO.Columns)
            {
                column.ReadOnly = true;
            }

            var materialNum = getMaterialNumFromDt(dgvPO);

            checkSLoc(materialNum);

            // 開放部份欄位供使用者修改，並以醒目顏色標示
            if (needSLoc)
            {
                dgvPO.Columns["儲存地點"].Visible = true;
                dgvPO.Columns["儲存地點"].ReadOnly = false;
                dgvPO.Columns["儲存地點"].DefaultCellStyle.BackColor = Color.LightYellow;
            }
            else
            {
                dgvPO.Columns["儲存地點"].Visible = false;
            }

            dgvPO.Columns["輸入數量"].ReadOnly = false;
            dgvPO.Columns["輸入數量"].DefaultCellStyle.BackColor = Color.LightYellow;

            autosizeCol(dgvPO);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (isTesting) this.Text += formVersion + " 測試版 " + " / SAP資料環境: " + poForm.connClient;
            else this.Text += formVersion;

            lblUserAccountValue.Text = domainUserID;
            lblDisplayNameValue.Text = domainUserName;

        }
    }
}
