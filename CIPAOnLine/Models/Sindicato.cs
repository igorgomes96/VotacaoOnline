using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("sindicatos")]
    public class Sindicato
    {
        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Column("nome")]
        [MaxLength(30)]
        [Required]
        public string Nome { get; set; }

        [Column("email")]
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [Column("endereco")]
        [MaxLength(255)]
        public string Endereco { get; set; }

        [Column("cidade")]
        [MaxLength(50)]
        public string Cidade { get; set; }

        [Required]
        [Column("responsavel")]
        [MaxLength(100)]
        public string Responsavel { get; set; }
    }
}