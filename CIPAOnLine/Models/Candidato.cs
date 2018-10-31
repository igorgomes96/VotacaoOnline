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
        [Column("matricula_funcionario", Order = 1)]
        [MaxLength(15)]
        public string MatriculaFuncionario { get; set; }
        [Key]
        [Column("codigo_eleicao", Order = 2)]
        public int CodigoEleicao { get; set; }
        [Required]
        [Column("horario_candidatura")]
        public DateTime HorarioCandidatura { get; set; }

        [Column("validado")]
        public bool? Validado { get; set; }


        [ForeignKey("MatriculaFuncionario")]
        public virtual Funcionario Funcionario { get; set; }
        [ForeignKey("CodigoEleicao")]
        public virtual Eleicao Eleicao { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }
        public virtual ICollection<CandidaturaReprovada> CandidaturasReprovadas { get; set; }
    }
}