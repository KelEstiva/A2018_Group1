<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminAuthorManagement.aspx.cs" Inherits="OnlineLibraryManagementSystem.AdminAuthorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/writer.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                 <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:textbox CssClass="form-control" ID="textbox1" runat="server" placeholder="ID"></asp:textbox>
                                    <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Go" />
                                </div>
                              </div>
                            </div>

                             <div class="col-md-8">
                                 <label>Author Name</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" placeholder="Author Name"></asp:textbox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-success btn-block" runat="server" Text="Add" />
                            </div>

                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-warning btn-block" runat="server" Text="Update" />
                            </div>

                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-danger btn-block" runat="server" Text="Delete" />
                            </div>
                        </div>

                    </div>
                  </div>
                <br>
               <a href="HomePage.aspx"><< Back to HomePage</a> <br> <br> <br> <br> <br> <br> <br>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Authort List</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>
                        
                   </div>
               </div>
            </div>
        </div> 
    </div>

</asp:Content>
