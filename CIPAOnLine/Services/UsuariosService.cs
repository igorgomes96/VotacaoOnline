using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using System.Text;
using System.Threading;
using CIPAOnLine.DTO;
using CIPAOnLine.Resources;
using CIPAOnLine.Exceptions;

namespace CIPAOnLine.Services
{
    public class UsuariosService
    {
        private Modelo db = new Modelo();
        private AuthService authService = new AuthService();
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

        /// <summary>
        /// Cria um usuário administrador.
        /// </summary>
        /// <param name="user"></param>
        public void PostAdministrador(Usuario user)
        {
            bool usuarioExiste = true;
            Usuario userBD = db.Usuarios.Find(user.Login.Trim().ToLower());

            if (userBD == null) {
                userBD = authService.GetUserAD(user.Login);
                userBD.MatriculaFuncionario = null;
                if (userBD == null)
                    throw new UsuarioNaoEncontradoException();
                usuarioExiste = false;
            }

            userBD.Perfil = "Administrador";

            if (!usuarioExiste)
                db.Usuarios.Add(userBD);

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

            usuario.Perfil = "Eleitor";
            
            db.SaveChanges();


        }

        public bool UsuarioExiste(string login)
        {
            return db.Usuarios.Any(x => x.Login == login);
        }
    }
}