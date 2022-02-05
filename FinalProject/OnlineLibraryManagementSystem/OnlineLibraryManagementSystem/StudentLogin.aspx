<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="OnlineLibraryManagementSystem.UserLogin" %>
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
                                    <img width="150px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Student Login</h3>
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
                                <label>Student ID</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox1" runat="server" placeholder="ID" TextMode="SingleLine" MaxLength="7"></asp:textbox>
                                </div>

                                <label>Password</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" placeholder="Password" TextMode="Password"></asp:textbox>
                                </div>

                                <div class="form-group">
                                    <asp:button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" text="Login" OnClick="Button1_Click" />
                                    
                                </div>

                                <div class="form-group">
                                    <a href="StudentSignUp.aspx">
                                    <input class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Sign Up" />
                                    </a>
                                </div>
                <center><a href="StudentForgotPassword.aspx">Forgot Password?</a><span class="clearfix"></span></center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
    </div>
    <br>
                <center><a href="HomePage.aspx"><< Back to HomePage</a><span class="clearfix"></span></center>
                <br>
</asp:Content>
