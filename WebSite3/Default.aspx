<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="container ">
       <div class="text-center mb-5"><h3>Blog Posts</h3></div>
       
       <%  if (!string.IsNullOrEmpty(Session["user"] as string))
           {  %>
        <div class="text-right mb-2"><a href="/newpost.aspx" class="btn btn-primary">create post</a></div>
       <%} %>
          

       <asp:Repeater ID="RepterDetails" runat="server">

           <ItemTemplate>
  <div class="card my-4">
  <div class="card-header">
   <%# Eval("name") %>  wrote
  </div>
  <div class="card-body">
    <h5 class="card-title"><%# Eval("title") %></h5>
    <p class="card-text"><%#Eval("body") %></p>
    <a href="#" class="mt-4">Read more</a>
  </div>
</div>
  
           </ItemTemplate>
       </asp:Repeater>
       
    
   
   </div>
</asp:Content>

