using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class AgendaModel
    {
        public string NomeCorretor { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public DateTime data { get; set; }
        public string status { get; set; }
        public string hora { get; set; }
    }
}
