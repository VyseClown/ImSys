<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroImoveis.aspx.cs" Inherits="SiteImo.cadastroImoveis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <meta charset="utf-8">
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

            <h6 style="text-align: center">Preencha o formulário abaixo para cadastrar seu imovel em nosso site!</h6>
            <asp:Label ID="aviso" runat="server"></asp:Label>
            <!-- CONTAINER DE CADASTRO DE IMOVEL -->
            <div class="container-fluid" style="border: 2px solid #D3D3D3; margin-right: 2%;">
                <br />
                <div class="col-md-3 form-group">
                    <asp:TextBox class="form-control" ID="txtCPFCliente" placeholder="Escreva seu CPF, caso já for cliente" runat="server" />
                </div>
                <div class="col-md-2 form-group">
                    <asp:TextBox class="form-control" ID="txtCEP" placeholder="CEP" onkeypress="mascara(this, '#####-###')" AutoPostBack="true" MaxLength="9" runat="server"/>
                </div>
                <div class="col-md-4 form-group">
                    <asp:DropDownList CssClass="form-control" ID="selEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selEstado_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-md-6 form-group">
                    <asp:DropDownList CssClass="form-control" ID="selCidade" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-6 form-group">
                    <asp:TextBox class="form-control" ID="txtRua" placeholder="Rua" runat="server" />
                </div>
                <div class="col-md-4 form-group">
                    <asp:TextBox class="form-control" ID="txtBairro" placeholder="Bairro" runat="server" />
                </div>
                <div class="col-md-2 form-group">
                    <asp:TextBox class="form-control" ID="txtNumero" placeholder="Numero" runat="server" />
                </div>
                <div class="col-md-3 form-group">
                    <asp:TextBox class="form-control" ID="txtAreaTotal" placeholder="Area Total" runat="server" />
                </div>
                <div class="col-md-3 form-group">
                    <asp:TextBox class="form-control" ID="txtAreaTotalConstruida" placeholder="Area Construida" runat="server" />
                </div>
                <div class="col-md-3 form-group">
                    <asp:TextBox class="form-control" ID="txtQuartos" placeholder="Quartos" runat="server" />
                </div>
                <div class="col-md-3 form-group">
                <div class="col-md-4 form-group">
                    <asp:DropDownList CssClass="form-control" ID="selFinalidade" runat="server">
                        <asp:ListItem Value="Venda">Venda</asp:ListItem>
                        <asp:ListItem Value="Aluguel">Aluguel</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="col-md-5 form-group">
                    <asp:DropDownList CssClass="form-control" ID="selCategoria" runat="server"></asp:DropDownList>
                </div>

                <div class="col-md-8 form-group">
                    <asp:FileUpload ID="fileFotos" runat="server" AllowMultiple="true" placeholder="Selecione 4 fotos" />
                </div>

                <div class="col-md-4">
                    <asp:Button Text="Enviar!" class="btn btn-success" ID="btnInteresse" runat="server" CausesValidation="False" UseSubmitBehavior="False" ValidateRequestMode="Disabled"
                        AutoPostBack="false" OnClick="btnInteresse_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
