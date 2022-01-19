<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="OnlineLibraryManagementSystem.AdminBookInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
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
                                    <img id="imgview" height="150px" width="100px" src="book_inventory/books1.png" />
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
                                 <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:textbox CssClass="form-control mr-1" ID="textbox7" runat="server" placeholder="Book ID"></asp:textbox>
                                    <asp:Button CssClass="btn btn-primary" ID="Button3" runat="server" Text="Go" OnClick="Button3_Click" />
                                </div>
                              </div>
                            </div>
                              <div class="col-md-8">
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
                                        <asp:ListItem Text="English" value="English"/>
                                        <asp:ListItem Text="Filipino" value="Filipino"/>
                                    </asp:DropDownList>
                                </div>
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList Class="form-control" ID="DropDownList2" runat="server">

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                 <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList Class="form-control" ID="DropDownList3" runat="server">

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
                                 <label>Pages</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                    <asp:textbox CssClass="form-control" ID="textbox9" runat="server" placeholder="Pages" TextMode="Number"></asp:textbox>
                                 </div>
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
                                <asp:FileUpload onchange="readURL(this);" Class="form-control" ID="FileUpload3" runat="server" />
                            </div>
                            <div class="col-md-6">
                                <label>Upload PDF File</label>
                                <asp:FileUpload Class="form-control" ID="FileUpload4" runat="server" />
                            </div>
                        </div>
                        <br>
                        <div class="row">
                            <div class="col-4">
                        <asp:Button Class="btn btn-lg btn-block btn-success" ID="Button5" Text="Add" runat="server" OnClick="Button5_Click"></asp:Button>
                            </div>
                            <div class="col-4">
                        <asp:Button Class="btn btn-lg btn-block btn-warning" ID="Button1" Text="Update" runat="server" OnClick="Button1_Click"></asp:Button>
                            </div>
                            <div class="col-4">
                        <asp:Button Class="btn btn-lg btn-block btn-danger" ID="Button2" Text="Delete" runat="server" OnClick="Button2_Click"></asp:Button>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:olmsConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                        <ControlStyle Font-Bold="True" />
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-9">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Author -
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Genre -
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher -
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish Date -
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Pages -
                                                                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;|Edition -
                                                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Description -
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>'></asp:Image>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                   </div>
               </div>
            </div>
        </div> 
    </div>
</asp:Content>
