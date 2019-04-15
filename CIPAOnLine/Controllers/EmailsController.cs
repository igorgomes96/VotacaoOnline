using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace CIPAOnLine.Controllers
{
    public class EmailsController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Send(EmailDTO email)
        {
            try
            {
                EmailService.Send(email);
                return Ok();
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [Route("api/Emails/Addresses/{codEleicao}/All")]
        public IHttpActionResult GetEmailsAddressesAll(int codEleicao)
        {
            EmailService service = new EmailService();
            try
            {
                return Ok(service.GetEmailAddressesAll(codEleicao));
            } catch (EleicaoNaoEncontradaException)
            {
                return NotFound();
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [Route("api/Emails/Addresses/{codEleicao}/Candidatos")]
        public IHttpActionResult GetEmailsAddressesCandidatos(int codEleicao)
        {
            EmailService service = new EmailService();
            try
            {
                return Ok(service.GetEmailAddressesCandidatos(codEleicao));
            }
            catch (EleicaoNaoEncontradaException)
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