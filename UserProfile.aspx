<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="UserProfile.cs" Inherits="UserProfile" Title="User Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%if(Session["name"] != null) { %>
    <i>Welcome to our employee board listing page!</i>
    <table style="font-size:12px">
        <tr>
            <td>
              <form name="editup" method="post" action="">
                  <table>
                      <tr>
                        <td colspan="2"><h4>User</h4></td>
                      </tr>
                      <%=GetUserProfile()%>
                      <tr>
                          <td colspan="2">
                            <input type="submit" value="Save" style="width:100px" />
                          </td>
                      </tr>
                    </table>
              </form>
            </td>
        </tr>
    </table>
    <input type="button" onclick="window.location.href = 'BoardListing.aspx';" value="Board Listing Page" />
    <%} %>
</asp:Content>