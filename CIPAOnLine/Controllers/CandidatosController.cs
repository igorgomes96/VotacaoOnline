using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CIPAOnLine.Models;
using CIPAOnLine.DTO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using CIPAOnLine.Filters;
using System.Drawing;
using CIPAOnLine.Services;
using CIPAOnLine.Exceptions;

namespace CIPAOnLine.Controllers
{
    [AuthenticationFilter]
    public class CandidatosController : ApiController
    {
        private CandidatosService candidatosService = new CandidatosService();
        private EleicoesService eleicoesService = new EleicoesService();
        private UsuariosService usuariosService = new UsuariosService();

        [Authorize(Roles = "Administrador")]
        public IEnumerable<CandidatoDTO> GetCandidatos(int? codEleicao = null)
        {
            return candidatosService.GetCandidatos(codEleicao)
                .Select(x => new CandidatoDTO(x));
        }


        [Route("api/Candidatos/Votos/{codEleicao}")]
        [ResponseType(typeof(IEnumerable<CandidatoFotoDTO>))]
        public IHttpActionResult GetCandidatosAtualVoto(int codEleicao)
        {
            try
            {
                Eleicao e = eleicoesService.GetEleicao(codEleicao);
                Usuario usuario = usuariosService.GetUsuario(User.Identity.Name);
                return Ok(candidatosService.GetCandidatosParaVoto(e, usuario));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Código de Eleição não encontrado!");
            }
            catch (ForaEtapaVotacaoException)
            {
                return Content(HttpStatusCode.BadRequest, "A eleição não está em processo de votação no momento!");
            }
            catch (VotoJaRealizadoException)
            {
                return Content(HttpStatusCode.Forbidden, "Você já realizou seu voto. Não é possível anular ou alterar!");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [Route("api/Candidatos/Validacao/{codEleicao}")]
        [ResponseType(typeof(IEnumerable<CandidatoFotoDTO>))]
        [Authorize(Roles = "Administrador")]
        public IHttpActionResult GetCandidatosValidacao(int codEleicao, bool? aprovado = null)
        {
            try
            {
                Eleicao e = eleicoesService.GetEleicao(codEleicao);
                return Ok(candidatosService.GetCandidatosParaValidacao(e, aprovado));
            }
            catch (ForaEtapaCandidaturaException)
            {
                return Content(HttpStatusCode.BadRequest, "A eleição não está na etapa de candidaturas!");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        // GET: api/Candidatos/5
        [HttpGet]
        [Route("api/Candidatos/{funcionarioId}/{codEleicao}")]
        [ResponseType(typeof(CandidatoFotoDTO))]
        public IHttpActionResult GetCandidato(int funcionarioId, int codEleicao)
        {
            try
            {
                return Ok(new CandidatoFotoDTO(candidatosService.GetCandidato(funcionarioId, codEleicao)));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não encontrada!");
            }
            catch (CandidatoNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Candidato não encontrado!");
            }
            catch (FuncionarioNaoCadastradoEleicaoException)
            {
                return Content(HttpStatusCode.Forbidden, "Usuário não está cadastrado na eleição " + codEleicao);
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }



        [HttpPost]
        [Route("api/Candidatos/AddOrUpdate")]
        public async Task<HttpResponseMessage> AddOrUpdateCandidato()
        {
            try
            {
                FuncionariosService funcService = new FuncionariosService();

                // Verifica se request contém multipart/form-data.
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                //Diretório App_Data, para salvar o arquivo temporariamente
                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);

                // Lê o arquivo da requisição assincronamente
                await Request.Content.ReadAsMultipartAsync(provider);

                //Deserializa os dados do Candidato
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                var obj = json_serializer.DeserializeObject(provider.FormData.Get("candidato")) as Dictionary<string, object>;

                Image thumbnail = null;
                Image img = null;
                try
                {
                    //Lê a foto do candidato

                    var httpPostedFile = HttpContext.Current.Request.Files["foto"];
                    if (httpPostedFile != null)
                    {
                        int length = httpPostedFile.ContentLength;
                        var bytes = new byte[length]; //get imagedata  
                        httpPostedFile.InputStream.Read(bytes, 0, length);
                        var stream = new MemoryStream(bytes);
                        img = Image.FromStream(stream, false, false);
                        img = ImageService.EnquadrarImagem((Bitmap)img);
                        thumbnail = ImageService.GetThumbnail(img, 75, 75);
                        stream.Dispose();
                        if (img.Height > 350)
                            img = ImageService.GetThumbnail(img, 350, 350);
                    }
                }
                catch
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Erro ao processar imagem. Por favor, escolha outra! ");
                }

                int funcionarioId = int.Parse(obj["FuncionarioId"].ToString());
                //Cria uma instância de Funcionario
                Funcionario funcionario = null;
                try
                {
                    funcionario = funcService.GetFuncionario(funcionarioId);
                }
                catch (FuncionarioNaoEncontradoException)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Funcionário não encontrado!");
                }

                funcionario.Login = obj["LoginFuncionario"].ToString();
                funcionario.Nome = obj["NomeFuncionario"].ToString();
                funcionario.Cargo = obj["CargoFuncionario"].ToString();
                funcionario.Area = obj["AreaFuncionario"].ToString();
                funcionario.Email = obj["EmailFuncionario"].ToString();
                funcionario.Sobre = (obj.ContainsKey("Sobre") && obj["Sobre"] != null) ? obj["Sobre"].ToString() : null;
                funcionario.DataAdmissao = DateTime.Parse(obj["DataAdmissaoFuncionario"].ToString());
                funcionario.Thumbnail = ImageService.ConvertImageByte(thumbnail);

                funcService.AddOrUpdateFuncionario(funcionario);

                FuncionarioFoto funcFoto = new FuncionarioFoto
                {
                    FuncionarioId = funcionario.Id,
                    Foto = ImageService.ConvertImageByte(img)
                };

                funcService.AddOrUpdateFuncionarioFoto(funcFoto);
                bool? validado = null;
                //if (User.IsInRole("Administrador")) validado = true;

                //Cria uma intância do candidato
                Candidato c = new Candidato
                {
                    FuncionarioId = funcionarioId,
                    CodigoEleicao = int.Parse(obj["CodigoEleicao"].ToString()),
                    HorarioCandidatura = DateTime.Now,
                    Validado = validado
                };

                //Tenta salvar as atualizações
                try
                {
                    c = candidatosService.AddOrUpdateCandidato(c);
                    candidatosService.ExcluirMotivoReprovacao(c);
                    //Excluir o arquivo
                    File.Delete(provider.FileData[0].LocalFileName);
                }
                catch (FuncionarioNaoCadastradoEleicaoException)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Você não está inscrito nessa eleição! Contate o administrador.");
                }
                catch (FuncionarioNaoElegivelException e)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, new CandidatoDTO(c));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [Route("api/Candidatos/{funcionarioId}/{codEleicao}/Aprovar")]
        [ResponseType(typeof(CandidatoDTO))]
        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IHttpActionResult AprovarCandidatura(int funcionarioId, int codEleicao)
        {
            Candidato c = candidatosService.GetCandidato(funcionarioId, codEleicao);

            if (c == null) return Content(HttpStatusCode.NotFound, "Candidato não encontrado!");

            try
            {
                return Ok(new CandidatoDTO(candidatosService.AprovarCandidatura(c)));
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [Route("api/Candidatos/AprovarTodos")]
        [ResponseType(typeof(IEnumerable<CandidatoDTO>))]
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IHttpActionResult AprovarCandidaturaTodos(Candidato[] candidatos)
        {
            try
            {
                return Ok(candidatosService.ToDTO(candidatosService.AprovarTodos(candidatos)));
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }


        [Route("api/Candidatos/{funcionarioId}/{codEleicao}/Reprovar")]
        [ResponseType(typeof(CandidaturaReprovadaDTO))]
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IHttpActionResult ReprovarCandidatura(int funcionarioId, int codEleicao, CandidaturaReprovada reprovacao)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }

            if (funcionarioId != reprovacao.FuncionarioId || codEleicao != reprovacao.CodigoEleicao)
                return Content(HttpStatusCode.BadRequest, "Parâmetros da Requisição inconsistentes!");

            try
            {
                return Ok(new CandidaturaReprovadaDTO(candidatosService.ReprovarCandidatura(reprovacao)));
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

    }
}