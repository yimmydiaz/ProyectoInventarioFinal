﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDeDatos.ModeloDeDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InventarioBDEntities : DbContext
    {
        public InventarioBDEntities()
            : base("name=InventarioBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_asociar> tb_asociar { get; set; }
        public virtual DbSet<tb_categoria> tb_categoria { get; set; }
        public virtual DbSet<tb_edificio> tb_edificio { get; set; }
        public virtual DbSet<tb_espacio> tb_espacio { get; set; }
        public virtual DbSet<tb_fotos> tb_fotos { get; set; }
        public virtual DbSet<tb_marca> tb_marca { get; set; }
        public virtual DbSet<tb_persona> tb_persona { get; set; }
        public virtual DbSet<tb_piso> tb_piso { get; set; }
        public virtual DbSet<tb_producto> tb_producto { get; set; }
        public virtual DbSet<tb_sede> tb_sede { get; set; }
        public virtual DbSet<tb_tipo_producto> tb_tipo_producto { get; set; }
    }
}