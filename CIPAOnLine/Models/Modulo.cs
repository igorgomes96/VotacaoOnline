using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("modulo")]
    public class Modulo
    {

        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("nome_modulo")]
        [MaxLength(50)]
        public string NomeModulo { get; set; }
    }
}