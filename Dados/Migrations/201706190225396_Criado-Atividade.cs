namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriadoAtividade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Atividades");
        }
    }
}
