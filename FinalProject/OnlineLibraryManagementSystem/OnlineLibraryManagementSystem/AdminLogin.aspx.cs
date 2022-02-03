﻿using System;
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
    public partial class AdminLogin : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]!=null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (textbox1.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Admin Username!');</script>");
            }
            else if (textbox2.Text.Equals(""))
            {
                Response.Write("<script>alert('Please Enter Admin Password!');</script>");
            }
            else
            {
                adminLogin();

            }
        }
        //login function
        void adminLogin()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from admin_login_tbl where username='" + textbox1.Text.Trim() + "' AND password='" + textbox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login Successful.');</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Admin Username or Password!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}