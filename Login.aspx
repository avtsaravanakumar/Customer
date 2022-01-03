<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="~/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/css/util.css">
    <link rel="stylesheet" type="text/css" href="~/css/main.css">
    <!--===============================================================================================-->
</head>
<body>
    <div class="limiter">
        <div class="container-login100" style="background-image: url('images/bg-01.jpg');">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server">
                <span class="login100-form-logo"> 
                    <asp:Image ID="Image1" runat="server"  
                    ImageUrl="~/images/Inecom-logo-1.png" Width="100px" /></span><span
                    class="login100-form-title p-b-34 p-t-27">Log in </span>
                <div class="wrap-input100 validate-input" data-validate="Enter username">
                    <asp:TextBox ID="txtusername" class="input100" name="username" placeholder="Username"
                        runat="server"></asp:TextBox>
                    <span class="focus-input100" data-placeholder="&#xf207;"></span>
                </div>
                <div class="wrap-input100 validate-input" data-validate="Enter password">
                    <asp:TextBox ID="txtpassword" class="input100" name="pass" placeholder="Password"
                        runat="server" TextMode="Password"></asp:TextBox>
                    <span class="focus-input100" data-placeholder="&#xf191;"></span>
                </div>                
                <div class="container-login100-form-btn">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" class="login100-form-btn" OnClick="btnLogin_Click" />
                </div>
                <div class="text-center p-t-90" style="padding-top: 8px;">
                    <p>
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div class="text-center p-t-90" style="padding-top: 8px;">
                    <a class="txt1" href="#">Forgot Password? </a>
                </div>
                </form>
            </div>
        </div>
    </div>
    <div id="dropDownSelect1">
    </div>
    <!--===============================================================================================-->
    <script src="~/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/vendor/bootstrap/js/popper.js"></script>
    <script src="~/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/vendor/daterangepicker/moment.min.js"></script>
    <script src="~/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="~/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="~/js/main.js"></script>
</body>
</html>
