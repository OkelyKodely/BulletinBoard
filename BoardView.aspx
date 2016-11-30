<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="BoardView.cs" Inherits="BoardView" Title="Board View Material" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%if(Session["name"] != null) { %>
    <i>Welcome to our employee board listing page!</i><%=abc %>
    <table class="table" cellpadding="3">
      <tr><td colspan="2" style="font-weight:bold;text-color:blue;"><img src="images/comments.jpg" width="20" height="20" /> Comments from: <%=GetUserNameTitle()%></td></tr>
      <tr><td colspan="2" /></td></tr>
      <tr><td colspan="2" /></td></tr>
      <tr><td colspan="2" /></td></tr>
      <tr><td colspan="2" /></td></tr>
      <%=GetBoardViewMaterial()%>
      <tr><td colspan="2" /></td></tr>
      <tr><td colspan="2" /></td></tr>
    </table>
    <input type="button" onclick="window.location.href = 'BoardListing.aspx';" value="Board Listing Page" />
    <%} %>
</asp:Content>