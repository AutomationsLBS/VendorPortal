using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPortal
{
    public partial class Vendor_Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string block2;
        protected void VendorPayment_Click(object sender, EventArgs e)
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

            string F_date = From_date_year + From_date_month + From_date_day;
            string T_date = To_date_year + To_date_month + To_date_day;

            Session["VendorPaymentF_date"] = F_date;
            Session["VendorPaymentT_date"] = T_date;
        }

        public string SAPData()
        {
            
            try
            {
                /* System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.AddRange(new DataColumn[8] { new DataColumn("LIFNR", typeof(string)),
                                                    new DataColumn("BELNR", typeof(string)),
                                                    new DataColumn("BUDAT", typeof(string)),
                                                    new DataColumn("GJAHR", typeof(string)),
                                                    new DataColumn("WRBTR", typeof(string)),
                                                    new DataColumn("ZUONR", typeof(string)),
                                                    new DataColumn("SGTXT", typeof(string)),
                                                    new DataColumn("EBELN", typeof(string)),}); */

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
                IRfcFunction myfunction = myrepository.CreateFunction("ZSP_VEND_PAYMENT");
                username = vendor_code.Value;
                myfunction.SetValue("I_LIFNR", username);
                String fd = Session["VendorPaymentF_date"].ToString();
                String ed = Session["VendorPaymentT_date"].ToString();
                myfunction.SetValue("I_FROM_BUDAT", fd);
                myfunction.SetValue("I_TO_BUDAT", ed);
                myfunction.Invoke(mydestination);

                IRfcTable messageTable = myfunction.GetTable("ITAB", true);
                int rowIndex = 0;
                foreach (IRfcStructure row in messageTable)
                {
                    String LIFNR = row.GetString("LIFNR");
                    String BELNR = row.GetString("BELNR");
                    String BUDAT = row.GetString("BUDAT");
                    String GJAHR = row.GetString("GJAHR");
                    String WRBTR = row.GetString("WRBTR");
                    String ZUONR = row.GetString("ZUONR");
                    String SGTXT = row.GetString("SGTXT");
                    String EBELN = row.GetString("EBELN");
                    block2 += "<tr>";
                    block2 += "<td>" + LIFNR + "</td>";
                    block2 += "<td>" + BELNR + "</td>";
                    block2 += "<td>" + BUDAT + "</td>";
                    block2 += "<td>" + GJAHR + "</td>";
                    block2 += "<td>" + WRBTR + "</td>";
                    block2 += "<td>" + ZUONR + "</td>";
                    block2 += "<td>" + SGTXT + "</td>";
                    block2 += "<td>" + EBELN + "</td>";
                    block2 += "</tr>";
                    rowIndex = rowIndex + 1;
                    /* rowIndex = rowIndex + 1;
                    dt.Rows.Add(LIFNR, BELNR, BUDAT, GJAHR, WRBTR, ZUONR, SGTXT, EBELN);
                    GridView1.DataSource = dt;
                    GridView1.DataBind(); */
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