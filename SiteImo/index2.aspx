<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="SiteImo.index2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8"/>
    <meta name="description" content=""/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Imobiliaria Toledo</title>
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/flexslider.css"/>
    <link rel="stylesheet" href="css/jquery.fancybox.css"/>
    <link rel="stylesheet" href="css/main.css"/>
    <link rel="stylesheet" href="css/responsive.css"/>
    <link rel="stylesheet" href="css/animate.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
        <style>
        .item {
            width:80%;
            background-color:#e5dfdf;
            border-radius:10px 10px;
            text-align:center;
            margin-left:auto;
            margin-right:auto;
            margin-top:20px;
            padding-bottom:20px;
        }
        .img {
            width:400px;
            height:300px;
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
                   <a class="logo" href="index2.aspx">
                       <img src="images/logo.png" alt=""/></a>
                   <nav class="navigation" role="navigation">
                       <ul class="primary-nav">
                           <li><a href="index2.aspx">Imoveis</a></li>
                           <li><a href="#contact">Contato</a></li>
                           <li><a href="cadastroImoveis.aspx">Enviar Imovel</a></li>
                       </ul>
                   </nav>
                   <a href="#" class="nav-toggle">Menu<span></span></a>
               </div>
               <!-- header content -->
           </header>
           <!-- header -->

<%--           <div class="container">
               <div class="col-md-10 col-md-offset-1">
                   <div class="banner-text text-center">
                       <h3>Pesquise o imóvel de seus sonhos.</h3>

                       <div id="custom-search-input">
                           <div class="input-group col-md-12">
                               <input type="text" class="  search-query form-control" placeholder="Procure..." />
                           </div>
                       </div>

                       <a href="#" class="btn btn-large glyphicon glyphicon-search">Encontrar !</a>
                   </div>
               </div>
           </div>--%>
       </section>
    <!-- banner -->
    <!-- Imóveis -->
    <section id="imoveis" class="works section no-padding">
        <div class="container-fluid">
            <div class="row no-gutter">
             <div class="headingsyle">
                 <h1><span>IMÓVEIS</span></h1>

                 <div class="row">
                     <div class="col-md-3 col-md-offset-1">
                         <br />
                             <asp:DropDownList ID="ddlValor" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlValor_SelectedIndexChanged">
                             <asp:ListItem Value="0">- Selecione um valor -</asp:ListItem>
                             <asp:ListItem Value="12">Valores para venda</asp:ListItem>
                             <asp:ListItem Value="1">0 a 30 mil</asp:ListItem>
                             <asp:ListItem Value="2">30 mil a 60 mil</asp:ListItem>
                             <asp:ListItem Value="3">60 mil a 90 mil</asp:ListItem>
                             <asp:ListItem Value="4">90 mil a 120 mil</asp:ListItem>
                             <asp:ListItem Value="5">Acima de 120 mil</asp:ListItem>
                             <asp:ListItem Value="6">Valores para Aluguel</asp:ListItem>
                             <asp:ListItem Value="7">0 a 800</asp:ListItem>
                             <asp:ListItem Value="8">800 a 1600</asp:ListItem>
                             <asp:ListItem Value="9">1600 a 2400</asp:ListItem>
                             <asp:ListItem Value="10">2400 a 3000</asp:ListItem>
                             <asp:ListItem Value="11">Acima de 3000</asp:ListItem>

                         </asp:DropDownList>
                     </div>
                     <div class="col-md-3 col-md-offset-2">
                         <br />
                         <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                             <asp:ListItem Value="0">- Selecione um Tipo -</asp:ListItem>
                             <asp:ListItem Value="1">Casa</asp:ListItem>
                             <asp:ListItem Value="2">Apartamento</asp:ListItem>
                             <asp:ListItem Value="3">Kitnet</asp:ListItem>
                             <asp:ListItem Value="4">Flat</asp:ListItem>
                             <asp:ListItem Value="5">Cobertura</asp:ListItem>
                             <asp:ListItem Value="6">Mansão</asp:ListItem>
                             <asp:ListItem Value="7">Casa de Praia</asp:ListItem>
                             <asp:ListItem Value="8">Casa de campo</asp:ListItem>
                             <asp:ListItem Value="9">Loft</asp:ListItem>
                             <asp:ListItem Value="10">Loja</asp:ListItem>
                             <asp:ListItem Value="11">Sala</asp:ListItem>
                             <asp:ListItem Value="12">Deposito</asp:ListItem>
                            
                         </asp:DropDownList>
                         </div>
                         <br />
                    
<%--                     <div class="col-md-3 col-md-offset-2">
                         <asp:DropDownList ID="DDListarImovelPreco" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DDListarImovelPreco_SelectedIndexChanged">
                         </asp:DropDownList>
                     </div>--%>
                     <br /><br /><br /><br /><asp:Label ID="lblAvisos" runat="server"></asp:Label>
                 </div>
                 <div class="row">
                     <asp:ListView ID="lvItens" runat="server">
                         <ItemTemplate>
                             <div class="col-md-4 container-fluid">
                                 <div class="container-fluid">
                                     <img src="imoveis/<%#Eval("imagem1") %>" class="img container-fluid img-responsive" />
                                     <br />
                                     <span class="valor">R$ <%#Eval("valorvendalocacao") %></span>
                                     <br />
                                     <span>Área Construida: <%#Eval("areacon") %>m²</span>&nbsp;&nbsp<span>Área Total: <%#Eval("areater") %>m²</span>
                                     <br />
                                     <a href="detalhes.aspx?id=<%#Eval("id") %>" class="btn btn-primary">Detalhes</a>
                                 </div>
                             </div>

                         </ItemTemplate>
                     </asp:ListView>
                 </div>
         </div>

            </div>
        </div>
        <div class="container-fluid">
            <div class="col-md-4 col-md-offset-4">
                <asp:DataPager ID="DataPager1" class="paginacao" runat="server" OnPreRender="DataPager1_PreRender" PagedControlID="lvItens" PageSize="3">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>

    </section>
    <!-- Imoveis -->

    <!-- Contact Form -->
       <%#Eval("areacon") %>
    <!-- End Contact Form -->
    <footer class="footer">
        <div class="footer-top">
            <div class="container">
                <div class="row">
                    <div class="footer-col col-md-4">
                        <h5>Localização</h5>
                        <p>Teodoro City<br/>
                            São Paulo</p>
                    </div>
                    <div class="footer-col col-md-4">
                        <h5>Compartilhe</h5>
                        <ul class="footer-share">
                            <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                            <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                        </ul>
                    </div>
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
