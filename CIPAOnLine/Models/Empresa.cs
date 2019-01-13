using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("empresas")]
    public class Empresa
    {
        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }
        [MaxLength(100)]
        [Required]
        public string RazaoSocial { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}