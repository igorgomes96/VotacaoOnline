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

        public Funcionario GetFuncionario(int id)
        {
            Funcionario f = db.Funcionarios.Find(id);
            if (f == null) throw new FuncionarioNaoEncontradoException(id);
            return f;
        }

        public Funcionario GetFuncionario(string matricula, int codigoEmpresa)
        {
            Funcionario func = db.Funcionarios.FirstOrDefault(f => f.MatriculaFuncionario == matricula && f.CodigoEmpresa == codigoEmpresa);
            if (func == null) throw new FuncionarioNaoEncontradoException(matricula, codigoEmpresa);
            return func;
        }

        public Funcionario AddOrUpdateFuncionario(Funcionario func)
        {
            Funcionario funcionario = null;
            if (func == null) throw new Exception("Funcionário inválido!");
            try
            {
                if (func.Email != null)
                    func.Email = func.Email.Trim().ToLower();
                if (func.Login != null)
                    func.Login = func.Login.Trim().ToLower();

                funcionario = GetByLogin(func.Login);
                if (funcionario != null)
                {
                    if (func.MatriculaFuncionario != funcionario.MatriculaFuncionario)
                        throw new Exception($"Já existe um funcionário cadastrado com esse mesmo login ({func.Login}) porém com matrícula diferente: {funcionario.MatriculaFuncionario}, empresa {funcionario.Empresa?.Codigo} - {funcionario.Empresa?.RazaoSocial}.");

                    func.Id = funcionario.Id;
                    if (func.Thumbnail == null)
                        func.Thumbnail = funcionario.Thumbnail;
                }
            }
            catch (FuncionarioNaoEncontradoException) { }

            Usuario user = db.Usuarios.Find(func.Login);

            // Verifica se já há um funcionário com a mesma matrícula em outra empresa
            var mesmaMatricula = db.Funcionarios.Where(f => f.MatriculaFuncionario == func.MatriculaFuncionario).ToList();
            if (mesmaMatricula.Count() > 1)
            {
                var empresas = mesmaMatricula.Select(f => f.CodigoEmpresa.ToString()).Aggregate("", (acc, curr) => acc + ", " + curr).Substring(2);
                var logins = mesmaMatricula.Select(f => f.Login).Aggregate("", (acc, curr) => acc + ", " + curr).Substring(2);
                throw new Exception($"O funcionário {func.Nome} ({func.MatriculaFuncionario}) está cadastrado em diferentes empresas ({empresas}), com diferente logins ({logins}), porém com a mesma matícula. Favor, corrija o cadastro em \"Base Geral\" e tente novamente.");
            }

            // Se o usuário for administrador, não muda a empresa
            if (user != null && user.Perfil == Perfil.ADMINISTRADOR && funcionario != null)
            {
                func.CodigoEmpresa = funcionario.CodigoEmpresa;
            }

            db.Funcionarios.AddOrUpdate(func);


            if (user != null)
            {
                user.FuncionarioId = func.Id;
                user.Nome = func.Nome;
            }

            db.SaveChanges();

            return func;
        }

        public FuncionarioFoto AddOrUpdateFuncionarioFoto(FuncionarioFoto func)
        {
            if (!FuncionarioExiste(func.FuncionarioId))
                throw new FuncionarioNaoEncontradoException(func.FuncionarioId);

            db.FuncionariosFotos.AddOrUpdate(func);
            db.SaveChanges();

            return func;
        }

        public Funcionario Delete(int funcionarioId)
        {
            Funcionario f = GetFuncionario(funcionarioId);
            Eleicao e = db.Eleicoes.FirstOrDefault(x => x.Funcionarios.Any(y => y.Id == funcionarioId));
            if (e != null)
                throw new Exception($"Não é possível excluir esse funcionário pois ele está cadastrado na eleição #{e.Codigo} (gestão {e.Gestao}).");

            Usuario u = db.Usuarios.FirstOrDefault(x => x.FuncionarioId == f.Id);
            if (u != null)
                u.FuncionarioId = null;
            db.Entry(f).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return f;
        }

        public bool FuncionarioExiste(string matricula, int codigoEmpresa)
        {
            return db.Funcionarios.Any(x => x.MatriculaFuncionario == matricula && x.CodigoEmpresa == codigoEmpresa);
        }

        public bool FuncionarioExiste(int id)
        {
            return db.Funcionarios.Any(x => x.Id == id);
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