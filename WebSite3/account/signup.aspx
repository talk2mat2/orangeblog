<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="d-flex flex-row justify-content-center ">
     
      <div class="col-8">

          <% if ( Pass_Email_Error ) { %>
  <div class="alert alert-danger" role="alert">
  <%=error_message %>
</div>
<% } %>
          <% if ( success ) { %>
<div class="alert alert-success" role="alert">
  <%=success_message %>
</div>
<% } %>
         
           <div class="text-center mb-5 mt-6"><h3>Register here</h3></div>
          <ul class="list-group">
             
              <li class="text-center"> Email address</li>
<li class="list-group-item border-0">  <asp:TextBox CssClass="form-control my-2" ID="Email" runat="server"></asp:TextBox></li>
  <li class="text-center"> Password</li>
              <li class="list-group-item border-0">  <asp:TextBox  TextMode="Password" CssClass="form-control my-2" ID="Password" runat="server"></asp:TextBox></li>

                  <li class="text-center"> Full Name</li>
              <li class="list-group-item border-0">  <asp:TextBox CssClass="form-control my-2" ID="Name" runat="server"></asp:TextBox></li>

</ul>
          <div class="text-center">
              <asp:Button CssClass="btn my-4 btn-primary" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
          </div>
      </div>

  </div>
</asp:Content>

