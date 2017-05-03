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

        string[,] poHeaderColArray = {
            {"COMP_CODE" , "公司代碼"},
            {"DOC_TYPE" , "採購文件類型"},
            {"VENDOR" , "供應商代號"},
            {"PURCH_ORG" , "採購組織"},
            {"PUR_GROUP" , "採購群組"},
            {"CURRENCY", "幣別碼"},
            {"EXCH_RATE" , "匯率"},
            {"DOC_DATE" , "採購文件日期"},
            {"CREAT_DATE" , "記錄建立日期"}
        };

        string[,] poItemColArray = {
            {"PO_NUMBER","採購單號" },
            {"MOVE_TYPE","異動類型" },
            {"PO_ITEM", "採單項次" },
            {"SHORT_TEXT","短文" },
            {"MATERIAL","物料號碼" },
            {"PLANT","工廠" },
            {"STGE_LOC","儲存地點" },
            {"MATL_GROUP","物料群組" },
            {"QUANTITY","採單數量" },
            {"PO_UNIT","單位" },
            {"ORDERPR_UN", "單位〈採購〉" },
            {"NET_PRICE", "金額" },
            {"PRICE_UNIT", "價格單位" },
            {"TAX_CODE","稅碼" },
            {"OVER_DLV_TOL", "超量允差" },
            {"ACCTASSCAT","科目類別" },
            {"FREE_ITEM","免費" },
            {"RET_ITEM","退貨" },
            {"PREQ_NAME","申請人" },
            {"ENTRY_QNT","輸入數量" },
            {"ENTRY_UOM","輸入單位" },
            {"BATCH","批次號碼" },
            {"MOVE_REAS","異動原因" },
            {"ITEM_TEXT","項目內文" },
            {"ORD_MATERIAL","工單料號" },
            {"FRGKE","採單核發" }
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
                    POHEADER = sc.GetDataTableFromRFCStructure(rfcPOHEADER);
                    POACCOUNT = sc.GetDataTableFromRFCTable(rfcPOACCOUNT);

                    twPoHeader = sc.chgColName(POHEADER, poHeaderColArray);
                    twPoItem = sc.chgColName(POITEM, poItemColArray);

                    bindPoHeader(twPoHeader);
                    

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

        private void bindPoHeader(DataTable twPoHeader)
        {
            foreach (DataRow row in twPoHeader.Rows)
            {
                lblPoDocTypeVal.Text = row[1].ToString();
                lblVendorNameVal.Text = row[2].ToString();
                lblPoGrpVal.Text = row[5].ToString();
                lblPoDateVal.Text = row[8].ToString();
                lblPoNumVal.Text = txtPONum.Text;
            }

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
