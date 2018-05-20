using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;
using System.IO;

namespace SiteImo
{
    public partial class cadastroImoveis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selEstado.DataSource = (new EnderecoDominio().listarTodosEstados());
                selEstado.DataValueField = "Id";
                selEstado.DataTextField = "Name";
                selEstado.DataBind();

                selCategoria.DataSource = (new ImovelDominio().listarTodasCategorias());
                selCategoria.DataValueField = "id";
                selCategoria.DataTextField = "nome";
                selCategoria.DataBind();

                
               // string caminhoimo = Server.MapPath("~" + @"\imoveis\");
            }
        }
        protected void selEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (selEstado.SelectedIndex != -1)
            {
                EnderecoDominio enddom = new EnderecoDominio();
                int idEstado = int.Parse(selEstado.SelectedValue.ToString());
                selCidade.DataSource = (new EnderecoDominio().listarTodasCidades(idEstado));
                selCidade.DataValueField = "Id";
                selCidade.DataTextField = "Name";
                selCidade.DataBind();

            }
        }
        protected void btnInteresse_Click(object sender, EventArgs e)
        {//tenho que validar o CPF do caboclo, não deixar ele se cadastrar caso não exista na base, e usar o CPF para pesquisar ele na hora de colocar o imóvel no nome dele
            if (txtBairro.Text != null && txtAreaTotalConstruida.Text != null && txtAreaTotal.Text != null &&
            txtCEP.Text != null && txtNumero.Text != null &&
            txtQuartos.Text != null && txtRua.Text != null)
            {
                pessoa pes = new pessoa();
                PessoaDominio pesdom = new PessoaDominio();
                ImovelDominio imodom = new ImovelDominio();
                EnderecoDominio enddom = new EnderecoDominio();
                string caminho = " ";
                pes = pesdom.selecionarPessoacomCPF(txtCPFCliente.Text);
                if (pes != null)
                {
                    imovel imo = new imovel();
                    endereco end = new endereco();
                    end.bairro = txtBairro.Text;
                    end.cep = txtCEP.Text;
                    end.logradouro = txtRua.Text;
                    end.numero = int.Parse(txtNumero.Text);
                    end.cidade = int.Parse(selCidade.SelectedValue);
                    //tenho que adicionar o endereco antes
                    enddom.AdicionarEndereco(end);
                    //apos isso o imovel(e cliente, que já tenho o objeto carregado graças ao pes)
                    imo.areacon = txtAreaTotalConstruida.Text;
                    imo.areater = txtAreaTotal.Text;
                    imo.idcategoria = int.Parse(selCategoria.SelectedValue);
                    imo.idproprietario = pesdom.selecionarCliente(pes).id;
                    imo.publicacaostatus = "Não publicar";
                    imo.qtdquartos = int.Parse(txtQuartos.Text);
                    imo.finalidade = selFinalidade.SelectedValue;
                    imo.idendereco = enddom.selecionarUltimoEnderecoID(end);
                    imodom.adicionarImovel(imo);

                    if (fileFotos.HasFiles)
                    {
                        int i = 1;
                        foreach(HttpPostedFile fotos in fileFotos.PostedFiles)
                        {
                            if(i == 1)
                            {
                                
                                FileInfo info = new FileInfo(fotos.FileName);
                                caminho = Server.MapPath("~" + @"\imoveis\" + info.Name);
                                imo.imagem1 = info.Name;
                                


                                fotos.SaveAs(caminho);
                            }
                            if(i == 2)
                            {
                                FileInfo info = new FileInfo(fotos.FileName);
                                caminho = Server.MapPath("~" + @"\imoveis\" + info.Name);
                                if (info.Name != null)
                                {
                                    imo.imagem2 = info.Name;
                                    //File.Copy(info.Name, caminho);
                                    fotos.SaveAs(caminho);
                                }
                            }
                            if (i == 3)
                            {
                                FileInfo info = new FileInfo(fotos.FileName);
                                caminho = Server.MapPath("~" + @"\imoveis\" + info.Name);
                                if (info.Name != null)
                                {
                                    imo.imagem3 = info.Name;
                                    fotos.SaveAs(caminho);
                                }
                                
                            }
                            if (i == 4)
                            {
                                FileInfo info = new FileInfo(fotos.FileName);
                                caminho = Server.MapPath("~" + @"\imoveis\" + info.Name);
                                if (info.Name != null)
                                {
                                    imo.imagem4 = info.Name;
                                    fotos.SaveAs(caminho);
                                }
                                
                            }
                            i++;
                        }
                        imodom.adicionarImagemAoImovel(imo);
                    }
                    txtBairro.Text = "";
                    txtAreaTotalConstruida.Text = "";
                    txtAreaTotal.Text = "";
                    txtCEP.Text = "";
                    txtNumero.Text = "";
                    txtQuartos.Text = "";
                    txtRua.Text = "";
                    aviso.Text = "Imovel enviado !";
                }
                aviso.Text = "Entre em contato conosco para se cadastrar como cliente ou escreva um CPF valido !";
            }
            aviso.Text = "Preencha todos os campos !";
        }
    }
}