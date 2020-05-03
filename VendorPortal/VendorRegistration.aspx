<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorRegistration.aspx.cs" Inherits="VendorPortal.Vendor_form" %>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title>Quixlab - Bootstrap Admin Dashboard Template by Themefisher.com</title>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="images/favicon.png">
   
    <link href="css/style.css" rel="stylesheet">

</head>

<body>
    

    
    <!--preloader include-->
    <%Response.WriteFile("preloader.inc"); %>
    <!--preloader include-->

    
    <!--**********************************
        Main wrapper start
    ***********************************-->
    <div id="main-wrapper">


    <!--Header Include-->
    <%Response.WriteFile("post_signin_header.inc"); %>
    <!--Header Include-->



    <!--Sidebar Include-->
    <% Response.WriteFile("post_signin_sidebar.inc"); %>
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
    



   <div class="container-fluid">
                <div class="row">
                <form class="Vendor_form" runat="server">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h1 class="card-title">VENDOR REGISTRATION FORM</h1> <br> <br> 
                                <h5>NAME</h5>
                                <div class="basic-form">
                                    
                                        <div class="form-row">
                                            <div class="col-md-2 ">
                                                <select id="title" class="form-control" runat="server" required >
                                                    <option value="">Title</option>
                                                    <option value="Ms">M/s</option>
                                                    <option value="Mr">Mr</option>
                                                    <option value="Mrs">Mrs</option>
                                                    <option value="Dr">Dr</option>
                                                </select>
                                            </div>
                                            <div class="col">
                                                <input type="text" class="form-control" required id="fname" placeholder="First name" runat="server" >
                                            </div>
                                            <div class="col">
                                                <input type="text" class="form-control" required id="mname" placeholder="Middle name" runat="server" >
                                            </div>
                                            <div class="col">
                                                <input type="text" class="form-control" required id="lname" placeholder="Last name" runat="server" >
                                            </div>
                                        </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">ADDRESS</h5>
                                <div class="basic-form">
                                   
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" required placeholder="House/ bldg. number" id="house_no" runat="server">
                                        </div>
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" required placeholder="Street" id="street"  runat="server">
                                        </div>
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" required placeholder="City/ Postal Code" id="city_code" runat="server">
                                        </div>
                                       
                                        <div class="form-row">
                                            <div class="form-group col-md-5 ">
                                                <label></label>
                                                <input type="text" class="form-control" required placeholder="City" id= "city" runat="server">
                                            </div>
                                            <div class="form-group col-md-5">
                                                <label> </label>
                                                <input type="text" class="form-control" required placeholder="State" id="state" runat="server">
                                            </div>
                                            <div class="form-group col-md-2">
                                                <label></label>
                                                <input type="text" class="form-control" required placeholder="PIN Code" id="pin" runat="server">
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" required placeholder="Country" id="country" runat="server">
                                        </div>
                                        <!--<div class="form-group">
                                            <div class="form-check">
                                                <input class="form-check-input" type="checkbox">
                                                <label class="form-check-label">Check me out</label>
                                            </div>
                                        </div>
                                        <button type="submit" class="btn btn-dark">Sign in</button>-->
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">COMMUNICATION</h5>
                                <div class="basic-form">
                                    
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" required placeholder="Contact person" id="contact_person" runat="server">
                                        </div>
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="number" class="form-control" required placeholder="Telephone number.ext." id="telephone_no" runat="server">
                                        </div>
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="number" class="form-control" required placeholder="Mobile Phone" id="mobile_no" runat="server">
                                        </div>
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="number" class="form-control" required placeholder=" FAX" id="fax" runat="server">
                                        </div> 
                                        <div class="form-group">
                                            <label> </label>
                                            
                                            <input type="email" class="form-control" required placeholder="Email" readonly id="email_id" runat="server">
                                        </div>
                                         <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" required placeholder=" PAN no." id="pan_no" runat="server">
                                        </div> 
                                         <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" required placeholder="GST no." id="gst_no" runat="server">
                                        </div> 
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">REFERENCE DATA</h5>
                                <div class="basic-form">
                                    
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" id="industry" required placeholder="Industry(whether psu, air force, military, Govt, others)" runat="server">
                                        </div>
                                        <div class="form-group">
                                            <label> </label>
                                            <input type="text" class="form-control" id="micro" required placeholder="Micro/SSI Status" runat="server">
                                        </div>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                <asp:Button ID="btnFormSubmit" CssClass="btn login-form__btn submit w-100" Text= "Submit" runat="server" OnClick="btnFormSubmit_Click"/>
                </form>
                </div>
            </div>
            <!-- #/ container -->
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