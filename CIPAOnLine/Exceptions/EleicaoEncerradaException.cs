using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class EleicaoEncerradaException : Exception
    {
        public Eleicao Eleicao { get; set; }
        public EleicaoEncerradaException() : base()
        { 
        }

        public EleicaoEncerradaException(Eleicao eleicao) : base()
        {
            Eleicao = eleicao;
        }
    }
}