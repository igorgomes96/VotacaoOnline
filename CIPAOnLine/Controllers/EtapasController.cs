using CIPAOnLine.DTO;
using CIPAOnLine.Models;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CIPAOnLine.Controllers
{
    public class EtapasController : ApiController
    {

        EtapasService etapasService = new EtapasService();

        [Route("api/Etapas/{codigoModulo}")]
        public IEnumerable<EtapaDTO> GetEtapas(int codigoModulo)
        {
            return etapasService.GetEtapas(codigoModulo).Select(x => new EtapaDTO(x));
        }
    }
}
