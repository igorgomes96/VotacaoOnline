using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("templates_emails")]
    public class TemplateEmail
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nome")]
        [MaxLength(80)]
        [Required]
        public string Nome { get; set; }

        [Column("template", TypeName = "text")]
        public string Template { get; set; }

    }
}