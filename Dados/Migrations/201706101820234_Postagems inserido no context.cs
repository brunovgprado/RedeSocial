namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Postagemsinseridonocontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Postagems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        DataPostagem = c.DateTime(nullable: false),
                        FotoPostagem = c.String(),
                        TextoPostagem = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Postagems");
        }
    }
}
