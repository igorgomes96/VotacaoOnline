using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("etapas")]
    public class Etapa
    {

        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoEtapa { get; set; }

        [Required]
        [Column("etapa")]
        [MaxLength(180)]
        [Index("nome_etapa_unq", 1, IsUnique = true)]
        public string NomeEtapa { get; set; }

        [Column("dias_prazo")]
        public int? DiasPrazo { get; set; }

        [Required]
        [Column("codigo_modulo")]
        [Index("nome_etapa_unq", 2, IsUnique = true)]
        public int CodigoModulo { get; set; }

        [Column("codigo_template")]
        public int? CodigoTemplate { get; set; }


        [ForeignKey("CodigoModulo")]
        public virtual Modulo Modulo { get; set; }

        [ForeignKey("CodigoTemplate")]
        public virtual TemplateEmail TemplateEmail { get; set; }


    }
}