using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class EleicaoJaCadastradaException : Exception
    {
        public Eleicao Eleicao { get; set; }
        public EleicaoJaCadastradaException() :base() { }
        public EleicaoJaCadastradaException(Eleicao eleicao) : base()
        {
            Eleicao = eleicao;
        }
    }
}