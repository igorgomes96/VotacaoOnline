using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions { 

    public class FuncionarioInconsistenteException : Exception
    {
        public Funcionario FuncionarioAtual { get; set; }
        public Funcionario FuncionarioNovo { get; set; }

        public FuncionarioInconsistenteException(Funcionario funcionarioAtual, Funcionario funcionarioNovo): base()
        {
            FuncionarioAtual = funcionarioAtual;
            FuncionarioNovo = funcionarioNovo;
        }
    }
}