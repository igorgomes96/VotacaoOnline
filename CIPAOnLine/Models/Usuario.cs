using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("usuarios")]
    public class Usuario
    {

        [Key]
        [MaxLength(50)]
        [Column("login")]
        public string Login { get; set; }
        [Required]
        [MaxLength(60)]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("perfil")]
        public string Perfil { get; set; }
        [MaxLength(15)]
        [Column("matricula_funcionario")]
        public string MatriculaFuncionario { get; set; }

        [ForeignKey("MatriculaFuncionario")]
        public virtual Funcionario Funcionario { get; set; }

    }
}