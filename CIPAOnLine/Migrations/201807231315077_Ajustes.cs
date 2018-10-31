namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.funcionarios", "login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.funcionarios", new[] { "login" });
        }
    }
}
