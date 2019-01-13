namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodigoRecuperacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.usuarios", "codigo_recuperacao", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.usuarios", "codigo_recuperacao");
        }
    }
}
