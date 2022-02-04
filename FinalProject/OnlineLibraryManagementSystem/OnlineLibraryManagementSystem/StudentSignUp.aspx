<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentSignUp.aspx.cs" Inherits="OnlineLibraryManagementSystem.UserSignUp" %>
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
                                    <h4>Student Sign Up</h4>
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
                                 <label>Student Name</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox1" runat="server" placeholder="Last Name/Given Name/M.I."></asp:textbox>
                                </div>
                            </div>

                             <div class="col-md-6">
                                 <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" TextMode="Date"></asp:textbox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                 <label>Contact No.</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox3" runat="server" placeholder="09*********" TextMode="Number"></asp:textbox>
                                </div>
                            </div>

                             <div class="col-md-6">
                                 <label>Email Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox4" runat="server" placeholder="Example@gmail.com" TextMode="Email"></asp:textbox>
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

                            <div class="col-md-6">
                                 <label>Course</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="--Select--" value="--Select--"/>
                                        <asp:ListItem Text="BSCS" value="BSCS"/>
                                        <asp:ListItem Text="BSIS" value="BSIS"/>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
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
                            <div class="col-md-4">
                                 <label>Student ID</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox6" runat="server" placeholder="ID" TextMode="Number"></asp:textbox>
                                </div>
                            </div>

                             <div class="col-md-4">
                                 <label>Password</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox8" runat="server" placeholder="Password" TextMode="Password"></asp:textbox>
                                </div>
                            </div>

                             <div class="col-md-4">
                                 <label>Confirm Password</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox9" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:textbox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Does Not Matched!" ControlToCompare="textbox8" ControlToValidate="textbox9" ForeColor="#CC0000"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" text="Sign Up" OnClick="Button1_Click"/>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server" text="Clear Form" OnClick="Button2_Click" />
                                </div>
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
