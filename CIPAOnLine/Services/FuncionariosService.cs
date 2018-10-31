using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using CIPAOnLine.DTO;
using System.Diagnostics;

namespace CIPAOnLine.Services
{
    public class FuncionariosService : IDisposable
    {
        private Modelo db = new Modelo();


        public Funcionario GetFuncionario(string matricula)
        {
            matricula = string.Concat(matricula.SkipWhile(c => c == '0'));
            Funcionario f = db.Funcionarios.Find(matricula);
            if (f == null) throw new FuncionarioNaoEncontradoException(matricula);
            return f;
        }

        public Funcionario AddOrUpdateFuncionario(Funcionario func)
        {
            try
            {
                func.MatriculaFuncionario = string.Concat(func.MatriculaFuncionario.SkipWhile(c => c == '0'));

                Usuario user = db.Usuarios.Find(func.Login);
                if (user != null) { 
                    user.MatriculaFuncionario = func.MatriculaFuncionario;
                    user.Nome = func.Nome;
                }

                Funcionario funcionario = GetFuncionario(func.MatriculaFuncionario);
                if (func.Thumbnail == null)
                    func.Thumbnail = funcionario.Thumbnail;
            }
            catch (FuncionarioNaoEncontradoException) { }

            db.Funcionarios.AddOrUpdate(func);
            db.SaveChanges();
            return func;
        }

        public FuncionarioFoto AddOrUpdateFuncionarioFoto(FuncionarioFoto func)
        {
            if (!FuncionarioExiste(func.MatriculaFuncionario))
                throw new FuncionarioNaoEncontradoException(func.MatriculaFuncionario);

            db.FuncionariosFotos.AddOrUpdate(func);
            db.SaveChanges();

            return func;
        }

        public Funcionario Delete(string matricula)
        {
            Funcionario f = GetFuncionario(matricula);
            Eleicao e = db.Eleicoes.FirstOrDefault(x => x.Funcionarios.Any(y => y.MatriculaFuncionario == matricula));
            if (e != null)
                throw new Exception($"Não é possível excluir esse funcionário pois ele está cadastrado na eleição #{e.Codigo} (gestão {e.Gestao}).");

            Usuario u = db.Usuarios.FirstOrDefault(x => x.MatriculaFuncionario == f.MatriculaFuncionario);
            if (u != null)
                u.MatriculaFuncionario = null;
            db.Entry(f).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return f;
        }
        
        public bool FuncionarioExiste(string matricula)
        {
            return db.Funcionarios.Count(x => x.MatriculaFuncionario == matricula) > 0;
        }

        public Funcionario GetByLogin(string login)
        {
            Funcionario func = db.Funcionarios.FirstOrDefault(x => x.Login == login);
            return func;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}