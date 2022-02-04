<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminStudentManagement.aspx.cs" Inherits="OnlineLibraryManagementSystem.AdminMemberManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });
   </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
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
                             <div class="col-md-12">
                                 <label>Student ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox7" runat="server" placeholder="ID" TextMode="Number"></asp:textbox>
                                    <asp:LinkButton Class="btn btn-primary" ID="LinkButton4" Text="Go" runat="server" OnClick="LinkButton4_Click"></asp:LinkButton>
                                </div>
                              </div>
                            </div>
                        </div>

                        <div class="row">
                              <div class="col-md-12">
                                 <label>Account Status</label>
                                <div class="form-group">
                                     <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox10" runat="server" placeholder="Status" ReadOnly="True"></asp:textbox>

                                    <asp:LinkButton Class="btn btn-success mr-1" ID="LinkButton6" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    <asp:LinkButton Class="btn btn-warning mr-1" ID="LinkButton7" runat="server" OnClick="LinkButton2_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                    <asp:LinkButton Class="btn btn-danger mr-1" ID="LinkButton8" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>

                                </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-12">
                                 <label>Stdudent Name</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox12" runat="server" placeholder="Last Name/Given Name/M.I." ReadOnly="True"></asp:textbox>
                                </div>
                            </div>
                            </div>

                        <div class="row">

                                <div class="col-md-6">
                                 <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox3" runat="server" ReadOnly="True" TextMode="Date"></asp:textbox>
                                </div>
                            </div>


                             <div class="col-md-6">
                                 <label>Contact No.</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox1" runat="server" placeholder="09*********" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                 <label>Email Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" placeholder="Example@gmail.com" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>
                             </div>

                        <div class="row">
                             <div class="col-md-6">
                                 <label>Gender</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox5" runat="server" placeholder="Gender" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-6">
                            <label>Age</label>
                                 <div class="form-group">
                                     <asp:TextBox CssClass="form-control" ID="textbox4" runat="server" placeholder="Age" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                 </div>
                                </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                 <label>Course</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox6" runat="server" placeholder="Course" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Year Level</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox8" runat="server" placeholder="Year Level" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                 <label>Permanent Address</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox11" runat="server" placeholder="House#/ Lot#/ Block#/ Street/ Barangay/ City/ Province" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 mx-auto">
                        <asp:Button Class="btn btn-lg btn-block btn-danger" ID="Button5" Text="Delete" runat="server" OnClick="Button5_Click"></asp:Button>
                            </div>
                            <div class="col-6 mx-auto">
                        <asp:Button Class="btn btn-lg btn-block btn-success" ID="Button1" Text="Clear" runat="server" OnClick="Button1_Click"></asp:Button>
                            </div>
                            </div>
                    </div>
                  </div>
            </div>

            <div class="col-md-8">

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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:olmsConnectionString %>" SelectCommand="SELECT * FROM [student_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="student_id" HeaderText="ID" ReadOnly="True" SortExpression="student_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_number" HeaderText="Contact No." SortExpression="contact_number" />
                                        <asp:BoundField DataField="email_address" HeaderText="Email Address" SortExpression="email_address" />
                                        <asp:BoundField DataField="course" HeaderText="Course" SortExpression="course" />
                                        <asp:BoundField DataField="year" HeaderText="Year Level" SortExpression="year" />
                                    </Columns>
                                </asp:GridView>
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
