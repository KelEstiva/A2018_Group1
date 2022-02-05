using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibraryManagementSystem
{
    public partial class UserLogin : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Input Student ID!');</script>");
            }
            else if(textbox2.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Input Password!');</script>");
            }
            else
            {
                studentlogin();
            }
        }
        //Student Login Function
        void studentlogin()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from student_master_tbl where student_id='" + textbox1.Text.Trim() + "' AND password='" + textbox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["username"] = dr.GetValue(7).ToString();
                        Session["fullname"] = dr.GetValue(0).ToString();
                        Session["role"] = "student";
                        Session["status"] = dr.GetValue(10).ToString();
                    }
                    if (Session["status"].Equals("Activated"))
                    {
                        Response.Write("<script>aler('Login Successful.')</script>");
                        Response.Redirect("Default.aspx");
                    }
                    else if (Session["status"].Equals("Pending"))
                    {
                        Response.Write("<script>alert('Your Account Status is Pending');</script>");
                        Session.Remove("role");
                        Session.RemoveAll();
                        Session.Abandon();
                    }
                    else if (Session["status"].Equals("Deactivated"))
                    {
                        Response.Write("<script>alert('Your account status is Deactivated');</script>");
                        Session.Remove("role");
                        Session.RemoveAll();
                        Session.Abandon();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Username or Password!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}