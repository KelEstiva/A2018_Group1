<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminStudentManagement.aspx.cs" Inherits="OnlineLibraryManagementSystem.AdminMemberManagement" %>
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
                                    <h4>Student Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                         <div class="row">

                             <div class="col-md-5">
                                 <label>Student ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox7" runat="server" placeholder="Student ID"></asp:textbox>
                                    <asp:LinkButton Class="btn btn-primary" ID="LinkButton4" Text="Go" runat="server"></asp:LinkButton>
                                </div>
                              </div>
                            </div>

                              <div class="col-md-7">
                                 <label>Account Status</label>
                                <div class="form-group">
                                     <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox3" runat="server" placeholder="Account Status" ReadOnly="True"></asp:textbox>

                                    <asp:LinkButton Class="btn btn-success mr-1" ID="LinkButton1" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    <asp:LinkButton Class="btn btn-warning mr-1" ID="LinkButton2" runat="server"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                    <asp:LinkButton Class="btn btn-danger mr-1" ID="LinkButton3" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>

                                </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                 <label>Full Name</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox12" runat="server" placeholder="Full Name" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" placeholder="Date of Birth" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                            </div>

                        <div class="row">

                             <div class="col-md-6">
                                 <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox1" runat="server" placeholder="Contact Number" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Email Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox4" runat="server" placeholder="Email Address" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                             <div class="col-md-4">
                                 <label>Gender</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox5" runat="server" placeholder="Gender" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Course</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox6" runat="server" placeholder="Course" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Year</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox8" runat="server" placeholder="Year" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-12">
                                 <label>Full Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox11" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                        <asp:Button Class="btn btn-lg btn-block btn-danger" ID="Button5" Text="Delete User Permanently" runat="server"></asp:Button>
                            </div>
                            </div>
                    </div>
                  </div>
                <br>
               <a href="HomePage.aspx"><< Back to HomePage</a> <br> <br>  
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Student List</h4>
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
