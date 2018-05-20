using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Dominio;

namespace ImSys
{
    public partial class frmSelecionarImovel : Form
    {
        public frmSelecionarImovel()
        {
            InitializeComponent();
        }

        private void frmSelecionarImovel_Load(object sender, EventArgs e)
        {
            string nome = "";
            ImovelBusiness catbus = new ImovelBusiness();
            PessoaBusiness pesbus = new PessoaBusiness();

            cbCategoria.DataSource = catbus.listarCategorias(nome);
            cbCategoria.ValueMember = "nome";
            cbCategoria.DisplayMember = "nome";

            cbValor.Items.Add("Valores para venda");
            cbValor.Items.Add("");//fazer os filtros de preço para venda e locação agora
        }

        private void cbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {

            ImovelBusiness imovelbus = new ImovelBusiness();
            List<ImovelEnderecoModel> imovellist = new List<ImovelEnderecoModel>();

            //pessoa pes = cor.retornarPessoaPorCPF();
            int cat = imovelbus.pegarIDCategoria(cbCategoria.SelectedValue.ToString());
            imovellist = imovelbus.listarimovelPorCategoriaeValor(cat);
            //como pegar o cpf quando o cara selecionar
            dgvImovels.DataSource = imovellist;
        }//já esta buscando por categoria ! ai carai !

        
        private void cbValor_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
