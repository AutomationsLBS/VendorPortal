using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPortal
{
    public partial class Vendor_form : System.Web.UI.Page
    {
        private string connectionStringGST = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringGST"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            email_id.Value = (String)Session["Login_email"];
        }
        protected void btnFormSubmit_Click(object sender, EventArgs e)
        {
           try
           {
               String selectp = Request.Form.Get("title");
               String Fname = fname.Value;
               String Mname = mname.Value;
               String Lname = lname.Value;
               String Username = selectp +" "+ Fname +" "+ Mname +" "+Lname;



               String House_no= house_no.Value;
               String Street= street.Value;
               String City_code= city_code.Value;
               String City=city.Value;
               String State= state.Value;
               String PIN= pin.Value;
               String Country= country.Value;
               String Address = House_no + ", " + Street + ", " + City_code + ", " + City + ", " + State + ", " + PIN + ", " + Country;


               String Contact_person = contact_person.Value;
               String Telephone_no =  telephone_no.Value;
               String Mobile_no = mobile_no.Value;
               String Fax = fax.Value;
               //String Email = email_id.Value;
               String Pan = pan_no.Value;
               String Gst_no= gst_no.Value;


               String Industry = industry.Value;
               String Micro = micro.Value;

               
               

               using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(connectionStringGST))
               {
                   connection.Open();
                   string queryString = "insert into VP_REGISTRATION (NAME, ADDRESS, CONTACT_PERSON,EMAIL,FAX, GST_NO, INDUSTRY, MICRO_OR_SSI_STATUS, MOBILE_NO, PAN_NO, TELEPHONE_NO_EXT) values (:username , :Address, :C_person, :Email, :Fax, :Gst, :Industry, :Micro, :Mob_no, :Pan_no, :Telephone_no)";
                   System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand(queryString, connection);
                   command.Parameters.AddWithValue("username", Username);
                   command.Parameters.AddWithValue("Address", Address);
                   command.Parameters.AddWithValue("C_person", Contact_person);
                   command.Parameters.AddWithValue("Email", Session["Login_email"]);
                   command.Parameters.AddWithValue("Fax", Fax);
                   command.Parameters.AddWithValue("Gst", Gst_no);
                   command.Parameters.AddWithValue("Industry", Industry);
                   command.Parameters.AddWithValue("Micro", Micro);
                   command.Parameters.AddWithValue("Mob_no", Mobile_no);
                   command.Parameters.AddWithValue("Pan_no", Pan);
                   command.Parameters.AddWithValue("Telephone_no", Telephone_no);
                   
                   
                   
                   
                  
                   int rowsUpdated = command.ExecuteNonQuery();
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
           catch(Exception ex)
           {
               lblError.Text = "Something Went Wrong!";
           }
        }
    }
}