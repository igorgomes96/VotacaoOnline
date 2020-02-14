using System.IO;
using System.Web;
using System.Web.Http;

namespace CIPAOnLine.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public string[] GetValues()
        {
            string appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data/");
            File.AppendAllText($@"{appDataFolder}/log.txt", "Testando");
            return new string[] { "Valor 1", "Valor 2" };
        }
    }
}
