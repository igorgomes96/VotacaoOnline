using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class TotalFuncionariosEleitoresDTO
    {
        public TotalFuncionariosEleitoresDTO() { }

        public int TotalFuncionarios { get; set; }
        public int TotalEleitores { get; set; }
        public int CodigoEleicao { get; set; }
    }
}