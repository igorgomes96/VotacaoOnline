using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Filters;
using CIPAOnLine.Jwt;
using CIPAOnLine.Models;
using CIPAOnLine.Resources;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace CIPAOnLine.Controllers
{
    public class AutenticacaoController : ApiController
    {

        private UsuariosService usuariosService = new UsuariosService();
        private AuthService authService = new AuthService();
        private FuncionariosService funcionariosService = new FuncionariosService();

        //[HttpPost]
        //[Route("api/Autentica")]
        //[AllowAnonymous]
        //public IHttpActionResult Login(UsuarioSenhaDTO usuario)
        //{
        //    if (usuario == null || usuario.Login == null || usuario.Senha == null) return BadRequest();

        //    Modelo db = new Modelo();
        //    Usuario user = null;

        //    SearchResult searchResult = authService.GetUserAD(usuario.Login, usuario.Senha);

        //    if (!authService.AuthenticateUserOnAD(searchResult))
        //        return BadRequest("Usuário ou senha incorretos!");

        //    try {
        //        Usuario userAD = authService.GetUserAD(usuario.Login);
        //        user = db.Usuarios.Find(usuario.Login);

        //        if (user == null)
        //        {
        //            user = userAD;
        //            user.MatriculaFuncionario = null;
        //            Funcionario func = funcionariosService.GetByLogin(user.Login);

        //            if (func != null) { 
        //                user.Nome = func.Nome;
        //                user.MatriculaFuncionario = func.MatriculaFuncionario;
        //            }

        //            user.Perfil = "Eleitor";
        //            db.Usuarios.Add(user);
        //        }


        //        db.SaveChanges();
        //    } catch (Exception e)
        //    {
        //        return Content(HttpStatusCode.InternalServerError, e);
        //    }

        //    // Login : Expiration Time : Role
        //    string token = CryptoGraph.Encrypt(usuario.Login + ":" + DateTime.Now.AddHours(6).ToString("yyyyMMddHHmm") + ":" + (user == null ? "Eleitor" : "Administrador"));

        //    db.Dispose();

        //    return Ok(new
        //    {
        //        Token = token,
        //        Usuario = user.Nome,
        //        usuario.Login,
        //        user.MatriculaFuncionario,
        //        user.Perfil
        //    });

        //}

        [HttpPost]
        [Route("api/Autenticacao/PrimeiroAcesso")]
        [AllowAnonymous]
        public IHttpActionResult PrimeiroAcesso(UsuarioDTO usuario)
        {
            if (usuario == null) return BadRequest("Usuário não informado!");
            usuario.Login = usuario.Login.ToLower();
            bool usuarioExiste = usuariosService.UsuarioExiste(usuario.Login);
            Funcionario funcionario;
            if (!usuarioExiste)
            {
                if (!funcionariosService.FuncionarioExiste(usuario.MatriculaFuncionario, usuario.CodigoEmpresa))
                    return BadRequest($"Matrícula {usuario.MatriculaFuncionario} não cadastrada!");

                funcionario = funcionariosService.GetFuncionario(usuario.MatriculaFuncionario, usuario.CodigoEmpresa);
                funcionario.Email = usuario.Email;
                funcionariosService.AddOrUpdateFuncionario(funcionario);

                Usuario novoUsuario = new Usuario
                {
                    Login = usuario.Login,
                    FuncionarioId = funcionario.Id,
                    Nome = funcionario.Nome,
                    Perfil = Perfil.ELEITOR,
                    Senha = CryptoGraph.Encrypt(usuario.Senha)
                };
                usuariosService.AddOrUpdateUsuario(novoUsuario);

                return Ok();
            }

            if (!funcionariosService.FuncionarioExiste(usuario.MatriculaFuncionario, usuario.CodigoEmpresa))
                return BadRequest($"Matrícula {usuario.MatriculaFuncionario} não cadastrada!");

            funcionario = funcionariosService.GetFuncionario(usuario.MatriculaFuncionario, usuario.CodigoEmpresa);
            funcionario.Email = usuario.Email;
            funcionariosService.AddOrUpdateFuncionario(funcionario);

            Usuario usuarioDB = usuariosService.GetUsuario(usuario.Login);
            usuarioDB.Senha = CryptoGraph.Encrypt(usuario.Senha);
            usuariosService.AddOrUpdateUsuario(usuarioDB);
            return Ok();


        }

        private static string GetCodigo(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*:.,-".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        [HttpPost]
        [Route("api/Autenticacao/RecuperarSenha")]
        [AllowAnonymous]
        public IHttpActionResult RecuperarSenha(UsuarioSenhaDTO usuario)
        {
            if (string.IsNullOrEmpty(usuario.Login))
                return BadRequest("É necessário informar o login!");

            if (string.IsNullOrEmpty(usuario.Senha))
                return BadRequest("É necessário informar a senha!");

            if (string.IsNullOrEmpty(usuario.CodigoRecuperacao))
                return BadRequest("É necessário informa o código de recuperação!");

            try
            {
                Usuario usuarioDB = usuariosService.GetUsuario(usuario.Login);
                if (usuario.CodigoRecuperacao != usuarioDB.CodigoRecuperacao)
                    return BadRequest("Código de Recuperação inválido!");

                usuarioDB.Senha = CryptoGraph.Encrypt(usuario.Senha);
                usuarioDB.CodigoRecuperacao = null;
                usuariosService.AddOrUpdateUsuario(usuarioDB);
                return Ok("Senha alterada com Sucesso!");
            }
            catch (UsuarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Usuário não encontrado!");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("api/Autenticacao/EnviarCodigo")]
        [AllowAnonymous]
        public IHttpActionResult EnviarCodigo(UsuarioDTO usuario)
        {
            Usuario usuarioDB = null;
            try { 
                usuarioDB = usuariosService.GetUsuario(usuario.Login);
            } catch (UsuarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Usuário não encontrado!");
            }

            if (usuarioDB == null)
                return BadRequest("Usuário não cadastrado!");

            if (usuarioDB.Funcionario == null)
                return BadRequest("Matrícula não cadastrada!");

            if (string.IsNullOrEmpty(usuarioDB.Funcionario.Email))
                return BadRequest("E-mail não cadastrado na base!");

            string codigo = GetCodigo(8);

            usuarioDB.CodigoRecuperacao = codigo;
            usuariosService.AddOrUpdateUsuario(usuarioDB);

            EmailDTO email = new EmailDTO
            {
                To = new List<string>() { usuarioDB.Funcionario.Email },
                Subject = "[Sistema de Votação Online] Código de Recuperação",
                Message = Emails.RecoverySenha.Replace("@CODIGO", codigo)
            };
            EmailService.Send(email);

            return Ok();
        }

        [HttpPost]
        [Route("api/Autenticacao/Login")]
        [AllowAnonymous]
        public IHttpActionResult Login(UsuarioSenhaDTO usuario)
        {
            if (usuario == null || usuario.Login == null || usuario.Senha == null) return BadRequest();

            Modelo db = new Modelo();
            Usuario user = null;

            try
            {
                user = db.Usuarios.Find(usuario.Login);

                if (user == null)
                    return BadRequest("Usuário não encontrado!");

                string senhaCrypt = CryptoGraph.Encrypt(usuario.Senha);

                if (user.Senha != senhaCrypt)
                    return BadRequest("Senha incorreta!");

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }

            string token = TokenServices.GenerateToken(user.Login, roles: user.Perfil);

            var userObj = new
            {
                Token = token,
                Usuario = user.Nome,
                usuario.Login,
                user.FuncionarioId,
                user.Funcionario?.MatriculaFuncionario,
                user.Funcionario?.CodigoEmpresa,
                user.Perfil
            };
            db.Dispose();

            return Ok(userObj);

        }


    }
}
