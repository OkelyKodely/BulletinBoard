using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class BoardListing : Page {
        
    protected void Page_Load(Object sender, EventArgs e)
    {

        if (IsPostBack)
        {

            string name = Request.Form["name"];

            if (name.Length == 0) Response.Redirect("BoardListing.aspx");

            string title = Request.Form["title"];

            string email = Request.Form["email"];

            string address = Request.Form["address"];

            string phone = Request.Form["phone"];

            string website = Request.Form["website"];

            string id = "";

            try
            {
                SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

                SqlCommand cmd = new SqlCommand("select max(id) as number from BoardListing", con);

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sda.Fill(ds);
            
                DataRow dRow = ds.Tables[0].Rows[0];

                if (dRow.ItemArray.GetValue(0) != null)
                {

                    id = "" + (Int64.Parse(dRow.ItemArray.GetValue(0).ToString()) + 1);

                }
                else
                {

                    id = "1";
                
                }
            
                cmd = new SqlCommand("insert into BoardListing (name, title, id, email, address, phone, website) values ('" + name + "', '" + title + "', " + id + ", '" + email + "', '" + address + "', '" + phone + "', '" + website + "')", con);
                        
                cmd.ExecuteNonQuery();
                
                con.Close();

                Response.Redirect("BoardListing.aspx");
            
            }
            catch (Exception ex)
            {

            }

        }

    }

    public string GetBoardListing() {
		
        SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

        string sql = " order by posts desc";

        string sort = null;

        if (Request.QueryString["sort"] != null)
        {

            sort = Request.QueryString["sort"];

        }

        if (sort != null)
        {

            sql = " order by id ";

            if (sort.Equals("Newest"))
            {

                sql += "desc";

            }
            else if (sort.Equals("Oldest"))
            {

                sql += "asc";

            }
            else if (sort.Equals("HighestPosts"))
            {

                sql = " order by posts desc";
            
            }
            else if (sort.Equals("LowestPosts"))
            {

                sql = " order by posts asc";

            }
            else
            {

                sql = " order by posts desc";

            }

        }

        SqlCommand cmd = new SqlCommand("select bl.name, bl.title, bl.id, count(bv._id) as posts from BoardListing bl left outer join BoardView bv on bl.id = bv.id group by bv.id, bl.name, bl.title, bl.id" + sql, con);

        string html = "<tr><td style=\"font-weight:bold\">Posts</td><td style=\"font-weight:bold\">Name</td><td style=\"font-weight:bold\">Title</td></tr>";

        try
        {

            con.Open();
         
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            DataSet ds = new DataSet();
            
            sda.Fill(ds);
            
            int inc = 0;
            
            int max = ds.Tables[0].Rows.Count;

            string color1 = "#e5e5e5";

            string color2 = "#c6c6c6";

            while (inc < max)
            {

                DataRow dRow = ds.Tables[0].Rows[inc];

                String id = dRow.ItemArray.GetValue(2).ToString();
            
                string name = dRow.ItemArray.GetValue(0).ToString();
                
                string title = dRow.ItemArray.GetValue(1).ToString();

                string posts = dRow.ItemArray.GetValue(3).ToString();

                if (inc % 2 == 1)
                {

                    color1 = "#c6c6c6";

                }
                else
                {

                    color1 = "#e5e5e5";
                
                }

                if (inc % 2 == 1)
                {

                    color2 = "#e5e5e5"; 

                }
                else
                {

                    color2 = "#c6c6c6";

                }

                html += "<tr><td bgcolor=\"" + color1 + "\"><a href=\"BoardView.aspx?_id=" + id + "\"><img src=\"images/glass.jpg\" width=\"25\" height=\"25\" /></a> " + posts + "</td><td bgcolor=\"" + color2 + "\"><a href=\"UserProfile.aspx?userid=" + id + "\">" + name + "</a></td><td bgcolor=\"" + color2 + "\">" + title + "</td></tr>";
                
                inc++;
            
            }

            con.Close();

        }
        catch (Exception ex) 
        {
        
        }

    	return html;

    }

    public string GetBoardLatestComment()
    {

        SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

        SqlCommand cmd = new SqlCommand("select bv.material, bv.id, bv.date_time, bl.name, bv._id from BoardView bv inner join BoardListing bl on bv.id = bl.id order by bv._id desc", con);

        string html = "";

        try
        {

            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            sda.Fill(ds);

            int inc = 0;

            int max = ds.Tables[0].Rows.Count;

            while (inc < max)
            {

                DataRow dRow = ds.Tables[0].Rows[inc];

                String id = dRow.ItemArray.GetValue(1).ToString();

                string material = dRow.ItemArray.GetValue(0).ToString();

                string date_time = dRow.ItemArray.GetValue(2).ToString();

                string name = dRow.ItemArray.GetValue(3).ToString();

                string _id = dRow.ItemArray.GetValue(4).ToString();

                if (material.Length > 80) material = material.Substring(0, 80) + "... [READ MORE]";
                else material = material + "... [READ MORE]";

                html += "Posted on " + date_time + " by " + name + "<br><a href=\"BoardPost.aspx?_id=" + _id + "\">" + material + "</a><br><br>";

                inc++;

            }

            con.Close();

        }
        catch (Exception ex)
        {

        }

        return html;

    }

}