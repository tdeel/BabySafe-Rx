<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drug-search.aspx.cs" Inherits="BabySafeRx.drug_search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js" lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>BabySafe Rx</title>
    <link rel="stylesheet" href="css/foundation.css" />
    <link rel="stylesheet" href="css/stylesheet.css" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/foundicons/3.0.0/foundation-icons.css" />
    <!-- DataTables CSS -->
    <link rel="stylesheet" type="text/css" href="css/jquery-dataTables.css" />
    <script src="js/vendor/modernizr.js"></script>
    <script src="js/vendor/jquery.js"></script>
    <script src="js/foundation.min.js"></script>
    <!-- jQuery -->
    <!-- DataTables -->
    <script src="js/jquery-dataTables.js"></script>
    <script>
        $(document).ready(function () {
            $('#searchTable').DataTable();
        });

        function runSearch() {
            searchText = new String("");
            searchText = $("#txtSearch").val();
            document.location.href = "drug-search.aspx?search=" + searchText;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="row">
                <div class="large-12 columns">
                    <div class="logo-container left">
                        <a class="logo" href="Home.aspx">
                            <img class="img-responsive" alt="BabySafe Rx" src="img/logo.png" /></a>
                    </div>
                    <div class="open-fda-container left">
                        <p>
                            <span class="powered-by">Powered by </span><a class="open-fda" href="https://open.fda.gov/" target="_blank">
                                <img class="img-responsive" alt="Open FDA" src="img/logo-open-fda.png" /></a>
                        </p>
                    </div>
                </div>
            </div>
        </header>
        <section class="content">
            <div class="row">
                <div class="breadcrumbcontainer large-12 medium-12 small-12 columns">
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home</a></li>
                        <li class="current"><a href="#">Search Results</a></li>
                    </ul>
                </div>
                <div class="heading large-12 medium-12 small-12 columns">
                    <h1>Prescription Drugs
                    </h1>
                    <div class="search-bar row collapse">
                        <div class="search-bar-input-div large-11 medium-11 small-10 columns">
                            <asp:TextBox ID="txtSearch" ClientIDMode="Static" runat="server" CssClass="search-bar-input" placeholder="Can I take this drug while pregnant?"></asp:TextBox>
                        </div>
                        <div class="search-icon-div large-1 medium-1 small-2 end columns">
                            <span class="search-icon postfix" onclick="runSearch();">
                                <i class="fi-magnifying-glass"></i>
                            </span>
                        </div>
                    </div>
                    <div class="risk-disclaimer">
                        <p>* no human studies </p>
                    </div>

                    <asp:Table ID="searchTable" runat="server" CssClass="results-section" ClientIDMode="Static">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell><u>Risk Level</u></asp:TableHeaderCell>
                            <asp:TableHeaderCell><u>Drug Name</u></asp:TableHeaderCell>
                            <asp:TableHeaderCell>Generic Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Usage</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow TableSection="TableBody">
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </section>
        <footer class="clear">
            <div class="row">
                <div class="large-9 medium-9 small-9 columns">
                    <p class="copyright left">Copyright &copy; 2015 BabySafe RX. All Rights Reserved.</p>
                </div>
                <div class="large-3 medium-3 small-3 columns">
                    <a class="fda right" href="http://www.fda.gov/" target="_blank">
                        <img class="img-responsive" alt="FDA" src="img/logo-fda.png" /></a>
                </div>
            </div>
        </footer>
        <script>
            $(document).foundation();

        </script>
    </form>
</body>
</html>
