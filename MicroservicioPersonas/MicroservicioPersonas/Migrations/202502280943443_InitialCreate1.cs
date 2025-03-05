namespace MicroservicioPersonas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Persona", name: "IdTipoPersona_Id", newName: "TipoPersona_Id");
            RenameIndex(table: "dbo.Persona", name: "IX_IdTipoPersona_Id", newName: "IX_TipoPersona_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Persona", name: "IX_TipoPersona_Id", newName: "IX_IdTipoPersona_Id");
            RenameColumn(table: "dbo.Persona", name: "TipoPersona_Id", newName: "IdTipoPersona_Id");
        }
    }
}
