using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ImovelModel
    {
        public int id { get; set; }
        public string finalidade { get; set; }
        public string clienteNome { get; set; }
        public DateTime dataultimopagamento { get; set; }
        public int idLocacao { get; set; }
    }
}
