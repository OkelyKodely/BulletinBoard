using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class UserProfile : Page {
        
    protected void Page_Load(Object sender, EventArgs e)
    {

        if (IsPostBack)
        {

            string name = Request.Form["name"];

            string title = Request.Form["title"];

            string email = Request.Form["email"];

            string address = Request.Form["address"];

            string phone = Request.Form["phone"];

            string website = Request.Form["website"];

            string id = Request.Form["id"];

            try
            {
                SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

                SqlCommand cmd = new SqlCommand("update BoardListing set name='" + name + "', title='" + title + "', id=" + id + ", email='" + email + "', address='" + address + "', phone='" + phone + "', website='" + website + "' where id = " + id, con);

                con.Open();
                
                cmd.ExecuteNonQuery();
                
                con.Close();

            }
            catch (Exception ex)
            {

            }

        }

    }

    public string GetUserProfile() {
		
        SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

        string id = Request.QueryString["userid"];

        SqlCommand cmd = new SqlCommand("select name, title, email, address, phone, website from BoardListing where id = " + id, con);

        string html = "";

        try
        {

            con.Open();
         
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            DataSet ds = new DataSet();
            
            sda.Fill(ds);
            
            DataRow dRow = ds.Tables[0].Rows[0];

            string name = dRow.ItemArray.GetValue(0).ToString();
                
            string title = dRow.ItemArray.GetValue(1).ToString();

            string email = dRow.ItemArray.GetValue(2).ToString();

            string address = dRow.ItemArray.GetValue(3).ToString();

            string phone = dRow.ItemArray.GetValue(4).ToString();

            string website = dRow.ItemArray.GetValue(5).ToString();

            html += "<tr><td>Name:</td><td><input type=\"text\" name=\"name\" value=\"" + name + "\" /></td></tr>";
            html += "<tr><td>Title:</td><td><input type=\"text\" name=\"title\" value=\"" + title + "\" /></td></tr>";
            html += "<tr><td>Email:</td><td><input type=\"text\" name=\"email\" value=\"" + email + "\" /></td></tr>";
            html += "<tr><td>Address:</td><td><input type=\"text\" name=\"address\" value=\"" + address + "\" /></td></tr>";
            html += "<tr><td>Phone:</td><td><input type=\"text\" name=\"phone\" value=\"" + phone + "\" /></td></tr>";
            html += "<tr><td>Website:</td><td><input type=\"text\" name=\"website\" value=\"" + website + "\" /><input type=\"hidden\" name=\"id\" value=\"" + id + "\"</td></tr>";

            con.Close();

        }
        catch (Exception ex) 
        {
            html = ex.Message;
        }

    	return html;

    }

}