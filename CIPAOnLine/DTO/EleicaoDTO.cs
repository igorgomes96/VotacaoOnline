﻿using CIPAOnLine.Models;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class EleicaoDTO
    {
        public EleicaoDTO()
        {
            PrazosEtapasObj = new HashSet<PrazosEtapasDTO>();
        }

        public EleicaoDTO(Eleicao e, QtdaEleicaoDTO qtda)
        {
            Load(e);
            QtdaEleicao = qtda;
        }


        public EleicaoDTO(Eleicao e)
        {
            Load(e);
        }

        private void Load(Eleicao e)
        {
            EtapasService etapasService = new EtapasService();
            PrazosEtapasObj = new HashSet<PrazosEtapasDTO>();

            if (e == null) return;
            Codigo = e.Codigo;
            Gestao = e.Gestao;
            DataInicio = e.DataInicio;
            DataFechamento = e.DataFechamento;
            CodigoEtapa = e.CodigoEtapa;
            CodigoUnidade = e.CodigoUnidade;
            CodigoModulo = e.CodigoModulo;
            CodigoSindicato = e.CodigoSindicato;
            if (e.Modulo != null)
            {
                NomeModulo = e.Modulo.NomeModulo;
            }
            if (e.EtapaAtual != null)
            {
                NomeEtapa = e.EtapaAtual.NomeEtapa;
            }
            if (e.Unidade != null)
            {
                UnidadeObj = new UnidadeDTO(e.Unidade);
            }
            if (e.Sindicato != null)
            {
                SindicatoObj = new SindicatoDTO(e.Sindicato);
            }

            foreach (Etapa etapa in etapasService.GetEtapas(CodigoModulo))
            {
                PrazoEtapa concluida = e.PrazosEtapas?.FirstOrDefault(x => x.CodigoEtapa == etapa.CodigoEtapa);

                ((HashSet<PrazosEtapasDTO>)PrazosEtapasObj).Add(new PrazosEtapasDTO
                {
                    CodigoEtapa = etapa.CodigoEtapa,
                    CodigoEleicao = Codigo,
                    NomeEtapa = etapa.NomeEtapa,
                    DataRealizada = concluida?.DataRealizada,
                    DataProposta = concluida?.DataProposta,
                    Ordem = concluida?.Etapa.Ordem != null ? concluida.Etapa.Ordem.Value : (concluida?.Etapa?.CodigoEtapa != null ? concluida.Etapa.CodigoEtapa : 0),
                    CodigoTemplate = etapa.CodigoTemplate
                });
            }
        }

        public int Codigo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFechamento { get; set; }
        public int? CodigoEtapa { get; set; }
        public string NomeEtapa { get; set; }
        public int CodigoUnidade { get; set; }
        public int CodigoModulo { get; set; }
        public string NomeModulo { get; set; }
        public int? CodigoSindicato { get; set; }
        public string Gestao { get; set; }
        public QtdaEleicaoDTO QtdaEleicao { get; set; }
        public IEnumerable<PrazosEtapasDTO> PrazosEtapasObj { get; set; }
        public UnidadeDTO UnidadeObj { get; set; }
        public SindicatoDTO SindicatoObj { get; set; }

    }
}