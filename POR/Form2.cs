using connDB;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public DataTable POACCOUNT { get; set; }
        public DataTable POHEADER { get; set; }
        public DataTable POITEM { get; set; }

        private void btnPoSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPONum.Text))
            {
                try
                {
                    sapConnClass sc = new sapConnClass();
                    var rfcPara = sc.setParaToConn("620");
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
                    var zmsg = iFunc.GetString("ZMSG");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "error");
                }

                dgvPoHeader.DataSource = POHEADER;
                dgvPoItem.DataSource = POITEM;
                dgvPoAccount.DataSource = POACCOUNT;
            }
            else MessageBox.Show("未輸入採購單號", "error");

        }
    }
}
