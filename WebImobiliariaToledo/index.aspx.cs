using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class preview_dotnet_templates_with_out_masterpages_one_page_Scroll_nav_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCategoria.DataSource = (new ImovelBusiness().listarCategorias(""));
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Selecione uma cateogira", "0"));

            ddlValor.DataSource = (new ImovelBusiness().listarImoveisValor(0));
            ddlValor.DataValueField = "valor";
            ddlValor.DataTextField = "Preço";
            ddlValor.DataBind();
            ddlValor.Items.Insert(0, new ListItem("- Selecione um valor -", "0"));

            
            imoveisItens.DataSource = (new ImovelBusiness().listarImoveis(0));
            imoveisItens.DataBind();
        }

        
    }
    protected void ddlValor_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataPager1_PreRender(sender, e);
    }
    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataPager1_PreRender(sender, e);
    }

    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        int valor = int.Parse(ddlValor.SelectedValue);
        imoveisItens.DataSource = (new ImovelBusiness().listarImoveisValor(valor));
        imoveisItens.DataBind();

        string categoria = ddlCategoria.SelectedValue;
        imoveisItens.DataSource = (new ImovelBusiness().listarCategorias(categoria));
        imoveisItens.DataBind();
    }
}