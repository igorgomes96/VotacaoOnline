using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class FuncionarioNaoCadastradoEleicaoException : Exception
    {
        public int FuncionarioId { get; set; }
        public int CodigoEleicao { get; set; }
        public FuncionarioNaoCadastradoEleicaoException(int funcionarioId, int codEleicao) : base()
        {
            FuncionarioId = funcionarioId;
            CodigoEleicao = codEleicao;
        } 
    }
}