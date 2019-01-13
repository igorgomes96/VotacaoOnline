namespace CIPAOnLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMySQL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.acrescimos_limite",
                c => new
                    {
                        codigo_grupo = c.String(nullable: false, maxLength: 8, storeType: "nvarchar"),
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
                        codigo = c.String(nullable: false, maxLength: 8, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.qtda_grupos",
                c => new
                    {
                        codigo_grupo = c.String(nullable: false, maxLength: 8, storeType: "nvarchar"),
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
                        funcionario_id = c.Int(nullable: false),
                        codigo_eleicao = c.Int(nullable: false),
                        horario_candidatura = c.DateTime(nullable: false, precision: 0),
                        validado = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.funcionario_id, t.codigo_eleicao })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .ForeignKey("dbo.funcionarios", t => t.funcionario_id)
                .Index(t => t.funcionario_id)
                .Index(t => t.codigo_eleicao);
            
            CreateTable(
                "dbo.candidaturas_reprovadas",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        funcionario_id = c.Int(nullable: false),
                        codigo_eleicao = c.Int(nullable: false),
                        motivo = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.candidatos", t => new { t.funcionario_id, t.codigo_eleicao })
                .Index(t => new { t.funcionario_id, t.codigo_eleicao });
            
            CreateTable(
                "dbo.eleicoes",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        gestao = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        data_inicio = c.DateTime(nullable: false, precision: 0),
                        data_fechamento = c.DateTime(precision: 0),
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
                        etapa = c.String(nullable: false, maxLength: 180, storeType: "nvarchar"),
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
                        nome_modulo = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.templates_emails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        template = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.funcionarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        matricula = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        codigo_empresa = c.Int(nullable: false),
                        nome = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        login = c.String(maxLength: 50, storeType: "nvarchar"),
                        cargo = c.String(maxLength: 80, storeType: "nvarchar"),
                        area = c.String(maxLength: 80, storeType: "nvarchar"),
                        data_admissao = c.DateTime(precision: 0),
                        data_nascimento = c.DateTime(precision: 0),
                        email = c.String(maxLength: 100, storeType: "nvarchar"),
                        codigo_gestor = c.Int(),
                        sobre = c.String(maxLength: 255, storeType: "nvarchar"),
                        thumbnail = c.Binary(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.empresas", t => t.codigo_empresa)
                .ForeignKey("dbo.gestores", t => t.codigo_gestor)
                .Index(t => new { t.matricula, t.codigo_empresa }, unique: true, name: "IdxFuncionario")
                .Index(t => t.login, unique: true)
                .Index(t => t.codigo_gestor);
            
            CreateTable(
                "dbo.empresas",
                c => new
                    {
                        codigo = c.Int(nullable: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        login = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        nome = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        perfil = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        funcionario_id = c.Int(),
                        senha = c.String(maxLength: 255, storeType: "nvarchar"),
                        codigo_recuperacao = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.login)
                .ForeignKey("dbo.funcionarios", t => t.funcionario_id)
                .Index(t => t.funcionario_id);
            
            CreateTable(
                "dbo.funcionarios_fotos",
                c => new
                    {
                        funcionario_id = c.Int(nullable: false),
                        foto = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.funcionario_id)
                .ForeignKey("dbo.funcionarios", t => t.funcionario_id)
                .Index(t => t.funcionario_id);
            
            CreateTable(
                "dbo.gestores",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        email = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.codigo)
                .Index(t => t.nome, unique: true);
            
            CreateTable(
                "dbo.votos",
                c => new
                    {
                        funcionario_id_eleitor = c.Int(nullable: false),
                        funcionario_id_candidato = c.Int(nullable: false),
                        codigo_eleicao = c.Int(nullable: false),
                        data_horario = c.DateTime(nullable: false, precision: 0),
                        ip = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.funcionario_id_eleitor, t.funcionario_id_candidato, t.codigo_eleicao })
                .ForeignKey("dbo.candidatos", t => new { t.funcionario_id_candidato, t.codigo_eleicao })
                .ForeignKey("dbo.funcionarios", t => t.funcionario_id_eleitor)
                .Index(t => t.funcionario_id_eleitor)
                .Index(t => new { t.funcionario_id_candidato, t.codigo_eleicao });
            
            CreateTable(
                "dbo.voto_branco",
                c => new
                    {
                        funcionario_id_eleitor = c.Int(nullable: false),
                        codigo_eleicao = c.Int(nullable: false),
                        data_horario = c.DateTime(nullable: false, precision: 0),
                        ip = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.funcionario_id_eleitor, t.codigo_eleicao })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .ForeignKey("dbo.funcionarios", t => t.funcionario_id_eleitor)
                .Index(t => t.funcionario_id_eleitor)
                .Index(t => t.codigo_eleicao);
            
            CreateTable(
                "dbo.prazos_etapas",
                c => new
                    {
                        codigo_eleicao = c.Int(nullable: false),
                        codigo_etapa = c.Int(nullable: false),
                        data_realizada = c.DateTime(precision: 0),
                        data_proposta = c.DateTime(precision: 0),
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
                        matricula_funcionario = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        codigo_empresa = c.Int(nullable: false),
                        razao_social = c.String(maxLength: 100, storeType: "nvarchar"),
                        login = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        cargo = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        area = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        data_admissao = c.DateTime(nullable: false, precision: 0),
                        qtda_votos = c.Int(nullable: false),
                        thumbnail = c.Binary(),
                        foto = c.Binary(),
                        efetivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.codigo_eleicao, t.matricula_funcionario, t.codigo_empresa })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .Index(t => t.codigo_eleicao);
            
            CreateTable(
                "dbo.sindicatos",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        email = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        endereco = c.String(maxLength: 255, storeType: "nvarchar"),
                        cidade = c.String(maxLength: 50, storeType: "nvarchar"),
                        responsavel = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.unidades",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        codigo_empresa = c.Int(nullable: false),
                        cidade = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        estabelecimento = c.String(maxLength: 200, storeType: "nvarchar"),
                        codigo_grupo = c.String(maxLength: 8, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.empresas", t => t.codigo_empresa)
                .ForeignKey("dbo.grupos", t => t.codigo_grupo)
                .Index(t => t.codigo_empresa)
                .Index(t => t.codigo_grupo);
            
            CreateTable(
                "dbo.log_email",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        para = c.String(nullable: false, unicode: false),
                        assunto = c.String(maxLength: 255, storeType: "nvarchar"),
                        erro = c.String(unicode: false),
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
                "dbo.usuario_empresa",
                c => new
                    {
                        codigo_empresa = c.Int(nullable: false),
                        login_usuario = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.codigo_empresa, t.login_usuario })
                .ForeignKey("dbo.empresas", t => t.codigo_empresa)
                .ForeignKey("dbo.usuarios", t => t.login_usuario)
                .Index(t => t.codigo_empresa)
                .Index(t => t.login_usuario);
            
            CreateTable(
                "dbo.funcionarios_eleicoes",
                c => new
                    {
                        codigo_eleicao = c.Int(nullable: false),
                        funcionario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.codigo_eleicao, t.funcionario_id })
                .ForeignKey("dbo.eleicoes", t => t.codigo_eleicao)
                .ForeignKey("dbo.funcionarios", t => t.funcionario_id)
                .Index(t => t.codigo_eleicao)
                .Index(t => t.funcionario_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.unidades", "codigo_grupo", "dbo.grupos");
            DropForeignKey("dbo.unidades", "codigo_empresa", "dbo.empresas");
            DropForeignKey("dbo.eleicoes", "codigo_unidade", "dbo.unidades");
            DropForeignKey("dbo.eleicoes", "codigo_sindicato", "dbo.sindicatos");
            DropForeignKey("dbo.resultados_eleicoes", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.prazos_etapas", "codigo_etapa", "dbo.etapas");
            DropForeignKey("dbo.prazos_etapas", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.eleicoes", "codigo_modulo", "dbo.modulo");
            DropForeignKey("dbo.funcionarios_eleicoes", "funcionario_id", "dbo.funcionarios");
            DropForeignKey("dbo.funcionarios_eleicoes", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.voto_branco", "funcionario_id_eleitor", "dbo.funcionarios");
            DropForeignKey("dbo.voto_branco", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.votos", "funcionario_id_eleitor", "dbo.funcionarios");
            DropForeignKey("dbo.votos", new[] { "funcionario_id_candidato", "codigo_eleicao" }, "dbo.candidatos");
            DropForeignKey("dbo.funcionarios", "codigo_gestor", "dbo.gestores");
            DropForeignKey("dbo.funcionarios_fotos", "funcionario_id", "dbo.funcionarios");
            DropForeignKey("dbo.funcionarios", "codigo_empresa", "dbo.empresas");
            DropForeignKey("dbo.usuario_empresa", "login_usuario", "dbo.usuarios");
            DropForeignKey("dbo.usuario_empresa", "codigo_empresa", "dbo.empresas");
            DropForeignKey("dbo.usuarios", "funcionario_id", "dbo.funcionarios");
            DropForeignKey("dbo.candidatos", "funcionario_id", "dbo.funcionarios");
            DropForeignKey("dbo.eleicoes", "codigo_etapa", "dbo.etapas");
            DropForeignKey("dbo.etapas", "codigo_template", "dbo.templates_emails");
            DropForeignKey("dbo.etapas", "codigo_modulo", "dbo.modulo");
            DropForeignKey("dbo.candidatos", "codigo_eleicao", "dbo.eleicoes");
            DropForeignKey("dbo.candidaturas_reprovadas", new[] { "funcionario_id", "codigo_eleicao" }, "dbo.candidatos");
            DropForeignKey("dbo.qtda_grupos", new[] { "codigo_grupo", "efetivo" }, "dbo.acrescimos_limite");
            DropForeignKey("dbo.acrescimos_limite", "codigo_grupo", "dbo.grupos");
            DropIndex("dbo.funcionarios_eleicoes", new[] { "funcionario_id" });
            DropIndex("dbo.funcionarios_eleicoes", new[] { "codigo_eleicao" });
            DropIndex("dbo.usuario_empresa", new[] { "login_usuario" });
            DropIndex("dbo.usuario_empresa", new[] { "codigo_empresa" });
            DropIndex("dbo.unidades", new[] { "codigo_grupo" });
            DropIndex("dbo.unidades", new[] { "codigo_empresa" });
            DropIndex("dbo.resultados_eleicoes", new[] { "codigo_eleicao" });
            DropIndex("dbo.prazos_etapas", new[] { "codigo_etapa" });
            DropIndex("dbo.prazos_etapas", new[] { "codigo_eleicao" });
            DropIndex("dbo.voto_branco", new[] { "codigo_eleicao" });
            DropIndex("dbo.voto_branco", new[] { "funcionario_id_eleitor" });
            DropIndex("dbo.votos", new[] { "funcionario_id_candidato", "codigo_eleicao" });
            DropIndex("dbo.votos", new[] { "funcionario_id_eleitor" });
            DropIndex("dbo.gestores", new[] { "nome" });
            DropIndex("dbo.funcionarios_fotos", new[] { "funcionario_id" });
            DropIndex("dbo.usuarios", new[] { "funcionario_id" });
            DropIndex("dbo.funcionarios", new[] { "codigo_gestor" });
            DropIndex("dbo.funcionarios", new[] { "login" });
            DropIndex("dbo.funcionarios", "IdxFuncionario");
            DropIndex("dbo.etapas", new[] { "codigo_template" });
            DropIndex("dbo.etapas", "nome_etapa_unq");
            DropIndex("dbo.eleicoes", new[] { "codigo_sindicato" });
            DropIndex("dbo.eleicoes", new[] { "codigo_etapa" });
            DropIndex("dbo.eleicoes", "gestao_unq");
            DropIndex("dbo.candidaturas_reprovadas", new[] { "funcionario_id", "codigo_eleicao" });
            DropIndex("dbo.candidatos", new[] { "codigo_eleicao" });
            DropIndex("dbo.candidatos", new[] { "funcionario_id" });
            DropIndex("dbo.qtda_grupos", new[] { "codigo_grupo", "efetivo" });
            DropIndex("dbo.acrescimos_limite", new[] { "codigo_grupo" });
            DropTable("dbo.funcionarios_eleicoes");
            DropTable("dbo.usuario_empresa");
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
            DropTable("dbo.usuarios");
            DropTable("dbo.empresas");
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
