using connDB;
using POR;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace POR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            dtStack = new DataTable();
            dgvPoItem.AllowUserToAddRows = false;
            dgvStack.AllowUserToAddRows = false;
        }
        public string connClient { get; set; }
        public DataTable POACCOUNT { get; set; }
        public DataTable POHEADER { get; set; }
        public DataTable POITEM { get; set; }

        public delegate void ReturnValueDelegate(DataTable dt);
        public event ReturnValueDelegate ReturnValueCallback;

        public DataTable dtStack { get; set; }
        public string zflag { get; private set; }
        public string zmsg { get; private set; }
        public DataTable twPoHeader { get; private set; }
        public DataTable twPoItem { get; private set; }
        public static string MvT { get; internal set; }
        public string sapInitDB { get; private set; }

        /* 陣列格式：
           {欄位名稱, 欄位說明, 欄位資料類別}
           資料類別： 
          	0		格式不變
            1		前置0
            2		日期
            3		後置0
            4		單位轉換			ST -> PC
            5       數值                小數點2位
            6       整數
            */

        string[,] poHeaderColArray = {
            {"COMP_CODE" , "公司代碼", "0"},
            {"DOC_TYPE" , "採購文件類型", "0"},
            {"VENDOR" , "供應商代號", "0"},
            {"PURCH_ORG" , "採購組織", "0"},
            {"PUR_GROUP" , "採購群組", "0"},
            {"CURRENCY", "幣別碼", "0"},
            {"EXCH_RATE" , "匯率", "5"},
            {"DOC_DATE" , "採購文件日期", "2"},
            {"CREAT_DATE" , "記錄建立日期", "2"}
        };

        public string[,] poItemColArray = {
            {"PO_NUMBER","採購單號", "1" },
            {"MOVE_TYPE","異動類型", "0" },
            {"PO_ITEM", "採單項次", "1" },
            {"SHORT_TEXT","短文", "0" },
            {"MATERIAL","物料號碼", "1" },
            {"PLANT","工廠", "0" },
            {"STGE_LOC","儲存地點", "1" },
            {"MATL_GROUP","物料群組", "1" },
            {"QUANTITY","採單數量", "6" },
            {"PO_UNIT","單位", "4" },
            {"ORDERPR_UN", "單位〈採購〉", "4" },
            {"NET_PRICE", "金額", "6" },
            {"PRICE_UNIT", "價格單位", "6" },
            {"TAX_CODE","稅碼", "0" },
            {"OVER_DLV_TOL", "超量允差", "0" },
            {"ACCTASSCAT","科目類別", "0" },
            {"FREE_ITEM","免費", "0" },
            {"RET_ITEM","退貨", "0" },
            {"PREQ_NAME","申請人", "0" },
            {"ENTRY_QNT","輸入數量", "6" },
            {"ENTRY_UOM","輸入單位", "0" },
            {"BATCH","批次號碼", "1" },
            {"MOVE_REAS","異動原因", "0" },
            {"ITEM_TEXT","項目內文", "0" },
            {"ORD_MATERIAL","工單料號", "1" },
            {"FRGKE","採單核發", "0" },
            {"GRQTY","已驗收", "6" },
            {"BLQTY","已暫收", "6" },
            {"ALLOWQTY", "可交貨", "6" }
        };

        public string[,] keepPoItemArray =
        {
            {"MATERIAL","物料號碼", "1" },
            {"ALLOWQTY", "可交貨", "6" },
            {"STGE_LOC","儲存地點", "1" },
            {"ENTRY_QNT","輸入數量", "6" },
            {"GRQTY","已驗收", "6" },
            {"BLQTY","已暫收", "6" },
            {"PO_NUMBER","採購單號", "1" },
            {"PO_ITEM", "採單項次", "1" },
            {"ORD_MATERIAL","工單料號", "1" },
            {"SHORT_TEXT","短文", "0" },
            {"BATCH","批次號碼", "1" },
            {"QUANTITY","採單數量", "6" },
            {"OVER_DLV_TOL", "超量允差", "0" },
            {"FREE_ITEM","免費", "0" },
            {"RET_ITEM","退貨", "0" }
        };

        private void btnPoSubmit_Click(object sender, EventArgs e)
        {
            DataTable formatDt = new DataTable();
            DataTable pruneDt = new DataTable();

            if (!string.IsNullOrEmpty(txtPONum.Text))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    sapConnClass sc = new sapConnClass();
                    var rfcPara = sc.setParaToConn(connClient);
                    var rfcDest = RfcDestinationManager.GetDestination(rfcPara);
                    var rfcRepo = rfcDest.Repository;
                    IRfcFunction iFunc = null;
                    iFunc = rfcRepo.CreateFunction("ZRFC006");
                    iFunc.SetValue("PURCHASEORDER", txtPONum.Text.Trim());
                    iFunc.SetValue("ZRFCTYPE", "G");
                    iFunc.Invoke(rfcDest);

                    var zflag = iFunc.GetString("ZFLAG");
                    var twZflag = translateFlag(zflag);
                    var zmsg = iFunc.GetString("ZMSG");
                    toolStripStatusLabel1.Text = twZflag + " : " + zmsg;

                    if (zflag == "E") MessageBox.Show(zmsg, "錯誤");
                    else
                    {
                        var rfcPOHEADER = iFunc.GetStructure("POHEADER");
                        var rfcPOITEM = iFunc.GetTable("POITEM");
                        var rfcPOACCOUNT = iFunc.GetTable("POACCOUNT");

                        POITEM = sc.GetDataTableFromRFCTable(rfcPOITEM);

                        formatDt = changeDataFormat(POITEM, poItemColArray);
                        POHEADER = sc.GetDataTableFromRFCStructure(rfcPOHEADER);
                        POACCOUNT = sc.GetDataTableFromRFCTable(rfcPOACCOUNT);

                        twPoItem = sc.chgColName(formatDt, poItemColArray, "tw");

                        pruneDt = removeCol(twPoItem, keepPoItemArray, "tw");

                        resetColOrder(pruneDt, keepPoItemArray, "tw");

                        dgvPoItem.DataSource = pruneDt;
                        dgvPoItem.ReadOnly = true;

                        autosizeCol(dgvPoItem);

                        bindPoHeader(POHEADER);
                    }

                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString(), "error");
                    toolStripStatusLabel1.Text = "無法取得採購單資料";
                }

            }
            else MessageBox.Show("未輸入採購單號", "error");

        }

        private string translateFlag(string zflag)
        {
            string twFlag = "";
            switch (zflag.ToUpper())
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

        private DataTable removeCol(DataTable dt, string[,] colOrderArray, string lang)
        {
            List<string> keepColNames = new List<string>();
            var arrayCount = colOrderArray.Length / 3;
            int langCode = 0;
            langCode = mapLangCode(lang);

            for (int i=0; i<arrayCount;i++)
            {
                keepColNames.Add(colOrderArray[i, langCode]);
            }              

            var allColumns = dt.Columns.Cast<DataColumn>();
            var allColNames = allColumns.Select(c => c.ColumnName);
            var removeColNames = allColNames.Except(keepColNames);
            var colsToRemove = from r in removeColNames
                               join c in allColumns on r equals c.ColumnName
                               select c;
            while (colsToRemove.Any())
                dt.Columns.Remove(colsToRemove.First());

            return dt;
        }

        private int mapLangCode(string lang)
        {
            int langCode = 0;
            switch (lang)
            {
                case "en":
                    langCode = 0;
                    break;
                case "tw":
                    langCode = 1;
                    break;
            }
            return langCode;

        }

        private DataTable changeDataFormat(DataTable tempDt, string[,] ColArray)
        {
            string colName, colDesc, colType;
            int totHeaderCol = ColArray.Length / 3; // 資料類別共三種
            DataTable finalDt = new DataTable();

            int mainLoopCounter = 0;
            do
            {
                if (finalDt.Columns.Count == 0) 
                {
                    for (int colCount = 0; colCount < totHeaderCol; colCount++)
                    {
                        colName = ColArray[colCount, 0]; //取第x筆的 colName 做為 data table 的表頭
                        finalDt.Columns.Add(colName);
                        colName = "";
                    }
                }
                else
                {
                    foreach (DataRow tempRow in tempDt.Rows)
                    {
                        DataRow finalRow = finalDt.NewRow();

                        for (int colCount = 0; colCount < totHeaderCol; colCount++)
                        {
                            colName = ColArray[colCount, 0];
                            colDesc = ColArray[colCount, 1];
                            colType = ColArray[colCount, 2];

                            switch (colType)
                            {
                                case "0":
                                    finalRow[colName] = tempRow[colCount].ToString();
                                    break;
                                case "1":
                                    finalRow[colName] = tempRow[colCount].ToString().TrimStart('0');
                                    break;
                                case "2":
                                    finalRow[colName] = tempRow[colCount].ToString().TrimStart('0');
                                    //當日期空白，預設會帶1899-12-30，如果是1899-12-30則不顯示。
                                    if (Convert.ToDateTime(tempRow[colCount]).ToString("yyyy-MM-dd") != "1899-12-30")
                                        finalRow[colName] = Convert.ToDateTime(tempRow[colCount]).ToString("yyyy-MM-dd");
                                    break;
                                case "3":
                                    finalRow[colName] = tempRow[colCount].ToString().TrimEnd('0');
                                    break;
                                case "4":
                                    if (tempRow[colCount].ToString() == "ST") finalRow[colName] = "PC";
                                    break;
                                case "5":
                                    finalRow[colName] = tempRow[colCount].ToString();
                                    break;
                                case "6":
                                    finalRow[colName] = tempRow[colCount].ToString().TrimEnd('0').TrimEnd('.');
                                    break;
                                case "7":
                                    //時間空白不顯示
                                    if (Convert.ToDateTime(tempRow[colCount]).ToString("HH:mm:ss") != "00:00:00")
                                        finalRow[colName] = Convert.ToDateTime(tempRow[colCount]).ToString("HH:mm:ss");
                                    break;
                                default:
                                    finalRow[colName] = tempRow[colCount].ToString();
                                    break;
                            }
                            mainLoopCounter++;
                        }
                        finalDt.Rows.Add(finalRow);
                    }
                }                
            } while (mainLoopCounter <= tempDt.Rows.Count);
            return finalDt;
        }

        private void setColOrder(DataTable table, string[,] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                table.Columns[columnName].SetOrdinal(columnIndex);
                columnIndex++;
            }
        }

        public void resetColOrder(DataTable table, string[,] columnNames, string lang)

        {
            int langCode = mapLangCode(lang);

            var colCount = columnNames.Length / 3;
            for (int i = 0; i < colCount; i++)
            {
                var columnName = columnNames[i, langCode].ToString();
                table.Columns[columnName].SetOrdinal(i);                
            }
        }

        private void bindPoHeader(DataTable poHeader)
        {
            DataTable tempDt = new DataTable();
            string poDocType, poDocName, vendorID, vendorName, poGrpID, poGrpName, poDate;

            tempDt = changeDataFormat(poHeader, poHeaderColArray);

            foreach (DataRow row in tempDt.Rows)
            {
                poDocType = row[1].ToString();
                vendorID = row[2].ToString();
                poGrpID = row[4].ToString();
                poDate = row[8].ToString();

                poDocName = getPoDocName(poDocType);
                vendorName = getVendor(vendorID);
                poGrpName = getPoGrp(poGrpID);

                lblPoDocTypeVal.Text = poDocName;
                lblVendorNameVal.Text = vendorName;
                lblPoGrpVal.Text = poGrpName;
                lblPoDateVal.Text = poDate;
            }

        }

        private string getPoDocName(string poDocType)
        {
            sapInitDB = detectDBName(connClient);
            string sql = "select BATXT from " + sapInitDB + ".T161T where MANDT='"+ connClient + "' and SPRAS='M' and BSTYP='F' and BSART = @sqlPara";
            string poDocName = execSingleQuery(sql, poDocType);
            return poDocName;
        }

        private string getPoGrp(string poGrpID)
        {
            sapInitDB = detectDBName(connClient);
            string sql = "select EKNAM from " + sapInitDB + ".T024 where MANDT='" + connClient + "' and EKGRP = @sqlPara";
            string poGrpName = execSingleQuery(sql, poGrpID);
            return poGrpName;
        }

        public string detectDBName(string connClient)
        {
            switch (connClient)
            {
                case "800":
                    sapInitDB = "prd";
                    break;
                case "620":
                    sapInitDB = "dev";
                    break;
                case "300":
                    sapInitDB = "dev";
                    break;
            }
            return sapInitDB;
        }

        private string getVendor(string vendorID)
        {
            sapInitDB = detectDBName(connClient);
            string sql = "select NAME1 from " + sapInitDB + ".LFA1 where MANDT='" + connClient + "' and LIFNR = @sqlPara";
            string vendorName = execSingleQuery(sql, vendorID);
            return vendorName;
        }

        private string execSingleQuery(string sql, string sqlPara)
        {
            mssqlConnClass msc = new mssqlConnClass();
            string connString = msc.toSAPDB(connClient);
            string result = null;
            var sqlConn = new SqlConnection(connString);
            try
            {
                sqlConn.Open();
                var paraKey = new SqlParameter("@sqlPara", SqlDbType.Char, 14);
                paraKey.Value = sqlPara;
                SqlCommand sCmd = new SqlCommand(sql,sqlConn);
                sCmd.Parameters.Add(paraKey);
                var value = sCmd.ExecuteScalar();
                if (value != null) result = value.ToString();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error when execSingleQuery()");
            }
            finally
            {
                sqlConn.Close();
            }
            return result;
        }

        public void autosizeCol(DataGridView dgv)
        {
            for (int i = 0;i<= dgv.ColumnCount - 1; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPONum.Text = null;
            dgvPoItem.DataSource = null;
            lblPoDateVal.Text = lblPoDocTypeVal.Text = lblPoGrpVal.Text = lblVendorNameVal.Text = null;
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            //暫存資料用
            DataTable dtTemp = new DataTable();
            //產生欄位及名稱
            foreach (DataGridViewColumn dgvCol in dgvPoItem.Columns) dtTemp.Columns.Add(dgvCol.Name, typeof(string));

            Int32 selectedRowCount = dgvPoItem.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0) //有在 PO item 選取資料
            {
                if (dgvStack.Rows.Count == 0) // 第一次存放選取的資料前，需先產生欄位及名稱
                {
                    foreach (DataGridViewColumn dgvCol in dgvPoItem.Columns) dtStack.Columns.Add(dgvCol.Name, typeof(string));
                } 

                //定義選取資料行
                for (int i = 0; i < dgvPoItem.SelectedRows.Count; i++)
                {
                    dtTemp.Rows.Add();
                    //定義選取資料列
                    for (int j = 0; j < dgvPoItem.Columns.Count; j++)
                    {
                        //將選取資料按照位置放入暫存區
                        dtTemp.Rows[i][j] = dgvPoItem.SelectedRows[i].Cells[j].Value;
                    }
                }

                dtStack.Merge(dtTemp);

                if (dtStack.Rows.Count>0)
                {
                    dgvStack.DataSource = null;
                    dgvStack.DataSource = dtStack;
                } else dgvStack.DataSource = dtStack;

                dgvPoItem.ClearSelection();

                dgvStack.FirstDisplayedScrollingRowIndex = dgvStack.RowCount - 1;
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dgvStack.Rows.Count==0)
            {
                MessageBox.Show("未選取採購單項目，請檢查資料");
            }
            else
            {
                ReturnValueCallback(dtStack);

                btnClear.PerformClick();
                dgvPoItem.DataSource = dgvStack.DataSource = null;

                this.Hide();

                Application.OpenForms[0].Show();
            }
        }
    }
}
