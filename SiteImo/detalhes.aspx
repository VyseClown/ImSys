<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detalhes.aspx.cs" Inherits="SiteImo.detalhes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/jquery.slick/1.8.0/slick.css"/>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick-theme.min.css" rel="stylesheet" />
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
            width:100%;
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
                .titulo {
            font-family:Arial;
            font-size:20px;
            font-weight:bold;
            color:#64148e; 
            text-align:center;
            margin-top:20px;
        }
        .descricao {
            text-align:justify;
            font-family:Arial;
            font-size:14px;
            color:#000000;
            margin:20px;
        }
        .novatumb{
            width:280px;
            height:200px;
            display:block;
            margin-left:auto;
            margin-right:auto;
            padding-top:20px;
        }
        .imgprincipal{
            width:400px;
            height:300px;
            display:block;
            margin-left:auto;
            margin-right:auto;
            padding-top:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="banner" role="banner">

                <header id="header">
                    <div class="header-content clearfix">
                        <a class="logo" href="index2.aspx">
                            <img src="images/logo.png" alt=""></a>
                        <nav class="navigation" role="navigation">
                            <ul class="primary-nav">
                                <li><a href="index2.aspx">Imoveis</a></li>
                                <li><a href="index2.aspx">Contato</a></li>
                                <li><a href="cadastroImoveis.aspx">Enviar Imovel</a></li>
                            </ul>
                        </nav>
                        <a href="#" class="nav-toggle">Menu<span></span></a>
                    </div>
                    <!-- header content -->
                </header>
                <!-- header -->
            </section>
        </div>
        <div class="row">
        <div class="container titulo">
            <asp:Literal ID="lblnome" runat="server"></asp:Literal>
        </div>
    </div>
    
    <div class="row" style="margin-top:30px;">
        <div class="container">
            <div class="col-md-6">
               <asp:Image ID="imgImovel" runat="server" 
                   CssClass="imgprincipal img-responsive"/>
                


                <div id="divGaleria">
                    <div id="responsive">
                        <!-- Bottom switcher of slider -->
                       
                            <asp:ListView ID="lvGaleria" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-3 item">
                                        <img src="imoveis/<%#Eval("imagem1") %>" class="novatumb img-responsive"/>
                                    </div>
                                    <div class="col-sm-3 item">
                                        <img src="imoveis/<%#Eval("imagem2") %>" class="novatumb img-responsive"/>
                                    </div>
                                    <div class="col-sm-3 item">
                                        <img src="imoveis/<%#Eval("imagem3") %>" class="novatumb img-responsive"/>
                                    </div>
                                    <div class="col-sm-3 item">
                                        <img src="imoveis/<%#Eval("imagem4") %>" class="novatumb img-responsive"/>
                                    </div>
                                </ItemTemplate>

                            </asp:ListView>

                        
                    </div>
                    <!--/Slider-->
                </div>




            </div>
            <div class="col-md-6">
                <span class="titulo">
                    <asp:Literal ID="lblvalor" runat="server"></asp:Literal>
                <asp:HiddenField ID="txtcodigo" runat="server" />
                </span>
                <div class="descricao">
                    <asp:Literal ID="lbldescricao" runat="server"></asp:Literal>
                </div>
                <asp:Button ID="btninteresse" runat="server"
                     Text="Tenho Interesse"
                    CssClass="btn btn-primary" OnClick="btncomprar_Click" />
                <asp:Button ID="btnvoltar" runat="server"
                     Text="Voltar"
                    CssClass="btn btn-primary" OnClick="btnvoltar_Click" />
            </div>
        </div>
    </div>
        
    </form>
    <script src="js/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick.min.js"></script>

        <script>
        $('#responsive').slick({
            dots: true,
            infinite: false,
            speed: 300,
            slidesToShow: 1,
            slidesToScroll: 1,
        });
    </script>


</body>
</html>
