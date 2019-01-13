using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class FuncionarioNaoEncontradoException : Exception
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public int CodigoEmpresa { get; set; }

        public FuncionarioNaoEncontradoException (string matricula, int codigoEmpresa) : base()
        {
            Matricula = matricula;
            CodigoEmpresa = codigoEmpresa;
        }

        public FuncionarioNaoEncontradoException(int id) : base()
        {
            Id = id;
        }
    }
}