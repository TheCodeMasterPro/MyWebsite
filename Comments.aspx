<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="Comments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>תגובות לשירים</title>
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
            /* Location of the image */ background-image: url(https://img.wallpapersafari.com/desktop/1024/576/57/52/yzDZKd.jpg); /* Background image is centered vertically and horizontally at all times */
            background-position: center center; /* Background image doesn’t tile */
            background-repeat: no-repeat; /* Background image is fixed in the viewport so that it doesn’t move when the content’s height is greater than the image’s height */
            background-attachment: fixed; /* This is what makes the background image rescale based on the container’s size */
            background-size: cover; /* Set a background color that will be displayed while the background image is loading */
            background-color: white;
        }
        p {
            text-align: right;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-sm-12"><br /><br /><h1>תגובות לשירינו</h1><br /><br /><br /></div>
        </div>
        <%=commentList %>
    </div>

     <%--Bootstrap script--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
