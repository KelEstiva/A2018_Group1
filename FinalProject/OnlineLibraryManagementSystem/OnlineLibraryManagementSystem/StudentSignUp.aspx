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
                                 <label>Student Full Name</label>
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
                                 <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox3" runat="server" placeholder="09*********" TextMode="Number" MaxLength="11"></asp:textbox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*sInvalid Contact Number!" ControlToValidate="textbox3" ForeColor="#CC0000" ValidationExpression="^([0]{1})([9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                             <div class="col-md-6">
                                 <label>Email Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox4" runat="server" placeholder="Example@gmail.com" TextMode="Email"></asp:textbox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Invalid Email Address!" ControlToValidate="textbox4" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                                        <asp:ListItem Text="BS in Computer Science" value="BSCS"/>
                                        <asp:ListItem Text="BS in Information System" value="BSIS"/>
                                        <asp:ListItem Text="BS in Business Administration" value="BSBA"/>
                                        <asp:ListItem Text="BS in Public Administration" value="BSPA"/>
                                        <asp:ListItem Text="BS in Civil Engineering" value="BSCE"/>
                                        <asp:ListItem Text="BS in Criminology" value="BS Crim"/>
                                        <asp:ListItem Text="BS in Hospitality Management" value="BSHM"/>
                                        <asp:ListItem Text="BS in Tourism Management" value="BSTM"/>
                                        <asp:ListItem Text="BS in Entrepreneurial Management" value="BSEM"/>
                                        <asp:ListItem Text="BS in Office Administration" value="BSOA"/>
                                        <asp:ListItem Text="BS in Psychology" value="BS Psych"/>
                                        <asp:ListItem Text="BS in Social Work" value="BSSW"/>
                                        <asp:ListItem Text="BS in Industrial Technology" value="BSIT"/>
                                        <asp:ListItem Text="BS in Industrial Engineering" value="BSIE"/>
                                        <asp:ListItem Text="BS in Secondary Education" value="BSEd"/>
                                        <asp:ListItem Text="BS in Elementary Education" value="BEEd"/>
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
                                    <asp:textbox class="form-control" ID="textbox6" runat="server" placeholder="ID" MaxLength="7" TextMode="SingleLine"></asp:textbox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Invalid Student ID!" ControlToValidate="textbox6" ForeColor="#CC0000" ValidationExpression="^([1-9]{2})([0-9]{5})$"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                             <div class="col-md-4">
                                 <label>Password</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox8" runat="server" placeholder="Password" TextMode="Password"></asp:textbox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Must have a-AZ-z and 0-9!" ControlToValidate="textbox8" ForeColor="#CC0000" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                             <div class="col-md-4">
                                 <label>Confirm Password</label>
                                <div class="form-group">
                                    <asp:textbox class="form-control" ID="textbox9" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:textbox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Password Doesn't Matched!" ControlToCompare="textbox8" ControlToValidate="textbox9" ForeColor="#CC0000"></asp:CompareValidator>
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
                <center><a href="Default.aspx"><< Back to HomePage</a><span class="clearfix"></span></center>
                <br>

</asp:Content>
