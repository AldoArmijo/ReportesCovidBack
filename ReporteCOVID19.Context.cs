﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReportesCovid19 : DbContext
    {
        public ReportesCovid19()
            : base("name=ReportesCovid19")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cat_Roles> Cat_Roles { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<QCat_Programas> QCat_Programas { get; set; }
    }
}
