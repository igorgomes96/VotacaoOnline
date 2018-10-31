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
            MatriculaEleitor = v.MatriculaEleitor;
            MatriculaCandidato = v.MatriculaCandidato;
            CodigoEleicao = v.CodigoEleicao;
            DataHorario = v.DataHorario;
            IP = v.IP;
        }

        public VotoDTO(VotoBranco v)
        {
            if (v == null) return;
            MatriculaEleitor = v.MatriculaEleitor;
            MatriculaCandidato = null;
            CodigoEleicao = v.CodigoEleicao;
            DataHorario = v.DataHorario;
            IP = v.IP;
        }

        public string MatriculaEleitor { get; set; }
        public string MatriculaCandidato { get; set; }
        public int CodigoEleicao { get; set; }
        public DateTime DataHorario { get; set; }
        public string IP { get; set; }

    }
}