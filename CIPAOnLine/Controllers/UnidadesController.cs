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
    public class UnidadesController : ApiController
    {
        private UnidadesService unService = new UnidadesService();

        [ResponseType(typeof(IEnumerable<UnidadeDTO>))]
        public IHttpActionResult GetUnidades()
        {
            try { 
                return Ok(unService.GetUnidades()
                    .Select(x => new UnidadeDTO(x)));
            } catch {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        // GET: api/Unidades/5
        [ResponseType(typeof(UnidadeDTO))]
        public IHttpActionResult GetUnidade(int id)
        {
            try { 
                return Ok(new UnidadeDTO(unService.GetUnidade(id)));
            } catch (UnidadeNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Unidade não encontrada!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }


        // POST: api/Unidades
        [ResponseType(typeof(UnidadeDTO))]
        [Authorize(Roles = "Administrador")]
        public IHttpActionResult PostUnidade(Unidade unidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(new UnidadeDTO(unService.SaveUnidade(unidade)));
            } catch
            {
                if (unService.UnidadeExiste(unidade.Codigo))
                    return Content(HttpStatusCode.Conflict, "Código de unidade já existe no banco de dados!");

                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        // DELETE: api/Unidades/5
        [ResponseType(typeof(UnidadeDTO))]
        [Authorize(Roles = "Administrador")]
        public IHttpActionResult DeleteUnidade(int id)
        {
            try { 
                return Ok(unService.DeleteUnidade(id));
            } catch (UnidadeNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Unidade não cadastrada!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }


    }
}