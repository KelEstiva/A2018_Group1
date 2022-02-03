using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;


namespace OnlineLibraryManagementSystem
{
    public partial class StudentForgotPassword : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        //Forgot Password Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Enter Your Registered Student ID!');</script>");
            }
            else if (textbox2.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Enter Your Registered Email Address!');</script>");
            }
            else
            {
                forgotPassword();
            }
        }
        //Forgot Password Function
        void forgotPassword()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM student_master_tbl WHERE student_id='" + textbox1.Text.Trim() + "' AND email_address='" + textbox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dr.Read();
                    string student_id = dr["student_id"].ToString().Trim();
                    string email_address = dr["email_address"].ToString().Trim();
                    string password = dr["password"].ToString().Trim();
                    string full_name = dr["full_name"].ToString().Trim();

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Registered Student ID:- " + student_id);
                    sb.AppendLine("Registered Email Address:- " + email_address);
                    sb.AppendLine("Your Password:- " + password);

                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("glenmichael05@gmail.com", "michael040599estiva");
                    MailMessage msg = new MailMessage();
                    msg.To.Add(textbox2.Text);
                    msg.From = new MailAddress("E-Libray..<glenmichael05@gmail.com>");
                    msg.Subject = "Hello, "+full_name;
                    msg.Body = sb.ToString();
                    client.Send(msg);
                    Response.Write("<script>alert('Your Password Has Been Sent Into Your Registered Email Address, Please Check Your Email Thank you.');</script>");
                    textbox1.Text = "";
                    textbox2.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Student ID or Email Address Does Not Exist In Our Database!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}