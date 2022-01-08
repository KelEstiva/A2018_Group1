<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="OnlineLibraryManagementSystem.AdminBookInventory" %>
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
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books.png" />
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
                                 <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox7" runat="server" placeholder="Book ID"></asp:textbox>
                                    <asp:LinkButton Class="btn btn-primary" ID="LinkButton4" Text="Go" runat="server"></asp:LinkButton>
                                </div>
                              </div>
                            </div>

                              <div class="col-md-7">
                                 <label>Book Name</label>
                                <div class="form-group">
                                     <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox3" runat="server" placeholder="Book Name"></asp:textbox>

                                </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                 <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList Class="form-control" ID="DropDownList1" runat="server">

                                        <asp:ListItem Text="Select" value="Select"/>
                                        <asp:ListItem Text="English" value="English"/>
                                        <asp:ListItem Text="Filipino" value="Filipino"/>

                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList Class="form-control" ID="DropDownList2" runat="server">

                                        <asp:ListItem Text="Select" value="Select"/>
                                        <asp:ListItem Text="Publisher1" value="Publisher1"/>
                                        <asp:ListItem Text="Publisher2" value="Publisher2"/>

                                    </asp:DropDownList>
                                </div>

                            </div>

                            <div class="col-md-6">
                                 <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList Class="form-control" ID="DropDownList3" runat="server">

                                        <asp:ListItem Text="Select" value="Select"/>
                                        <asp:ListItem Text="A1" value="A1"/>
                                        <asp:ListItem Text="A2" value="A2"/>

                                    </asp:DropDownList>
                                </div>

                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox2" runat="server" placeholder="Date" TextMode="Date"></asp:textbox>
                                </div>

                            </div>

                            </div>

                        <div class="row">

                            <div class="col-md-6">
                                 <label>Edition</label>
                                <div class="form-group">
                                     <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox1" runat="server" placeholder="Edition"></asp:textbox>
                                </div>
                                </div>

                                <label>Actual Stock</label>
                                <div class="form-group">
                                     <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox8" runat="server" placeholder="Actual Stock"></asp:textbox>
                                </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">

                                        <asp:ListItem Text="Action" Value="Action"/>
                                        <asp:ListItem Text="Adventure" Value="Adventure"/>
                                        <asp:ListItem Text="Comic Book" Value="Comic Book"/>
                                        <asp:ListItem Text="Self Help" Value="Self Help"/>
                                        <asp:ListItem Text="Motivation" Value="Motivation"/>
                                        <asp:ListItem Text="Healthy Living" Value="Healthy Living"/>
                                        <asp:ListItem Text="Wellness" Value="Wellness"/>
                                        <asp:ListItem Text="Crime" Value="Crime"/>
                                        <asp:ListItem Text="Action" Value="Action"/>
                                        <asp:ListItem Text="Drama" Value="Adventure"/>
                                        <asp:ListItem Text="Fantasy" Value="Fantasy"/>
                                        <asp:ListItem Text="Horror" Value="Horror"/>
                                        <asp:ListItem Text="Poetry" Value="Poetry"/>
                                        <asp:ListItem Text="Personal Development" Value="Personal Development"/>
                                        <asp:ListItem Text="Romance" Value="Romance"/>
                                        <asp:ListItem Text="Science Fiction" Value="Science Fiction"/>
                                        <asp:ListItem Text="Suspense" Value="Suspense"/>
                                        <asp:ListItem Text="Thriller" Value="Thriller"/>
                                        <asp:ListItem Text="Art" Value="Art"/>
                                        <asp:ListItem Text="Autobiography" Value="Autobiography"/>
                                        <asp:ListItem Text="Encyclopedia" Value="Encyclopedia"/>
                                        <asp:ListItem Text="Health" Value="Health" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Math" Value="Math" />
                                        <asp:ListItem Text="Textbook" Value="Textbook" />
                                        <asp:ListItem Text="Science" Value="Science" />
                                        <asp:ListItem Text="Travel" Value="Travel" />

                                    </asp:ListBox>
                                </div>
                            </div>

                            </div>

                        <div class="row">

                            <div class="col-md-6">
                                 <label>Book Cost (Per Unit)</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox4" runat="server" placeholder="Book Cost (Per Unit)" TextMode="Number"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Pages</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox9" runat="server" placeholder="Pages" TextMode="Number"></asp:textbox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                 <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox5" runat="server" placeholder="Current Stock" ReadOnly="True" TextMode="Number"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox10" runat="server" placeholder="Issued Books"  ReadOnly="True" TextMode="Number"></asp:textbox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-12">
                                 <label>Book Description</label>
                                <div class="form-group">
                                    <asp:textbox CssClass="form-control" ID="textbox11" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:textbox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Book Image</label>
                                <asp:FileUpload Class="form-control" ID="FileUpload3" runat="server" />
                            </div>

                            <div class="col-md-6">
                                <label>Upload PDF File</label>
                                <asp:FileUpload Class="form-control" ID="FileUpload4" runat="server" />
                            </div>

                        </div>

                        <br>

                        <div class="row">
                            <div class="col-4">
                        <asp:Button Class="btn btn-lg btn-block btn-success" ID="Button5" Text="Add" runat="server"></asp:Button>
                            </div>
                            <div class="col-4">
                        <asp:Button Class="btn btn-lg btn-block btn-warning" ID="Button1" Text="Update" runat="server"></asp:Button>
                            </div>
                            <div class="col-4">
                        <asp:Button Class="btn btn-lg btn-block btn-danger" ID="Button2" Text="Delete" runat="server"></asp:Button>
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
                                    <h4>Book Inventory List</h4>
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
