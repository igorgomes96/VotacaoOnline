using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class EleicaoQtdaRepresentantesDTO
    {
        public EleicaoQtdaRepresentantesDTO() { }
        public EleicaoQtdaRepresentantesDTO(Eleicao e, int efetivos, int suplentes)
        {
            if (e == null) return;
            Codigo = e.Codigo;
            Gestao = e.Gestao;
            CodigoUnidade = e.CodigoUnidade;
            CodigoModulo = e.CodigoModulo;
            Efetivos = efetivos;
            Suplentes = suplentes;
        }
        public int Codigo { get; set; }
        public int CodigoUnidade { get; set; }
        public int CodigoModulo { get; set; }
        public string Gestao { get; set; }
        public int Efetivos { get; set; }
        public int Suplentes { get; set; }
    }
}