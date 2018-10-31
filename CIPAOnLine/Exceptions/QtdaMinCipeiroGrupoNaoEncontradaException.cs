using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class QtdaMinCipeiroGrupoNaoEncontradaException : Exception
    {
        public string CodigoGrupo { get; set; }
        public int QtdaFuncionarios { get; set; }
        public QtdaMinCipeiroGrupoNaoEncontradaException() : base () { }
        public QtdaMinCipeiroGrupoNaoEncontradaException(string codigoGrupo, int qtdaFuncionarios) : base()
        {
            CodigoGrupo = codigoGrupo;
            QtdaFuncionarios = qtdaFuncionarios;
        }
    }
}