using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class CandidatoEleitoDTO : FuncionarioDTO
    {
        public CandidatoEleitoDTO() { }
        public CandidatoEleitoDTO(Candidato c) : base(c.Funcionario)
        {
        }
        public CandidatoEleitoDTO(Candidato c, int qtdaVotos) : base(c.Funcionario)
        {
            QtdaVotos = qtdaVotos;
        }

        public int QtdaVotos { get; set; }
    }
}