using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class SignIn : Page {
    public string abc = "";
    protected void Page_Load(Object sender, EventArgs e)
    {

        if (IsPostBack)
        {

            string name = Request.Form["name"];

            if (name.Length == 0) Response.Redirect("BoardListing.aspx");

            try
            {
                SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

                SqlCommand cmd = new SqlCommand("select name, id from BoardListing where name = '" + name + "'", con);

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sda.Fill(ds);
            
                DataRow dRow = ds.Tables[0].Rows[0];

                string id = dRow.ItemArray.GetValue(1).ToString();

                Session.Add("name", name);

                Session.Add("_id", id);

                Session.Timeout = 16;

                con.Close();

                Response.Redirect("BoardListing.aspx");
            
            }
            catch (Exception ex)
            {
                ///abc = ex.Message;
            }

        }

    }

}