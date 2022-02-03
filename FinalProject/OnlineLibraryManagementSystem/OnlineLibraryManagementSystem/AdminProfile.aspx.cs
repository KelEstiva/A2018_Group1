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
    public partial class AdminProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again!');</script>");
                    Response.Redirect("AdminLogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getAdminPersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again!');</script>");
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again!');</script>");
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                updateAdminPersonalDetails();
            }
        }

        void updateAdminPersonalDetails()
        {
            string password = "";

            if (textbox9.Text.Equals(""))
            {
                password = textbox8.Text.Trim();
            }
            else
            {
                password = textbox9.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE admin_login_tbl SET full_name=@full_name,date_of_birth=@date_of_birth,contact_number=@contact_number,email_address=@email_address,gender=@gender,full_address=@full_address,password=@password WHERE username='" + Session["username"].ToString().Trim() + "'", con);
                cmd.Parameters.AddWithValue("@full_name", textbox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date_of_birth", textbox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_number", textbox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email_address", textbox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@full_address", textbox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Admin Personal Details Updated Successfully.');</script>");
                    getAdminPersonalDetails();
                }
                else
                {
                    Response.Write("<script>alert('Admin Username Does Not Exists!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getAdminPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from admin_login_tbl where username='" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                textbox6.Text = dt.Rows[0]["username"].ToString();
                textbox1.Text = dt.Rows[0]["full_name"].ToString();
                textbox2.Text = dt.Rows[0]["date_of_birth"].ToString();
                textbox3.Text = dt.Rows[0]["contact_number"].ToString();
                textbox4.Text = dt.Rows[0]["email_address"].ToString();
                DropDownList3.SelectedValue = dt.Rows[0]["gender"].ToString();
                textbox5.Text = dt.Rows[0]["full_address"].ToString();
                textbox8.Text = dt.Rows[0]["password"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}