namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExclusãoSenhaUsuário : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.usuarios", "senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.usuarios", "senha", c => c.String(maxLength: 45));
        }
    }
}
