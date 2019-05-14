using CIPAOnLine.Exceptions;
using CIPAOnLine.Filters;
using CIPAOnLine.Models;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CIPAOnLine.Controllers
{
    [AuthenticationFilter]
    public class EmpresasController : ApiController
    {
        private EmpresasService empresasService = new EmpresasService();

        // GET: api/Empresas
        public IEnumerable<Empresa> Get()
        {
            return empresasService.GetAll(User);
        }

        [ResponseType(typeof(Empresa))]
        public IHttpActionResult Get(int id)
        {
            Empresa g = empresasService.Get(id);
            if (g == null) return NotFound();
            return Ok(g);
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(Empresa))]
        public IHttpActionResult Post(Empresa empresa)
        {
            return Ok(empresasService.Save(empresa));
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Empresa empresa)
        {
            try
            {
                if (id != empresa.Codigo) return BadRequest("Código passado por parâmetro é diferente do código do empresa passado no corpo da requisição.");
                empresasService.Save(empresa);
                return Ok();
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(Empresa))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(empresasService.Delete(id));
            }
            catch (EmpresaNaoEncontradaException)
            {
                return NotFound();
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }
    }
}
