<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="BoardPostComment.cs" Inherits="BoardPostComment" Title="Board Post Comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%if(Session["name"] != null) { %>
    <i>Welcome to our employee board listing page!</i>
    <br />
      <form method="post" action="">
          <font size="4">POST YOUR COMMENT</font><br />
          <textarea name="material" cols="100" rows="14"></textarea>
          <br /><input type="submit" name="admit" style="width:100px" value="Post" />
          <input type="hidden" name="_id" value="<%=Session["_id"]%>" />
      </form><br /><br />
    <input type="button" onclick="window.location.href = 'BoardListing.aspx';" value="Board Listing Page" />
    <%} %>
</asp:Content>