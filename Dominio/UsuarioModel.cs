using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string gerenciarusuario { get; set; }
        public string publicarimovel { get; set; }
        public string gerenciarvisita { get; set; }
        public string gerenciarvendaaluguel { get; set; }
        public string gerenciarpermissoes { get; set; }
        public string gerenciarpagamentoaluguel { get; set; }
        public string senha { get; set; }
    }
}
