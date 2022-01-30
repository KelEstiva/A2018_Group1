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
        //Sign Up Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Student Name!');</script>");
            }
            else if (textbox2.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Date of Birth!');</script>");
            }
            else if (textbox3.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Contact Number!');</script>");
            }
            else if (textbox4.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Email Address!');</script>");
            }
            else if (DropDownList3.SelectedItem.Value == "Select")
            {
                Response.Write("<script>alert('Please Select Gender!');</script>");
            }
            else if (DropDownList1.SelectedItem.Value == "Select")
            {
                Response.Write("<script>alert('Please Select Course!');</script>");
            }
            else if (DropDownList2.SelectedItem.Value == "Select")
            {
                Response.Write("<script>alert('Please Select Year Level!');</script>");
            }
            else if (textbox5.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Permanent Address!');</script>");
            }
            else if (textbox6.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Your Student ID!');</script>");
            }
            else if (textbox8.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter a Password!');</script>");
            }
            else
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
                clearForm();
                //Response.Redirect("HomePage.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void clearForm()
        {
            textbox1.Text = "";
            textbox2.Text = "";
            textbox3.Text = "";
            textbox4.Text = "";
            DropDownList3.SelectedValue = "Select";
            DropDownList1.SelectedValue = "Select";
            DropDownList2.SelectedValue = "Select";
            textbox5.Text = "";
            textbox6.Text = "";
            textbox8.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}