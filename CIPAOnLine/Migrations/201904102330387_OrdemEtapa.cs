namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdemEtapa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.etapas", "ordem", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.etapas", "ordem");
        }
    }
}
