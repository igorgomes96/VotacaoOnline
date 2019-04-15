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
    public class GestoresController : ApiController
    {
        private GestoresService gestoresService = new GestoresService();

        // GET: api/Gestores
        public IEnumerable<Gestor> Get()
        {
            return gestoresService.GetAll();
        }

        [ResponseType(typeof(Gestor))]
        public IHttpActionResult Get(int id)
        {
            Gestor g = gestoresService.Get(id);
            if (g == null) return NotFound();
            return Ok(g);
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(Gestor))]
        public IHttpActionResult Post(Gestor gestor)
        {
            return Ok(gestoresService.Save(gestor));
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Gestor gestor)
        {
            if (id != gestor.Codigo) return BadRequest("Código passado por parâmetro é diferente do código do gestor passado no corpo da requisição.");
            gestoresService.Save(gestor);
            return Ok();
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(Gestor))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (gestoresService.GestorPossuiVinculo(id))
                    return BadRequest("Esse gestor está vinculado a um ou mais funcionários, por isso não será possível excluí-lo.");
                return Ok(gestoresService.Delete(id));
            } catch (GestorNaoEncontradoException)
            {
                return NotFound();
            } catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
