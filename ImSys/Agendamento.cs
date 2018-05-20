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
    public partial class Agendamento : Form
    {
        public Agendamento()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            foreach (Control verifica in this.Controls)
            {
                if (verifica.GetType().Equals(typeof(TextBox)))
                {
                    if (verifica.Text == string.Empty)
                    {
                        MessageBox.Show("Preencha todos os campos !");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnBuscarCorretor_Click(object sender, EventArgs e)
        {
            Corretores frmCorretor = new Corretores();
         //   int codigocorretor = 0;
            frmCorretor.ShowDialog();
         //   codigocorretor = frmCorretor.codigocorretor;
        }


        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            pessoa pes = new pessoa();
            PessoaBusiness pesbus = new PessoaBusiness();
            pes = pesbus.retornarPessoaPorCPF(txtCPFCliente.Text);
            if (pes != null)
            {
                txtNomeCliente.Text = pes.nome;
                txtTelefoneCliente.Text = pes.telefone;

            }
            else
                MessageBox.Show("Cadastre o cliente antes de pesquisar o CPF dele !!");
        }

        private void btnBuscarImovel_Click(object sender, EventArgs e)
        {
            frmSelecionarImovel frmImovel = new frmSelecionarImovel();
            frmImovel.Show();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            bool valida = Validar();
            if (valida)
            {

            }
            else
                MessageBox.Show("Preencha todos os campos !");
        }
    }
}
