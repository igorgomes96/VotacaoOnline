namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JWTAuthEmpresas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.empresas",
                c => new
                    {
                        codigo = c.Int(nullable: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.usuario_empresa",
                c => new
                    {
                        codigo_empresa = c.Int(nullable: false),
                        login_usuario = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.codigo_empresa, t.login_usuario })
                .ForeignKey("dbo.empresas", t => t.codigo_empresa)
                .ForeignKey("dbo.usuarios", t => t.login_usuario)
                .Index(t => t.codigo_empresa)
                .Index(t => t.login_usuario);
            
            AddColumn("dbo.unidades", "codigo_empresa", c => c.Int(nullable: false));
            AddColumn("dbo.usuarios", "senha", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.unidades", "codigo_empresa");
            AddForeignKey("dbo.unidades", "codigo_empresa", "dbo.empresas", "codigo");
            DropColumn("dbo.unidades", "razao_social");
        }
        
        public override void Down()
        {
            AddColumn("dbo.unidades", "razao_social", c => c.String(nullable: false, maxLength: 200));
            DropForeignKey("dbo.unidades", "codigo_empresa", "dbo.empresas");
            DropForeignKey("dbo.usuario_empresa", "login_usuario", "dbo.usuarios");
            DropForeignKey("dbo.usuario_empresa", "codigo_empresa", "dbo.empresas");
            DropIndex("dbo.usuario_empresa", new[] { "login_usuario" });
            DropIndex("dbo.usuario_empresa", new[] { "codigo_empresa" });
            DropIndex("dbo.unidades", new[] { "codigo_empresa" });
            DropColumn("dbo.usuarios", "senha");
            DropColumn("dbo.unidades", "codigo_empresa");
            DropTable("dbo.usuario_empresa");
            DropTable("dbo.empresas");
        }
    }
}
