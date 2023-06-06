using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    public string error = "";
    public string firstName = "";
    public string lastName = "";
    public string id = "";
    public string pass = "";
    public string confirmPass = "";
    public string classStr = "";
    public string email = "";
    public string gender = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["submit"] != null)
        {
            firstName = Request.Form["firstName"];
            lastName = Request.Form["lastName"];
            id = Request.Form["id"];
            pass = Request.Form["pass"];
            confirmPass = Request.Form["confirmPass"];
            email = Request.Form["email"];
            gender = Request.Form["gender"];
            //if (firstName == "" ||
            //    lastName == "" ||
            //    id == "" ||
            //    pass == "" ||
            //    confirmPass == "" ||
            //    email == "" ||
            //    gender == null)
            //{
            //    error = "!מלא את כל השדות";
            //}
            //else if (pass != confirmPass)
            //{
            //    error = "!הסיסמאות אינן תואמות";
            //}
            if (MyAdoHelper.IsExist("myDB.mdb", $"SELECT * FROM usersTable WHERE email='{email}'"))
            {
                error = "!משתמש עם אימייל זה כבר קיים";
            }
            else if (MyAdoHelper.IsExist("myDB.mdb", $"SELECT * FROM usersTable WHERE id='{id}'"))
            {
                error = "!משתמש עם תעודת זהות זו כבר קיים";
            }
            else
            {
                string sql = $"INSERT INTO usersTable(id,firstName,lastName,pass,email,gender) VALUES('{id}','{firstName}','{lastName}','{pass}','{email}','{gender}')";
                MyAdoHelper.DoQuery("myDB.mdb", sql);
                bool isAdmin = MyAdoHelper.IsExist("myDb.mdb", $"SELECT * FROM usersTable WHERE email='{email}' AND isAdmin=true");
                User user = new User(firstName, lastName, id, email, gender, isAdmin);
                Session["user"] = user;
                sql = $"UPDATE usersTable set isConnected=true WHERE email='{email}'";
                MyAdoHelper.DoQuery("myDB.mdb", sql);
                Response.Redirect("Home.aspx");
            }
        }
    }
}