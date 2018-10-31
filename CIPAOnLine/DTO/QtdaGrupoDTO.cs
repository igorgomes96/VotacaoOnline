using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class QtdaGrupoDTO
    {

        public QtdaGrupoDTO() { }

        public QtdaGrupoDTO(QtdaGrupo q)
        {
            if (q == null) return;
            CodigoGrupo = q.CodigoGrupo;
            Efetivo = q.Efetivo;
            QtdaMin = q.QtdaMin;
            QtdaMax = q.QtdaMax;
            Valor = q.Valor;
        }

        public string CodigoGrupo { get; set; }
        public bool Efetivo { get; set; }
        public int QtdaMin { get; set; }
        public int? QtdaMax { get; set; }
        public int Valor { get; set; }

    }
}