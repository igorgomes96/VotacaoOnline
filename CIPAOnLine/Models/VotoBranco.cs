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
        [Column("funcionario_id_eleitor", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuncionarioIdEleitor { get; set; }
        [Key]
        [Column("codigo_eleicao", Order = 1)]
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
        [ForeignKey("CodigoEleicao")]
        public virtual Eleicao Eleicao { get; set; }
    }
}