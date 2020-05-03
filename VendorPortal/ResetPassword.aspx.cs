using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPortal
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        private string connectionStringGST = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringGST"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {

                String newpassword = New_password.Value;
                using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(connectionStringGST))
                {
                    connection.Open();
                    string queryString = "update VP_LOGIN SET PASSWORD =:New_password WHERE EMAIL_ID = :email";
                    System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand(queryString, connection);
                    command.Parameters.AddWithValue("email", Session["Otp_email"]);
                    command.Parameters.AddWithValue("New_password", newpassword);
                    int rowsUpdated = command.ExecuteNonQuery();
                    Response.Redirect("Login.aspx");
                }

             }
            catch(Exception ex)
            {
                Response.Write("pm");
            }
        }       
    }
}