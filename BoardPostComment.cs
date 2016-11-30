using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class BoardPostComment : Page {
        
    protected void Page_Load(Object sender, EventArgs e)
    {
        if (IsPostBack)
        {

            string id = Request.Form["_id"];

            string material = Request.Form["material"];

            if (id != null && material != null)
            {
                
                material = material.Replace("'", "''");

                SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

                SqlCommand cmd = new SqlCommand("insert into BoardView (material, id, date_time) values ('" + material + "', " + id + ", getdate())", con);

                con.Open();

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("select max(_id) as topid from BoardView", con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sda.Fill(ds);

                DataRow dRow = ds.Tables[0].Rows[0];

                int topid = (int) Int64.Parse(dRow.ItemArray.GetValue(0).ToString());

                con.Close();

                Response.Redirect("BoardPost.aspx?_id=" + topid);

            }
            
        }
    }

}