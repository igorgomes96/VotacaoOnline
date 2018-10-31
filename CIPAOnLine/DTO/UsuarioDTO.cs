using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO() { }

        public UsuarioDTO(Usuario u)
        {
            if (u == null) return;
            Login = u.Login;
            Nome = u.Nome;
            Perfil = u.Perfil;
            MatriculaFuncionario = u.MatriculaFuncionario;

            if (u.Funcionario != null)
            {
                Nome = u.Funcionario.Nome;
                Cargo = u.Funcionario.Cargo;
                Area = u.Funcionario.Area;
                DataAdmissao = u.Funcionario.DataAdmissao;
                Email = u.Funcionario.Email;
                Sobre = u.Funcionario.Sobre;                
            }
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
        public string MatriculaFuncionario { get; set; }
        public string Login { get; set; }
        public string Area { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public string Sobre { get; set; }
        public string Cargo { get; set; }

    }
}