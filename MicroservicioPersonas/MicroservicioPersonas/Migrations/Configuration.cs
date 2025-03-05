namespace MicroservicioPersonas.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Microservicio_Personas.Infrastructure.Repository.PersonaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Microservicio_Personas.Infrastructure.Repository.PersonaContext";
        }

        protected override void Seed(Microservicio_Personas.Infrastructure.Repository.PersonaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
