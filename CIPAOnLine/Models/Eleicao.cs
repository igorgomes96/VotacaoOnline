using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("eleicoes")]
    public class Eleicao
    {
        public Eleicao()
        {
            Candidatos = new HashSet<Candidato>();
            PrazosEtapas = new HashSet<PrazoEtapa>();
            Funcionarios = new HashSet<Funcionario>();
        }

        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required]
        [Column("gestao")]
        [MaxLength(15)]
        [Index("gestao_unq", 1, IsUnique = true)]
        public string Gestao { get; set; }

        [Required]
        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fechamento")]
        public DateTime? DataFechamento { get; set; }

        [Column("codigo_etapa")]
        [ForeignKey("EtapaAtual")]
        public int? CodigoEtapa { get; set; }

        [Required]
        [Column("codigo_unidade")]
        [Index("gestao_unq", 2, IsUnique = true)]
        public int CodigoUnidade { get; set; }

        [Column("codigo_sindicato")]
        public int? CodigoSindicato { get; set; }

        [Required]
        [Column("codigo_modulo")]
        [Index("gestao_unq", 3, IsUnique = true)]
        public int CodigoModulo { get; set; }


        [ForeignKey("CodigoUnidade")]
        public virtual Unidade Unidade { get; set; }

        [ForeignKey("CodigoSindicato")]
        public virtual Sindicato Sindicato { get; set; }

        [ForeignKey("CodigoModulo")]
        public virtual Modulo Modulo { get; set; }

        public virtual Etapa EtapaAtual { get; set; }

        public virtual ICollection<Candidato> Candidatos { get; set; }
        public virtual ICollection<PrazoEtapa> PrazosEtapas { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<ResultadoEleicao> Resultado { get; set; }
        public virtual ICollection<VotoBranco> VotosBrancos { get; set; }
    }
}