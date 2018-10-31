using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class ResultadoDTO
    {
        public ResultadoDTO()
        {
            Efetivos = new List<CandidatoEleitoDTO>();
            Suplentes = new List<CandidatoEleitoDTO>();
        }

        public void OrdernarListas ()
        {
            Efetivos = Efetivos.OrderByDescending(x => x.QtdaVotos).ToList();
            Suplentes = Suplentes.OrderByDescending(x => x.QtdaVotos).ToList();
        }
        public ICollection<CandidatoEleitoDTO> Efetivos { get; set; }
        public ICollection<CandidatoEleitoDTO> Suplentes { get; set; }
    }
}