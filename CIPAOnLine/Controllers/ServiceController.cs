using CIPAOnLine.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CIPAOnLine.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpGet]
        [Route("api/Base64/To/{texto}")]
        public string ConverteToBase64(string texto)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(texto));
        }

        [HttpGet]
        [Route("api/Base64/From/{texto}")]
        public string ConverteFromBase64(string texto)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(texto));
        }
    }
}
