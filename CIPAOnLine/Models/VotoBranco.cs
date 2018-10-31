using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("voto_branco")]
    public class VotoBranco
    {
        [Key]
        [Column("matricula_eleitor", Order = 1)]
        [MaxLength(15)]
        public string MatriculaEleitor { get; set; }
        [Key]
        [Column("codigo_eleicao", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoEleicao { get; set; }
        [Required]
        [Column("data_horario")]
        public DateTime DataHorario { get; set; }
        [Required]
        [MaxLength(15)]
        [Column("ip")]
        public string IP { get; set; }

        [ForeignKey("MatriculaEleitor")]
        public virtual Funcionario Eleitor { get; set; }
        [ForeignKey("CodigoEleicao")]
        public virtual Eleicao Eleicao { get; set; }
    }
}