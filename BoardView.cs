using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class BoardView : Page {
        
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

                con.Close();

            }
            
        }
    }

    public string GetUserNameTitle() {

        string id = Request.QueryString["_id"];

        SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");
        
        SqlCommand cmd = new SqlCommand("select name, title from BoardListing where id = " + id, con);

    	string html = "";

        try
        {

            con.Open();
         
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            DataSet ds = new DataSet();
            
            sda.Fill(ds);
            
            DataRow dRow = ds.Tables[0].Rows[0];

            html = dRow.ItemArray.GetValue(0).ToString() + " " + dRow.ItemArray.GetValue(1).ToString(); ;
                
            con.Close();

        }
        catch (Exception ex) 
        {
            html = ex.Message + cmd.CommandText;
        }

    	return html;

    }
    public string abc = "";
	public string GetBoardViewMaterial() {

        string id = Request.QueryString["_id"];

        SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

        SqlCommand cmd = new SqlCommand("select material, DATEDIFF(day, date_time, getdate()) as daysago, DATEDIFF(hour, date_time, getdate()) as hoursago, DATEDIFF(week, date_time, getdate()) as weeksago, DATEDIFF(month, date_time, getdate()) as monthsago, DATEDIFF(year, date_time, getdate()) as yearsago, DATEDIFF(minute, date_time, getdate()) as minutesago, date_time, _id from BoardView where id = " + id + " order by _id desc", con);

    	string html = "";

        try
        {

            con.Open();
         
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            DataSet ds = new DataSet();
            
            sda.Fill(ds);
            
            int inc = 0;
            
            int max = ds.Tables[0].Rows.Count;

            string bgcol = "#e8e8e8";

            html += "<tr><td><i>User has <b>" + max + "</b> entries.</i></td></tr>";

            while (inc < max)
            {

                if (inc % 2 == 1)
                {

                    bgcol = "#d9d9d9";

                }

                DataRow dRow = ds.Tables[0].Rows[inc];

                string material = dRow.ItemArray.GetValue(0).ToString();

                int days_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(1).ToString());

                int hours_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(2).ToString());

                int weeks_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(3).ToString());

                int months_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(4).ToString());

                int years_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(5).ToString());

                int minutes_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(6).ToString());

                string date_time = dRow.ItemArray.GetValue(7).ToString();

                string _id = dRow.ItemArray.GetValue(8).ToString();

                if (years_ago > 0)
                {

                    html += "<tr><td style=\"font-size:12px\"><a href=\"BoardPost.aspx?_id=" + _id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + years_ago + " years ago</font> " + date_time + ": </i></a><br></td></tr>";
                
                }
                else if (weeks_ago >= 4)
                {

                    html += "<tr><td style=\"font-size:12px\"><a href=\"BoardPost.aspx?_id=" + _id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + months_ago + " months ago</font> " + date_time + ": </i></a><br></td></tr>";
                
                }
                else if (days_ago >= 7)
                {

                    html += "<tr><td style=\"font-size:12px\"><a href=\"BoardPost.aspx?_id=" + _id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + weeks_ago + " weeks ago</font> " + date_time + ": </i></a><br></td></tr>";

                }
                else if (hours_ago >= 24)
                {

                    html += "<tr><td style=\"font-size:12px\"><a href=\"BoardPost.aspx?_id=" + _id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + days_ago + " days ago</font> " + date_time + ": </i></a><br></td></tr>";

                }
                else if (minutes_ago >= 60)
                {

                    html += "<tr><td style=\"font-size:12px\"><a href=\"BoardPost.aspx?_id=" + _id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + hours_ago + " hours ago </font> " + date_time + ": </i></a><br></td></tr>";

                }
                else if (minutes_ago >= 1)
                {

                    html += "<tr><td style=\"font-size:12px\"><a href=\"BoardPost.aspx?_id=" + _id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + minutes_ago + " minutes ago </font> " + date_time + ": </i></a><br></td></tr>";

                }
                else
                {

                    html += "<tr><td style=\"font-size:12px\"><a href=\"BoardPost.aspx?_id=" + _id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">just now</font> " + date_time + ": </i></a><br></td></tr>";

                }
                
                html += "<tr><td style=\"font-size:12px;background-color:" + bgcol + ";\">" + material + "</td></tr>";
                
                inc++;
            
            }

            con.Close();

        }
        catch (Exception ex) 
        {
            html = "asdf" + ex.Message;
        }
        //html += "adsfa";
    	return html;

    }

    public string GetBoardPost()
    {

        string _id = Request.QueryString["_id"];

        SqlConnection con = new SqlConnection("Server=127.0.0.1;Database=Board;User Id=sa;Password=coppersink21;");

        SqlCommand cmd = new SqlCommand("select material, DATEDIFF(day, date_time, getdate()) as daysago, DATEDIFF(hour, date_time, getdate()) as hoursago, DATEDIFF(week, date_time, getdate()) as weeksago, DATEDIFF(month, date_time, getdate()) as monthsago, DATEDIFF(year, date_time, getdate()) as yearsago, DATEDIFF(minute, date_time, getdate()) as minutesago, date_time, id from BoardView where _id = " + _id, con);

        string html = "";

        try
        {

            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            sda.Fill(ds);

            DataRow dRow = ds.Tables[0].Rows[0];

            string material = dRow.ItemArray.GetValue(0).ToString();

            int days_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(1).ToString());

            int hours_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(2).ToString());

            int weeks_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(3).ToString());

            int months_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(4).ToString());

            int years_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(5).ToString());

            int minutes_ago = (int)Int64.Parse(dRow.ItemArray.GetValue(6).ToString());

            string date_time = dRow.ItemArray.GetValue(7).ToString();

            string id = dRow.ItemArray.GetValue(8).ToString();

            if (years_ago > 0)
            {

                html += "<tr><td style=\"font-size:12px\"><a href=\"BoardView.aspx?_id=" + id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + years_ago + " years ago</font> " + date_time + ": </i></a><br></td></tr>";

            }
            else if (weeks_ago >= 4)
            {

                html += "<tr><td style=\"font-size:12px\"><a href=\"BoardView.aspx?_id=" + id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + months_ago + " months ago</font> " + date_time + ": </i></a><br></td></tr>";

            }
            else if (days_ago >= 7)
            {

                html += "<tr><td style=\"font-size:12px\"><a href=\"BoardView.aspx?_id=" + id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + weeks_ago + " weeks ago</font> " + date_time + ": </i></a><br></td></tr>";

            }
            else if (hours_ago >= 24)
            {

                html += "<tr><td style=\"font-size:12px\"><a href=\"BoardView.aspx?_id=" + id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + days_ago + " days ago</font> " + date_time + ": </i></a><br></td></tr>";

            }
            else if (minutes_ago >= 60)
            {

                html += "<tr><td style=\"font-size:12px\"><a href=\"BoardView.aspx?_id=" + id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + hours_ago + " hours ago </font> " + date_time + ": </i></a><br></td></tr>";

            }
            else if (minutes_ago >= 1)
            {

                html += "<tr><td style=\"font-size:12px\"><a href=\"BoardView.aspx?_id=" + id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">" + minutes_ago + " minutes ago </font> " + date_time + ": </i></a><br></td></tr>";

            }
            else
            {

                html += "<tr><td style=\"font-size:12px\"><a href=\"BoardView.aspx?_id=" + id + "\"><i>" + GetUserNameTitle().Substring(0, GetUserNameTitle().IndexOf(" ")) + " Wrote this <font size=\"4\">just now</font> " + date_time + ": </i></a><br></td></tr>";

            }

            html += "<tr><td style=\"font-size:12px\">" + material + "</td></tr>";

            con.Close();

        }
        catch (Exception ex)
        {

        }

        return html;

    }

}