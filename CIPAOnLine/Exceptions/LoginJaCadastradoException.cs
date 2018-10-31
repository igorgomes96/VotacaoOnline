using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class LoginJaCadastradoException : Exception
    {
        public Funcionario Funcionario { get; set; }
        public LoginJaCadastradoException (Funcionario funcionario) : base()
        {
            Funcionario = funcionario;
        }
    }
}