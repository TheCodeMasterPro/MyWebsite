using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string comments = "<a href='Comments.aspx'><div class='item'>תגובות לשירינו</div></a>";
        string ourSongs = "<a href='OurSongs.aspx'><div class='item'>השירים שלנו</div></a>";
        string about = "<a href='#'><div class='item'>אודות הלהקה</div></a>";
        string members = "<a href='Members.aspx'><div class='item'>חברי הלהקה</div></a>";
        string logo = "<a href='Home.aspx' style='margin-left:20px'><img src='images/members.jpeg' height='60px' style='border-radius:5px;' /></a>";
        string addSongs = "<a href='addSongs.aspx'><div class='item'>הוספת שירים</div></a>";
        string leftItem;
        string manager = "";

        User user = null;
        if (Request.Form["logOut"] != null)
        {
            user = (User)Session["user"];
            string sql = $"UPDATE usersTable set isConnected=false WHERE email='{user.GetEmail()}'";
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
    }
}