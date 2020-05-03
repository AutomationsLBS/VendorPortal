using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace VendorPortal
{
    public partial class VendorAccountStatement : System.Web.UI.Page
    {
        private string connectionStringGST = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringGST"].ConnectionString;
        public string block2;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void VendorAccountStatement_Click(object sender, EventArgs e)
        {
            SAPData();
            string From_date = from_date.Value;
            string To_date = to_date.Value;

            string From_date_year = From_date.Split('-')[0].ToString();
            string From_date_month = From_date.Split('-')[1].ToString();
            string From_date_day = From_date.Split('-')[2].ToString();


            string To_date_year = To_date.Split('-')[0].ToString();
            string To_date_month = To_date.Split('-')[1].ToString();
            string To_date_day = To_date.Split('-')[2].ToString();


            string F_date= From_date_year + From_date_month + From_date_day;
            string T_date = To_date_year + To_date_month + To_date_day;


            Session["VendorAccountStatementF_date"]= F_date;
            Session["VendorAccountStatementT_date"]= T_date;


        }
        
        public string SAPData()
        {
            



            //f.Value = From_date_year + From_date_month + From_date_day;

            try
            {
               

                String username = (string)(Session["username"]);
                RfcConfigParameters rfc = new RfcConfigParameters();////Assign values in rfcconfigparameters
                rfc.Add(RfcConfigParameters.Name, ConfigurationManager.AppSettings["Name"].ToString());
                rfc.Add(RfcConfigParameters.AppServerHost, ConfigurationManager.AppSettings["ServerHost"].ToString());
                rfc.Add(RfcConfigParameters.Client, ConfigurationManager.AppSettings["Client"].ToString());
                rfc.Add(RfcConfigParameters.User, ConfigurationManager.AppSettings["User"].ToString());
                rfc.Add(RfcConfigParameters.Password, ConfigurationManager.AppSettings["Password"].ToString());
                rfc.Add(RfcConfigParameters.SystemNumber, ConfigurationManager.AppSettings["SystemNumber"].ToString());
                rfc.Add(RfcConfigParameters.Language, ConfigurationManager.AppSettings["Language"].ToString()); ;
                rfc.Add(RfcConfigParameters.PoolSize, ConfigurationManager.AppSettings["PoolSize"].ToString());

                RfcDestination mydestination = RfcDestinationManager.GetDestination(rfc);
                RfcRepository myrepository = mydestination.Repository;
                IRfcFunction myfunction = myrepository.CreateFunction("ZSP_VEND_AC_STMT");
                username = vendor_code.Value;
                myfunction.SetValue("I_LIFNR", username);
                String fd = Session["VendorAccountStatementF_date"].ToString();
                String ed = Session["VendorAccountStatementF_date"].ToString(); 
                myfunction.SetValue("I_FROM_DT", fd);
                myfunction.SetValue("I_TO_DT", ed);
                myfunction.Invoke(mydestination);

                IRfcTable messageTable = myfunction.GetTable("ITAB2", true);
                int rowIndex = 0;
                foreach (IRfcStructure row in messageTable)
                {
                    String LIFNR = row.GetString("LIFNR");
                    String BELNR = row.GetString("BELNR");
                    String BLDAT = row.GetString("BLDAT");
                    String BLART = row.GetString("BLART");
                    String DR_AMT = row.GetString("DR_AMT");
                    String CR_AMT = row.GetString("CR_AMT");
                    String DZUONR = row.GetString("DZUONR");
                    String SGTXT = row.GetString("SGTXT");
                    String O_OP_BLNC = row.GetString("O_OP_BLNC");
                    String O_CL_BLNC = row.GetString("O_CL_BLNC");
                    block2 += "<tr>";
                    block2 += "<td>" + LIFNR + "</td>";
                    block2 += "<td>" + BELNR + "</td>";
                    block2 += "<td>" + BLDAT + "</td>";
                    block2 += "<td>" + BLART + "</td>";
                    block2 += "<td>" + DR_AMT + "</td>";
                    block2 += "<td>" + CR_AMT + "</td>";
                    block2 += "<td>" + DZUONR + "</td>";
                    block2 += "<td>" + SGTXT + "</td>";
                    block2 += "<td>" + O_OP_BLNC + "</td>";
                    block2 += "<td>" + O_CL_BLNC + "</td>";
                    block2 += "</tr>";
                    rowIndex = rowIndex + 1;
                }
                return block2;
            }
            catch (Exception ex)
            {

            }
            return block2;
        }     
    }
}