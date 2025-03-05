using Microservicio_Personas.Domain.Entities;
using MicroservicioRecetas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MicroservicioRecetas.Repository
{
	public class RecetaContext : DbContext
	{
        public RecetaContext() : base("name=RecetasContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Receta> Recetas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Receta>().
                ToTable("Receta");
            base.OnModelCreating(modelBuilder);
        }
    }
}