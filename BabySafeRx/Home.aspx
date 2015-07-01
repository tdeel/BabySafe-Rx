<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BabySafeRx.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js" lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>BabySafe Rx</title>
    <link rel="stylesheet" href="css/foundation.css" />
    <link rel="stylesheet" href="css/stylesheet.css" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic,700italic' rel='stylesheet' type='text/css' />
    <link type="text/css" rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/foundicons/3.0.0/foundation-icons.css" />
    <script src="js/vendor/modernizr.js"></script>
    <script src="js/vendor/jquery.js"></script>
    <script>

        function searchLink(searchText) {
            $("#inputSearch").val(searchText);
            $("#searchButton").click();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="searchButton">
<asp:LinkButton ID="LinkButton1" runat="server" />
                <header>
            <div class="row">
                <div class="large-12 columns">
                    <div class="logo-container left">
                        <a class="logo" href="Home.aspx">
                            <img class="img-responsive" alt="BabySafe Rx" src="img/logo.png" /></a>
                    </div>

                    <div class="open-fda-container left">
                        <p>
                            <span class="powered-by">Powered by </span>
                            <a class="open-fda" href="https://open.fda.gov/" target="_blank">
                                <img class="img-responsive" alt="Open FDA" src="img/logo-open-fda.png" /></a>
                        </p>
                    </div>
                </div>
            </div>
        </header>

        <section class="content">
            <div class="content-row">
                <div class="pregnant-woman large-3 medium-4 small-4 columns">
                    <img class="pregnant-woman-img img-responsive" alt="pregnant woman" src="img/pregnant-woman.jpg" />
                </div>

                <div class="intro-text large-9 medium-8 small-8 columns">
                    <h1>Is it OK to take?</h1>
                    <p>Powered by the FDA's prescription drug database, BabySafe Rx gives expectant and breastfeeding mothers the facts they need to help make informed decisions when taking prescription medication during pregnancy.</p>
                </div>

                <div class="prescription-drugs-container large-6 medium-8 small-12 columns">
                    <div class="prescription-drugs">
                        <h2>Prescription Drugs</h2>

                        <div class="search-bar row collapse">
                            <div class="search-bar-input-div large-11 medium-11 small-10 columns">
                                <asp:TextBox runat="server" id="inputSearch" placeholder="Can I take this drug while pregnant?" CssClass="search-bar-input"></asp:TextBox>
                            </div>
                            <div class="search-icon-div large-1 medium-1 small-2 end columns">
                                <span class="search-icon postfix">
                                    <asp:ImageButton runat="server" ID="searchButton" CssClass="fi-magnifying-glass no-outline" ClientIDMode="Static" 
                                        ImageUrl="https://cdnjs.cloudflare.com/ajax/libs/foundicons/3.0.0/svgs/fi-magnifying-glass.svg" 
                                        BorderStyle="None"
                                        Width="22" Height="22"
                                        OnClick="searchButton_Click" />
                                </span>
                            </div>
                        </div>
                        <asp:Label runat="server" ID="lblError" ForeColor="Red" Visible="false" Text=""></asp:Label>
                        <h3>Common Prescription Drugs</h3>
                        <ul>
                            <li><a href="javascript:void(0)" onclick="searchLink('Topamax')">Topamax (topiramate)</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Nasonex')">Nasonex (mometasone f...</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Lunesta')">Lunesta (eszopiclone)</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Claravis')">Claravis (isotretinoi...</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Amoxicillin')">Amoxil (amoxicillin)</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Zofran')">Zofran (ondansetron)</a></li>
                        </ul>
                    </div>
                </div>
                <div class="new-data-container large-3 medium-8 small-12 columns">
                    <div class="new-data">
                        <h2>We Have New Data About</h2>
                        <ul>
                            <li><a href="javascript:void(0)" onclick="searchLink('Zoloft')">Zoloft (sertraline h...</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Lunesta')">Lunesta (eszopiclone)</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Amoxil')">Amoxil (amoxicillin)</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Nasonex')">Nasonex (mometasone f...</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Topamax')">Topamax (topiramate)</a></li>
                            <li><a href="javascript:void(0)" onclick="searchLink('Zofran')">Zofran (ondansetron)</a></li>
                        </ul>
                    </div>
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

        <script src="js/vendor/jquery.js"></script>
        <script src="js/foundation.min.js"></script>
        <script>
            $(document).foundation();
        </script>
    </form>
</body>
</html>
