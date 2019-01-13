using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("candidatos")]
    public class Candidato
    {

        public Candidato()
        {
            Votos = new HashSet<Voto>();
            CandidaturasReprovadas = new HashSet<CandidaturaReprovada>();
        }

        [Key]
        [Column("funcionario_id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuncionarioId { get; set; }
        [Key]
        [Column("codigo_eleicao", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoEleicao { get; set; }
        [Required]
        [Column("horario_candidatura")]
        public DateTime HorarioCandidatura { get; set; }

        [Column("validado")]
        public bool? Validado { get; set; }


        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
        [ForeignKey("CodigoEleicao")]
        public virtual Eleicao Eleicao { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }
        public virtual ICollection<CandidaturaReprovada> CandidaturasReprovadas { get; set; }
    }
}