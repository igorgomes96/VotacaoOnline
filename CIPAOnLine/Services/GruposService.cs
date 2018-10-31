using CIPAOnLine.Models;
using System.Collections.Generic;
using System.Linq;

namespace CIPAOnLine.Services
{
    public class GruposService
    {
        private Modelo db = new Modelo();

        public IEnumerable<Grupo> GetGrupos()
        {
            return db.Grupos.ToList();
        }

        public bool GrupoExiste (string codigo)
        {
            return db.Grupos.Count(x => x.Codigo == codigo) > 0;
        }
    }
}