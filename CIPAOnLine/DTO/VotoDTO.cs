using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class VotoDTO
    {
        public VotoDTO() { }

        public VotoDTO (Voto v)
        {
            if (v == null) return;
            FuncionarioIdEleitor = v.FuncionarioIdEleitor;
            FuncionarioIdCandidato = v.FuncionarioIdCandidato;
            MatriculaEleitor = v.Eleitor?.MatriculaFuncionario;
            FuncionarioIdCandidato = v.Candidato?.FuncionarioId;
            MatriculaCandidato = v.Candidato?.Funcionario.MatriculaFuncionario;
            CodigoEleicao = v.CodigoEleicao;
            DataHorario = v.DataHorario;
            IP = v.IP;
        }

        public VotoDTO(VotoBranco v)
        {
            if (v == null) return;
            FuncionarioIdEleitor = v.Eleitor?.Id;
            MatriculaEleitor = v.Eleitor?.MatriculaFuncionario;
            FuncionarioIdCandidato = null;
            MatriculaCandidato = null;
            CodigoEleicao = v.CodigoEleicao;
            DataHorario = v.DataHorario;
            IP = v.IP;
        }

        public int? FuncionarioIdEleitor { get; set; }
        public string MatriculaEleitor { get; set; }
        public int? FuncionarioIdCandidato { get; set; }
        public string MatriculaCandidato { get; set; }
        public int CodigoEleicao { get; set; }
        public DateTime DataHorario { get; set; }
        public string IP { get; set; }

    }
}