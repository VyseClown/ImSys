//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dominio
{
    using System;
    using System.Collections.Generic;
    
    public partial class imovel
    {
        public imovel()
        {
            this.visita = new HashSet<visita>();
            this.imagem = new HashSet<imagem>();
            this.interesse = new HashSet<interesse>();
        }
    
        public int id { get; set; }
        public Nullable<int> idendereco { get; set; }
        public Nullable<int> idcategoria { get; set; }
        public string finalidade { get; set; }
        public string areacon { get; set; }
        public string areater { get; set; }
        public Nullable<int> qtdquartos { get; set; }
        public Nullable<decimal> valor { get; set; }
        public Nullable<decimal> valorvendalocacao { get; set; }
        public Nullable<int> idcliente { get; set; }
        public Nullable<int> idimagens { get; set; }
        public string publicacaostatus { get; set; }
        public Nullable<int> idproprietario { get; set; }
        public string imagem1 { get; set; }
        public string imagem2 { get; set; }
        public string imagem3 { get; set; }
        public string imagem4 { get; set; }
    
        public virtual ICollection<visita> visita { get; set; }
        public virtual categoria categoria { get; set; }
        public virtual endereco endereco { get; set; }
        public virtual ICollection<imagem> imagem { get; set; }
        public virtual cliente cliente { get; set; }
        public virtual cliente cliente1 { get; set; }
        public virtual ICollection<interesse> interesse { get; set; }
    }
}
