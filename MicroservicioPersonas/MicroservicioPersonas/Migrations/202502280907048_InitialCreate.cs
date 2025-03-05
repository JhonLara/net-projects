namespace MicroservicioPersonas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificacion = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        IdTipoPersona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoPersona", t => t.IdTipoPersona_Id)
                .Index(t => t.IdTipoPersona_Id);
            
            CreateTable(
                "dbo.TipoPersona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persona", "IdTipoPersona_Id", "dbo.TipoPersona");
            DropIndex("dbo.Persona", new[] { "IdTipoPersona_Id" });
            DropTable("dbo.TipoPersona");
            DropTable("dbo.Persona");
        }
    }
}
