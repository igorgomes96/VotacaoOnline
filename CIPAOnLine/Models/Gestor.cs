using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("gestores")]
    public class Gestor
    {
        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required]
        [MaxLength(80)]
        [Column("nome")]
        [Index(IsUnique = true)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(80)]
        [Column("email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}