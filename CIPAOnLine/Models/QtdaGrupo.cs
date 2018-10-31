using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("qtda_grupos")]
    public class QtdaGrupo
    {
        [Key]
        [Column("codigo_grupo", Order = 1)]
        [MaxLength(8)]
        public string CodigoGrupo { get; set; }

        [Key]
        [Column("efetivo", Order = 2)]
        public bool Efetivo { get; set; }

        [Key]
        [Column("qtda_min", Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QtdaMin { get; set; }

        [Column("qtda_max")]
        public int? QtdaMax { get; set; }

        [Required]
        [Column("valor")]
        public int Valor { get; set; }

        [ForeignKey("CodigoGrupo, Efetivo")]
        public virtual AcrescimoLimite AcrescimoLimite { get; set; }
    }
}