namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadasPropriedadesDeHorta2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hortas", "UserId", c => c.String());
            AddColumn("dbo.Hortas", "data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hortas", "data");
            DropColumn("dbo.Hortas", "UserId");
        }
    }
}
