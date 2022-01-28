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
    public partial class UserSignUp : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkStudentExists())
            {
                Response.Write("<script>alert('Student already Exist with this ID, try other ID.');</script>");
            }
            else
            {
                signUpNewStudent();
            }
        }

        bool checkStudentExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from student_master_tbl where student_id='"+textbox6.Text.Trim()+"';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void signUpNewStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO student_master_tbl(full_name,date_of_birth,contact_number,email_address,gender,course,year,student_id,full_address,password,account_status) values (@full_name,@date_of_birth,@contact_number,@email_address,@gender,@course,@year,@student_id,@full_address,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", textbox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date_of_birth", textbox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_number", textbox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email_address", textbox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@course", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@year", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@full_address", textbox5.Text.Trim());
                cmd.Parameters.AddWithValue("@student_id", textbox6.Text.Trim());
                cmd.Parameters.AddWithValue("@password", textbox8.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "Pending");

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Sign Up Successfull. Go to Student Login to Login');</script>");
                Response.Redirect("StudentLogin.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}