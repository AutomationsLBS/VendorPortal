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
    public partial class Vendor_Movement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string block2;
        protected void VendorMovement_Click(object sender, EventArgs e)
        {
            SAPData();
        }

        public string SAPData()
        {
            try
            {
                /* System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.AddRange(new DataColumn[14] { new DataColumn("LIFNR", typeof(string)),
                                                    new DataColumn("BELNR", typeof(string)),
                                                    new DataColumn("BUZEI", typeof(string)),
                                                    new DataColumn("GJAHR", typeof(string)),
                                                    new DataColumn("BUDAT", typeof(string)),
                                                    new DataColumn("BWART", typeof(string)),
                                                    new DataColumn("MATNR", typeof(string)),
                                                    new DataColumn("SGTXT", typeof(string)),
                                                    new DataColumn("EBELN", typeof(string)),
                                                    new DataColumn("AEDAT", typeof(string)),
                                                    new DataColumn("MAKTX", typeof(string)),
                                                    new DataColumn("MENGE", typeof(string)),
                                                    new DataColumn("MEINS", typeof(string)),
                                                    new DataColumn("DMBTR", typeof(string)),}); */

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
                IRfcFunction myfunction = myrepository.CreateFunction("ZSP_VEND_MOVEMENT");
                username = vendor_code.Value;
                myfunction.SetValue("I_LIFNR", username);
                String ponumber = po_number.Value;
                myfunction.SetValue("I_EBELN", ponumber);
                myfunction.Invoke(mydestination);

                IRfcTable messageTable = myfunction.GetTable("ITAB", true);
                int rowIndex = 0;
                foreach (IRfcStructure row in messageTable)
                {
                    String LIFNR = row.GetString("LIFNR");
                    String BELNR = row.GetString("BELNR");
                    String BUZEI = row.GetString("BUZEI");
                    String GJAHR = row.GetString("GJAHR");
                    String BUDAT = row.GetString("BUDAT");
                    String BWART = row.GetString("BWART");
                    String MATNR = row.GetString("MATNR");
                    String SGTXT = row.GetString("SGTXT");
                    String EBELN = row.GetString("EBELN");
                    String AEDAT = row.GetString("AEDAT");
                    String MAKTX = row.GetString("MAKTX");
                    String MENGE = row.GetString("MENGE");
                    String MEINS = row.GetString("MEINS");
                    String DMBTR = row.GetString("DMBTR");
                    block2 += "<tr>";
                    block2 += "<td>" + LIFNR + "</td>";
                    block2 += "<td>" + BELNR + "</td>";
                    block2 += "<td>" + BUZEI + "</td>";
                    block2 += "<td>" + GJAHR + "</td>";
                    block2 += "<td>" + BUDAT + "</td>";
                    block2 += "<td>" + BWART + "</td>";
                    block2 += "<td>" + MATNR + "</td>";
                    block2 += "<td>" + SGTXT + "</td>";
                    block2 += "<td>" + EBELN + "</td>";
                    block2 += "<td>" + AEDAT + "</td>";
                    block2 += "<td>" + MAKTX + "</td>";
                    block2 += "<td>" + MENGE + "</td>";
                    block2 += "<td>" + MEINS + "</td>";
                    block2 += "<td>" + DMBTR + "</td>";
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