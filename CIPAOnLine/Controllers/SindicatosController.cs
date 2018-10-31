using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
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
    public class SindicatosController : ApiController
    {
        SindicatosService sindicatosService = new SindicatosService();

        public IEnumerable<SindicatoDTO> Get()
        {
            return sindicatosService.GetAllSindicatos()
                .Select(x => new SindicatoDTO(x));
        }

        [ResponseType(typeof(SindicatoDTO))]
        public IHttpActionResult Get(int id)
        {
            try { 
                return Ok(new SindicatoDTO(sindicatosService.GetSindicato(id)));
            } catch (SindicatoNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Sindicato não cadastrado!");
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [ResponseType(typeof(SindicatoDTO))]
        public IHttpActionResult Post([FromBody]Sindicato sindicato)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }

            try { 
                return Ok(new SindicatoDTO(sindicatosService.SaveSindicato(sindicato)));
            } catch(Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [ResponseType(typeof(SindicatoDTO))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(new SindicatoDTO(sindicatosService.DeleteSindicato(id)));
            }
            catch (SindicatoNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Sindicato não cadastrado!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
