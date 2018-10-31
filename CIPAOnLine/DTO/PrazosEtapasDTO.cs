using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class PrazosEtapasDTO
    {
        public PrazosEtapasDTO() { }
        public PrazosEtapasDTO(PrazoEtapa p)
        {
            if (p == null) return;
            CodigoEleicao = p.CodigoEleicao;
            CodigoEtapa = p.CodigoEtapa;
            DataRealizada = p.DataRealizada;
            DataProposta = p.DataProposta;
            if (p.Etapa != null) { 
                Ordem = p.Etapa.CodigoEtapa;
                NomeEtapa = p.Etapa.NomeEtapa;
                CodigoTemplate = p.Etapa.CodigoTemplate;
            }
        }

        public PrazoEtapa GetPrazoEtapa()
        {
            PrazoEtapa p = new PrazoEtapa
            {
                CodigoEleicao = CodigoEleicao,
                CodigoEtapa = CodigoEtapa,
                DataRealizada = DataRealizada,
                DataProposta = DataProposta
            };

            return p;
            
        }

        public int CodigoEleicao { get; set; }
        public int CodigoEtapa { get; set; }
        public string NomeEtapa { get; set; }
        public DateTime? DataRealizada{ get; set; }
        public DateTime? DataProposta { get; set; }
        public int Ordem { get; set; }
        public int? CodigoTemplate { get; set; }
    }
}