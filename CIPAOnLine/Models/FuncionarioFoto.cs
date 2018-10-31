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
        [MaxLength(15)]
        [Column("matricula_funcionario")]
        public string MatriculaFuncionario { get; set; }

        [Required]
        [Column("foto")]
        public byte[] Foto { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}