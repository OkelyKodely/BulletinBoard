<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="SignIn.cs" Inherits="SignIn" Title="Sign In" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <i>Welcome to our employee board listing page!</i><%=abc %>
    <table style="font-size:12px">
        <tr>
            <td>
              <form name="signin" method="post" action="">
                  <table>
                      <tr>
                        <td colspan="2"><h4>Sign In</h4></td>
                      </tr>
                      <tr>
                          <td>
                            Name:
                          </td>
                          <td>
                            <input type="text" name="name" />
                          </td>
                      </tr>
                      <tr>
                          <td colspan="2">
                            <input type="submit" value="Sign In" style="width:100px" />
                          </td>
                      </tr>
                    </table>
              </form>
            </td>
        </tr>
    </table>
</asp:Content>