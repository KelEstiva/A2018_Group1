<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineLibraryManagementSystem.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <img src="imgs/home-bg.jpg" class="img-fluid" />
    </section>

    <section>
        <div class="container">
           <div class="row">
               <div class="col-12">
                   <center>
                   <h2>Our Features</h2>
                   <p><b>Our 3 Primary Features</b></p>
                   </center>
               </div>
           </div>

            <div class="row">
               <div class="col-md-4">
                   <center>
                   <img width="150px" src="imgs/digital-inventory.png" />
                   <h4>Digital Book Inventory</h4>
                   <p class="text-justify"> - This feature displays a list of in-process and available books, including raw and finished books. This also keeps track of reel-to-reel activity.</p>
                   </center>
               </div>

                <div class="col-md-4">
                   <center>
                   <img width="150px" src="imgs/search-online.png" />
                   <h4>Search Books</h4>
                   <p class="text-justify"> - This feature allows users to search for books in their preferred category.</p>
                   </center>
               </div>

                <div class="col-md-4">
                   <center>
                   <img width="150px" src="imgs/manage-user-account.jpg" />
                   <h4>Manage Student Account</h4>
                   <p class="text-justify"> - Only the admin has control for student account activation and deactivation.</p>
                   </center>
               </div>

           </div>

        </div>

    </section>

    <section>
        <img src="imgs/in-homepage-banner.jpg" class="img-fluid" />
    </section>

     <section>
        <div class="container">
           <div class="row">
               <div class="col-12">
                   <center>
                   <h2>Our Process</h2>
                   <p><b>We have a Simple 3 Step Process</b></p>
                   </center>
               </div>
           </div>

            <div class="row">
               <div class="col-md-4">
                   <center>
                   <img width="150px" src="imgs/sign-up.png" />
                   <h4>Sign Up</h4>
                   <p class="text-justify"> - To access the online library, the users need to create an account and wait for admin approval.</p>
                   </center>
               </div>

                <div class="col-md-4">
                   <center>
                   <img width="150px" src="imgs/search-online.png" />
                   <h4>Search Books</h4>
                   <p class="text-justify"> - Users can look for books they want to read or even pdf files related to the books they want to read.</p>
                   </center>
               </div>

                <div class="col-md-4">
                   <center>
                   <img width="260px" src="imgs/read-online.jpg" />
                   <h4>Read Online</h4>
                   <p class="text-justify"> - Users can view or download related pdf files to a book they want to read.</p>
                   </center>
               </div>

           </div>

        </div>

    </section>

</asp:Content>
