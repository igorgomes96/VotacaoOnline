namespace CIPAOnLine.Models
{
    using MySql.Data.Entity;
    using Npgsql;
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.DependencyResolution;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Diagnostics;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Modelo : DbContext
    {

        public Modelo() : base("name=ModeloMySQL")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Modelo>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Modelo>());
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //if (Database.Connection.ToString().Contains("Npgsql"))
            //modelBuilder.HasDefaultSchema("public");

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Eleicao>()
                .HasMany(c => c.Funcionarios)
                .WithMany()                 // Note the empty WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("codigo_eleicao");
                    x.MapRightKey("funcionario_id");
                    x.ToTable("funcionarios_eleicoes");
                });

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Usuarios)
                .WithMany(u => u.Empresas)
                .Map(m =>
                {
                    m.MapLeftKey("codigo_empresa");
                    m.MapRightKey("login_usuario");
                    m.ToTable("usuario_empresa");
                });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Candidato> Candidatos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Unidade> Unidades { get; set; }
        public virtual DbSet<Eleicao> Eleicoes { get; set; }
        public virtual DbSet<Voto> Votos { get; set; }
        public virtual DbSet<Etapa> Etapas { get; set; }
        public virtual DbSet<PrazoEtapa> PrazosEtapas { get; set; }
        public virtual DbSet<Sindicato> Sindicatos { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<QtdaGrupo> QtdasGrupos { get; set; }
        public virtual DbSet<CandidaturaReprovada> CandidaturasReprovadas { get; set; }
        public virtual DbSet<FuncionarioFoto> FuncionariosFotos { get; set; }
        public virtual DbSet<QtdaComissaoInterna> QtdasComissaoInterna { get; set; }
        public virtual DbSet<ResultadoEleicao> ResultadosEleicoes { get; set; }
        public virtual DbSet<LogEmail> LogEmails { get; set; }
        public virtual DbSet<Gestor> Gestores { get; set; }
        public virtual DbSet<AcrescimoLimite> AcrescimosLimites { get; set; }
        public virtual DbSet<TemplateEmail> Templates { get; set; }
        public virtual DbSet<VotoBranco> VotosBrancos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }

    }

}