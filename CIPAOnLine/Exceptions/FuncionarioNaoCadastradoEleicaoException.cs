using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class FuncionarioNaoCadastradoEleicaoException : Exception
    {
        public string MatriculaFuncionario { get; set; }
        public int CodigoEleicao { get; set; }
        public FuncionarioNaoCadastradoEleicaoException(string matricula, int codEleicao) : base()
        {
            MatriculaFuncionario = matricula;
            CodigoEleicao = codEleicao;
        } 
    }
}