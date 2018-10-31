using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class QtdaVotosDTO
    {
        public QtdaVotosDTO() { }
        public QtdaVotosDTO(Candidato candidato, int qtdaVotos)
        {
            Candidato = new CandidatoDTO(candidato);
            QtdaVotos = qtdaVotos;
        }
        public CandidatoDTO Candidato { get; set; }
        public int QtdaVotos { get; set; }
    }
}