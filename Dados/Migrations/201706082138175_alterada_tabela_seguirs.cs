namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterada_tabela_seguirs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seguirs", "SeguidorId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seguirs", "SeguidorId", c => c.Int(nullable: false));
        }
    }
}
