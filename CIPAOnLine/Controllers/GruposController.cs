using CIPAOnLine.DTO;
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
    public class GruposController : ApiController
    {
        private GruposService gruposService = new GruposService();

        [ResponseType(typeof(IEnumerable<GrupoDTO>))]
        public IHttpActionResult GetGrupos()
        {
            return Ok(gruposService.GetGrupos().Select(x => new GrupoDTO(x)));
        }
    }
}
