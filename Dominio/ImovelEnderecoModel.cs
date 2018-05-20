using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ImovelEnderecoModel
    {
        public string categoria { get; set; }
        public decimal valor { get; set; }

        public string logradouro { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }
    }
}
