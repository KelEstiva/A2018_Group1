using System;
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

        static string global_filepath_img, global_filepath_pdf;

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
                    if (!IsPostBack)
                    {
                        fillAuthorPublisherValues();
                    }
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
            if (textbox7.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Input Book ID!');</script>");
            }
            else if (textbox3.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Input Book Name!');</script>");
            }
            else if (DropDownList1.SelectedItem.Value == "--Select--")
            {
                Response.Write("<script>alert('Please Select Book Language!');</script>");
            }
            else if (textbox2.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Input Book Publish Date!');</script>");
            }
            else if (textbox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Input Book Edition!');</script>");
            }
            else if (textbox9.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Input Book Pages!');</script>");
            }
            else if (textbox11.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Please Input Book Description!');</script>");
            }
            else
            {
                addNewBook();
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
                Response.Write("<script>alert('Please Enter Book ID.');</script>");
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
                Response.Write("<script>alert('Invalid Book ID!');</script>");

            }
        }
        //Clear Form Function
        void clearForm()
        {
            textbox7.Text = "";
            textbox3.Text = "";
            DropDownList1.SelectedValue = "--Select--";
            //DropDownList2
            //DropDownLost3
            textbox2.Text = "";
            textbox1.Text = "";
            textbox9.Text = "";
            ListBox1.ClearSelection();
            textbox1.Text = "";
            textbox11.Text = "";
            //FileUpload3
            //FileUpload4
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
                        genres = genres + ListBox1.Items[i] + ',';
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath_img = "~/book_inventory/books1.png";
                    string filename_img = Path.GetFileName(FileUpload3.PostedFile.FileName);

                    if (filename_img == "" || filepath_img == null)
                    {
                        filepath_img = global_filepath_img;
                    }
                    else
                    {
                        FileUpload3.SaveAs(Server.MapPath("book_inventory/" + filename_img));
                        filepath_img = "~/book_inventory/" + filename_img;
                    }

                    string filepath_pdf = "~/book_pdf/";
                    string filename_pdf = Path.GetFileName(FileUpload4.PostedFile.FileName);

                    if (filename_pdf == "" || filepath_pdf == null)
                    {
                        filepath_pdf = global_filepath_pdf;
                    }
                    else
                    {
                        FileUpload4.SaveAs(Server.MapPath("book_pdf/" + filename_pdf));
                        filepath_pdf = "~/book_pdf/" + filename_pdf;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,no_of_pages=@no_of_pages,book_description=@book_description,book_img_link=@book_img_link,book_pdf_link=@book_pdf_link WHERE book_id= '" + textbox7.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", textbox3.Text);
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", textbox2.Text);
                    cmd.Parameters.AddWithValue("@edition", textbox1.Text);
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@no_of_pages", textbox9.Text);
                    cmd.Parameters.AddWithValue("@book_description", textbox11.Text);
                    cmd.Parameters.AddWithValue("@book_img_link", filepath_img);
                    cmd.Parameters.AddWithValue("@book_pdf_link", filepath_pdf);
                    //1
                    if (FileUpload3.HasFile && FileUpload4.HasFile)
                    {
                        string FileExtension_IMG = Path.GetExtension(FileUpload3.FileName);
                        string FileExtension_PDF = Path.GetExtension(FileUpload4.FileName);

                        if ((FileExtension_IMG == ".jpg" || FileExtension_IMG == ".png") && FileExtension_PDF == ".pdf")
                        {
                            cmd.ExecuteNonQuery();
                            con.Close();
                            GridView1.DataBind();
                            getBookbyID();
                            Response.Write("<script>alert('Book Details Updated Successfully.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Please Upload JPG or PNG File for Book Image and PDF File for Book PDF!');</script>");
                        }
                    }
                    //2
                    else if (FileUpload3.HasFile)
                    {
                        string FileExtension_IMG = Path.GetExtension(FileUpload3.FileName);

                        if (FileExtension_IMG == ".jpg" || FileExtension_IMG == ".png")
                        {
                            cmd.ExecuteNonQuery();
                            con.Close();
                            GridView1.DataBind();
                            getBookbyID();
                            Response.Write("<script>alert('Book Details Updated Successfully.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Please Upload JPG or PNG File Book Image!');</script>");
                        }
                    }
                    //3
                    else if (FileUpload4.HasFile)
                    {
                        string FileExtension_PDF = Path.GetExtension(FileUpload4.FileName);

                        if (FileExtension_PDF == ".pdf")
                        {
                            cmd.ExecuteNonQuery();
                            con.Close();
                            GridView1.DataBind();
                            getBookbyID();
                            Response.Write("<script>alert('Book Details Updated Successfully.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Please Upload PDF File for Book PDF!');</script>");
                        }
                    }
                    //4
                    else
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();
                        GridView1.DataBind();
                        getBookbyID();
                        Response.Write("<script>alert('Book Details Updated Successfully.');</script>");
                    }
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
                SqlCommand cmd = new SqlCommand("Select * FROM book_master_tbl WHERE book_id='" + textbox7.Text.Trim() + "';", con);
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
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }
                    global_filepath_img = dt.Rows[0]["book_img_link"].ToString().Trim();
                    global_filepath_pdf = dt.Rows[0]["book_pdf_link"].ToString().Trim();
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
            catch (Exception ex)
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

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + textbox7.Text.Trim() + "' OR book_name='" + textbox3.Text.Trim() + "';", con);
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
        //Clear Form Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        //Adding Button function
        void addNewBook()
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book ID Already Exists!');</script>");
            }
            else
            {
                try
                {
                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ',';
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath_img = "~/book_inventory/books1.png";
                    string filename_img = Path.GetFileName(FileUpload3.PostedFile.FileName);
                    FileUpload3.SaveAs(Server.MapPath("book_inventory/" + filename_img));
                    filepath_img = "~/book_inventory/" + filename_img;

                    string filepath_pdf = "~/book_pdf/";
                    string filename_pdf = Path.GetFileName(FileUpload4.PostedFile.FileName);
                    FileUpload4.SaveAs(Server.MapPath("book_pdf/" + filename_pdf));
                    filepath_pdf = "~/book_pdf/" + filename_pdf;

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,no_of_pages,book_description,book_img_link,book_pdf_link) values (@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@no_of_pages,@book_description,@book_img_link,@book_pdf_link)", con);
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
                    cmd.Parameters.AddWithValue("@book_img_link", filepath_img);
                    cmd.Parameters.AddWithValue("@book_pdf_link", filepath_pdf);

                    if (FileUpload3.HasFile && FileUpload4.HasFile)
                    {
                        string FileExtension_IMG = Path.GetExtension(FileUpload3.FileName);
                        string FileExtension_PDF = Path.GetExtension(FileUpload4.FileName);

                        if ((FileExtension_IMG == ".jpg" || FileExtension_IMG == ".png") && FileExtension_PDF == ".pdf")
                        {
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('Book Added Successfully.');</script>");
                            clearForm();
                            GridView1.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('Please Upload JPG or PNG File For Book Image And PDF File for Book PDF!');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}