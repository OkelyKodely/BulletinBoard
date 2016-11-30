using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class SignOut : Page {
        
    protected void Page_Load(Object sender, EventArgs e)
    {

        Session.Clear();

        Response.Redirect("SignIn.aspx");

    }

}