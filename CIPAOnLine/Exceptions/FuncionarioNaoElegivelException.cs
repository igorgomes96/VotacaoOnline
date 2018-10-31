using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class FuncionarioNaoElegivelException : Exception
    {
        public FuncionarioNaoElegivelException() { }
        public FuncionarioNaoElegivelException(string message) : base(message) { }
    }
}