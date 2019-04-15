using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Filters;
using CIPAOnLine.Models;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace CIPAOnLine.Controllers
{
    public class FuncionariosController : ApiController
    {

        private FuncionariosService funcService = new FuncionariosService();
        private UsuariosService usuariosService = new UsuariosService();

        [ResponseType(typeof(FuncionarioDTO))]
        [HttpPost]
        [Route("api/findbylogin")]
        [AllowAnonymous]
        public IHttpActionResult FindByLogin(Funcionario funcLogin)
        {
            try
            {
                if (funcLogin == null || funcLogin.Login == null) return Ok();
                Funcionario func = funcService.GetByLogin(funcLogin.Login);
                if (func == null) return NotFound();
                return Ok(new FuncionarioDTO(func));
            }
            catch (FuncionarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Funcionário não encontrado!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [ResponseType(typeof(FuncionarioDTO))]
        [AuthenticationFilter]
        public IHttpActionResult Get(int id)
        {
            try { 
                return Ok(new FuncionarioDTO(funcService.GetFuncionario(id)));
            } catch (FuncionarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Funcionário não encontrado!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        

        [ResponseType(typeof(FuncionarioDTO))]
        [AuthenticationFilter]
        [Route("api/Funcionarios/{matricula}/{codigoEmpresa}")]
        public IHttpActionResult GetByMatriculaEmpresa(string matricula, int codigoEmpresa)
        {
            try
            {
                return Ok(new FuncionarioDTO(funcService.GetFuncionario(matricula, codigoEmpresa)));
            }
            catch (FuncionarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Funcionário não encontrado!");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        

        [HttpPost]
        [Route("api/Funcionarios/Importacao/{codEleicao}")]
        [Authorize(Roles = "Administrador")]
        [AuthenticationFilter]
        public async Task<HttpResponseMessage> ImportacaoFuncionarios(int codEleicao)
        {
            // Verifica se request contém multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            //Diretório App_Data, para salvar o arquivo temporariamente
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            // Lê o arquivo da requisição assincronamente
            await Request.Content.ReadAsMultipartAsync(provider);

            ImportacaoOleDB imp = new ImportacaoOleDB(provider.FileData[0].LocalFileName, usuariosService.GetUsuario(User.Identity.Name));
            try
            {
                imp.ExecutarImportacaoGestores();
                List<InconsistenciaFuncionarioDTO> inconsistencias = imp.ExecutarImportacaoFuncionarios(codEleicao);
                File.Delete(provider.FileData[0].LocalFileName);
                //if (inconsistencias != null && inconsistencias.Count > 0) return Request.CreateResponse(HttpStatusCode.Accepted, inconsistencias);
            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [ResponseType(typeof(FuncionarioDTO))]
        [Authorize(Roles = "Administrador")]
        [AuthenticationFilter]
        public IHttpActionResult Post(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, ModelState);

            try
            {
                return Ok(new FuncionarioDTO(funcService.AddOrUpdateFuncionario(funcionario)));
            } catch (LoginJaCadastradoException e)
            {
                return Content(HttpStatusCode.BadRequest, "Já existe um funcionário cadastrado com o login informado! (Mat.: " + e.Funcionario.MatriculaFuncionario + "; Nome: " + e.Funcionario.Nome + ")");
            } catch (FuncionarioInconsistenteException e) {
                return Content(HttpStatusCode.Accepted, new { FuncionarioAtual = new FuncionarioDTO(e.FuncionarioAtual), FuncionarioNovo = new FuncionarioDTO(e.FuncionarioNovo) });
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [ResponseType(typeof(void))]
        [Authorize(Roles = "Administrador")]
        [Route("api/Funcionarios/SaveAll")]
        [HttpPost]
        [AuthenticationFilter]
        public IHttpActionResult SaveAll(IEnumerable<Funcionario> funcionarios)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, ModelState);

            try
            {
                foreach (Funcionario funcionario in funcionarios)
                {
                    funcService.AddOrUpdateFuncionario(funcionario);
                }
                return Ok();
            }
            catch (LoginJaCadastradoException e)
            {
                return Content(HttpStatusCode.BadRequest, "Já existe um funcionário cadastrado com o Login informado! (Mat.: " + e.Funcionario.MatriculaFuncionario + "; Nome: " + e.Funcionario.Nome + ")");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [ResponseType(typeof(void))]
        [Authorize(Roles = "Administrador")]
        [AuthenticationFilter]
        public IHttpActionResult Put(int id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, ModelState);

            if (funcionario.Id != id)
                return BadRequest("Id do funcionário não correspondete ao ID da URL!");

            try
            {
                return Ok(new FuncionarioDTO(funcService.AddOrUpdateFuncionario(funcionario)));
            }
            catch (LoginJaCadastradoException e)
            {
                return Content(HttpStatusCode.BadRequest, "Já existe um funcionário cadastrado com o login informado! (Mat.: " + e.Funcionario.MatriculaFuncionario + "; Nome: " + e.Funcionario.Nome + ")");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(FuncionarioDTO))]
        [AuthenticationFilter]
        public IHttpActionResult Delete(int id)
        {
            try { 
                return Ok(new FuncionarioDTO(funcService.Delete(id)));
            } catch (FuncionarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Funcionário não cadastrado!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

    }
}
