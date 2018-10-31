using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class CandidaturaReprovadaDTO
    {

        public CandidaturaReprovadaDTO() { }
        public CandidaturaReprovadaDTO(CandidaturaReprovada cand)
        {
            if (cand == null) return;
            Codigo = cand.Codigo;
            MatriculaFuncionario = cand.MatriculaFuncionario;
            CodigoEleicao = cand.CodigoEleicao;
            Motivo = cand.Motivo;
        }
        public int Codigo { get; set; }
        public string MatriculaFuncionario { get; set; }
        public int CodigoEleicao { get; set; }
        public string Motivo { get; set; }
    }
}