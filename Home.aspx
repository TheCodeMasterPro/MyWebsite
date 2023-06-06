<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>בית</title>
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
            /* Location of the image */ background-image: url("images/guitar.png"); /* Background image is centered vertically and horizontally at all times */
            background-position: center center; /* Background image doesn’t tile */
            background-repeat: no-repeat; /* Background image is fixed in the viewport so that it doesn’t move when the content’s height is greater than the image’s height */
            background-attachment: fixed; /* This is what makes the background image rescale based on the container’s size */
            background-size: cover; /* Set a background color that will be displayed while the background image is loading */
            background-color: white;
            color: white;
        }
        p {
            text-align: center;
            font-size: x-large;
        }
    </style>
</head>

<body>
    <div class="container">
        <div class="row">
            <div class="col-sm-12"><br /><br /><h1><strong>ברוכים הבאים לאתרינו החדש</strong></h1><br /><br /></div>
        </div>
        <div class="row">
            <div class="col-sm-12"><p>.באתר זה תוכלו לקרוא על הלהקה שלנו ולהכיר את חברי הקבוצה</p></div>
        </div>
        <div class="row">
            <div class="col-sm-12"><p>.תוכלו למצוא בו את האלבומים והשירים שלנו כולל המילים ולשתף איתנו - חברי הלהקה, את החוויות והדעות שלכם על השירים</p></div>
        </div>
        <div class="row">
            <div class="col-sm-12"><p>.מקווים שתהנו ממנו על מנת שיואב ירגיש טוב עם עצמו על כך שהשקיע את כל זמנו בבניית אתר זה</p></div>
        </div>
    </div>

    <%--Bootstrap script--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
