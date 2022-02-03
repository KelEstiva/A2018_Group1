using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibraryManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; //student login button link
                    LinkButton2.Visible = true; //student sign up button link
                    LinkButton4.Visible = false; //view books button link
                    LinkButton3.Visible = false; //logout button link
                    LinkButton7.Visible = false; //hello student button link 
                    LinkButton6.Visible = true; //admin login button link
                    LinkButton11.Visible = false; // admin author management button link
                    LinkButton12.Visible = false; //admin publisher management button link
                    LinkButton8.Visible = false; //book inventory button link
                    LinkButton9.Visible = false; // book issuing button link
                    LinkButton10.Visible = false; // admin student management button link
                }
                else if (Session["role"].Equals("student"))
                {
                    LinkButton1.Visible = false; //student login button link
                    LinkButton2.Visible = false; //student sign up button link
                    LinkButton4.Visible = true; //view books button link
                    LinkButton3.Visible = true; //logout button link
                    LinkButton7.Visible = true; //hello student button link 
                    LinkButton7.Text = "Hello! " + Session["fullname"].ToString();
                    LinkButton6.Visible = false; //admin login button link
                    LinkButton11.Visible = false; // admin author management button link
                    LinkButton12.Visible = false; //admin publisher management button link
                    LinkButton8.Visible = false; //book inventory button link
                    LinkButton9.Visible = false; // book issuing button link
                    LinkButton10.Visible = false; // admin student management button link

                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //student login button link
                    LinkButton2.Visible = false; //student sign up button link
                    LinkButton4.Visible = true; //view books button link
                    LinkButton3.Visible = true; //logout button link
                    LinkButton7.Visible = true; //hello student button link 
                    LinkButton7.Text = "Hello! " + Session["fullname"].ToString();
                    LinkButton6.Visible = false; //admin login button link
                    LinkButton11.Visible = true; // admin author management button link
                    LinkButton12.Visible = true; //admin publisher management button link
                    LinkButton8.Visible = true; //book inventory button link
                    LinkButton9.Visible = false; // book issuing button link
                    LinkButton10.Visible = true; // admin student management button link
                }
            }
            catch (Exception ex)
            {
                Response.Write("<srcipt>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAuthorManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPublisherManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuingPage.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminStudentManagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSignUp.aspx");
        }
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("student"))
            {
                Response.Redirect("StudentProfile.aspx");
            }
            else if (Session["role"].Equals("admin"))
            {
                Response.Redirect("AdminProfile.aspx");
            }
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session.Remove("username");
            Session.RemoveAll();
            Session.Abandon();

            LinkButton1.Visible = true; //student login button link
            LinkButton2.Visible = true; //student sign up button link
            LinkButton4.Visible = false; //view books button link

            LinkButton3.Visible = false; //logout button link
            LinkButton7.Visible = false; //hello student button link 

            LinkButton6.Visible = true; //admin login button link

            LinkButton11.Visible = false; // admin author management button link
            LinkButton12.Visible = false; //admin publisher management button link
            LinkButton8.Visible = false; //book inventory button link
            LinkButton9.Visible = false; //book issuing button link
            LinkButton10.Visible = false; //admin student management button link
            LinkButton4.Visible = false; //view books button link

            Response.Redirect("HomePage.aspx");

        }
    }
}