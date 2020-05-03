using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPortal
{
    public partial class Get_OTP : System.Web.UI.Page
    {
        private string connectionStringGST = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringGST"].ConnectionString;
        
        


        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateOtp();
             

        }
        public string GenerateOtp()
        {
            string OtpLength = "8";
            string NewOtp = "";

            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";


            char[] sep = {  
            ','  
        };
            string[] arr = allowedChars.Split(sep);


            string IDString = "";
            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(OtpLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewOtp = IDString;

            }
            return NewOtp;
        }

        
        //Value which you want to pass






        public void btnGet_OTP_Click(object sender, EventArgs e)
        {
            try
            {

                // to save the Email_id and OTP in database
                String email = send_otp.Value;
                Session["Otp_email"] = email;
                string strNewOtp = GenerateOtp().ToString();
                using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(connectionStringGST))
                {
                    connection.Open();
                    string queryString = "update VP_OTP SET VALIDITY =:NO WHERE EMAIL = :email AND VALIDITY= :YES ";
                    System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand(queryString, connection);
                    command.Parameters.AddWithValue("email", email);
                    command.Parameters.AddWithValue("YES", "YES");
                    command.Parameters.AddWithValue("NO", "NO");
                    int rowsUpdated = command.ExecuteNonQuery();


                    string QueryString = "insert into VP_OTP (EMAIL,OTP, VALIDITY) values (:email,:OTP,:VALIDITY)";
                    System.Data.OracleClient.OracleCommand Command = new System.Data.OracleClient.OracleCommand(QueryString, connection);
                    Command.Parameters.AddWithValue("email", email);
                    Command.Parameters.AddWithValue("OTP", strNewOtp);
                    Command.Parameters.AddWithValue("VALIDITY", "YES");
                    int RowsUpdated = Command.ExecuteNonQuery();
                    HttpContext.Current.Response.Redirect("OTP.aspx", false);
                }


                
                // to send the random OTP in email
    //            MailMessage msg = new MailMessage();
   //             msg.From = new MailAddress("itadmin@rcfltd.com");
    //            msg.To.Add(email);
   //             msg.Body = "Dear " + email + ", <br/><br/> Your OTP is " + strNewOtp + " for Vendor Registration for RCF. <br/> Kindly ignore this email if already submitted. <br/><br/>This is system generated mail.<br/>Please do not reply.<br/><br/>Regards,<br/>RCF Ltd.";
                //Response.Write(msg.Body);
  //              msg.IsBodyHtml = true;
 //               msg.Subject = "OTP for Verification for Grievance Monitoring System";
 ///               SmtpClient smt = new SmtpClient("webmail.rcfltd.com");
 //               smt.Port = 25;
 //               smt.Credentials = new NetworkCredential("itadmin@rcfltd.com", "asdfgh@123");
                //smt.EnableSsl = true;
//                smt.Send(msg);
                //string script = "<script>alert('Mail Sent Successfully');self.close();</script>";
                //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "sendMail", script);

            
  
  
               
            }
            catch(Exception ex)
            {

            }
            
        }

       
    }
}