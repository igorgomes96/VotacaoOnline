using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace CIPAOnLine.Services
{
    public class SindicatosService : IDisposable
    {
        private Modelo db = new Modelo();

        public IEnumerable<Sindicato> GetAllSindicatos()
        {
            return db.Sindicatos.ToList();
        }

        public Sindicato GetSindicato(int codigo)
        {
            Sindicato s = db.Sindicatos.Find(codigo);
            if (s == null) throw new SindicatoNaoEncontradoException(codigo);
            return s;
        }

        public Sindicato SaveSindicato(Sindicato sindicato)
        {
            db.Sindicatos.AddOrUpdate(sindicato);
            db.SaveChanges();
            return sindicato;
        }

        public Sindicato DeleteSindicato (int codigo)
        {
            Sindicato s = db.Sindicatos.Find(codigo);
            if (s == null) throw new SindicatoNaoEncontradoException(codigo);
            db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return s;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool SindicatoExiste(int codigo)
        {
            return db.Sindicatos.Count(x => x.Codigo == codigo) > 0;
        }
    }
}