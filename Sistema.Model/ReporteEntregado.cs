//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema.Model
{
    using System.Runtime.Serialization;using System;
    using System.Collections.Generic;
    [DataContract] public partial class ReporteEntregado
    {
        [DataMember] public int IdEntrega { get; set; }
        [DataMember] public int IdUsuario { get; set; }
        [DataMember] public System.DateTime Fecha { get; set; }
        [DataMember] public int IdArticulo { get; set; }
        [DataMember] public Nullable<int> Celular { get; set; }
        [DataMember] public string Email { get; set; }
    
        public virtual Articulo Articulo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
