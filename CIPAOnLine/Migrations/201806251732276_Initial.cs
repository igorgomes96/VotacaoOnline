namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.acrescimos_limite",
                c => new
                    {
                        codigo_grupo = c.String(nullable: false, maxLength: 8),
                        efetivo = c.Boolean(nullable: false),
                        qtda_limite = c.Int(nullable: false),
                        intervalo_acrescimo = c.Int(nullable: false),
                        qtda_acrescimo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.codigo_grupo, t.efetivo })
                .ForeignKey("dbo.grupos", t => t.codigo_grupo)
                .Index(t => t.codigo_grupo);
            
            CreateTable(
                "dbo.grupos",
                c => new
                    {
                        codigo = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.qtda_grupos",
                c => new
                    {
                        codigo_grupo = c.String(nullable: false, maxLength: 8),
                        efetivo = c.Boolean(nullable: false),
                        qtda_min = c.Int(nullable: false),
                        qtda_max = c.Int(),
                        valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.codigo_grupo, t.efetivo, t.qtda_min })
                .ForeignKey("dbo.acrescimos_limite", t => new { t.codigo_grupo, t.efetivo })
                .Index(t => new { t.codigo_grupo, t.efetivo });
            
            CreateTable(
                "dbo.candidatos",
                c => new
                    {
                        matricula_funcionario = c.String(nullable: false, maxLength: 15),
                        codigo_eleicao = c.Int(nullable: false),
                        horario_candidatura = c.DateTime(nullable: false),
                        validado = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.matricula_funcionario, t.codigo_eleicao })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .ForeignKey("dbo.funcionarios", t => t.matricula_funcionario)
                .Index(t => t.matricula_funcionario)
                .Index(t => t.codigo_eleicao);
            
            CreateTable(
                "dbo.candidaturas_reprovadas",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        matricula_funcionario = c.String(maxLength: 15),
                        codigo_eleicao = c.Int(nullable: false),
                        motivo = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.candidatos", t => new { t.matricula_funcionario, t.codigo_eleicao })
                .Index(t => new { t.matricula_funcionario, t.codigo_eleicao });
            
            CreateTable(
                "dbo.eleicoes",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        gestao = c.String(nullable: false, maxLength: 15),
                        data_inicio = c.DateTime(nullable: false),
                        data_fechamento = c.DateTime(),
                        codigo_etapa = c.Int(),
                        codigo_unidade = c.Int(nullable: false),
                        codigo_sindicato = c.Int(),
                        codigo_modulo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.etapas", t => t.codigo_etapa)
                .ForeignKey("dbo.modulo", t => t.codigo_modulo)
                .ForeignKey("dbo.sindicatos", t => t.codigo_sindicato)
                .ForeignKey("dbo.unidades", t => t.codigo_unidade)
                .Index(t => new { t.gestao, t.codigo_unidade, t.codigo_modulo }, unique: true, name: "gestao_unq")
                .Index(t => t.codigo_etapa)
                .Index(t => t.codigo_sindicato);
            
            CreateTable(
                "dbo.etapas",
                c => new
                    {
                        codigo = c.Int(nullable: false),
                        etapa = c.String(nullable: false, maxLength: 180),
                        dias_prazo = c.Int(),
                        codigo_modulo = c.Int(nullable: false),
                        codigo_template = c.Int(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.modulo", t => t.codigo_modulo)
                .ForeignKey("dbo.templates_emails", t => t.codigo_template)
                .Index(t => new { t.etapa, t.codigo_modulo }, unique: true, name: "nome_etapa_unq")
                .Index(t => t.codigo_template);
            
            CreateTable(
                "dbo.modulo",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome_modulo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.templates_emails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 80),
                        template = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.funcionarios",
                c => new
                    {
                        matricula = c.String(nullable: false, maxLength: 15),
                        nome = c.String(nullable: false, maxLength: 60),
                        login = c.String(maxLength: 50),
                        cargo = c.String(maxLength: 80),
                        area = c.String(maxLength: 80),
                        data_admissao = c.DateTime(),
                        data_nascimento = c.DateTime(),
                        email = c.String(maxLength: 100),
                        codigo_gestor = c.Int(),
                        sobre = c.String(maxLength: 255),
                        thumbnail = c.Binary(),
                    })
                .PrimaryKey(t => t.matricula)
                .ForeignKey("dbo.gestores", t => t.codigo_gestor)
                .Index(t => t.codigo_gestor);
            
            CreateTable(
                "dbo.funcionarios_fotos",
                c => new
                    {
                        matricula_funcionario = c.String(nullable: false, maxLength: 15),
                        foto = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.matricula_funcionario)
                .ForeignKey("dbo.funcionarios", t => t.matricula_funcionario)
                .Index(t => t.matricula_funcionario);
            
            CreateTable(
                "dbo.gestores",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 80),
                        email = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.codigo)
                .Index(t => t.nome, unique: true);
            
            CreateTable(
                "dbo.votos",
                c => new
                    {
                        matricula_eleitor = c.String(nullable: false, maxLength: 15),
                        matricula_candidato = c.String(nullable: false, maxLength: 15),
                        codigo_eleicao = c.Int(nullable: false),
                        data_horario = c.DateTime(nullable: false),
                        ip = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => new { t.matricula_eleitor, t.matricula_candidato, t.codigo_eleicao })
                .ForeignKey("dbo.candidatos", t => new { t.matricula_candidato, t.codigo_eleicao })
                .ForeignKey("dbo.funcionarios", t => t.matricula_eleitor)
                .Index(t => t.matricula_eleitor)
                .Index(t => new { t.matricula_candidato, t.codigo_eleicao });
            
            CreateTable(
                "dbo.voto_branco",
                c => new
                    {
                        matricula_eleitor = c.String(nullable: false, maxLength: 15),
                        codigo_eleicao = c.Int(nullable: false),
                        data_horario = c.DateTime(nullable: false),
                        ip = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => new { t.matricula_eleitor, t.codigo_eleicao })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .ForeignKey("dbo.funcionarios", t => t.matricula_eleitor)
                .Index(t => t.matricula_eleitor)
                .Index(t => t.codigo_eleicao);
            
            CreateTable(
                "dbo.prazos_etapas",
                c => new
                    {
                        codigo_eleicao = c.Int(nullable: false),
                        codigo_etapa = c.Int(nullable: false),
                        data_realizada = c.DateTime(),
                        data_proposta = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.codigo_eleicao, t.codigo_etapa })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .ForeignKey("dbo.etapas", t => t.codigo_etapa)
                .Index(t => t.codigo_eleicao)
                .Index(t => t.codigo_etapa);
            
            CreateTable(
                "dbo.resultados_eleicoes",
                c => new
                    {
                        codigo_eleicao = c.Int(nullable: false),
                        matricula_funcionario = c.String(nullable: false, maxLength: 15),
                        login = c.String(nullable: false, maxLength: 50),
                        cargo = c.String(nullable: false, maxLength: 80),
                        area = c.String(nullable: false, maxLength: 80),
                        data_admissao = c.DateTime(nullable: false),
                        qtda_votos = c.Int(nullable: false),
                        thumbnail = c.Binary(),
                        foto = c.Binary(),
                        efetivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.codigo_eleicao, t.matricula_funcionario })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .Index(t => t.codigo_eleicao);
            
            CreateTable(
                "dbo.sindicatos",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 30),
                        email = c.String(nullable: false, maxLength: 50),
                        endereco = c.String(maxLength: 255),
                        cidade = c.String(maxLength: 50),
                        responsavel = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.unidades",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        razao_social = c.String(nullable: false, maxLength: 200),
                        cidade = c.String(nullable: false, maxLength: 100),
                        estabelecimento = c.String(maxLength: 200),
                        codigo_grupo = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.grupos", t => t.codigo_grupo)
                .Index(t => t.codigo_grupo);
            
            CreateTable(
                "dbo.log_email",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        para = c.String(nullable: false),
                        assunto = c.String(maxLength: 255),
                        erro = c.String(),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.qtda_comissao_interna",
                c => new
                    {
                        qtda_min = c.Int(nullable: false),
                        valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.qtda_min);
            
            CreateTable(
                "dbo.sessao",
                c => new
                    {
                        chave = c.String(nullable: false, maxLength: 100),
                        login_usuario = c.String(nullable: false, maxLength: 50),
                        inicio = c.DateTime(nullable: false),
                        fim = c.DateTime(),
                    })
                .PrimaryKey(t => t.chave)
                .ForeignKey("dbo.usuarios", t => t.login_usuario)
                .Index(t => t.login_usuario);
            
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        login = c.String(nullable: false, maxLength: 50),
                        nome = c.String(nullable: false, maxLength: 60),
                        senha = c.String(maxLength: 45),
                        perfil = c.String(nullable: false, maxLength: 20),
                        matricula_funcionario = c.String(maxLength: 15),
                        drt = c.String(maxLength: 25),
                        cargo = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.login)
                .ForeignKey("dbo.funcionarios", t => t.matricula_funcionario)
                .Index(t => t.matricula_funcionario);
            
            CreateTable(
                "dbo.funcionarios_eleicoes",
                c => new
                    {
                        codigo_eleicao = c.Int(nullable: false),
                        matricula_funcionario = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => new { t.codigo_eleicao, t.matricula_funcionario })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .ForeignKey("dbo.funcionarios", t => t.matricula_funcionario)
                .Index(t => t.codigo_eleicao)
                .Index(t => t.matricula_funcionario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sessao", "login_usuario", "dbo.usuarios");
            DropForeignKey("dbo.usuarios", "matricula_funcionario", "dbo.funcionarios");
            DropForeignKey("dbo.unidades", "codigo_grupo", "dbo.grupos");
            DropForeignKey("dbo.eleicoes", "codigo_unidade", "dbo.unidades");
            DropForeignKey("dbo.eleicoes", "codigo_sindicato", "dbo.sindicatos");
            DropForeignKey("dbo.resultados_eleicoes", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.prazos_etapas", "codigo_etapa", "dbo.etapas");
            DropForeignKey("dbo.prazos_etapas", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.eleicoes", "codigo_modulo", "dbo.modulo");
            DropForeignKey("dbo.funcionarios_eleicoes", "matricula_funcionario", "dbo.funcionarios");
            DropForeignKey("dbo.funcionarios_eleicoes", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.voto_branco", "matricula_eleitor", "dbo.funcionarios");
            DropForeignKey("dbo.voto_branco", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.votos", "matricula_eleitor", "dbo.funcionarios");
            DropForeignKey("dbo.votos", new[] { "matricula_candidato", "codigo_eleicao" }, "dbo.candidatos");
            DropForeignKey("dbo.funcionarios", "codigo_gestor", "dbo.gestores");
            DropForeignKey("dbo.funcionarios_fotos", "matricula_funcionario", "dbo.funcionarios");
            DropForeignKey("dbo.candidatos", "matricula_funcionario", "dbo.funcionarios");
            DropForeignKey("dbo.eleicoes", "codigo_etapa", "dbo.etapas");
            DropForeignKey("dbo.etapas", "codigo_template", "dbo.templates_emails");
            DropForeignKey("dbo.etapas", "codigo_modulo", "dbo.modulo");
            DropForeignKey("dbo.candidatos", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.candidaturas_reprovadas", new[] { "matricula_funcionario", "codigo_eleicao" }, "dbo.candidatos");
            DropForeignKey("dbo.qtda_grupos", new[] { "codigo_grupo", "efetivo" }, "dbo.acrescimos_limite");
            DropForeignKey("dbo.acrescimos_limite", "codigo_grupo", "dbo.grupos");
            DropIndex("dbo.funcionarios_eleicoes", new[] { "matricula_funcionario" });
            DropIndex("dbo.funcionarios_eleicoes", new[] { "codigo_eleicao" });
            DropIndex("dbo.usuarios", new[] { "matricula_funcionario" });
            DropIndex("dbo.sessao", new[] { "login_usuario" });
            DropIndex("dbo.unidades", new[] { "codigo_grupo" });
            DropIndex("dbo.resultados_eleicoes", new[] { "codigo_eleicao" });
            DropIndex("dbo.prazos_etapas", new[] { "codigo_etapa" });
            DropIndex("dbo.prazos_etapas", new[] { "codigo_eleicao" });
            DropIndex("dbo.voto_branco", new[] { "codigo_eleicao" });
            DropIndex("dbo.voto_branco", new[] { "matricula_eleitor" });
            DropIndex("dbo.votos", new[] { "matricula_candidato", "codigo_eleicao" });
            DropIndex("dbo.votos", new[] { "matricula_eleitor" });
            DropIndex("dbo.gestores", new[] { "nome" });
            DropIndex("dbo.funcionarios_fotos", new[] { "matricula_funcionario" });
            DropIndex("dbo.funcionarios", new[] { "codigo_gestor" });
            DropIndex("dbo.etapas", new[] { "codigo_template" });
            DropIndex("dbo.etapas", "nome_etapa_unq");
            DropIndex("dbo.eleicoes", new[] { "codigo_sindicato" });
            DropIndex("dbo.eleicoes", new[] { "codigo_etapa" });
            DropIndex("dbo.eleicoes", "gestao_unq");
            DropIndex("dbo.candidaturas_reprovadas", new[] { "matricula_funcionario", "codigo_eleicao" });
            DropIndex("dbo.candidatos", new[] { "codigo_eleicao" });
            DropIndex("dbo.candidatos", new[] { "matricula_funcionario" });
            DropIndex("dbo.qtda_grupos", new[] { "codigo_grupo", "efetivo" });
            DropIndex("dbo.acrescimos_limite", new[] { "codigo_grupo" });
            DropTable("dbo.funcionarios_eleicoes");
            DropTable("dbo.usuarios");
            DropTable("dbo.sessao");
            DropTable("dbo.qtda_comissao_interna");
            DropTable("dbo.log_email");
            DropTable("dbo.unidades");
            DropTable("dbo.sindicatos");
            DropTable("dbo.resultados_eleicoes");
            DropTable("dbo.prazos_etapas");
            DropTable("dbo.voto_branco");
            DropTable("dbo.votos");
            DropTable("dbo.gestores");
            DropTable("dbo.funcionarios_fotos");
            DropTable("dbo.funcionarios");
            DropTable("dbo.templates_emails");
            DropTable("dbo.modulo");
            DropTable("dbo.etapas");
            DropTable("dbo.eleicoes");
            DropTable("dbo.candidaturas_reprovadas");
            DropTable("dbo.candidatos");
            DropTable("dbo.qtda_grupos");
            DropTable("dbo.grupos");
            DropTable("dbo.acrescimos_limite");
        }
    }
}
