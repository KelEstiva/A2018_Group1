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
    public partial class AdminPublisherManagement : System.Web.UI.Page
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
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Publisher ID!');</script>");
            }
            else if (textbox2.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Publisher Name!');</script>");
            }
            else
            {
                if (checkIfPublisherIdExists())
                {
                    Response.Write("<script>alert('Publisher ID Already Exist!');</script>");
                }
                else
                {
                    if (checkIfPublisherNameExists())
                    {
                        Response.Write("<script>alert('Publisher Name Already Exist!');</script>");
                    }
                    else
                    {
                        addNewPublisher();
                    }
                }
            }
        }

        // Update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Publisher ID!');</script>");
            }
            else
            {
                if (checkIfPublisherIdExists())
                {
                    if (textbox2.Text.Equals(""))
                    {
                        Response.Write("<script>alert('Please Enter Publisher Name!');</script>");
                    }
                    else
                    {
                        updatePublisher();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Publisher ID Does Not Exists.');</script>");
                }
            }
        }

        //Delete Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Publisher ID!');</script>");
            }
            else
            {
                if (checkIfPublisherIdExists())
                {
                    deletePublisher();
                }
                else
                {
                    Response.Write("<script>alert('Publisher ID Does Not Exists!');</script>");
                }
            }
        }

        // Go Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Publisher ID!');</script>");
            }
            else
            {
                getPublisherByID();
            }
        }

        void getPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + textbox1.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    textbox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Publisher ID Does Not Exists!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //
        bool checkIfPublisherNameExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_name='" + textbox2.Text.Trim() + "';", con);

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
        bool checkIfPublisherIdExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + textbox1.Text.Trim() + "';", con);

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

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) values (@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", textbox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", textbox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher Added Successfully.');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE  publisher_id='" + textbox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", textbox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert(' Publisher Updated Successfully.');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from publisher_master_tbl WHERE publisher_id='" + textbox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher Deleted Successfully.');</script>");
                clearForm();
                GridView1.DataBind();

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
        }
        // Clear Form Button
        protected void Button5_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}