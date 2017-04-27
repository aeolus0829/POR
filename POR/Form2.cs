﻿using connDB;
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
                    dgvPoHeader.DataSource = POHEADER;
                    dgvPoItem.DataSource = POITEM;
                }

            }
            else MessageBox.Show("未輸入採購單號", "error");

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPONum.Text = null;
            dgvPoHeader.DataSource = null;
            dgvPoItem.DataSource = null;
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();
            foreach (DataGridViewColumn dgvCol in dgvPoItem.Columns) dtTemp.Columns.Add(dgvCol.Name, typeof(string));

            Int32 selectedRowCount = dgvPoItem.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                if (dgvStack.Rows.Count == 0)
                {
                    foreach (DataGridViewColumn dgvCol in dgvPoItem.Columns) dtStack.Columns.Add(dgvCol.Name, typeof(string));
                }
                for (int i = 0; i < dgvPoItem.SelectedRows.Count; i++)
                {
                    dtTemp.Rows.Add();
                    for (int j = 0; j < dgvPoItem.Columns.Count; j++)
                    {
                        dtTemp.Rows[i][j] = dgvPoItem.SelectedRows[i].Cells[j].Value;
                    }
                }

                dtStack.Merge(dtTemp);

                if (dtStack.Rows.Count>0)
                {
                    dgvStack.DataSource = null;
                    dgvStack.DataSource = dtStack;
                } else dgvStack.DataSource = dtStack;


            }
        }
    }
}
