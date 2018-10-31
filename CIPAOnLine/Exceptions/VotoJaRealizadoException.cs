using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class VotoJaRealizadoException : Exception
    {
        public Funcionario Funcionario { get; set; }
        public Eleicao Eleicao { get; set; }
        public VotoJaRealizadoException(Funcionario func, Eleicao ele) : base()
        {
            Funcionario = func;
            Eleicao = ele;
        }
    }
}