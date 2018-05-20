<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="SiteImobiliaria.index" %>

<!doctype html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang=""> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8" lang=""> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9" lang=""> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js" lang="">
<!--<![endif]-->
<head>
    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Imobiliaria Toledo</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/flexslider.css">
    <link rel="stylesheet" href="css/jquery.fancybox.css">
    <link rel="stylesheet" href="css/main.css">
    <link rel="stylesheet" href="css/responsive.css">
    <link rel="stylesheet" href="css/animate.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
        <style>
        .item {
            width:40%;
            background-color:#e5dfdf;
            border-radius:10px 10px;
            text-align:center;
            margin-left:auto;
            margin-right:auto;
            margin-top:20px;
            padding-bottom:20px;
        }
        .img {
            width:30%;
            height:30%;
            display:block;
            margin-left:auto;
            margin-right:auto;
            padding-top:20px;
        }
        .valor {
            color:#1ec2a9;
            font-size:20px;
            font-weight:bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <section class="banner" role="banner">
   
        <header id="header">
            <div class="header-content clearfix">
                <a class="logo" href="#"><img src="images/logo.png" alt=""></a>
                <nav class="navigation" role="navigation">
                    <ul class="primary-nav">
                        <li><a href="#imoveis">Imoveis</a></li>
                        <li><a href="#contact">Contato</a></li>
                    </ul>
                </nav>
                <a href="#" class="nav-toggle">Menu<span></span></a>
            </div><!-- header content -->
        </header><!-- header -->
       
        <div class="container">
            <div class="col-md-10 col-md-offset-1">
                <div class="banner-text text-center">
                    <h3>Pesquise o imóvel de seus sonhos.</h3>

                    <div id="custom-search-input">
                        <div class="input-group col-md-12">
                            <input type="text" class="  search-query form-control" placeholder="Procure..." />
                        </div>
                    </div>

                    <a href="#" class="btn btn-large glyphicon glyphicon-search"> Encontrar !</a>
                </div><!-- banner text -->
            </div>
        </div>
    </section>
    <!-- banner -->
    <!-- Imóveis -->
    <section id="imoveis" class="works section no-padding">
        <div class="container-fluid">
            <div class="row no-gutter">
             <div class="headingsyle">
             <h1><span>IMÓVEIS</span></h1>

                 <div class="row" style="visibility: hidden">
                     <div class="col-md-3 col-md-offset-1">
                         <br />
                         <asp:DropDownList ID="ddlValor" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlValor_SelectedIndexChanged">
                             <asp:ListItem Value="0">- Selecione um Tipo -</asp:ListItem>
                             <asp:ListItem Value="1">0 a 30 mil</asp:ListItem>
                             <asp:ListItem Value="2">30 mil a 60 mil</asp:ListItem>
                             <asp:ListItem Value="3">60 mil a 90 mil</asp:ListItem>
                             <asp:ListItem Value="4">90 mil a 120 mil</asp:ListItem>
                         </asp:DropDownList>
                     </div>
                     <div class="col-md-3 col-md-offset-2">
                         <br />
                         <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                             <asp:ListItem Value="0">- Selecione um Tipo -</asp:ListItem>
                             <asp:ListItem Value="1">Apartamento</asp:ListItem>
                             <asp:ListItem Value="2">Casa</asp:ListItem>
                            
                         </asp:DropDownList>
                     </div>
                 </div>
                 <div class="row">
                     <asp:ListView ID="imoveisItens" runat="server">
                         <ItemTemplate>
                             <div class="col-md-6">
                                 <div class="item">
                                     <img src="imoveis/<%#Eval("imagem") %>" class="img-responsive img" />
                                     <br />
                                     <%#Eval("nome") %>
                                     <br />
                                     <span class="valor">R$ <%#Eval("valor") %></span>
                                     <br />
                                     <a href="detalhes.aspx?codigo=<%#Eval("id") %>" class="btn btn-primary">Comprar</a>
                                 </div>
                             </div>
                         </ItemTemplate>
                     </asp:ListView>
                 </div>

                  <div class="row">
        <div class="container-fluid">
            <div class="col-md-4 col-md-offset-4">
                <asp:DataPager ID="DataPager1" class="paginacao" runat="server" OnPreRender="DataPager1_PreRender" PagedControlID="lvItens" PageSize="2">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>
    </div>
           </div>
                <%--<div class="col-lg-3 col-md-6 col-sm-6 work">
                    <a href="images/work-1.jpg" class="work-box">
                        <img src="images/work-1.jpg" alt="">
                        <div class="overlay">
                            <div class="overlay-caption">
                                <h5>Project Name</h5>
                                <p>Website Design</p>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 work">
                    <a href="images/work-2.jpg" class="work-box">
                        <img src="images/work-2.jpg" alt="">
                        <div class="overlay">
                            <div class="overlay-caption">
                                <h5>Project Name</h5>
                                <p>Website Design</p>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 work">
                    <a href="images/work-3.jpg" class="work-box">
                        <img src="images/work-3.jpg" alt="">
                        <div class="overlay">
                            <div class="overlay-caption">
                                <h5>Project Name</h5>
                                <p>Website Design</p>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 work">
                    <a href="images/work-4.jpg" class="work-box">
                        <img src="images/work-4.jpg" alt="">
                        <div class="overlay">
                            <div class="overlay-caption">
                                <h5>Project Name</h5>
                                <p>Website Design</p>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 work">
                    <a href="images/work-5.jpg" class="work-box">
                        <img src="images/work-5.jpg" alt="">
                        <div class="overlay">
                            <div class="overlay-caption">
                                <h5>Project Name</h5>
                                <p>Website Design</p>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 work">
                    <a href="images/work-6.jpg" class="work-box">
                        <img src="images/work-6.jpg" alt="">
                        <div class="overlay">
                            <div class="overlay-caption">
                                <h5>Project Name</h5>
                                <p>Website Design</p>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 work">
                    <a href="images/work-7.jpg" class="work-box">
                        <img src="images/work-7.jpg" alt="">
                        <div class="overlay">
                            <div class="overlay-caption">
                                <h5>Project Name</h5>
                                <p>Website Design</p>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 work">
                    <a href="images/work-8.jpg" class="work-box">
                        <img src="images/work-8.jpg" alt="">
                        <div class="overlay">
                            <div class="overlay-caption">
                                <h5>Project Name</h5>
                                <p>Website Design</p>
                            </div>
                        </div>
                    </a>
                </div>--%>
            </div>
        </div>
    </section>
    <!-- Imoveis -->

    <!-- Contact Form -->
    <section id="contact" class="space100">
        <div class="container">
            <div class="row">
                
            </div>
            <!-- ./end row -->
            <div class="row">
                <div class="col-md-12">
                    <div id="main-contact-form" class="contact-form">
                        <!-- form -->
                        <form role="form" action="contact.php" method="post">
                        <div class="form-group">
                            <label class="sr-only" for="contact-name">
                                Name</label>
                            <input type="text" name="name" placeholder="Nome..." class="contact-name form-control"
                                id="contact-name">
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="contact-email">
                                Email</label>
                            <input type="text" name="email" placeholder="Email..." class="contact-email form-control"
                                id="contact-email">
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="contact-subject">
                                Subject</label>
                            <input type="text" name="subject" placeholder="Assunto..." class="contact-subject form-control"
                                id="contact-subject">
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="contact-message">
                                Message</label>
                            <textarea name="message" placeholder="Mensagem..." class="contact-message form-control"
                                id="contact-message"></textarea>
                        </div>
                        <button type="submit" class="btn btn-large">
                            <i class="fa fa-envelope"></i>Enviar mensagem</button>
                        </form>
                        <!-- ./form -->
                    </div>
                </div>
            </div>
            <!-- ./end row -->
        </div>
    </section>
    <!-- End Contact Form -->
    <footer class="footer">
        <div class="footer-top">
            <div class="container">
                <div class="row">
                    <div class="footer-col col-md-4">
                        <h5>Location</h5>
                        <p>3481 Hi-Tech City<br>Hyderabad, INDIA 500072</p>
                    </div>
                    <div class="footer-col col-md-4">
                        <h5>Compartilhe</h5>
                        <ul class="footer-share">
                            <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="https://twitter.com/kamal_chaneman"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="https://www.linkedin.com/in/kamalchaneman"><i class="fa fa-linkedin"></i></a></li>
                            <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                        </ul>
                </div>
            </div>
        </div><!-- footer top -->
        <div class="footer-bottom">
            <div class="container">
                <div class="col-md-12">
                    <p>Copyright © 2017 VyseVision. All Rights Reserved</p>
                </div>
            </div>
        </div>
    </footer>
    <!-- footer -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script>        window.jQuery || document.write('<script src="js/jquery.min.js"><\/script>')</script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.flexslider-min.js"></script>
    <script src="js/jquery.fancybox.pack.js"></script>
    <script src="js/jquery.waypoints.min.js"></script>
    <script src="js/retina.min.js"></script>
    <script src="js/modernizr.js"></script>
    <script src="js/main.js"></script>
    </form>
</body>
</html>
