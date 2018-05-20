using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{
    public class EnderecoBusiness
    {
        public int AdicionarEnderecoERetornarID(endereco end)
        {
            EnderecoDominio enddom = new EnderecoDominio();
            enddom.AdicionarEndereco(end);
            int id = enddom.selecionarUltimoEnderecoID(end);

            return id;
        }
        public List<State> listarEstados(string estado)
        {
            List<State> lista = new List<State>();
            EnderecoDominio enddom = new EnderecoDominio();
            lista = enddom.listarTodosEstados(estado);
            return lista;
        }
        public List<City> listarCidades(string estado)
        {
            List<City> lista = new List<City>();
            
            EnderecoDominio enddom = new EnderecoDominio();
            int id = enddom.pegarIDEstado(estado);
            lista = enddom.listarTodasCidades(id);
            return lista;
        }

        public endereco retornarEnderecoPorID(int id)
        {
            endereco end = new endereco();
            EnderecoDominio enddom = new EnderecoDominio();

            end = enddom.selecionarEnderecoPorID(id);

            return end;

        }

        public int buscarIDCidade(string cidade)
        {
            int id = 0;
            EnderecoDominio enddom = new EnderecoDominio();
            return id = enddom.pegarIDCidade(cidade);
        }
        public int buscarIDEstado(string estado)
        {
            int id = 0;
            EnderecoDominio enddom = new EnderecoDominio();
            return id = enddom.pegarIDEstado(estado);
        }
        public City buscarCidade(int id)
        {
            EnderecoDominio enddom = new EnderecoDominio();
            return enddom.selecionarCidade(id);
            
        }
        public State buscarEstado(int id)
        {

            EnderecoDominio enddom = new EnderecoDominio();
            return enddom.selecionarEstadoComIDdaCidade(id);
        }
    }
}
