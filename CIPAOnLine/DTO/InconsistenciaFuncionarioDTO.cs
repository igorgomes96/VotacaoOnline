using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.DTO
{
    public class InconsistenciaFuncionarioDTO
    {
        public FuncionarioDTO Atual { get; set; }
        public FuncionarioDTO Novo { get; set; }
        public InconsistenciaFuncionarioDTO(Funcionario atual, Funcionario novo)
        {
            Atual = new FuncionarioDTO(atual);
            Novo = new FuncionarioDTO(novo);
        }
    }
}