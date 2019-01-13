using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CIPAOnLine.Services
{
    public class EmpresasService
    {

        private Modelo db = new Modelo();

        public IEnumerable<Empresa> GetAll(IPrincipal user)
        {
            Usuario usuario = db.Usuarios.Find(user.Identity.Name);
            if (usuario == null) throw new UsuarioNaoEncontradoException();
            return usuario.Empresas.ToList();
        }

        public Empresa Get(int codigo)
        {
            return db.Empresas.Find(codigo);
        }

        public Empresa Get(string nome)
        {
            return db.Empresas.FirstOrDefault(x => x.RazaoSocial.Equals(nome, StringComparison.InvariantCultureIgnoreCase));
        }

        public Empresa Save(Empresa empresa)
        {
            db.Empresas.AddOrUpdate(empresa);
            db.SaveChanges();

            return empresa;
        }


        public Empresa Delete(string nome)
        {
            Empresa g = Get(nome);
            if (g == null) throw new EmpresaNaoEncontradaException();
            db.Empresas.Remove(g);
            db.SaveChanges();
            return g;
        }

        public Empresa Delete(int codigo)
        {
            Empresa g = Get(codigo);
            if (g == null) throw new EmpresaNaoEncontradaException();
            db.Empresas.Remove(g);
            db.SaveChanges();
            return g;
        }

        public bool EmpresaNomeDuplicado(Empresa empresa)
        {
            Empresa g = Get(empresa.RazaoSocial);
            if (g == null) return false;
            return true;
        }

    }
}