using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPortal
{
    public partial class OTP : System.Web.UI.Page
    {
        private string connectionStringGST = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringGST"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
             
                
        }
        protected void btnConfirm_OTP_Click(object sender, EventArgs e)
        {

           try
           {
               
                String match_OTP = enter_OTP.Value;
                using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(connectionStringGST))
                {
                    connection.Open();
                    string queryString = "SELECT * FROM VP_OTP WHERE EMAIL = :email AND OTP = :match_OTP AND VALIDITY=:YES";
                    System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand(queryString, connection);
                    command.Parameters.AddWithValue("email", Session["Otp_email"]);
                    command.Parameters.AddWithValue("match_OTP", match_OTP);
                    command.Parameters.AddWithValue("YES", "YES");
                    using (System.Data.OracleClient.OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            HttpContext.Current.Response.Redirect("ResetPassword.aspx", false);
                        }
                        else
                        {
                            lblError.Text = "Check Your OTP!";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}