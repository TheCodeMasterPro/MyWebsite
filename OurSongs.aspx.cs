using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OurSongs : System.Web.UI.Page
{
    public string songsTable = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql;
        string comments = "<a href='Comments.aspx'><div class='item'>תגובות לשירינו</div></a>";
        string ourSongs = "<a href='OurSongs.aspx'><div class='item'>השירים שלנו</div></a>";
        string about = "<a href='About.aspx'><div class='item'>אודות הלהקה</div></a>";
        string members = "<a href='Members.aspx'><div class='item'>חברי הלהקה</div></a>";
        string logo = "<a href='Home.aspx' style='margin-left:20px'><img src='images/members.jpeg' height='60px' style='border-radius:5px;' /></a>";
        string addSongs = "<a href='addSongs.aspx'><div class='item'>הוספת שירים</div></a>";
        string leftItem;
        string manager = "";

        User user = null;
        if (Request.Form["logOut"] != null)
        {
            user = (User)Session["user"];
            sql = $"UPDATE usersTable set isConnected=false WHERE email='{user.GetEmail()}'";
            MyAdoHelper.DoQuery("myDB.mdb", sql);
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
        if (Session["user"] == null)
        {
            leftItem = "<a href='SignIn.aspx'><div class='item'>התחברות</div></a>";
            Response.Write($"<div class='navBar'><div class='left'>{leftItem}</div><div class='right'>{comments}{members}{about}{ourSongs}{logo}</div></div>");
        }
        else
        {
            leftItem = "<div class='logOutItem'><form action='' method='post'><button type='submit' name='logOut'>התנתקות</button></form></div>";
            string profile = $"<div class='item'><div class='dropdown'><button class='dropbtn'><img src = 'https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/160/joypixels/291/bust-in-silhouette_1f464.png' height='40'/></button><div class='dropdown-content'><a href = 'Profile.aspx' >פרופיל</a>{leftItem}</div></div></div>";
            user = (User)Session["user"];
            if (user.GetIsAdmin() == true)
            {
                manager = "<a href='Manager.aspx'><div class='item'>ניהול משתמשים</div></a>";
                Response.Write($"<div class='navBar'><div class='left'>{profile}{manager}{addSongs}</div><div class='right'>{comments}{members}{about}{ourSongs}{logo}</div></div>");
            }
            else
            {
                Response.Write($"<div class='navBar'><div class='left'>{profile}</div><div class='right'>{comments}{members}{about}{ourSongs}{logo}</div></div>");
            }
        }

        sql = $"SELECT songName,lyrics,albumId FROM songsTable";
        DataTable table = MyAdoHelper.ExecuteDataTable("myDB.mdb", sql);

        DataView tableView = table.DefaultView;
        tableView.Sort = "songName ASC";
        table = tableView.ToTable();
        for (int i = 0; i < tableView.Table.Rows.Count; i++)
        {
            songsTable += "<tr>";
            songsTable += $"<td>{table.Rows[i]["songName"].ToString()}</td>";
            songsTable += $"<td>{table.Rows[i]["lyrics"].ToString()}</td>";
            songsTable += $"<td>{MyAdoHelper.ExecuteDataTable("myDB.mdb", $"SELECT albumName FROM albumsTable WHERE id={(int)table.Rows[i]["albumId"]}").Rows[0][0]}</td>";
            songsTable += "</tr>";
        }
    }
}