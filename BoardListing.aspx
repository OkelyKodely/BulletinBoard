<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="BoardListing.cs" Inherits="BoardListing" Title="Board Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%if(Session["name"] != null) { %>
    <i>Welcome to our employee board listing page!</i>
    <table style="font-size:12px">
        <tr>
            <td valign="top">
    <table class="table" cellpadding="5">
      <tr><td colspan="2" style="font-weight:bold;text-color:blue;"><img src="images/comments.jpg" width="20" height="20" /> Board Listing</td></tr>
      <tr><td><input type="button" onclick="window.location.href='BoardPostComment.aspx'" style="background-color:white;" value="NEW COMMENT" /></td><td><select name="recency" onchange="window.location.href='BoardListing.aspx?sort='+this.value;"><option value="HighestPosts" <%if(Request.QueryString["sort"] != null) { if (Request.QueryString["sort"].Equals("HighestPosts")) { %>selected<% } } %>>Highest Posts</option><option value="LowestPosts" <%if(Request.QueryString["sort"] != null) { if (Request.QueryString["sort"].Equals("LowestPosts")) { %>selected<% } } %>>Lowest Posts</option><option value="Newest" <%if(Request.QueryString["sort"] != null) { if (Request.QueryString["sort"].Equals("Newest")) { %>selected<% } } %>>Newest Addition</option><option value="Oldest"<%if(Request.QueryString["sort"] != null) { if (Request.QueryString["sort"].Equals("Oldest")) { %>selected<% } } %>>Oldest Addition</option></select></td></tr>
      <%=GetBoardListing()%>
    </table>
            </td>
            <td valign="top">
                <h4>Lastest Comments</h4>
                <div style="font-size:12px">
                  <%=GetBoardLatestComment()%>
                </div>
            </td>
        </tr>
    </table>
    <%} else {%>
        <a href="SignIn.aspx" style="font-size:15px;color:brown">> Sign In here to Employee Board Listing.</a>
    <%} %>
</asp:Content>