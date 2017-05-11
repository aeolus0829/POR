using connDB;
using POR;
using SAP.Middleware.Connector;
using System;
using System.Data;
using System.Windows.Forms;

namespace POR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            dtStack = new DataTable();

            
        }
        public string connClient { get; set; }
        public DataTable POACCOUNT { get; set; }
        public DataTable POHEADER { get; set; }
        public DataTable POITEM { get; set; }

        public DataTable dtStack { get; set; }
        public string zflag { get; private set; }
        public string zmsg { get; private set; }
        public DataTable twPoHeader { get; private set; }
        public DataTable twPoItem { get; private set; }
        public static string MvT { get; internal set; }

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
            {"VENDOR" , "供應商代號", "1"},
            {"PURCH_ORG" , "採購組織", "0"},
            {"PUR_GROUP" , "採購群組", "0"},
            {"CURRENCY", "幣別碼", "0"},
            {"EXCH_RATE" , "匯率", "5"},
            {"DOC_DATE" , "採購文件日期", "2"},
            {"CREAT_DATE" , "記錄建立日期", "2"}
        };

        string[,] poItemColArray = {
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
            {"FRGKE","採單核發", "0" }
        };

        string[,] POItemColOrder =
        {
            {"MOVE_TYPE"},
            {"PO_NUMBER"},
            {"PO_ITEM"},
            {"MATERIAL"},
            {"ORD_MATERIAL"},
            {"SHORT_TEXT"},
            {"PLANT"},
            {"STGE_LOC"},
            {"QUANTITY"},
            {"OVER_DLV_TOL"},
            {"ENTRY_QNT"},
            {"BATCH"},
            {"FREE_ITEM"},
            {"RET_ITEM"}
        };


        private void btnPoSubmit_Click(object sender, EventArgs e)
        {
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

                    var rfcPOHEADER = iFunc.GetStructure("POHEADER");
                    var rfcPOITEM = iFunc.GetTable("POITEM");
                    var rfcPOACCOUNT = iFunc.GetTable("POACCOUNT");

                    POITEM = sc.GetDataTableFromRFCTable(rfcPOITEM);
                    DataTable tempDt = new DataTable();
                    tempDt = arrangeDataTable(POITEM, poItemColArray);
                    POHEADER = sc.GetDataTableFromRFCStructure(rfcPOHEADER);
                    POACCOUNT = sc.GetDataTableFromRFCTable(rfcPOACCOUNT);

                    setColOrder(tempDt, POItemColOrder);
                    

                    //twPoHeader = sc.chgColName(POHEADER, poHeaderColArray);
                    twPoItem = sc.chgColName(tempDt, poItemColArray);

                    bindPoHeader(POHEADER);
                    

                    zflag = iFunc.GetString("ZFLAG");
                    zmsg = iFunc.GetString("ZMSG");

                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "error");
                }
                if (zflag == "E") MessageBox.Show(zmsg, "錯誤");
                else
                {
                    dgvPoItem.DataSource = twPoItem;

                    autosizeCol(dgvPoItem);
                }

            }
            else MessageBox.Show("未輸入採購單號", "error");

        }

        private DataTable arrangeDataTable(DataTable tempDt, string[,] ColArray)
        {
            string colName, colDesc, colType;
            int totHeaderCol = ColArray.Length / 3; // 資料類別共三種
            DataTable finalDt = new DataTable();

            for (int mainLoopCounter = 0; mainLoopCounter <= tempDt.Rows.Count; mainLoopCounter++)
            {
                if (mainLoopCounter == 0) //這一列是表頭欄位
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
                                    if (tempRow[colCount].ToString()=="ST") finalRow[colName] ="PC";
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
                            if (colName == "MOVE_TYPE") finalRow[colName] = MvT.ToString();
                        }
                        finalDt.Rows.Add(finalRow);
                    }                    
                }
            }
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

        private void bindPoHeader(DataTable poHeader)
        {
            DataTable tempDt = new DataTable();
            string poDocType, vendorID, vendorName, poGrpID, poGrpName, poDate;

            tempDt = arrangeDataTable(poHeader, poHeaderColArray);

            foreach (DataRow row in tempDt.Rows)
            {
                poDocType = row[1].ToString();
                vendorID = row[2].ToString();
                poGrpID = row[4].ToString();
                poDate = row[8].ToString();
                vendorName = getVendor(vendorID);
                poGrpName = getPoGrp(poGrpID);

                lblPoDocTypeVal.Text = poDocType;
                lblVendorNameVal.Text = vendorName;
                lblPoGrpVal.Text = poGrpName;
                lblPoDateVal.Text = poDate;
            }

        }

        private string getPoGrp(string poGrpID)
        {
            throw new NotImplementedException();
        }

        private string getVendor(string vendorID)
        {
            throw new NotImplementedException();
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
            lblPoDateVal.Text = lblPoDocTypeVal.Text = lblPoGrpVal.Text = lblPoNumVal.Text = lblVendorNameVal.Text = null;
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
                if (dgvStack.Rows.Count == 0) // 第一次存放選取資料前，需先產生欄位及名稱
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
            Form1.dtStack = dtStack;
            btnClear.PerformClick();
            dgvPoItem.DataSource = dgvStack.DataSource = null;

            this.Close();

            Application.OpenForms[0].Show();
        }
    }
}
