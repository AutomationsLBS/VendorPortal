<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_Movement.aspx.cs" Inherits="VendorPortal.Vendor_Movement" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title>Quixlab - Bootstrap Admin Dashboard Template by Themefisher.com</title>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="images/favicon.png">
    <!-- Custom Stylesheet -->
    <link href="./plugins/tables/css/datatable/dataTables.bootstrap4.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

</head>

<body >
    

    
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
       <div class="row justify-content-center h-100">
                <form class="Vendor_form" runat="server">
                        <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="basic-form">
                                    <div class="form-row">
                                        <div class="col">
                                            <h5>VENDOR CODE</h5>
                                            <input type="number" class="form-control" id="vendor_code" required runat="server">
                                        </div>
                                        <div class="col">
                                            <h5>PO NUMBER</h5>
                                            <input type="number" class="form-control" id="po_number" required  runat="server">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>        
                <asp:Button ID="VendorMovementSubmit"  CssClass="btn login-form__btn submit  w-50 SubmitBtnVendorCode" Text= "Submit" runat="server" OnClick="VendorMovement_Click" />

                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Data Table</h4>
                                <div class="table-responsive"> 
                                        <table class="table table-striped table-bordered zero-configuration">
                                        <thead>
                                            <tr>
                                                <th>LIFNR</th>
                                                <th>BELNR</th>
                                                <th>BUZEI</th>
                                                <th>GJAHR</th>
                                                <th>BUDAT</th>
                                                <th>BWART</th>
                                                <th>MATNR</th>
                                                <th>SGTXT</th>
                                                <th>EBELN</th>
                                                <th>AEDAT</th>
                                                <th>MAKTX</th>
                                                <th>MENGE</th>
                                                <th>MEINS</th>
                                                <th>DMBTR</th> 
                                                        
                                            </tr>
                                        </thead>
                                        <tbody>
                                           <%= SAPData() %>                                         
                                        </tbody>
                                        <tfoot>
                                            <tr>    
                                                <th>LIFNR</th>
                                                <th>BELNR</th>
                                                <th>BUZEI</th>
                                                <th>GJAHR</th>
                                                <th>BUDAT</th>
                                                <th>BWART</th>
                                                <th>MATNR</th>
                                                <th>SGTXT</th>
                                                <th>EBELN</th>
                                                <th>AEDAT</th>
                                                <th>MAKTX</th>
                                                <th>MENGE</th>
                                                <th>MEINS</th>
                                                <th>DMBTR</th>            
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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

    <script src="./plugins/tables/js/jquery.dataTables.min.js"></script>
    <script src="./plugins/tables/js/datatable/dataTables.bootstrap4.min.js"></script>
    <script src="./plugins/tables/js/datatable-init/datatable-basic.min.js"></script>

    
</body>

</html>