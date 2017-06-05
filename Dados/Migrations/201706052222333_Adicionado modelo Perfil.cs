namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadomodeloPerfil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hortas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PerfilID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Plantas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        HortaId = c.Int(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Hortas", t => t.HortaId, cascadeDelete: true)
                .Index(t => t.HortaId);
            
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        NomeExibicao = c.String(),
                        FotoPerfil = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plantas", "HortaId", "dbo.Hortas");
            DropIndex("dbo.Plantas", new[] { "HortaId" });
            DropTable("dbo.Perfils");
            DropTable("dbo.Plantas");
            DropTable("dbo.Hortas");
        }
    }
}
