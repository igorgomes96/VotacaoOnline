using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("funcionarios_fotos")]
    public class FuncionarioFoto
    {
        [Key, ForeignKey("Funcionario")]
        [Column("funcionario_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuncionarioId { get; set; }

        [Required]
        [Column("foto")]
        public byte[] Foto { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}