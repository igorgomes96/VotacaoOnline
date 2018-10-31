using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class EtapaDTO
    {
        public EtapaDTO() { }
        public EtapaDTO(Etapa etapa)
        {
            if (etapa == null) return;
            CodigoEtapa = etapa.CodigoEtapa;
            NomeEtapa = etapa.NomeEtapa;
            DiasPrazo = etapa.DiasPrazo;
            CodigoModulo = etapa.CodigoModulo;
            CodigoTemplate = etapa.CodigoTemplate;
        }
        public int CodigoEtapa { get; set; }
        public string NomeEtapa { get; set; }
        public int? DiasPrazo { get; set; }
        public int CodigoModulo { get; set; }
        public int? CodigoTemplate { get; set; }
    }
}