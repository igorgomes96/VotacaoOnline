using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class FiltroEleicaoDTO
    {
        public string Label { get; set; }
        public ICollection<UnidadeFiltroDTO> Unidades { get; set; }
    }
}