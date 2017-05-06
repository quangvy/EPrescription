<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Esteem Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- //custom-theme -->
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/snow.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/component.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/style_grid.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <!-- font-awesome-icons -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <!-- //font-awesome-icons -->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800" rel="stylesheet">
</head>
<body>
    <!-- /pages_agile_info_w3l -->

    <div class="pages_agile_info_w3l">
        <!-- /login -->
        <div class="over_lay_agile_pages_w3ls">
            <div class="registration">

                <div class="signin-form profile">
                    <div class="logo">
                        <img src="images/logo.png">
                    </div>
                    <div class="login-form">
                        <form runat="server">
                            <input id="txtName" type="text" placeholder="Username" required="" runat="server" />
                            <input ID="txtPassword" type="password" name="password" placeholder="Password" required="" runat="server" />
                            <div class="tp">
                                <asp:Button ID="btnSignIn" Text="SIGN IN" runat="server" OnClick="btnSignIn_OnClick" />
                            </div>
                        </form>
                    </div>



                    <h6></h6>
                </div>
            </div>
            <!--copy rights start here-->
            <div class="copyrights_agile">
                <p>© 2017 Raffles Medical | Design by  <a href="http://w3layouts.com/" target="_blank">W3layouts</a> </p>
            </div>
            <!--copy rights end here-->
        </div>
    </div>
    <!-- /login -->
    <!-- //pages_agile_info_w3l -->


    <!-- js -->

    <script type="text/javascript" src="js/jquery-2.1.4.min.js"></script>
    <script src="js/modernizr.custom.js"></script>

    <script src="js/classie.js"></script>
    <script src="js/gnmenu.js"></script>
    <script>
        new gnMenu(document.getElementById('gn-menu'));
    </script>

    <!-- //js -->

    <script src="js/screenfull.js"></script>
    <script>
        $(function () {
            $('#supported').text('Supported/allowed: ' + !!screenfull.enabled);

            if (!screenfull.enabled) {
                return false;
            }



            $('#toggle').click(function () {
                screenfull.toggle($('#container')[0]);
            });
        });
    </script>
    <script src="js/jquery.nicescroll.js"></script>
    <script src="js/scripts.js"></script>
    <script src="js/snow.js"></script>
    <script type="text/javascript" src="js/bootstrap-3.1.1.min.js"></script>
</html>
