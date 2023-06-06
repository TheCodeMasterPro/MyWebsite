<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>אודות הלהקה</title>
    <%--Bootstrap link--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <%--font links--%>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Varela+Round&display=swap" rel="stylesheet">
    <%--css link--%>
    <link rel="stylesheet" href="Home.css" />
    <style>
        body {
            /* Location of the image */ background-image: url(https://oldschoolgrappling.com/wp-content/uploads/2018/08/Background-opera-speeddials-community-web-simple-backgrounds.jpg); /* Background image is centered vertically and horizontally at all times */
            background-position: center center; /* Background image doesn’t tile */
            background-repeat: no-repeat; /* Background image is fixed in the viewport so that it doesn’t move when the content’s height is greater than the image’s height */
            background-attachment: fixed; /* This is what makes the background image rescale based on the container’s size */
            background-size: cover; /* Set a background color that will be displayed while the background image is loading */
            background-color: white;
        }
        p {
            text-align: right;
            font-size: large;
        }
        .image {
            
        }
        .image img {
            border-radius: 30px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-sm-12"><br /><br /><h1>אודות הלהקה</h1><br /><br /><br /></div>
        </div>
        <div class="row">
            <div class="col-sm-12"><p>.חבורת החצר הינה להקת רוק מפורסמת שהוקמה בשלהי שנות ה-20 של המאה ה-21</p></div>
        </div>
        <div class="row">
            <div class="col-sm-12"><p>.הלהקה התחילה מקבוצה של תלמידי כיתה י'א שניסו למצוא דרך להפיג את הלחץ של הלימודים ועם הזמן התפתחה והפכה ללהקה אמיתית ואיכותית</p></div>
        </div>
        <div class="row">
            <div class="col-sm-12"><p>."חבורת החצר התפרסמה והפכה להיות הלהקה שהיא כיום לאחר יציאת האלבום הראשון שלה - "רוק ליאיר" שכלל בתוכו את הלהיט מספר אחד של הלהקה: "היי גבר</p></div>
        </div>
        <br /><br />
        <div class="image"><img src="images/members.jpeg"/></div>
    </div>
    <%--Bootstrap script--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
