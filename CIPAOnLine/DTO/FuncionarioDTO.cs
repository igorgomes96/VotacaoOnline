using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class FuncionarioDTO
    {
        public FuncionarioDTO() { }

        public FuncionarioDTO (Funcionario f)
        {
            if (f == null) return;
            MatriculaFuncionario = f.MatriculaFuncionario;
            Nome = f.Nome;
            Login = f.Login;
            Cargo = f.Cargo;
            Area = f.Area;
            DataAdmissao = f.DataAdmissao;
            DataNascimento = f.DataNascimento;
            Email = f.Email;
            Thumbnail = f.Thumbnail;
            CodigoGestor = f.CodigoGestor;
            Sobre = f.Sobre;
            
            if (f.Gestor != null)
            {
                NomeGestor = f.Gestor.Nome;
                EmailGestor = f.Gestor.Email;
            }
        }

        public string MatriculaFuncionario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public byte[] Thumbnail { get; set; }
        public int? CodigoGestor { get; set; }
        public string NomeGestor { get; set; }
        public string EmailGestor { get; set; }
        public string Sobre { get; set; }

    }
}