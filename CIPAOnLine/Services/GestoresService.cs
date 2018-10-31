using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Filters;
using System.Web.Http;

namespace CIPAOnLine.Services
{
    
    public class GestoresService
    {
        private Modelo db = new Modelo();

        public IEnumerable<Gestor> GetAll()
        {
            return db.Gestores.ToList();
        }

        public Gestor Get(int codigo)
        {
            return db.Gestores.Find(codigo);
        }

        public Gestor Get(string nome)
        {
            return db.Gestores.FirstOrDefault(x => x.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase));
        }

        [Authorize(Roles = "Administrador")]
        public Gestor Save(Gestor gestor)
        { 
            db.Gestores.AddOrUpdate(gestor);
            db.SaveChanges();

            return gestor;
        }

        
        public Gestor Delete (string nome)
        {
            Gestor g = Get(nome);
            if (g == null) throw new GestorNaoEncontradoException();
            db.Gestores.Remove(g);
            db.SaveChanges();
            return g;
        }

        public Gestor Delete (int codigo)
        {
            Gestor g = Get(codigo);
            if (g == null) throw new GestorNaoEncontradoException();
            db.Gestores.Remove(g);
            db.SaveChanges();
            return g;
        }

        public bool GestorNomeDuplicado(Gestor gestor)
        {
            Gestor g = Get(gestor.Nome);
            if (g == null) return false;
            return true;
        }
    }
}