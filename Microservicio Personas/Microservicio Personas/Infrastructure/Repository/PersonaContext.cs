using Microservicio_Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Microservicio_Personas.Infrastructure.Repository
{
	public class PersonaContext : DbContext
	{
		public PersonaContext() : base("name=PersonasContext")
        {
			this.Configuration.LazyLoadingEnabled = false;	
		}
		public DbSet<Persona> Personas { get; set; }

        public DbSet<TipoPersona> TipoPersonas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().
                ToTable("Persona");
            modelBuilder.Entity<TipoPersona>().
                ToTable("TipoPersona");
            base.OnModelCreating(modelBuilder);
        }


    }
}