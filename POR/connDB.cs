using SAP.Middleware.Connector;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace connDB
{
    public class sapConnClass
    {
        public RfcConfigParameters setParaToConn(string sapClient)
        {
            RfcConfigParameters rfcPara = new RfcConfigParameters();
            switch (sapClient)
            {
                case "800":
                    rfcPara.Add(RfcConfigParameters.Name, "PRD");
                    rfcPara.Add(RfcConfigParameters.AppServerHost, "192.168.0.16");
                    rfcPara.Add(RfcConfigParameters.Client, "800");
                    break;
                case "620":
                    rfcPara.Add(RfcConfigParameters.Name, "DEV");
                    rfcPara.Add(RfcConfigParameters.AppServerHost, "192.168.0.15");
                    rfcPara.Add(RfcConfigParameters.Client, "620");
                    break;
                case "300":
                    rfcPara.Add(RfcConfigParameters.Name, "DEV");
                    rfcPara.Add(RfcConfigParameters.AppServerHost, "192.168.0.15");
                    rfcPara.Add(RfcConfigParameters.Client, "300");
                    break;
                default:
                    rfcPara.Add(RfcConfigParameters.Name, "DEV");
                    rfcPara.Add(RfcConfigParameters.AppServerHost, "192.168.0.15");
                    rfcPara.Add(RfcConfigParameters.Client, "620");
                    break;
            }
            rfcPara.Add(RfcConfigParameters.User, "DDIC");
            rfcPara.Add(RfcConfigParameters.Password, "Ubn3dx");
            rfcPara.Add(RfcConfigParameters.SystemNumber, "00");
            rfcPara.Add(RfcConfigParameters.Language, "ZF");

            return rfcPara;
        }

        public DataTable GetDataTableFromRFCTable(IRfcTable rfcTable)
        {
            DataTable loTable = new DataTable();

            int liElement = 0;

            for (liElement = 0; liElement <= rfcTable.ElementCount - 1; liElement++)
            {

                RfcElementMetadata metadata = rfcTable.GetElementMetadata(liElement);

                loTable.Columns.Add(metadata.Name);

            }

            foreach (IRfcStructure Row in rfcTable)
            {
                DataRow ldr = loTable.NewRow();

                for (liElement = 0; liElement <= rfcTable.ElementCount - 1; liElement++)
                {
                    RfcElementMetadata metadata = rfcTable.GetElementMetadata(liElement);

                    ldr[metadata.Name] = Row.GetString(metadata.Name);
                }

                loTable.Rows.Add(ldr);
            }

            return loTable;
        }

        public DataTable GetDataTableFromRFCStructure(IRfcStructure rfcPOHEADER)
        {            
            DataTable dt = new DataTable();

            for (int i = 0; i <= rfcPOHEADER.ElementCount - 1; i++) dt.Columns.Add(rfcPOHEADER.GetElementMetadata(i).Name);

            DataRow row = dt.NewRow();

            for (int j = 0; j <= rfcPOHEADER.ElementCount - 1; j++) row[j] = rfcPOHEADER.GetValue(j);

            dt.Rows.Add(row);

            return dt;          



        }
    }


    class mssqlConnClass
    {
        public string toPackingDB(string DBenv)
        {
            string packingConn;
            DBenv = DBenv.ToUpper();
            string source, catalog, auth;
            source = "Data Source=SBSDB;";
            auth = "Uid=PACKING; Pwd=Admin12-1; ";
            switch (DBenv)
            {
                case "PRD":
                    catalog = "Initial Catalog=PACKING;";
                    break;
                case "DEV":
                    catalog = "Initial Catalog=PACKING_DEV;";
                    break;
                default:
                    catalog = "Initial Catalog=PACKING_DEV;";
                    break;
            }
            packingConn = source + catalog + auth;
            return packingConn;
        }

    }

    class chkFormStatusClass
    {
        private bool formStatus;

        public bool isFormActive(string formName)
        {
            string connString = "Data Source=192.168.0.9;Initial Catalog=rptsvrDB ;User ID=rptsvrDB ;Password=adminrp";
            string queryString = "select activeStatus from activeForm where formName=@formName";
            
            SqlConnection scToSbsdb = new SqlConnection(connString);
            SqlCommand cmdToSbsdb = new SqlCommand(queryString, scToSbsdb);
            cmdToSbsdb.Parameters.Add("@formName", SqlDbType.VarChar).Value = formName;

            try
            {
                scToSbsdb.Open();

                SqlDataReader sdr = cmdToSbsdb.ExecuteReader();
                formStatus = Convert.ToBoolean(sdr.Read());

                scToSbsdb.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(),"error");
            }
            return formStatus;
        }
    }
}
