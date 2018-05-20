using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Dominio;
using System.Web.Services;

namespace SiteImo
{
    public partial class cadastro : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cod"] == null)
            {
                Response.Redirect("index2.aspx");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index2.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtemail.Text != "" && txtnome.Text != "" && txttelefone.Text != "" && txtcpf.Text != "" && validarCPF(txtcpf.Text) == true)
            {

                interesse inte = new interesse();
                cliente cli = new cliente();
                pessoa pes = new pessoa();
                AgendaBusiness agebus = new AgendaBusiness();
                PessoaDominio pesdom = new PessoaDominio();
                

                if(pesdom.selecionarPessoacomCPF(txtcpf.Text) == null)
                {
                    pes.nome = txtnome.Text;
                    pes.cpf = txtcpf.Text;
                    pes.email = txtemail.Text;
                    pes.telefone = txttelefone.Text;
                    pesdom.AdicionarPessoa(pes);

                    cli.idpessoa = pesdom.selecionarUltimaPessoaIDcomCPF(pes);
                    pesdom.AdicionarCliente(cli);


                    inte.idcliente = cli.idpessoa;
                }
                else
                {
                    inte.idcliente = pesdom.selecionarPessoaIDcomCPF(txtcpf.Text);
                }
                
                inte.data = DateTime.Now;
                inte.idimovel = int.Parse(Request.QueryString["cod"]);//poderia fazer uma verificação para caso a pessoa
                //já tenha enviado um interesse para aquele imóvel
                inte.status = "Sem visita";
                //agora será criado um cliente no ato do cadastro de interesse
                //logo, um cliente terá vários interesses, não podendo coincidir os horários
                //a tabela interesse terá o codigo de cliente daquela tabela, será bom ter todos os clientes
                //em um dgv, fazendo com que assim possa ser visto os clientes com o cadastro ainda incompleto
                //ou fazer uma veirificação no ato do cadastro da visita se o cliente está com o cadastro
                //completo ou não, caso estiver, pedir para que seja preenchido todos os campos
                //(acredito que já tenha uma veirificação para isso, mas o botão de alterar a pessoa não deve estar funcionando)
                //criar uma barrinha de feedback enquanto a pessoa está cadastrando uma visita, cliente já selecionado(estando
                // com todos os campos da tabela pessoa preenchidos), corretor já selecionado e obviamente imovel já selecionado


                //criar um cliente com isso e depois usar a chave dele no interesse
                agebus.SalvarInteresse(inte);
                aviso.Text = "Cadastro Enviado com sucesso !";
                txtnome.Text = "";
                txtemail.Text = "";
                txttelefone.Text = "";
                txtcpf.Text = "";
            }
            else
                aviso.Text = "Preencha todos os campos e CPF valido !!";
                
            
        }
        public static bool validarCPF(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }
    }
}