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
    
    public partial class pagamentos
    {
        public int id { get; set; }
        public Nullable<int> idlocacoes { get; set; }
        public Nullable<System.DateTime> datap { get; set; }
        public Nullable<decimal> valor { get; set; }
    
        public virtual locacoes locacoes { get; set; }
    }
}
