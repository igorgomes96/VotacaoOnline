using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class CandidatosInsuficientesException : Exception
    {
        public int QtdaCandidatos { get; set; }
        public int QtdaEfetivos { get; set; }
        public int QtdaSuplentes { get; set; }

        public CandidatosInsuficientesException(int qtdaCandidatos, int qtdaEfetivos, int qtdaSuplentes) : base()
        {
            QtdaCandidatos = qtdaCandidatos;
            QtdaEfetivos = qtdaEfetivos;
            QtdaSuplentes = qtdaSuplentes;
        }
    }
}