<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentForgotPassword.aspx.cs" Inherits="OnlineLibraryManagementSystem.StudentForgotPassword" %>
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
                                    <h3>Please Enter Your Registered Student ID And Email Address</h3>
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

                                <label>Email Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" placeholder="Example@gmail.com" TextMode="Email"></asp:textbox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Invalid Email Address!" ControlToValidate="textbox2" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group">
                                    <asp:button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" text="Submit" OnClick="Button1_Click" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
    </div>
    <br>
    <br>
    <br>
    <br>
                <center><a href="Default.aspx"><< Back to HomePage</a><span class="clearfix"></span></center>
                <br>

</asp:Content>
