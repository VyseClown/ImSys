using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{
    public class PessoaBusiness
    {
        public bool SalvarPessoa(pessoa pes, usuario usu, endereco end)
        {
            PessoaDominio PesDom = new PessoaDominio();
            EnderecoBusiness EndBus = new EnderecoBusiness();
            permissoes per = new permissoes();
            bool cpfValido = validarCPF(pes.cpf);
            if (cpfValido == true)
            {
                PesDom.AdicionarPessoa(pes);
                usu.idpessoa = PesDom.selecionarUltimaPessoaIDcomCPF(pes);
                PesDom.AdicionarUsuario(usu);
                int id = EndBus.AdicionarEnderecoERetornarID(end);
                pes.idendereco = id;
                PesDom.AdicionarEnderecoIDUsuario(pes);
                per.idusuario = usu.id;
                PesDom.adicionarRegistroPermissaoParaNovoUsuario(per);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public pessoa retornarPessoaPorCPF(string cpf)
        {
            PessoaDominio PesDom = new PessoaDominio();
            return PesDom.selecionarPessoacomCPF(cpf);

        }

        public bool SalvarPessoa(pessoa pes, corretor cor, endereco end, string categoria)
        {
            PessoaDominio PesDom = new PessoaDominio();
            EnderecoBusiness EndBus = new EnderecoBusiness();
            especializacao esp = new especializacao();
            bool cpfValido = validarCPF(pes.cpf);
            if (cpfValido == true)
            {
                
                PesDom.AdicionarPessoa(pes);
                cor.idpessoa = PesDom.selecionarUltimaPessoaIDcomCPF(pes);
                PesDom.AdicionarCorretor(cor);
                //pegar id do corretor após adicionar
                esp.idcategoria = PesDom.PegarIDCategoria(categoria);
                esp.idcorretor = PesDom.SelecionarUltimoCorretor(Convert.ToInt32(cor.idpessoa));
                PesDom.AdicionarEspecializacao(esp);
                int id = EndBus.AdicionarEnderecoERetornarID(end);
                pes.idendereco = id;
                PesDom.AdicionarEnderecoIDUsuario(pes);
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SalvarNovaEspecializacao(string cpf, string categoria)
        {
            PessoaDominio pesdom = new PessoaDominio();
            pessoa pes = pesdom.selecionarPessoacomCPF(cpf);
            corretor cor = pesdom.selecionarCorretorcomCPF(cpf);
            especializacao esp = new especializacao();
            
            esp.idcategoria = pesdom.PegarIDCategoria(categoria);
            esp.idcorretor = cor.id;

            if (pesdom.verificarSeJaExisteEspecializacao(esp.idcategoria.Value, esp.idcorretor.Value) == true)
            {
                pesdom.AdicionarEspecializacao(esp);
                return true;
            }
            else return false;
            

        }
        public bool SalvarPessoa(pessoa pes, cliente cli, endereco end)
        {
            PessoaDominio PesDom = new PessoaDominio();
            EnderecoBusiness EndBus = new EnderecoBusiness();
            EnderecoDominio enddom = new EnderecoDominio();
            bool cpfValido = validarCPF(pes.cpf);
            if (cpfValido == true)
            {
                if(PesDom.selecionarPessoacomCPF(pes.cpf) == null)//agora deve funcionar
                {
                    PesDom.AdicionarPessoa(pes);
                    cli.idpessoa = PesDom.selecionarUltimaPessoaIDcomCPF(pes);
                    PesDom.AdicionarCliente(cli);
                    int id = EndBus.AdicionarEnderecoERetornarID(end);
                    pes.idendereco = id;
                    PesDom.AdicionarEnderecoIDUsuario(pes);
                    return true;
                }
                else if(enddom.verificarSeEnderecoExiste((PesDom.selecionarPessoacomCPF(pes.cpf).id)) == null)//isso é para quando vai adicionar um endereço ao cliente já criado, vindo do formulário de interesse !
                {
                    pes.id = PesDom.selecionarPessoacomCPF(pes.cpf).id;
                    
                    int id = EndBus.AdicionarEnderecoERetornarID(end);
                    pes.idendereco = id;
                    PesDom.AdicionarEnderecoIDUsuario(pes);
                    return true;
                }
                else//agora é as modificações comuns !
                {
                    pessoa pesMod = PesDom.selecionarPessoacomCPF(pes.cpf);
                    pesMod.telefone = pes.telefone;
                    pesMod.celular = pes.celular;
                    pesMod.email = pes.email;


                    endereco enderecoMod = enddom.selecionarEnderecoComIDPessoa(pesMod.id);
                    enderecoMod.bairro = end.bairro;
                    enderecoMod.cep = end.cep;
                    enderecoMod.cidade = end.cidade;
                    enderecoMod.logradouro = end.logradouro;
                    enderecoMod.numero = end.numero;
                    
                    
                    PesDom.modificarPessoa(pesMod);
                    PesDom.modificarEndereco(enderecoMod);

                    return true;
                }
                
            }
            else
            {
                return false;
            }

        }

        public List<PessoaCorretorModel> listarCorretoresPorCategoria(string categoria)
        {
            List<PessoaCorretorModel> lista = new List<PessoaCorretorModel>();
            //bora fazer isso funcionar e tem que dar uma olhada se ele tem não compromisso para aquele horario
            PessoaDominio pesdom = new PessoaDominio();
            ImovelBusiness imobus = new ImovelBusiness();
            int idcat = imobus.pegarIDCategoria(categoria);

            lista = pesdom.listarCorretoresPorCategoria(idcat);
            return lista;
        }

        public CorretorModel selecionarCorretor(int id)
        {
            PessoaDominio pesdom = new PessoaDominio();
            return pesdom.selecionarCorretor(id);
        }

        public corretor selecionarCorretor(pessoa pes)
        {
            PessoaDominio pesdom = new PessoaDominio();
            return pesdom.selecionarCorretor(pes);
        }
        public cliente selecionarCliente(pessoa pes)
        {
            PessoaDominio pesdom = new PessoaDominio();
            return pesdom.selecionarCliente(pes);
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
