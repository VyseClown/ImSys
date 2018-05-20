using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Dominio;

namespace SiteImo
{
    public partial class detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Request.QueryString["id"] != "")
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        imovel imo = new ImovelBusiness().SelecionarImovel(id);
                        if (imo != null)
                        {
                            lbldescricao.Text = "Total de Área Construida: " + imo.areacon
                                + "<br/><br/> Quantidade de Comodos: " + imo.qtdquartos
                                + "<br/><br/> Metragem do Terreno:" + imo.areater
                                + "<br/><br/> Valor:" + imo.valorvendalocacao;
                            lblnome.Text = imo.finalidade;
                            imgImovel.ImageUrl = "~/imoveis/" + imo.imagem1;
                            lblvalor.Text = "Valor: R$ " + imo.valorvendalocacao;
                            txtcodigo.Value = imo.id.ToString();
                            carregaGaleria();
                        }
                    }
                    else
                        {
                        Response.Redirect("index2.aspx");
                        }
                }
            }
            catch (Exception)
            {

                lbldescricao.Text = "Erro ao carregar os dados!";
            }
        }
        protected void btncomprar_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Value != "")
                Response.Redirect("cadastro.aspx?cod=" + txtcodigo.Value);
        }

        protected void btnvoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index2.aspx");
        }

        protected void carregaGaleria()
        {
            List<string> lista = new List<string>();
            imovel imo = new imovel();
            imo = (new ImovelDominio()).SelecionarImovel(int.Parse(Request.QueryString["id"]));
            List < imovel > listaimo = (new ImovelDominio()).listarUmImovelParaEnganar(int.Parse(Request.QueryString["id"]));
            //for (int i = 1; i < 5; i++)
            //{
            //lista.Add(imo.imagem1.ToString() + i.ToString());
            // lista.Add("imagem" + i.ToString());

            //}
            lvGaleria.DataSource = listaimo;
            lvGaleria.DataBind();
        }
    }
}