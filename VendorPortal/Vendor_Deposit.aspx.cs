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
    public partial class Vendor_Deposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string block2;
        protected void VendorDeposit_Click(object sender, EventArgs e)
        {
            SAPData(); string From_date = from_date.Value;
            string To_date = to_date.Value;

            string From_date_year = From_date.Split('-')[0].ToString();
            string From_date_month = From_date.Split('-')[1].ToString();
            string From_date_day = From_date.Split('-')[2].ToString();


            string To_date_year = To_date.Split('-')[0].ToString();
            string To_date_month = To_date.Split('-')[1].ToString();
            string To_date_day = To_date.Split('-')[2].ToString();

            string F_date = From_date_year + From_date_month + From_date_day;
            string T_date = To_date_year + To_date_month + To_date_day;

            Session["VendorDepositF_date"] = F_date;
            Session["VendorDepositT_date"] = T_date;
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
                IRfcFunction myfunction = myrepository.CreateFunction("ZSP_VEND_DEPOSIT");
                username = vendor_code.Value;
                myfunction.SetValue("I_LIFNR", username);
                String fd = Session["VendorDepositF_date"].ToString();
                String ed = Session["VendorDepositT_date"].ToString();
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
                    String WRBTR = row.GetString("WRBTR");
                    String DMBTR = row.GetString("DMBTR");
                    String BLART = row.GetString("BLART");
                    String UMSKZ = row.GetString("UMSKZ");
                    String ZUONR = row.GetString("ZUONR");
                    String SGTXT = row.GetString("SGTXT");
                    block2 += "<tr>";
                    block2 += "<td>" + LIFNR + "</td>";
                    block2 += "<td>" + BELNR + "</td>";
                    block2 += "<td>" + BUDAT + "</td>";
                    block2 += "<td>" + WRBTR + "</td>";
                    block2 += "<td>" + DMBTR + "</td>";
                    block2 += "<td>" + BLART + "</td>";
                    block2 += "<td>" + UMSKZ + "</td>";
                    block2 += "<td>" + ZUONR + "</td>";
                    block2 += "<td>" + SGTXT + "</td>";
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