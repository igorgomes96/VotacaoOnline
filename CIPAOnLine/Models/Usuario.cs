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
        public Usuario()
        {
            Empresas = new HashSet<Empresa>();
        }

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

        [Column("funcionario_id")]
        public int? FuncionarioId { get; set; }

        [MaxLength(255)]
        [Column("senha")]
        public string Senha { get; set; }

        [MaxLength(255)]
        [Column("codigo_recuperacao")]
        public string CodigoRecuperacao { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }

    }
}