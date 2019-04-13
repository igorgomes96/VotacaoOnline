using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CIPAOnLine.Models;
using CIPAOnLine.DTO;
using CIPAOnLine.Filters;
using CIPAOnLine.Services;
using CIPAOnLine.Exceptions;
using System.Security.Claims;

namespace CIPAOnLine.Controllers
{
    [AuthenticationFilter]
    public class EleicoesController : ApiController
    {

        private EleicoesService eleicoesService = new EleicoesService();
        private CandidatosService candidatosService = new CandidatosService();
        private UsuariosService usuariosService = new UsuariosService();

        private Usuario GetUsuario()
        {
            return usuariosService.GetUsuario(User.Identity.Name);
        }

        [ResponseType(typeof(IEnumerable<EleicaoDTO>))]
        public IHttpActionResult GetEleicoes(int? codigoModulo = null, bool? aberta = null)
        {
            try
            {
                ICollection<Eleicao> eleicoes = eleicoesService.GetEleicoes(codigoModulo, aberta).ToList();


                if (!User.IsInRole("Administrador"))
                    eleicoes = eleicoes.Where(e => e.Funcionarios.Any(f => f.Login == User.Identity.Name)).ToList();

                return Ok(eleicoes
                    .Select((Eleicao x) =>
                        {
                            EleicaoQtdaRepresentantesDTO representantes = eleicoesService.GetQtdaRepresentantes(x.Codigo);
                            QtdaEleicaoDTO qtda = new QtdaEleicaoDTO
                            {
                                TotalFuncionarios = eleicoesService.GetQtdaFuncionarios(x.Codigo),
                                Efetivos = representantes.Efetivos,
                                Suplentes = representantes.Suplentes,
                                TotalCandidatos = candidatosService.GetQtdaCandidatos(x.Codigo)
                            };
                            return new EleicaoDTO(x, qtda);
                        }).ToList());
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [ResponseType(typeof(EleicaoDTO))]
        [Route("api/Eleicoes/Corrente")]
        public IHttpActionResult GetEleicaoCorrente(int? codigoModulo = null)
        {
            try
            {
                Eleicao e = eleicoesService.GetEleicoes(codigoModulo, true)
                    .FirstOrDefault(x => x.Funcionarios.Any(y => y.Login.Equals(User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)));
                if (e == null)
                    return Ok();
                return Ok(new EleicaoDTO(e));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/Eleicoes/{codEleicao}/Cadastrado")]
        public IHttpActionResult FuncionarioCadastrado(int codEleicao)
        {
            try
            {
                if (User.IsInRole(Perfil.ADMINISTRADOR)) return Ok(true);
                Usuario user = GetUsuario();
                return Ok(eleicoesService.FuncionarioCadastrado(codEleicao, user.Login, user.FuncionarioId.Value));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [Route("api/Filtro/Eleicoes/{codigoModulo}")]
        public IHttpActionResult GetFiltroEleicoes(int codigoModulo)
        {
            try
            {
                return Ok(eleicoesService.GetFiltroEleicoes((ClaimsPrincipal)User, codigoModulo));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("api/Eleicoes/{codEleicao}/Funcionarios")]
        [ResponseType(typeof(IEnumerable<FuncionarioDTO>))]
        public IHttpActionResult GetFuncionarios(int codEleicao)
        {
            try
            {
                return Ok(eleicoesService.GetFuncionarios(codEleicao).Select(x => new FuncionarioDTO(x)));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/Eleicoes/{codEleicao}/RemoveFuncionario/{funcionarioId}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteFuncionario(int codEleicao, int funcionarioId)
        {
            try
            {
                return Ok(eleicoesService.DeleteFuncionario(eleicoesService.GetEleicao(codEleicao), funcionarioId));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não encontrada");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("api/Eleicoes/{codEleicao}/RemoveTodosFuncionarios")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteFuncionariosAll(int codEleicao)
        {
            try
            {
                eleicoesService.DeleteTodosFuncionarios(eleicoesService.GetEleicao(codEleicao));
                return Ok();
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não encontrada");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/Eleicoes/{codEleicao}/PrazosEtapas")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrazoEtapa(int codEleicao, PrazoEtapa prazo)
        {
            if (prazo.CodigoEleicao != codEleicao)
                return Content(HttpStatusCode.BadRequest, "Código de Eleição inconsistente");

            try
            {
                eleicoesService.AtualizaPrazoEtapa(prazo);
            }
            catch (CronogramaInconsistenteException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }

            return Ok();

        }


        [Route("api/Eleicoes/Gestoes/{codModulo}")]
        public IHttpActionResult GetGestoes(int codModulo)
        {
            try
            {
                return Ok(eleicoesService.GetTodasGestoes(codModulo));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("api/Eleicoes/TotalFuncionariosEleitores/{codigoEleicao}")]
        [ResponseType(typeof(TotalFuncionariosEleitoresDTO))]
        public IHttpActionResult GetTotalFuncionarioEleitores(int codigoEleicao)
        {
            try
            {
                Eleicao eleicao = eleicoesService.GetEleicao(codigoEleicao);
                return Ok(eleicoesService.GetTotalFuncionariosEleitores(eleicao));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Código de eleição não cadastrado!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPut]
        [Authorize(Roles = "Administrador")]
        [Route("api/Eleicoes/ProximaEtapa/{codigoEleicao}")]
        public IHttpActionResult SetProximaEtapa(int codigoEleicao)
        {
            Eleicao eleicao = eleicoesService.GetEleicao(codigoEleicao);

            if (eleicao == null) return Content(HttpStatusCode.NotFound, "Código de Eleição não encontrado!");

            try
            {
                return Ok(new EleicaoDTO(eleicoesService.ProximaEtapa(eleicao, GetUsuario())));
            }
            catch (ConfirmacaoEmailsException e)
            {
                return Content(HttpStatusCode.Accepted, e.Emails);
            }
            catch (CandidatosInsuficientesException e)
            {
                return Content(HttpStatusCode.Forbidden, "Ainda não houveram candidaturas suficientes! (Candidatos: " + e.QtdaCandidatos + "; Efetivos: " + e.QtdaEfetivos + "; Suplentes: " + e.QtdaSuplentes + ")");
            }
            catch (EleicaoEncerradaException)
            {
                return Content(HttpStatusCode.BadRequest, "A eleição já foi encerrada!");
            }
            catch (AntesDataPrevistaException e)
            {
                return Content(HttpStatusCode.BadRequest, "A etapa atual não pode ser encerrada antes da data prevista (" + e.DataPrevista.ToString("dd/MM/yy") + "), conforme cronograma!");
            }
            catch (CandidaturasPendentesException)
            {
                return Content(HttpStatusCode.BadRequest, "Ainda existem candidaturas pendentes de aprovação! Por favor, verifique.");
            }
            catch (VotosInsuficientesException e)
            {
                return Content(HttpStatusCode.BadRequest, "É necessário que mais de 50% (" + e.QtdaMinVotos + ") do quadro de funcionários votem para concluir a etapa de votação!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpGet]
        [ResponseType(typeof(EleicaoDTO))]
        [Route("api/Eleicoes/PorGestao/PorUnidade/{codigoModulo}/{gestao}/{codigoUnidade}")]
        public IHttpActionResult GetEleicaoPorGestaoPorUnidade(int codigoModulo, string gestao, int codigoUnidade)
        {
            try
            {
                return Ok(new EleicaoDTO(eleicoesService.GetEleicaoPorGestaoPorUnidade(codigoModulo, gestao, codigoUnidade)));
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

        [ResponseType(typeof(EleicaoDTO))]
        public IHttpActionResult GetEleicao(int id)
        {
            try
            {
                Eleicao eleicao = eleicoesService.GetEleicao(id);
                Usuario user = GetUsuario();
                if (user.Perfil != "Administrador" && !eleicao.Funcionarios.Any(x => x.Login == user.Login))
                    return Content(HttpStatusCode.Forbidden, "Usuário não cadastrado na eleição " + id + "!");
                return Ok(new EleicaoDTO(eleicao));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [ResponseType(typeof(EleicaoQtdaRepresentantesDTO))]
        [Route("api/Eleicoes/QtdaCipeiros/{codEleicao}")]
        public IHttpActionResult GetQtdaCipeiros(int codEleicao)
        {
            try
            {
                return Ok(eleicoesService.GetQtdaRepresentantes(codEleicao));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            }
            catch (QtdaMinCipeiroGrupoNaoEncontradaException)
            {
                return Content(HttpStatusCode.InternalServerError, "Não foram cadastradas corretamente as informações de quantidade de efetivos e suplentes a quantidade de funcionários dessa unidade!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(EleicaoDTO))]
        public IHttpActionResult PostEleicao(EleicaoDTO eleicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return CreatedAtRoute("DefaultApi", new { id = eleicao.Codigo }, new EleicaoDTO(eleicoesService.SalvarComCronograma(eleicao)));
            }
            catch (SindicatoNaoEncontradoException e)
            {
                return Content(HttpStatusCode.NotFound, "Sindicato não encontrado! (Cód.: " + e.CodSindicato + ")");
            }
            catch (UnidadeNaoEncontradaException e)
            {
                return Content(HttpStatusCode.NotFound, "Unidade não encontrada! (Cód.: " + e.Codigo + ")");
            }
            catch (EleicaoJaCadastradaException)
            {
                return Content(HttpStatusCode.Conflict, "Eleição já cadastrada!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(EleicaoDTO))]
        public IHttpActionResult PutEleicao(int id, EleicaoDTO eleicao)
        {

            try
            {
                eleicoesService.AtualizaEleicao(eleicao);
                return Ok();
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não encontrada!");
            }
            catch (SindicatoNaoEncontradoException e)
            {
                return Content(HttpStatusCode.NotFound, "Sindicato não encontrado! (Cód.: " + e.CodSindicato + ")");
            }
            catch (UnidadeNaoEncontradaException e)
            {
                return Content(HttpStatusCode.NotFound, "Unidade não encontrada! (Cód.: " + e.Codigo + ")");
            }
            catch (EleicaoJaCadastradaException)
            {
                return Content(HttpStatusCode.Conflict, "Eleição já cadastrada!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ResponseType(typeof(EleicaoDTO))]
        [Route("api/Eleicoes/{codigoEleicao}/AddFuncionario/{funcionarioId}")]
        public IHttpActionResult AddFuncionario(int codigoEleicao, int funcionarioId)
        {
            try
            {
                return Ok(eleicoesService.AddFuncionario(codigoEleicao, funcionarioId));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            }
            catch (FuncionarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.NotFound, "Funcionário não cadastrado!");
            }
        }

    }

}