using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VisitaModel
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public int idcorretor { get; set; }
        public int idimovel { get; set; }
        public DateTime data { get; set; }
        public string resultado { get; set; }
        public string status { get; set; }
        public string hora { get; set; }
        public decimal corretorcomissao { get; set; }
    }
}
