using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("votos")]
    public class Voto
    {
        [Key]
        [Column("funcionario_id_eleitor", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuncionarioIdEleitor { get; set; }
        [Key]
        [Column("funcionario_id_candidato", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuncionarioIdCandidato { get; set; }
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

        [ForeignKey("FuncionarioIdEleitor")]
        public virtual Funcionario Eleitor { get; set; }
        [ForeignKey("FuncionarioIdCandidato, CodigoEleicao")]
        public virtual Candidato Candidato { get; set; }
    }
}