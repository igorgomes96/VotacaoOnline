using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class ForaEtapaCandidaturaException : Exception
    {
        public Eleicao Eleicao { get; set; }
        public ForaEtapaCandidaturaException(Eleicao eleicao) : base()
        {
            Eleicao = eleicao;
        }
    }
}