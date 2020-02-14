using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;

namespace CIPAOnLine.Services
{
    public class UsuariosService
    {
        private Modelo db = new Modelo();
        private FuncionariosService funcionariosService = new FuncionariosService();
        
        public IEnumerable<Usuario> GetAdministradores()
        {
            return db.Usuarios.Where(x => x.Perfil == "Administrador").ToList();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return db.Usuarios.ToList();
        }

        public Usuario GetUsuario(string login)
        {
            Usuario u = db.Usuarios.Find(login);
            if (u == null) throw new UsuarioNaoEncontradoException();
            return u;
        }

        private void AddEmpresas(Usuario usuario, List<int> codigosEmpresas)
        {
            codigosEmpresas.ForEach(c =>
            {
                Empresa e = db.Empresas.Find(c);
                usuario.Empresas.Add(e);
            });
        }

        /// <summary>
        /// Cria um usuário administrador.
        /// </summary>
        /// <param name="user"></param>
        public void PostAdministrador(UsuarioDTO user)
        {

            bool funcionarioExistente = false;
            user.Login = user.Login.Trim().ToLower();
            user.Email = user.Email.Trim().ToLower();
            Usuario userBD = db.Usuarios.Find(user.Login);

            if (user.FuncionarioId.HasValue)
                funcionarioExistente = funcionariosService.FuncionarioExiste(user.FuncionarioId.Value);
            else
                funcionarioExistente = funcionariosService.FuncionarioExiste(user.MatriculaFuncionario, user.CodigoEmpresa);

            if (!funcionarioExistente)
            {
                Funcionario funcLogin = funcionariosService.GetByLogin(user.Login);
                if (funcLogin != null)
                    throw new Exception("Já existe outro usuário cadastrado com esse Login!");

                Funcionario funcionario = new Funcionario()
                {
                    MatriculaFuncionario = user.MatriculaFuncionario,
                    Nome = user.Nome,
                    Email = user.Email,
                    Login = user.Login,
                    CodigoEmpresa = user.CodigoEmpresa
                };
                funcionariosService.AddOrUpdateFuncionario(funcionario);
            } else
            {
                Funcionario func = null;
                if (user.FuncionarioId.HasValue)
                    func = funcionariosService.GetFuncionario(user.FuncionarioId.Value);
                else
                    func = funcionariosService.GetFuncionario(user.MatriculaFuncionario, user.CodigoEmpresa);

                func.CodigoEmpresa = user.CodigoEmpresa;
                func.Nome = user.Nome;
                func.Email = user.Email;
                funcionariosService.AddOrUpdateFuncionario(func);
            }

            if (userBD != null)
            {
                userBD.Nome = user.Nome;
                userBD.Perfil = Perfil.ADMINISTRADOR;
                userBD.Empresas.Clear();
                AddEmpresas(userBD, user.Empresas.Select(e => e.Codigo).ToList());
                db.SaveChanges();
                return;
            }

           
            userBD = new Usuario
            {
                Nome = user.Nome,
                Login = user.Login,
                FuncionarioId = user.FuncionarioId,
                Perfil = Perfil.ADMINISTRADOR
            };

            db.Usuarios.Add(userBD);
            db.SaveChanges();

            AddEmpresas(userBD, user.Empresas.Select(e => e.Codigo).ToList());

            db.SaveChanges();

        }

        public void AddOrUpdateUsuario(Usuario usuario)
        {
            db.Usuarios.AddOrUpdate(usuario);
            db.SaveChanges();
        }

        public Usuario PutAdministrador(Usuario user)
        {
            Usuario usuario = db.Usuarios.Find(user.Login);
            if (usuario == null) throw new UsuarioNaoEncontradoException();

            usuario.Nome = user.Nome;
            usuario.Perfil = "Administrador";

            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return usuario;

        }

        public UsuarioDTO DeleteUsuario(string login)
        {
            Usuario usuario = GetUsuario(login);

            if (usuario == null) throw new UsuarioNaoEncontradoException();

            UsuarioDTO user = new UsuarioDTO(usuario);

            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return user;

        }

        public void DeleteAdministrador(string login)
        {
            Usuario usuario = GetUsuario(login);

            if (usuario == null) throw new UsuarioNaoEncontradoException();

            usuario.Perfil = Perfil.ELEITOR;

            db.SaveChanges();


        }

        public void AddPermissaoEmpresa(string login, int codigoEmpresa)
        {
            Usuario usuario = db.Usuarios.FirstOrDefault(u => u.Login == login);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException();

            Empresa empresa = db.Empresas.Find(codigoEmpresa);
            if (empresa == null)
                throw new EmpresaNaoEncontradaException();

            if (!usuario.Empresas.Any(e => e.Codigo == codigoEmpresa)) { 
                usuario.Empresas.Add(empresa);
                db.SaveChanges();
            }
        }

        public bool UsuarioExiste(string login)
        {
            return db.Usuarios.Any(x => x.Login == login);
        }
    }
}