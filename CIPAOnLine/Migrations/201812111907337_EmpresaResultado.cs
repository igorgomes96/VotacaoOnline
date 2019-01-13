namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmpresaResultado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.resultados_eleicoes", "razao_social", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.resultados_eleicoes", "razao_social");
        }
    }
}
