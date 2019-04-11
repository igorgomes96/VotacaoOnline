namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrazoEtapaOrdem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.prazos_etapas", "ordem", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.prazos_etapas", "ordem");
        }
    }
}
