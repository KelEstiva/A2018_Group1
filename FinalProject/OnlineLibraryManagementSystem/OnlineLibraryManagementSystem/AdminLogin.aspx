<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="OnlineLibraryManagementSystem.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/adminuser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Admin Username</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox1" runat="server" placeholder="Username"></asp:textbox>
                                </div>

                                <label>Password</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" placeholder="Password" TextMode="Password"></asp:textbox>
                                </div>

                                <div class="form-group">
                                    <asp:button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" text="Login" OnClick="Button1_Click" />
                                </div>
                                <center><a href="AdminForgotPassword.aspx">Forgot Password?</a><span class="clearfix"></span></center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
    </div>
    <br>
                <center><a href="Default.aspx"><< Back to HomePage</a><span class="clearfix"></span></center>
                <br>

</asp:Content>
