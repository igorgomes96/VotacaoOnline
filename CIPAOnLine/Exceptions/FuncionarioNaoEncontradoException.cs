using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class FuncionarioNaoEncontradoException : Exception
    {
        public string Matricula { get; set; }
        public FuncionarioNaoEncontradoException (string matricula) : base()
        {
            Matricula = matricula;
        }
    }
}