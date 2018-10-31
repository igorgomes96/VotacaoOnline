using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;

namespace CIPAOnLine.Services
{
    public class UnidadesService : IDisposable
    {
        Modelo db = new Modelo();

        public IEnumerable<Unidade> GetUnidades()
        {
            return db.Unidades.ToList();
        } 

        public Unidade GetUnidade(int codigo)
        {
            Unidade u = db.Unidades.Find(codigo);
            if (u == null) throw new UnidadeNaoEncontradaException();

            return u;
        }

        public Unidade SaveUnidade(Unidade unidade)
        {
            db.Unidades.AddOrUpdate(unidade);
            db.SaveChanges();
            return unidade;
        }

        public Unidade DeleteUnidade(int codigo)
        {
            Unidade u = GetUnidade(codigo);
            db.Unidades.Remove(u);
            db.SaveChanges();
            return u;
        }


        public bool UnidadeExiste (int codigo)
        {
            return db.Unidades.Count(x => x.Codigo == codigo) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}