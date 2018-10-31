using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class CandidatoDTO : FuncionarioDTO
    {

        public CandidatoDTO(){ }

        public CandidatoDTO(Candidato c) : base(c.Funcionario)
        {
            if (c == null) return;
            CodigoEleicao = c.CodigoEleicao;
            HorarioCandidatura = c.HorarioCandidatura;
            Validado = c.Validado;
            MotivoReprovacao = c.CandidaturasReprovadas?.FirstOrDefault()?.Motivo;
        }

        public int CodigoEleicao { get; set; }
        public DateTime HorarioCandidatura { get; set; }
        public bool? Validado { get; set; }
        public string MotivoReprovacao { get; set; }

    }
}