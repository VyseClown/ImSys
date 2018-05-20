<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="SiteImo.cadastro" %>

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
        <div class="container container-fluid">
            <h1>Cadastro de Interesse</h1>
            <asp:Label ID="aviso" runat="server"></asp:Label>
            <div class="form-group">
                Nome:
        <asp:TextBox ID="txtnome" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                Email:
        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                Telefone:
        <asp:TextBox ID="txttelefone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                CPF:
        <asp:TextBox ID="txtcpf" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="Button1" CssClass="btn btn-default btn-block" runat="server" Text="Salvar" OnClick="Button1_Click" />
                <asp:Button ID="Button2" CssClass="btn btn-default btn-block" runat="server" OnClick="Button2_Click" Text="Cancelar" />

            </div>
        </div>
    </form>
<%--    <script>
        function validaCPF(cpf) {
            var numeros, digitos, soma, i, resultado, digitos_iguais;
            digitos_iguais = 1;
            if (cpf.length < 11)
                return false;
            for (i = 0; i < cpf.length - 1; i++)
                if (cpf.charAt(i) != cpf.charAt(i + 1)) {
                    digitos_iguais = 0;
                    break;
                }
            if (!digitos_iguais) {
                numeros = cpf.substring(0, 9);
                digitos = cpf.substring(9);
                soma = 0;
                for (i = 10; i > 1; i--)
                    soma += numeros.charAt(10 - i) * i;
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(0))
                    return false;
                numeros = cpf.substring(0, 10);
                soma = 0;
                for (i = 11; i > 1; i--)
                    soma += numeros.charAt(11 - i) * i;
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(1))
                    return false;
                return true;
            }
            else
                return false;
        }

        function isDigit(c) {
            return ((c >= "0") && (c <= "9"))
        }
    </script>--%>

</body>
</html>
