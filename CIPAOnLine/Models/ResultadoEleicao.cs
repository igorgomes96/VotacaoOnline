using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("resultados_eleicoes")]
    public class ResultadoEleicao
    {
        [Key]
        [Column("codigo_eleicao", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoEleicao { get; set; }

        [Key]
        [Column("matricula_funcionario", Order = 2)]
        [MaxLength(15)]
        public string MatriculaFuncionario { get; set; }

        [Required]
        [Column("login")]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [Column("cargo")]
        [MaxLength(80)]
        public string Cargo { get; set; }
        [Required]
        [Column("area")]
        [MaxLength(80)]
        public string Area { get; set; }
        [Required]
        [Column("data_admissao")]
        public DateTime? DataAdmissao { get; set; }

        [Required]
        [Column("qtda_votos")]
        public int QtdaVotos { get; set; }

        [Column("thumbnail")]
        public byte[] Thumbnail { get; set; }

        [Column("foto")]
        public byte[] Foto { get; set; }

        [Required]
        [Column("efetivo")]
        public bool Efetivo { get; set; }


        [ForeignKey("CodigoEleicao")]
        public virtual Eleicao Eleicao { get; set; }
    }
}