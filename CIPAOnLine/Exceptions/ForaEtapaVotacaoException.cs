using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class ForaEtapaVotacaoException : Exception
    {
        public Eleicao Eleicao { get; set; }
        public ForaEtapaVotacaoException(Eleicao eleicao) : base()
        {
            Eleicao = eleicao;
        }
    }
}