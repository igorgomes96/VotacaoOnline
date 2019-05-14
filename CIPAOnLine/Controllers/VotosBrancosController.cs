using CIPAOnLine.Exceptions;
using CIPAOnLine.Filters;
using CIPAOnLine.Models;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace CIPAOnLine.Controllers
{
    [AuthenticationFilter]
    public class VotosBrancosController : ApiController
    {
        private readonly VotosService votosService = new VotosService();
        private UsuariosService usuariosService = new UsuariosService();

        [Route("api/VotosBrancos/{codEleicao}")]
        public IHttpActionResult Get(int codEleicao)
        {
            try
            {
                return Ok(votosService.GetVotosBrancos(codEleicao));
            } catch (EleicaoNaoEncontradaException)
            {
                return NotFound();
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        public IHttpActionResult Post(VotoBranco voto)
        {
            try
            {
                voto.FuncionarioIdEleitor = usuariosService.GetUsuario(User.Identity.Name).FuncionarioId.Value;

                if (votosService.VotoExiste(voto.FuncionarioIdEleitor, voto.CodigoEleicao))
                {
                    return Content(HttpStatusCode.BadRequest, "Voto já registrado!");
                }

                return Ok(votosService.RegistrarVotoBranco(voto));
            }
            catch (FuncionarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.BadRequest, "Matrícula do funcionário eleitor não encontrada!");
            }
            catch (DbUpdateException e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }
    }
}