<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>התחברות</title>
    <%--Bootstrap link--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <%--font links--%>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Varela+Round&display=swap" rel="stylesheet">
    <%--css link--%>
    <link rel="stylesheet" href="Register.css">
</head>
<body>
    <%--<audio autoplay="autoplay" loop="loop">
        <source src="Alone Together.mp3" type="audio/mp3"/>
    </audio>--%>
    <div class="box">
    <form action="#" method="post">
        <h1 style="text-align:center">התחברות</h1>  
        <label style="text-align:center; color:red"><%=error %></label>
        <input type="text" name="email" id="email" placeholder="אימייל" class="form-control"/>
        <input type="password" name="pass" id="pass" placeholder="סיסמה" class="form-control"/>
        <button type="submit" class="btn btn-success" name="submit">התחבר</button>
        <a href="Register.aspx">אין לי עדיין משתמש</a>    
    </form>
    </div>
    <%--Bootstrap script--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
