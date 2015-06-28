<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drug-details.aspx.cs" Inherits="BabySafeRx.drug_details" %>

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
                            <span class="powered-by">Powered by </span>
                            <a class="open-fda" href="https://open.fda.gov/" target="_blank">
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
                        <li><a href="drug-search.aspx">Search Results</a></li>
                        <li class="current"><a href="#">Drug Details</a></li>
                    </ul>
                </div>

                <div class="heading large-12 medium-12 small-12 columns">
                    <h1>Prescription Drugs: <span runat="server" id="brandName"></span></h1>
                    <h2><span runat="server" id="genericName"></span></h2>
                </div>


                <div class="details-left large-4 medium-6 small-12 columns">

                    <div class="risk-level">
                        <h3>Risk Level</h3>
                        <div class="risk-level-number large-3 medium-3 small-2 columns">
                            <img runat="server" id="riskImage" class="risk-level-img img-responsive" src="img/Risk-1.png" />
                        </div>
                        <div class="risk-level-text large-9 medium-9 small-10 columns">
                            <p runat="server" id="riskText"></p>
                            <p>* no human studies</p>
                        </div>
                    </div>

                    <div class="drug-info-box">
                        <article data-readmore="" aria-expanded="false" id="Article2">
                            <h3>Use During Pregnancy</h3>
                            <p runat="server" id="pregnancyUse"></p>
                        </article>
                    </div>

                    <div class="drug-info-box">
                        <h3>Use During Labor and Delivery</h3>
                        <p runat="server" id="laborDelivery"></p>
                    </div>

                    <div class="drug-info-box">
                        <h3>Use While Nursing</h3>
                        <p runat="server" id="nursingUse"></p>
                    </div>

                </div>

                <div class="details-right large-8 medium-6 small-12 columns">

                    <div class="details-right-lcolumn large-6 medium-12 small-12 columns">
                        <div class="drug-info-box">
                            <article data-readmore="" aria-expanded="false" id="rmjs-1">
                                <h3>Usage</h3>
                                <p runat="server" id="usageText"></p>
                            </article>
                        </div>

                        <div class="drug-info-box">
                            <h3>Ingredients</h3>
                            <p runat="server" id="ingredientsText"></p>
                        </div>

                    </div>

                    <%--                    <div class="details-right-rcolumn large-6 medium-12 small-12 columns">
                        <div class="alternatives drug-info-box">
                            <h3>Alternatives</h3>
                            <p>* no human studies</p>
                            <ul>
                                <li><span>
                                    <img class="risk-3" src="img/risk-3.png" /></span><a href="#">[brand name]</a></li>
                                <li><span>
                                    <img class="risk-2" src="img/risk-2.png" /></span><a href="#">[brand name]</a></li>
                                <li><span>
                                    <img class="risk-1" src="img/risk-1.png"></span><a href="#">[brand name]</a></li>
                                <li><span>
                                    <img class="risk-5" src="img/risk-5.png"></span><a href="#">[brand name]</a></li>
                            </ul>
                        </div>
                    </div>--%>
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
        <script src="js/Readmore.js-master/readmore.js"></script>

        <script>
            $(document).foundation();
            $('#rmjs-1').readmore();
        </script>
    </form>
</body>
</html>
