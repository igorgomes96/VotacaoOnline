using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class GrupoDTO
    {
        public GrupoDTO()
        {
            AcrescimosLimite = new HashSet<AcrescimoLimiteDTO>();
        }

        public GrupoDTO(Grupo grupo)
        {
            AcrescimosLimite = new HashSet<AcrescimoLimiteDTO>();
            Codigo = grupo.Codigo;
            AcrescimosLimite = grupo.AcrescimosLimite
                .Select(x => new AcrescimoLimiteDTO(x)).ToList();
        }
        public string Codigo { get; set; }
        public ICollection<AcrescimoLimiteDTO> AcrescimosLimite { get; set; }

    }
}