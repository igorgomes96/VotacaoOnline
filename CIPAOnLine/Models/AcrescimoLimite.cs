using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("acrescimos_limite")]
    public class AcrescimoLimite
    {

        public AcrescimoLimite()
        {
            QtdasCipeiros = new HashSet<QtdaGrupo>();
        }
        [Key]
        [Column("codigo_grupo", Order = 1)]
        [MaxLength(8)]
        public string CodigoGrupo { get; set; }
        [Key]
        [Column("efetivo", Order = 2)]
        public bool Efetivo { get; set; }
        [Required]
        [Column("qtda_limite")]
        public int QtdaLimite { get; set; }
        [Required]
        [Column("intervalo_acrescimo")]
        public int IntervaloLimite { get; set; }
        [Required]
        [Column("qtda_acrescimo")]
        public int QtdaAcrescimo { get; set; }

        [ForeignKey("CodigoGrupo")]
        public virtual Grupo Grupo { get; set; }

        public virtual ICollection<QtdaGrupo> QtdasCipeiros { get; set; }
    }
}