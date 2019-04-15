using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class FuncionarioNaoElegivelException : Exception
    {
        public FuncionarioNaoElegivelException(): base("Funcionário não é elegível para esta eleição.") { }
        public FuncionarioNaoElegivelException(string message) : base(message) { }
    }
}