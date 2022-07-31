<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="newpost.aspx.cs" Inherits="newpost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="newPostBody">
        
          <% if ( PostError ) { %>
  <div class="alert alert-danger" role="alert">
  <%=error_message %>
</div>
<% } %>
       <div class="card newPost">
  <div class="card-body">
    <h6 class="card-title">Title</h6>
  <div class="input-group mb-3">
      <asp:TextBox CssClass="form-control" ID="PostTitle" runat="server"></asp:TextBox>
 
</div>
       <h6 class="card-title">Body</h6>
  <div class="input-group mb-3">

      <asp:TextBox Rows="9" CssClass="form-control" TextMode="MultiLine" ID="descriptionTextBox"  runat="server"></asp:TextBox>
  </div>
    <div class="my-4">
        <asp:Button ID="Button1" runat="server" Text="Post" CssClass="btn btn-primary" OnClick="Button1_Click" />
    </div>
</asp:Content>

