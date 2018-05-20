using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class InteresseModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public DateTime data { get; set; }
        public string status { get; set; }
        public int idimovel { get; set; }
        public string cpf { get; set; }

    }
}
