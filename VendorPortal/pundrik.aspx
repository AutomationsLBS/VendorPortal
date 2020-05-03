<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pundrik.aspx.cs" Inherits="VendorPortal.pundrik" %>

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
                                            <h5> VENDOR CODE </h5>
                                            <input type="number" class="form-control" id="vendor_code" required runat="server">
                                        </div>
                                        <div class="col">
                                            <h5> FROM DATE </h5>
                                            <input type="date" class="form-control" id="from_date" required  runat="server">
                                        </div>
                                        <div class="col">
                                            <h5>TO DATE</h5>
                                            <input type="date" class="form-control" id="to_date" required  runat="server">
                                            <!--<input type="text" class="form-control" id="f"  runat="server">-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                            <asp:Button ID="VendorAcountStatementSubmit"  CssClass="btn login-form__btn submit  w-50 SubmitBtnVendorCode" Text= "Submit" runat="server" OnClick="VendorAccountStatement_Click" />
                        </div>        
                

                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Data Table</h4>
                                <div class="table-responsive"> 
                                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered zero-configuration" AutoGenerateColumns="true" BorderWidth="1">
                                            <Columns>
                                             <asp:BoundField DataField="LIFNR" HeaderText="LIFNR"  />
                                             <asp:BoundField DataField="BELNR" HeaderText="BELNR"  />    
                                             <asp:BoundField DataField="BLDAT" HeaderText="BLDAT"  />
                                             <asp:BoundField DataField="BLART" HeaderText="BLART"  />
                                             <asp:BoundField DataField="DR_AMT" HeaderText="DR_AMT"  />
                                             <asp:BoundField DataField="CR_AMT" HeaderText="CR_AMT"  />
                                             <asp:BoundField DataField="DZUONR" HeaderText="DZUONR"  /> 
                                             <asp:BoundField DataField="SGTXT" HeaderText="SGTXT"  />
                                             <asp:BoundField DataField="O_OP_BLNC" HeaderText="O_OP_BLNC"  />
                                             <asp:BoundField DataField="O_CL_BLNC" HeaderText="O_CL_BLNC"  />     
                                        </Columns>
                                       </asp:GridView>
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