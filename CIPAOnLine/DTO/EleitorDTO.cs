using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class EleitorDTO : FuncionarioDTO
    {
        public EleitorDTO() { }
        public EleitorDTO(Voto v) : base(v.Eleitor)
        {
            DataHorario = v.DataHorario;
            IP = v.IP;
        }

        public EleitorDTO(VotoBranco v) : base(v.Eleitor)
        {
            DataHorario = v.DataHorario;
            IP = v.IP;
        }

        public DateTime DataHorario { get; set; }
        public string IP { get; set; }
    }
}