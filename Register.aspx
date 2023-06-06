<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>הרשמה</title>
    <%--Bootstrap link--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <%--font links--%>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Varela+Round&display=swap" rel="stylesheet">
    <%--css link--%>
    <link rel="stylesheet" href="Register.css">
    <%--javascript link--%>
    <script defer="defer" src="register.js"></script>
</head>
<body>
    <audio autoplay="autoplay" loop="loop">
        <source src="Alone Together.mp3" type="audio/mp3"/>
    </audio>
    <div class="box">
    <form id="form" action="#" method="post">
        <h1 style="text-align:center">הרשמה</h1>
        <label id="error" style="text-align:center; color:red"><%=error %></label>
        <div class="name">
            <input type="text" name="lastName" id="lastName" placeholder="שם משפחה" style="float:left" value="<%=lastName %>" class="form-control" required/>
            <input type="text" name="firstName" id="firstName" placeholder="שם פרטי" value="<%=firstName %>" style="margin-left:20px" class="form-control"/ required>
        </div>
        <input type="text" name="id" id="id" placeholder="תעודת זהות" value="<%=id %>" class="form-control" required/>
        <%--<div class="class">
            <select id="class" name="class" class="form-control">
                <option value="" selected disabled hidden>בחר כיתה</option>
                <option value="י">י</option>
                <option value="יא">יא</option>
                <option value="יב">יב</option>
            </select>
        </div>--%>
        <input type="text" name="email" id="email" placeholder="אימייל"/ value="<%=email %>" class="form-control" required/>
        <input type="password" name="pass" id="pass" placeholder="סיסמה" value="<%=pass %>" class="form-control" required/>
        <input type="password" name="confirmPass" id="confirmPass" placeholder="אימות סיסמה" value="<%=confirmPass %>" class="form-control" required/>
        <div class="gender">
            <div class="option">
                <label>אחר</label><input type="radio" name="gender" value="other" style="margin-left:auto" required/>
            </div>
            <div class="option">
                <label>נקבה</label><input type="radio" name="gender" value="female" style="margin-left:auto"/>
            </div>
            <div class="option">
                 <label>זכר</label><input type="radio" name="gender" value="male"/ style="margin-left:auto"/>
            </div>
        </div>
        <br />
        <button type="submit" class="btn btn-success" name="submit">הירשם</button>
        <a href="SignIn.aspx">יש לי כבר משתמש</a>
    </form>
    </div>
    <%--Bootstrap script--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
