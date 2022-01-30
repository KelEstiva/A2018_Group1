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
    public partial class UserProfile : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"]==null)
                {
                    Response.Write("<script>alert('Session Expired Login Again!');</script>");
                    Response.Redirect("StudentLogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getStudentPersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again!');</script>");
                Response.Redirect("StudentLogin.aspx");
            }
        }
        //Update Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again!');</script>");
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                updateStudentPersonalDetails();
            }
        }

        void updateStudentPersonalDetails()
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
                SqlCommand cmd = new SqlCommand("UPDATE student_master_tbl SET full_name=@full_name,date_of_birth=@date_of_birth,contact_number=@contact_number,email_address=@email_address,gender=@gender,course=@course,year=@year,full_address=@full_address,password=@password WHERE student_id='" + Session["username"].ToString().Trim() + "'", con);
                cmd.Parameters.AddWithValue("@full_name", textbox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date_of_birth", textbox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_number", textbox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email_address", textbox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@course", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@year", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@full_address", textbox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
              
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result>0)
                {
                    Response.Write("<script>alert('Student Personal Details Updated Successfully.');</script>");
                    getStudentPersonalDetails();
                }
                else
                {
                    Response.Write("<script>alert('Student ID Does Not Exists!');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getStudentPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from student_master_tbl where student_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                textbox1.Text = dt.Rows[0]["full_name"].ToString();
                textbox2.Text = dt.Rows[0]["date_of_birth"].ToString();
                textbox3.Text = dt.Rows[0]["contact_number"].ToString();
                textbox4.Text = dt.Rows[0]["email_address"].ToString();
                DropDownList3.SelectedValue = dt.Rows[0]["gender"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["course"].ToString();
                DropDownList2.SelectedValue = dt.Rows[0]["year"].ToString();
                textbox5.Text = dt.Rows[0]["full_address"].ToString();
                textbox6.Text = dt.Rows[0]["student_id"].ToString();
                textbox8.Text = dt.Rows[0]["password"].ToString();


                Label1.Text = dt.Rows[0]["account_status"].ToString();
                if (dt.Rows[0]["account_status"].ToString().Trim() == "Activated")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "Pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "Deactivated")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}