using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Comments : System.Web.UI.Page
{
    public string commentList = "";
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
        user = (User)Session["user"];

        //if (user == null)
        //{
        //    Response.Redirect("Home.aspx");
        //}

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

        sql = $"SELECT * FROM commentsTable";
        DataTable table = MyAdoHelper.ExecuteDataTable("myDB.mdb", sql);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            string fullName = MyAdoHelper.ExecuteDataTable("myDB.mdb", $"SELECT firstName FROM usersTable WHERE id='{table.Rows[i]["userId"].ToString()}'").Rows[0][0].ToString() + " " + MyAdoHelper.ExecuteDataTable("myDB.mdb", $"SELECT lastName FROM usersTable WHERE id='{table.Rows[i]["userId"].ToString()}'").Rows[0][0].ToString();
            string songName = MyAdoHelper.ExecuteDataTable("myDB.mdb", $"SELECT songName FROM songsTable WHERE id={(int)table.Rows[i]["songId"]}").Rows[0][0].ToString();
            commentList += "<div class='row'>";
            commentList += "<div class='col-sm-12'>";
            commentList += $"<p style='font-size: 12px'>{table.Rows[i]["creationTime"]}</p>";
            commentList += "</div>";
            commentList += "</div>";
            commentList += "<div class='row'>";
            commentList += "<div class='col-sm-12'>";
            commentList += $"<p><strong>{fullName}</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;הגיב לשיר: " + songName + "</p>";
            commentList += "</div>";
            commentList += "</div>";
            commentList += "<div class='row'>";
            commentList += "<div class='col-sm-12'>";
            commentList += $"<p dir='rtl'>{table.Rows[i]["comment"]}</p>";
            commentList += "</div>";
            commentList += "</div>";
            commentList += "<br/>";
        }
    }
}