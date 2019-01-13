using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class UnidadeDTO
    {
        public UnidadeDTO() { }
        public UnidadeDTO (Unidade u)
        {
            if (u == null) return;
            Codigo = u.Codigo;
            CodigoEmpresa = u.CodigoEmpresa;
            RazaoSocial = u.Empresa?.RazaoSocial;
            Cidade = u.Cidade;
            Estabelecimento = u.Estabelecimento;
            CodigoGrupo = u.CodigoGrupo;
        }
        public int Codigo { get; set; }
        public int CodigoEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string Cidade { get; set; }
        public string Estabelecimento { get; set; }
        public string CodigoGrupo { get; set; }
    }
}