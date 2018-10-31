namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExclusãoSessão : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.sessao", "login_usuario", "dbo.usuarios");
            DropIndex("dbo.sessao", new[] { "login_usuario" });
            DropTable("dbo.sessao");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.sessao",
                c => new
                    {
                        chave = c.String(nullable: false, maxLength: 100),
                        login_usuario = c.String(nullable: false, maxLength: 50),
                        inicio = c.DateTime(nullable: false),
                        fim = c.DateTime(),
                    })
                .PrimaryKey(t => t.chave);
            
            CreateIndex("dbo.sessao", "login_usuario");
            AddForeignKey("dbo.sessao", "login_usuario", "dbo.usuarios", "login");
        }
    }
}
