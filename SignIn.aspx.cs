using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    public string error = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string email = Request.Form["email"];
        string password = Request.Form["pass"];
        if (Request.Form["submit"] != null)
        {
            if (email == "" || password == "")
            {
                error = "!מלא את כל השדות";
            }
            else
            {
                if (!MyAdoHelper.IsExist("myDB.mdb", $"SELECT * FROM usersTable WHERE email='{email}' AND pass='{password}'"))
                {
                    error = "אימייל או סיסמה אינם נכונים";
                }
                else
                {
                    string sql = $"SELECT* FROM usersTable";
                    object[] userDetails = MyAdoHelper.ExecuteDataTable("myDB.mdb", sql).Select($"email='{email}'")[0].ItemArray;
                    User user = new User(userDetails[1].ToString(), userDetails[2].ToString(), userDetails[0].ToString(), userDetails[4].ToString(), userDetails[5].ToString(), (bool)userDetails[7]);
                    Session["user"] = user;
                    sql = $"UPDATE usersTable set isConnected=true WHERE email='{email}'";
                    MyAdoHelper.DoQuery("myDB.mdb", sql);
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }
}