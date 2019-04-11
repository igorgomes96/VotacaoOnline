using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Services
{
    public class EtapasService : IDisposable
    {
        private Modelo db = new Modelo();

        public IEnumerable<Etapa> GetEtapas(int codModulo)
        {
            return db.Etapas.ToList()
                .Where(x => x.CodigoModulo == codModulo).OrderBy(x => x.Ordem).ThenBy(x => x.CodigoEtapa);
        }

        public Etapa GetEtapa(string nomeEtapa)
        {
            return db.Etapas.Find(nomeEtapa);
        }

        public Etapa ProximaEtapa(Etapa etapa)
        {
            return db.Etapas.ToList()
                .Where(x => x.CodigoEtapa > etapa.CodigoEtapa)
                .OrderBy(x => x.CodigoEtapa)
                .FirstOrDefault();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}