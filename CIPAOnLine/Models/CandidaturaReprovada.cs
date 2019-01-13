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

        [Column("funcionario_id")]
        [Required]
        public int FuncionarioId { get; set; }

        [Column("codigo_eleicao")]
        [Required]
        public int CodigoEleicao { get; set; }

        [Column("motivo")]
        [MaxLength(255)]
        public string Motivo { get; set; }

        [ForeignKey("FuncionarioId, CodigoEleicao")]
        public virtual Candidato Candidato { get; set; }
    }
}