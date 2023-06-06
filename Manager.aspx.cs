using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager : System.Web.UI.Page
{
    public string usersTable = "";
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

        if (user == null || (user != null && user.GetIsAdmin() == false))
        {
            Response.Redirect("Home.aspx");
        }
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
        sql = $"SELECT* FROM usersTable";
        DataTable table = MyAdoHelper.ExecuteDataTable("myDB.mdb", sql);
        DataView tableView = table.DefaultView;
        tableView.Sort = "firstName ASC";
        table = tableView.ToTable();
        //tableView.Sort = "firstName ASC"; // not working!
        for (int i = 0; i < tableView.Table.Rows.Count; i++)
        {
            usersTable += "<tr>";
            usersTable += $"<td><input type='text' name='gender{i}' id='gender{i}' class='form-control' value='{table.Rows[i]["gender"].ToString()}'></td>";
            usersTable += $"<td><input type='text' name='id{i}' id='id{i}' class='form-control' value='{table.Rows[i]["id"].ToString()}'></td>";
            usersTable += $"<td><input type='text' name='email{i}' id='email{i}' class='form-control' value='{table.Rows[i]["email"].ToString()}'></td>";
            usersTable += $"<td><input type='text' name='name{i}' id='name{i}' class='form-control' value='{table.Rows[i]["firstName"].ToString() + " " + table.Rows[i]["lastName"].ToString()}'></td>";
            usersTable += $"<td><input type='checkbox' name='{table.Rows[i]["id"].ToString()}'></td>";
            usersTable += "</tr>";
        }

        if (Request.Form["deleteUsers"] != null)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string id = table.Rows[i]["id"].ToString();
                if (Request.Form[id] != null)
                {
                    sql = $"DELETE FROM usersTable WHERE id='{id}'";
                    MyAdoHelper.DoQuery("myDB.mdb", sql);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
        if (Request.Form["updateUsers"] != null)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sql = $"UPDATE usersTable SET id='{Request.Form["id" + i.ToString()]}', firstName='{Request.Form["name" + i.ToString()].Split(' ')[0]}', lastName='{Request.Form["name" + i.ToString()].Split(' ')[1]}', email='{Request.Form["email" + i.ToString()]}', gender='{Request.Form["gender" + i.ToString()]}' WHERE id='{table.Rows[i]["id"]}'";
                MyAdoHelper.DoQuery("myDB.mdb", sql);
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}