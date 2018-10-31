using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class UnidadeFiltroDTO
    {
        public UnidadeDTO Unidade { get; set; }
        public ICollection<EleicaoDTO> Eleicoes { get; set; }
    }
}