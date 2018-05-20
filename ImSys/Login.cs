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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            PessoaDominio pesdom = new PessoaDominio();
            permissoes per = pesdom.logarNoSistema(txtLogin.Text, txtSenha.Text);
            CadastroPessoa frmCad = new CadastroPessoa(per);
            if ((per) != null)
            {
                frmCad.ShowDialog();
                this.Hide();
            }
            else
                MessageBox.Show("Informe login e senha adequados !");

        }
    }
}
