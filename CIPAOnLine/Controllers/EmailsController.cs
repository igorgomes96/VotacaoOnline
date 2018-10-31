using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            } catch (Exception ex)
            {
                return InternalServerError(ex);
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
            } catch (Exception e)
            {
                return InternalServerError(e);
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
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}