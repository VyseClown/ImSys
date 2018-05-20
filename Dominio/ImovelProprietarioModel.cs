using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ImovelProprietarioModel
    {
        public string categoria { get; set; }
        public decimal valor { get; set; }
        public decimal valorvenda { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string areacon { get; set; }
        public string areater { get; set; }
        public int qtdquartos { get; set; }
        public int numero { get; set; }
        public string CEP { get; set; }
        public string nomeproprietario { get; set; }
        public string nomecliente { get; set; }
        public int idimovel { get; set; }
        public int idcliente { get; set; }
        public string CPFCliente { get; set; }
        public string CPFProprietario { get; set; }
        public string TelefoneCliente { get; set; }
        public int idcatimovel { get; set; }
        public string finalidade { get; set; }
        public string publicacao { get; set; }
    }
}
