using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("grupos")]
    public class Grupo
    {

        public Grupo()
        {
            AcrescimosLimite = new HashSet<AcrescimoLimite>();
        }

        [Key]
        [Column("codigo")]
        [MaxLength(8)]
        public string Codigo { get; set; }

        public virtual ICollection<AcrescimoLimite> AcrescimosLimite { get; set; }

    }
}