using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class CandidatoFotoDTO : FuncionarioDTO
    {

        public CandidatoFotoDTO(Candidato c) : base(c.Funcionario)
        {
            if (c == null) return;
            CodigoEleicao = c.CodigoEleicao;
            HorarioCandidatura = c.HorarioCandidatura;
            Validado = c.Validado;
            Foto = c.Funcionario?.FuncionarioFoto?.Foto;
            MotivoReprovacao = c.CandidaturasReprovadas?.FirstOrDefault()?.Motivo;
        }

        public int CodigoEleicao { get; set; }
        public DateTime HorarioCandidatura { get; set; }
        public bool? Validado { get; set; }
        public byte[] Foto { get; set; }
        public string MotivoReprovacao { get; set; }
    }
}