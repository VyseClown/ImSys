using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{
    public class AgendaBusiness
    {
        public void AdicionarAgendamento(visita vis)
        {
            AgendaDominio agedom = new AgendaDominio();
            agedom.AdicionarAgendamento(vis);
        }
        public bool SalvarVisita(pessoa pes, corretor cor, endereco end, string categoria)
        {
            PessoaDominio PesDom = new PessoaDominio();
            EnderecoBusiness EndBus = new EnderecoBusiness();
            especializacao esp = new especializacao();
            bool cpfValido = true; // validarCPF(pes.cpf);
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
        public void SalvarInteresse(interesse inte)
        {
            AgendaDominio agedom = new AgendaDominio();
            agedom.AdicionarInteresse(inte);
        }
    }
}
