using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class UnidadeNaoEncontradaException : Exception
    {
        public int Codigo { get; set; }
        public UnidadeNaoEncontradaException() : base() { }
        public UnidadeNaoEncontradaException(int codigo) : base()
        {
            Codigo = codigo;
        }
    }
}