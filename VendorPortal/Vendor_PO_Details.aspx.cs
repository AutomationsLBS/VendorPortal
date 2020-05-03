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
    public partial class Vendor_PO_Details : System.Web.UI.Page
    {
        private string connectionStringGST = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringGST"].ConnectionString;
        public string block2;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void VendorPODetails_Click(object sender, EventArgs e)
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


            Session["VendorPoDetailsF_date"] = F_date;
            Session["VendorPoDetailsT_date"] = T_date;

        }

        public string SAPData()
        {
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
                IRfcFunction myfunction = myrepository.CreateFunction("ZSP_VEND_PO_DETAILS");
                username = vendor_code.Value;
                myfunction.SetValue("I_LIFNR", username);
                String fd = Session["VendorPoDetailsF_date"].ToString();
                String ed = Session["VendorPoDetailsT_date"].ToString();
                myfunction.SetValue("I_FROM_AEDAT", fd);
                myfunction.SetValue("I_TO_AEDAT", ed);
                myfunction.Invoke(mydestination);

                IRfcTable messageTable = myfunction.GetTable("ITAB", true);
                int rowIndex = 0;
                foreach (IRfcStructure row in messageTable)
                {
                    String LIFNR = row.GetString("LIFNR");
                    String EBELN = row.GetString("EBELN");
                    String BSART = row.GetString("BSART");
                    String WERKS = row.GetString("WERKS");
                    String AEDAT = row.GetString("AEDAT");
                    String EBELP = row.GetString("EBELP");
                    String MENGE = row.GetString("MENGE");
                    String MEINS = row.GetString("MEINS");
                    String NETWR = row.GetString("NETWR");
                    String DMBTR = row.GetString("DMBTR");
                    String DELIV_DATE = row.GetString("DELIV_DATE");
                    block2 += "<tr>";
                    block2 += "<td>" + LIFNR + "</td>";
                    block2 += "<td>" + EBELN + "</td>";
                    block2 += "<td>" + BSART + "</td>";
                    block2 += "<td>" + WERKS + "</td>";
                    block2 += "<td>" + AEDAT + "</td>";
                    block2 += "<td>" + EBELP + "</td>";
                    block2 += "<td>" + MENGE + "</td>";
                    block2 += "<td>" + MEINS + "</td>";
                    block2 += "<td>" + NETWR + "</td>";
                    block2 += "<td>" + DMBTR + "</td>";
                    block2 += "<td>" + DELIV_DATE + "</td>";
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