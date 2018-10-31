using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class AcrescimoLimiteDTO
    {

        public AcrescimoLimiteDTO() {
            QtdasGrupos = new HashSet<QtdaGrupoDTO>();
        }

        public AcrescimoLimiteDTO(AcrescimoLimite a)
        {
            if (a == null) return;
            QtdasGrupos = new HashSet<QtdaGrupoDTO>();
            CodigoGrupo = a.CodigoGrupo;
            Efetivo = a.Efetivo;
            QtdaLimite = a.QtdaLimite;
            IntervaloLimite = a.IntervaloLimite;
            QtdaAcrescimo = a.QtdaAcrescimo;
            QtdasGrupos = a.QtdasCipeiros
                .Select(x => new QtdaGrupoDTO(x)).ToList();
        }

        public string CodigoGrupo { get; set; }
        public bool Efetivo { get; set; }
        public int QtdaLimite { get; set; }
        public int IntervaloLimite { get; set; }
        public int QtdaAcrescimo { get; set; }
        public ICollection<QtdaGrupoDTO> QtdasGrupos { get; set; }
    }
}