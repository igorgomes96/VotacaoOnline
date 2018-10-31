using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class FormatoDataInvalidoException : ExcelException
    {
        public string DataValor { get; set; }
        public FormatoDataInvalidoException(string aba, int linha, string data) : base(aba, linha)
        {
            DataValor = data;
        }
    }
}