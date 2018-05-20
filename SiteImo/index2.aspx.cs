using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SiteImo
{
    public partial class index2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //ddlCategoria.DataSource = (new ImovelBusiness().listarCategorias(""));
                //ddlCategoria.DataValueField = "id";
                //ddlCategoria.DataBind();
                //ddlCategoria.Items.Insert(0, new ListItem("Selecione uma categoria", "0"));

                //ddlValor.DataSource = (new ImovelBusiness().listarImoveisValor(""));
                //ddlValor.DataValueField = "valor";
                //ddlValor.DataTextField = "valor";
                //ddlValor.DataBind();
                //ddlValor.Items.Insert(0, new ListItem("- Selecione um valor -", "0"));


                lvItens.DataSource = (new ImovelBusiness().listarImoveisValor(0));
                lvItens.DataBind();
            }
        }

        

        protected void ddlValor_SelectedIndexChanged(object sender, EventArgs e)
        {
           // DataPager1_PreRender(sender, e);
        }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           // DataPager1_PreRender(sender, e);
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            if (int.Parse(ddlCategoria.SelectedValue) == 0 && int.Parse(ddlValor.SelectedValue) == 0 || int.Parse(ddlValor.SelectedValue) == 12 || int.Parse(ddlValor.SelectedValue) == 6)
            {
                lvItens.DataSource = (new ImovelBusiness().listarImoveisValor(0));
                lvItens.DataBind();
            }
            else if (int.Parse(ddlValor.SelectedValue) != 0 && int.Parse(ddlValor.SelectedValue) != 12 && int.Parse(ddlValor.SelectedValue) != 6 && int.Parse(ddlCategoria.SelectedValue) == 0)
            { 
                int valor = int.Parse(ddlValor.SelectedValue);
                lvItens.DataSource = (new ImovelBusiness().listarImoveisValor(valor));
                lvItens.DataBind();
                if (new ImovelBusiness().listarImoveisValor(valor).Count == 0)
                {
                    lblAvisos.Text = "Nenhum imovel cadastrado nos filtros selecionados !";
                }
                else
                    lblAvisos.Text = "";
            }
            else if (int.Parse(ddlCategoria.SelectedValue) != 0 && int.Parse(ddlValor.SelectedValue) == 0 || int.Parse(ddlValor.SelectedValue) == 12 || int.Parse(ddlValor.SelectedValue) == 6)
            {
                lvItens.DataSource = (new ImovelBusiness().listarImoveisporCategoriasemValor(int.Parse(ddlCategoria.SelectedValue)));
                lvItens.DataBind();
                if (new ImovelBusiness().listarImoveisporCategoriasemValor(int.Parse(ddlCategoria.SelectedValue)).Count == 0)
                {
                    lblAvisos.Text = "Nenhum imovel cadastrado nos filtros selecionados !";
                }
                else
                    lblAvisos.Text = "";
            }
            else
            {
                lvItens.DataSource = new ImovelBusiness().listarPorValoreCategoria(int.Parse(ddlValor.SelectedValue), int.Parse(ddlCategoria.SelectedValue));
                lvItens.DataBind();
                if (new ImovelBusiness().listarPorValoreCategoria(int.Parse(ddlValor.SelectedValue), int.Parse(ddlCategoria.SelectedValue)).Count == 0)
                {
                    lblAvisos.Text = "Nenhum imovel cadastrado nos filtros selecionados !";
                }
                else
                    lblAvisos.Text = "";
            }
            

        }
    }
}