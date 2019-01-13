using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Models
{
    [Table("funcionarios")]
    public class Funcionario
    {
        public Funcionario()
        {
            Candidatos = new HashSet<Candidato>();
            Votos = new HashSet<Voto>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(15)]
        [Column("matricula")]
        [Required]
        [Index("IdxFuncionario", IsUnique = true, Order = 0)]
        public string MatriculaFuncionario { get; set; }

        [Column("codigo_empresa")]
        [Required]
        [Index("IdxFuncionario", IsUnique = true, Order = 1)]
        public int CodigoEmpresa { get; set; }

        [Required]
        [MaxLength(60)]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("login")]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Login { get; set; }

        
        [Column("cargo")]
        [MaxLength(80)]
        public string Cargo { get; set; }

        [Column("area")]
        [MaxLength(80)]
        public string Area { get; set; }

        [Column("data_admissao")]
        public DateTime? DataAdmissao { get; set; }

        [Column("data_nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("codigo_gestor")]
        public int? CodigoGestor { get; set; }

        [Column("sobre")]
        [MaxLength(255)]
        public string Sobre { get; set; }

        [Column("thumbnail")]
        public byte[] Thumbnail { get; set; }


        [ForeignKey("CodigoGestor")]
        public virtual Gestor Gestor { get; set; }
        [ForeignKey("CodigoEmpresa")]
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }
        public virtual ICollection<Voto> Votos { get; set; }
        public virtual ICollection<VotoBranco> VotosBrancos { get; set; }
        public virtual FuncionarioFoto FuncionarioFoto { get; set; }
    }
}