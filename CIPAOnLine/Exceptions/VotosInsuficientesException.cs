using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class VotosInsuficientesException : Exception
    {
        public int QtdaMinVotos { get; set; }
        public VotosInsuficientesException(int qtdaMin)
        {
            QtdaMinVotos = qtdaMin;
        }
    }
}