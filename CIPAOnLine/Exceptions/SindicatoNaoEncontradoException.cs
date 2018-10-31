using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class SindicatoNaoEncontradoException : Exception
    {
        public int CodSindicato { get; set; }

        public SindicatoNaoEncontradoException() : base() { }

        public SindicatoNaoEncontradoException(int codigo) : base()
        {
            CodSindicato = codigo;
        }
    }
}