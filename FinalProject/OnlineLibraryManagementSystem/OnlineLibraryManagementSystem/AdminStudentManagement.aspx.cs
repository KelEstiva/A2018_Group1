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
    public partial class AdminMemberManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again!');</script>");
                    Response.Redirect("AdminLogin.aspx");
                }
                else
                {
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again!');</script>");
                Response.Redirect("AdminLogin.aspx");
            }
        }
        //Go Button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getStudentByID();
        }
        //Activate Button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (textbox7.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please enter Student ID.');</script>");
            }
            else
            {
                updateStudentStatusByID("Activated");
            }
        }
        //Pending Button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (textbox7.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please enter Student ID.');</script>");
            }
            else
            {
                updateStudentStatusByID("Pending");
            }
        }
        //DeActivate Button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (textbox7.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please enter Student ID.');</script>");
            }
            else
            {
                updateStudentStatusByID("Deactivated");
            }
        }
        //Delete Button
        protected void Button5_Click(object sender, EventArgs e)
        {
            deleteStudentByID();
        }
        //Clear Form Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        void deleteStudentByID()
        {
            if (textbox7.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please enter Student ID.');</script>");
            }
            else
            {
                if (checkIfStudentExists())
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd = new SqlCommand("DELETE from student_master_tbl WHERE student_id='" + textbox7.Text.Trim() + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Student Account Deleted Successfully.');</script>");
                        clearForm();
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Student ID!');</script>");

                }
            }
        }
        void getStudentByID()
        {
            if (textbox7.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please enter Student ID.');</script>");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from student_master_tbl where student_id='" + textbox7.Text.Trim() + "'", con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            textbox12.Text = dr.GetValue(0).ToString();
                            textbox10.Text = dr.GetValue(10).ToString();
                            textbox3.Text = dr.GetValue(1).ToString();
                            textbox1.Text = dr.GetValue(2).ToString();
                            textbox2.Text = dr.GetValue(3).ToString();
                            textbox5.Text = dr.GetValue(4).ToString();
                            textbox6.Text = dr.GetValue(5).ToString();
                            textbox8.Text = dr.GetValue(6).ToString();
                            textbox11.Text = dr.GetValue(8).ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Student ID does not exist!');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        void updateStudentStatusByID(string status)
        {
            if (checkIfStudentExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE student_master_tbl SET account_status='" + status + "' WHERE student_id= '" + textbox7.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("SELECT * from student_master_tbl where student_id='" + textbox7.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            textbox10.Text = dr.GetValue(10).ToString();
                        }
                    }
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Student Account Status Updated Successfully.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Student ID!');</script>");
            }
        }
        bool checkIfStudentExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from student_master_tbl where student_id='" + textbox7.Text.Trim() + "';", con);

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
        void clearForm()
        {
            textbox12.Text = "";
            textbox10.Text = "";
            textbox3.Text = "";
            textbox1.Text = "";
            textbox2.Text = "";
            textbox5.Text = "";
            textbox6.Text = "";
            textbox8.Text = "";
            textbox11.Text = "";
            textbox7.Text = "";
        }
    }
}