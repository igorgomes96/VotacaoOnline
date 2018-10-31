using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("qtda_comissao_interna")]
    public class QtdaComissaoInterna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("qtda_min")]
        public int QtdaMin { get; set; }
        [Required]
        [Column("valor")]
        public int Valor { get; set; }
    }
}