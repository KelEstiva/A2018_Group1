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
    public partial class AdminAuthorManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null)
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
        // Add Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Enter Author ID!');</script>");
            }
            else if (textbox2.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Enter Author Name!');</script>");
            }
            else
            {
                if (checkIfAuthorIdExists())
                {
                    Response.Write("<script>alert('Author ID Already Exists!');</script>");
                }
                else
                {
                    if (checkIfAuthorNameExists())
                    {
                        Response.Write("<script>alert('Author Name Already Exists!');</script>");
                    }
                    else
                    {
                        addNewAuthor();
                    }
                }
            }
        }
        //Update Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Author ID!');</script>");
            }
            else
            {
                if (checkIfAuthorIdExists())
                {
                    if (textbox2.Text.Equals(""))
                    {
                        Response.Write("<script>alert('Please Enter Author Name!');</script>");
                    }
                    else
                    {
                        updateAuthor();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Author ID Does Not Exists!');</script>");
                }
            }
        }
        //Delete Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Author ID!');</script>");
            }
            else
            {
                if (checkIfAuthorIdExists())
                {
                    deleteAuthor();
                }
                else
                {
                    Response.Write("<script>alert('Author Does Not Exists!');</script>");
                }
            }
        }
        //Go Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Enter Author ID!');</script>");
            }
            else
            {
                getAuthorByID();
            }
        }
        //Clear Button
        protected void Button5_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + textbox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    textbox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                Response.Write("<script>alert('Author ID Does Not Exists!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from author_master_tbl WHERE author_id='" + textbox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author Deleted Successfully.');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='"+textbox1.Text.Trim()+"'", con);
                cmd.Parameters.AddWithValue("@author_name", textbox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values (@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", textbox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", textbox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Added Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //
        bool checkIfAuthorNameExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_name='" + textbox2.Text.Trim() + "';", con);

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
        //
        bool checkIfAuthorIdExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + textbox1.Text.Trim() + "';", con);

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
            textbox1.Text = "";
            textbox2.Text = "";
        }
    }
}