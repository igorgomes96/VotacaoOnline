using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CIPAOnLine.Models;
using CIPAOnLine.DTO;
using CIPAOnLine.Filters;
using CIPAOnLine.Services;
using CIPAOnLine.Exceptions;

namespace CIPAOnLine.Controllers
{
    [AuthenticationFilter]
    public class UsuariosController : ApiController
    {
        private UsuariosService usuariosService = new UsuariosService();

        [Authorize(Roles = "Administrador")]
        public IEnumerable<UsuarioDTO> GetUsuarios(string matriculaFuncionario = null)
        {
            return usuariosService.GetUsuarios()
                .Where(x => matriculaFuncionario == null || x.MatriculaFuncionario == matriculaFuncionario)
                .Select(x => new UsuarioDTO(x));
        }

        [ResponseType(typeof(UsuarioDTO))]
        [HttpGet]
        [Route("api/Usuarios/{id}")]
        public IHttpActionResult GetUsuario(string id)
        {
            try { 
                return Ok(new UsuarioDTO(usuariosService.GetUsuario(id)));
            } catch (UsuarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Usuário não cadastrado!");
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [Route("api/Usuarios/Administradores")]
        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult GetAdministradores()
        {
            try
            {
                return Ok(usuariosService.GetAdministradores().Select(x => new UsuarioDTO(x)));
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Authorize(Roles = "Administrador")]
        [Route("api/Usuarios/Administradores")]
        [ResponseType(typeof(string))]
        public IHttpActionResult PostAdministrador(Usuario usuario)
        {
            try
            {
                usuariosService.PostAdministrador(usuario);
                return Ok();
            }
            catch (UsuarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.BadRequest, "Usuário de rede não encontrado!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }


        [Authorize(Roles = "Administrador")]
        [Route("api/Usuarios/{login}")]
        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult DeleteUsuario(string login)
        {
            try
            {
                return Ok(usuariosService.DeleteUsuario(login));
            }
            catch (UsuarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.BadRequest, "Usuário de rede não encontrado!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Authorize(Roles = "Administrador")]
        [Route("api/Usuarios/Administradores/{login}")]
        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult DeleteAdministrador(string login)
        {
            try
            {
                usuariosService.DeleteAdministrador(login);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }


    }
}