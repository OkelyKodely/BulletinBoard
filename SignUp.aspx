<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="BoardListing.cs" Inherits="BoardListing" Title="Board Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <i>Welcome to our employee board listing page!</i>
    <table style="font-size:12px">
        <tr>
            <td>
              <form name="signup" method="post" action="">
                  <table>
                      <tr>
                        <td colspan="2"><h4>Sign Up</h4></td>
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
                          <td>
                            Title:
                          </td>
                          <td>
                            <input type="text" name="title" />
                          </td>
                      </tr>
                      <tr>
                          <td>
                            Email:
                          </td>
                          <td>
                            <input type="text" name="email" />
                          </td>
                      </tr>
                      <tr>
                          <td>
                            Address:
                          </td>
                          <td>
                            <input type="text" name="address" />
                          </td>
                      </tr>
                      <tr>
                          <td>
                            Phone:
                          </td>
                          <td>
                            <input type="text" name="phone" />
                          </td>
                      </tr>
                      <tr>
                          <td>
                            Website:
                          </td>
                          <td>
                            <input type="text" name="website" />
                          </td>
                      </tr>
                      <tr>
                          <td colspan="2">
                            <input type="submit" value="Sign Up" style="width:100px" />
                          </td>
                      </tr>
                    </table>
              </form>
            </td>
        </tr>
    </table>
</asp:Content>