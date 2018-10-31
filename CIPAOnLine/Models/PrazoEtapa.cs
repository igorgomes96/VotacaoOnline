using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("prazos_etapas")]
    public class PrazoEtapa
    {
        [Key]
        [Column("codigo_eleicao", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoEleicao { get; set; }

        [Key]
        [Column("codigo_etapa", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoEtapa { get; set; }

        [Column("data_realizada")]
        public DateTime? DataRealizada { get; set; }

        [Column("data_proposta")]
        public DateTime? DataProposta { get; set; }


        [ForeignKey("CodigoEleicao")]
        public virtual Eleicao Eleicao { get; set; }

        [ForeignKey("CodigoEtapa")]
        public virtual Etapa Etapa { get; set; }

        
    }
}