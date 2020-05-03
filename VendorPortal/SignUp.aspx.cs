using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPortal
{
    public partial class SignUp : System.Web.UI.Page
    {
        private string connectionStringGST = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringGST"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        


        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            
            try
            {
                String username = user_name.Value;
                String email = user_email.Value;
                String password = user_password.Value;
                using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(connectionStringGST))
                {
                    connection.Open();
                    string queryString = "SELECT * FROM VP_LOGIN WHERE EMAIL_ID = :useremail";
                    System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand(queryString, connection);
                    command.Parameters.AddWithValue("useremail", email);
                    using (System.Data.OracleClient.OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            lblError_email.Text = "Email already exist!";

                        }
                        else
                        {
                            
                            string QueryString = "insert into VP_LOGIN (NAME,EMAIL_ID,PASSWORD) values (:username,:email,:password)";
                            System.Data.OracleClient.OracleCommand Command = new System.Data.OracleClient.OracleCommand(QueryString, connection);
                            Command.Parameters.AddWithValue("username", username);
                            Command.Parameters.AddWithValue("email", email);
                            Command.Parameters.AddWithValue("password", password);
                            int rowsUpdated = Command.ExecuteNonQuery();
                            if (rowsUpdated == 0)
                            {
                                Response.Write("Record not inserted");
                            }
                            else
                            {
                                
                                HttpContext.Current.Response.Redirect("Login.aspx", false);
                    
                            }
                    
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