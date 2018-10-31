namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetiradaDRTeCargodeUsuario : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.usuarios", "drt");
            DropColumn("dbo.usuarios", "cargo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.usuarios", "cargo", c => c.String(maxLength: 80));
            AddColumn("dbo.usuarios", "drt", c => c.String(maxLength: 25));
        }
    }
}
