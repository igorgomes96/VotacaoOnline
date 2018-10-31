using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("unidades")]
    public class Unidade
    {

        public Unidade() {
            Eleicoes = new HashSet<Eleicao>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("razao_social")]
        public string RazaoSocial { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("cidade")]
        public string Cidade { get; set; }

        [MaxLength(200)]
        [Column("estabelecimento")]
        public string Estabelecimento { get; set; }

        [MaxLength(8)]
        [Column("codigo_grupo")]
        public string CodigoGrupo { get; set; }

        [ForeignKey("CodigoGrupo")]
        public virtual Grupo Grupo { get; set; }

        public virtual ICollection<Eleicao> Eleicoes { get; set; }
    }
}