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
    public class TemplatesEmailsController : ApiController
    {

        TemplatesEmailsService templatesEmailsService = new TemplatesEmailsService();

        public IHttpActionResult Get()
        {
            return Ok(templatesEmailsService.GetTemplates());
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                TemplateEmail template = templatesEmailsService.GetTemplate(id);
                if (template == null) return NotFound();
                return Ok(template);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Post(TemplateEmail template)
        {
            try
            {
                return Ok(templatesEmailsService.PostTemplate(template));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Put(int id, TemplateEmail template)
        {
            try
            {
                if (id != template.Id) return BadRequest();
                templatesEmailsService.PutTemplate(template);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try { 
                TemplateEmail template = templatesEmailsService.DeleteTemplate(id);
                if (template == null) return NotFound();
                return Ok(template);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
