<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="OnlineLibraryManagementSystem.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Student Profile</h4>
                                    <span>Account Status - </span>
                                     <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your Status"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                 <label>Student Full Name</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox1" runat="server" placeholder="Student Full Name"></asp:textbox>
                                </div>
                            </div>

                             <div class="col-md-6">
                                 <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" placeholder="Password" TextMode="Date"></asp:textbox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                 <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox3" runat="server" placeholder="Contact Number" TextMode="Number"></asp:textbox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Contact Number!" ControlToValidate="textbox3" ForeColor="#CC0000" ValidationExpression="^([0]{1})([9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                             <div class="col-md-6">
                                 <label>Email Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox4" runat="server" placeholder="Email Address" TextMode="Email"></asp:textbox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                             <div class="col-md-6">
                                 <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="--Select--" value="--Select--"/>
                                        <asp:ListItem Text="Male" value="Male"/>
                                        <asp:ListItem Text="Female" value="Female"/>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                             <div class="col-md-6">
                                 <label>Age</label>
                                 <div class="form-group">
                                     <asp:TextBox CssClass="form-control" ID="textbox7" runat="server" placeholder="Age" TextMode="Number"></asp:TextBox>
                                 </div>
                             </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                 <label>Course</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="--Select--" value="--Select--"/>
                                        <asp:ListItem Text="BSCS" value="BSCS"/>
                                        <asp:ListItem Text="BSIS" value="BSIS"/>
                                        <asp:ListItem Text="Select" value="select"/>
                                        <asp:ListItem Text="Select" value="select"/>
                                        <asp:ListItem Text="Select" value="select"/>
                                        <asp:ListItem Text="Select" value="select"/>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Year Level</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="--Select--" value="--Select--"/>
                                        <asp:ListItem Text="1st Year" value="1st Year"/>
                                        <asp:ListItem Text="2nd Year" value="2nd Year"/>
                                        <asp:ListItem Text="3rd Year" value="3rd Year"/>
                                        <asp:ListItem Text="4th Year" value="4th Year"/>
                                        <asp:ListItem Text="5th Year" value="5th Year"/>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12 mx-auto">
                                 <label>Permanent Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox5" runat="server" placeholder="House#/ Lot#/ Block#/ Street/ Barangay/ City/ Province" TextMode="MultiLine" Rows="2"></asp:textbox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                <span class="badge badge-pill badge-info">Student Login Credentials</span>
                                    </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                 <label>Student ID</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox6" runat="server" placeholder="Student ID" TextMode="Number" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                             <div class="col-md-6">
                                 <label>Current Password</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox8" runat="server" placeholder="Password" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                 <label>New Password</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox9" runat="server" placeholder="Password" TextMode="Password"></asp:textbox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Password!" ControlToValidate="textbox9" ForeColor="#CC0000" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Confirm New Password</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox10" runat="server" placeholder="Confirm New Password" TextMode="Password"></asp:textbox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="New Password Does Not Matched!" ControlToCompare="textbox9" ControlToValidate="textbox10" ForeColor="#CC0000"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12 mx-auto">
                                <center>
                                <div class="form-group">
                                    <asp:button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" text="Update" OnClick="Button1_Click" />
                                </div>
                                </center>
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
