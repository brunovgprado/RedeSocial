namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadasPropriedadesDeHorta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hortas", "tipo", c => c.String());
            AddColumn("dbo.Hortas", "capacidade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hortas", "capacidade");
            DropColumn("dbo.Hortas", "tipo");
        }
    }
}
