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
    public partial class Corretores : Form
    {
        public Corretores()
        {
            InitializeComponent();
        }

        private void cbCategorias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ImovelBusiness cat = new ImovelBusiness();

            //cbCategorias.DataSource = cat.listarCategorias(cbCategorias.SelectedValue.ToString());
            //cbCategorias.ValueMember = "name";
            //cbCategorias.DisplayMember = "name";
            PessoaBusiness cor = new PessoaBusiness();
            List<PessoaCorretorModel> peslist = new List<PessoaCorretorModel>();
            //pessoa pes = cor.retornarPessoaPorCPF();
            peslist = cor.listarCorretoresPorCategoria(cbCategoria.SelectedValue.ToString());
            //como pegar o cpf quando o cara selecionar
            dgvCorretores.DataSource = peslist;

        }

        private void Corretores_Load(object sender, EventArgs e)
        {
            string nome = "";
            ImovelBusiness catbus = new ImovelBusiness();
            PessoaBusiness pesbus = new PessoaBusiness();

            cbCategoria.DataSource = catbus.listarCategorias(nome);
            cbCategoria.ValueMember = "nome";
            cbCategoria.DisplayMember = "nome";

            

        }

        private void dgvCorretores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvCorretores.CurrentRow.Cells[0].Value;
        }
    }
}
