//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReporteCOVID19Back
{
    using System;
    using System.Collections.Generic;
    
    public partial class Permiso
    {
        public long ID { get; set; }
        public string IDSIU { get; set; }
        public long Rol { get; set; }
        public string Escuela { get; set; }
        public string Campus { get; set; }
        public string Usuario { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<System.DateTime> FechaCrea { get; set; }
    }
}