using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("log_email")]
    public class LogEmail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }
        [Required]
        [Column("para")]
        public string Para { get; set; }
        [MaxLength(255)]
        [Column("assunto")]
        public string Assunto { get; set; }
        [Column("erro")]
        public string Erro { get; set; }

    }
}