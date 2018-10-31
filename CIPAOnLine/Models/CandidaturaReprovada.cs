using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("candidaturas_reprovadas")]
    public class CandidaturaReprovada
    {
        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Column("matricula_funcionario")]
        [MaxLength(15)]
        public string MatriculaFuncionario { get; set; }

        [Column("codigo_eleicao")]
        public int CodigoEleicao { get; set; }

        [Column("motivo")]
        [MaxLength(255)]
        public string Motivo { get; set; }

        [ForeignKey("MatriculaFuncionario, CodigoEleicao")]
        public virtual Candidato Candidato { get; set; }
    }
}