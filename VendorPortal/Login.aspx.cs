using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPortal
{
    public partial class Login : System.Web.UI.Page
    {
        private string connectionStringGST = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringGST"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("Construtor is Called!");

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                String useremail = txtemail.Value;
                Session["Login_email"] = useremail;
                String password = txtpassword.Value;

                using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(connectionStringGST))
                {
                    connection.Open();
                    string queryString = "SELECT * FROM VP_LOGIN WHERE EMAIL_ID = :useremail AND PASSWORD = :password";
                    System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand(queryString, connection);
                    command.Parameters.AddWithValue("useremail", useremail);
                    command.Parameters.AddWithValue("password", password);
                    using (System.Data.OracleClient.OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            /*Session["username"] = Convert.ToString(reader["EMAIL_ID"]);
                            Session["name"] = Convert.ToString(reader["NAME"]);
                            Session["contact"] = Convert.ToString(reader["CONTACT"]);*/
                            HttpContext.Current.Response.Redirect("VendorRegistration.aspx", false);
                        }
                        else
                        {
                            lblError.Text = "Check Your User Name and Password!";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                lblError.Text = "Something Went Wrong!";
            }
        }
    }
}