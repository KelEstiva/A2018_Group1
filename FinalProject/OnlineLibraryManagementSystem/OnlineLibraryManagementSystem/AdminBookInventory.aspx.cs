﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibraryManagementSystem
{
    public partial class AdminBookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }
            GridView1.DataBind();
        }
        //Go Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (textbox7.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Input Book ID!');</script>");
            }
            else
            {
                getBookbyID();
            }
        }
        //Add book Button
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (textbox7.Text.Trim().Equals("") | textbox3.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Input Book ID or Book Name!');</script>");
            }
            else
            {
                if (checkIfBookExists())
                {
                    Response.Write("<script>alert('Book ID Already Exist!');</script>");
                }
                else
                {
                    addNewBook();
                }
            }
        }
        //Update Book Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }
        //Delete Book Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (textbox7.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please enter Student ID.');</script>");
            }
            else
            {
                deleteBookByID();
            }
        }
        //Delete Book Function
        void deleteBookByID()
        {
                if (checkIfBookExists())
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + textbox7.Text.Trim() + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Book Deleted Successfully.');</script>");
                        //clearForm();
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID!');</script>");

                }
        }
        //Update Button Function
        void updateBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    
                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FileUpload3.PostedFile.FileName);

                    if (filename == "" || filename == null)
                    { 
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload3.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,no_of_pages=@no_of_pages,book_description=@book_description,book_img_link=@book_img_link WHERE book_id= '" + textbox7.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", textbox3.Text);
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", textbox2.Text);
                    cmd.Parameters.AddWithValue("@edition", textbox1.Text);
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@no_of_pages", textbox9.Text);
                    cmd.Parameters.AddWithValue("@book_description", textbox11.Text);
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Details Updated Successfully.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID!');</script>");
            }
        }
        //Go Button Function
        void getBookbyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * FROM book_master_tbl WHERE book_id='"+textbox7.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    textbox3.Text = dt.Rows[0]["book_name"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    textbox2.Text = dt.Rows[0]["publish_date"].ToString().Trim();
                    textbox1.Text = dt.Rows[0]["edition"].ToString().Trim();
                    textbox9.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    textbox11.Text = dt.Rows[0]["book_description"].ToString().Trim();
                    ListBox1.ClearSelection();

                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i=0; i<genre.Length; i++)
                    {
                        for (int j=0; j<ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString()==genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //Getting the values of Author Name and Publisher Name from database function
        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select author_name FROM author_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("Select publisher_name FROM publisher_master_tbl;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //Checking if the book id or name exists function
        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + textbox7.Text.Trim() + "' OR book_name='"+textbox3.Text.Trim()+"';", con);
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
        //Adding Button function
        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload3.PostedFile.FileName);
                FileUpload3.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,no_of_pages,book_description,book_img_link) values (@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@no_of_pages,@book_description,@book_img_link)", con);
                cmd.Parameters.AddWithValue("@book_id", textbox7.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", textbox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", textbox2.Text.Trim());
                cmd.Parameters.AddWithValue("@edition", textbox1.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@no_of_pages", textbox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", textbox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Added Successfully.');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}