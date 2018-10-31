using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Exceptions
{
    public class AntesDataPrevistaException : Exception
    {
        public DateTime DataPrevista { get; set; }
        public AntesDataPrevistaException(DateTime data)
        {
            DataPrevista = data;
        }
    }
}