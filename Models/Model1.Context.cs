﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Avto.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Avto_DBEntities : DbContext
    {
        public Avto_DBEntities()
            : base("name=Avto_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Arrival> Arrival { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Dispatch> Dispatch { get; set; }
        public virtual DbSet<dogovor> dogovor { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Refund> Refund { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
