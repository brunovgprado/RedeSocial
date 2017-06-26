namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadasPropriedadesDeHorta1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hortas", "nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hortas", "nome");
        }
    }
}
