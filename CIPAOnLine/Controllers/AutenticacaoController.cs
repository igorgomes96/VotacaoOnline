using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Filters;
using CIPAOnLine.Models;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace CIPAOnLine.Controllers
{
    public class AutenticacaoController : ApiController
    {

        private UsuariosService usuariosService = new UsuariosService();
        private AuthService authService = new AuthService();
        private FuncionariosService funcionariosService = new FuncionariosService();

        [HttpPost]
        [Route("api/Autentica")]
        [AllowAnonymous]
        public IHttpActionResult Login(UsuarioSenhaDTO usuario)
        {
            if (usuario == null || usuario.Login == null || usuario.Senha == null) return BadRequest();

            Modelo db = new Modelo();
            Usuario user = null;

            SearchResult searchResult = authService.GetUserAD(usuario.Login, usuario.Senha);

            if (!authService.AuthenticateUserOnAD(searchResult))
                return BadRequest("Usuário ou senha incorretos!");

            try {
                Usuario userAD = authService.GetUserAD(usuario.Login);
                user = db.Usuarios.Find(usuario.Login);

                if (user == null)
                {
                    user = userAD;
                    user.MatriculaFuncionario = null;
                    Funcionario func = funcionariosService.GetByLogin(user.Login);

                    if (func != null) { 
                        user.Nome = func.Nome;
                        user.MatriculaFuncionario = func.MatriculaFuncionario;
                    }

                    user.Perfil = "Eleitor";
                    db.Usuarios.Add(user);
                }


                db.SaveChanges();
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }

            // Login : Expiration Time : Role
            string token = CryptoGraph.Encrypt(usuario.Login + ":" + DateTime.Now.AddHours(6).ToString("yyyyMMddHHmm") + ":" + (user == null ? "Eleitor" : "Administrador"));

            db.Dispose();

            return Ok(new
            {
                Token = token,
                Usuario = user.Nome,
                usuario.Login,
                user.MatriculaFuncionario,
                user.Perfil
            });
            
        }

    }
}
