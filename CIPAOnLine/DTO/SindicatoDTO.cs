using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class SindicatoDTO
    {
        public SindicatoDTO() { }
        public SindicatoDTO(Sindicato s)
        {
            if (s == null) return;
            Codigo = s.Codigo;
            Nome = s.Nome;
            Email = s.Email;
            Endereco = s.Endereco;
            Cidade = s.Cidade;
            Responsavel = s.Responsavel;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Responsavel { get; set; }
    }
}