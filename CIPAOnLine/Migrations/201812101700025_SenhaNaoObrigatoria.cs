namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SenhaNaoObrigatoria : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.usuarios", "senha", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.usuarios", "senha", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
