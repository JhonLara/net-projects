using MicroservicioCitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MicroservicioCitas.Infrastructure.Repository
{
	public class CitaContext : DbContext
	{
        public CitaContext() : base("name=CitasContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>().
                ToTable("Cita");
            base.OnModelCreating(modelBuilder);
        }
    }
}