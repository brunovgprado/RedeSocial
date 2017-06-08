namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corrigida_tabela_seguir : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seguirs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SeguidorId = c.Int(nullable: false),
                        PerfilID = c.Int(nullable: false),
                        HortaID = c.Int(nullable: false),
                        PlantaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seguirs");
        }
    }
}
