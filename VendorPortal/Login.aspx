<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VendorPortal.Login" %>

<!DOCTYPE html>
<html class="h-100" lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title>Vendor Portal</title>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../../assets/images/favicon.png">
    <!-- <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous"> -->
    <link href="css/style.css" rel="stylesheet">
    
</head>

<body class="h-100">
    
    <!--preloader include-->
    <%Response.WriteFile("preloader.inc"); %>
    <!--preloader include-->

    
    <!--**********************************
        Main wrapper start
    ***********************************-->
    <div id="main-wrapper">


    <!--Header Include-->
    <%Response.WriteFile("pre_signin_header.inc"); %>
    <!--Header Include-->



    <!--Sidebar Include-->
    <% Response.WriteFile("pre_signin_sidebar.inc"); %>
    <!--Sidebar Include-->    



        <!--**********************************
            Content body start
        ***********************************-->
        <div class="content-body">

            <div class="row page-titles mx-0">
                <div class="col p-md-0">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="javascript:void(0)">Dashboard</a></li>
                        <li class="breadcrumb-item active"><a href="javascript:void(0)">Home</a></li>
                    </ol>
                </div>
            </div>
            <!-- row -->
    



    <div class="login-form-bg h-100">
        <div class="container h-100">
            <div class="row justify-content-center h-100">
                <div class="col-xl-6">
                    <div class="form-input-content">
                        <div class="card login-form mb-0">
                            <div class="card-body pt-5">
                                <a class="text-center" href="index.html"> <h4>Vendor Login</h4></a>
        
                                <form class="mt-5 mb-5 login-input" runat="server">
                                    <div class="form-group">
                                        <input type="email" class="form-control" required id="txtemail" runat="server" placeholder="Email">
                                    </div>
                                    <div class="form-group">
                                        <input type="password" class="form-control" required id="txtpassword" runat="server" placeholder="Password">
                                    </div>

                                    <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                                    
                                    <asp:Button ID="btnLogin" CssClass="btn login-form__btn submit w-100" Text= "Sign In" runat="server" OnClick="btnLogin_Click"/>
                                </form>
                                <p class="mt-5 login-form__footer"> Don't have account? <a href="SignUp.aspx" class="text-primary">Sign Up</a> now</p>
                                <p class="mt-5 login-form__footer"> <a href="get_OTP.aspx" class="text-primary">Forgot Password?</a> </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
    <!--**********************************
            Content body end
        ***********************************-->
        
        
         <!--footer include-->
        <%Response.WriteFile("footer.inc"); %>
        <!--footer include-->



    </div>
    <!--**********************************
        Main wrapper end
    ***********************************-->

    <!--**********************************
        Scripts
    ***********************************-->
    <script src="plugins/common/common.min.js"></script>
    <script src="js/custom.min.js"></script>
    <script src="js/settings.js"></script>
    <script src="js/gleek.js"></script>
    <script src="js/styleSwitcher.js"></script>

</body>
</html>
