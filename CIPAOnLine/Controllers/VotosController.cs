﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CIPAOnLine.Models;
using CIPAOnLine.DTO;
using System.Web;
using CIPAOnLine.Filters;
using CIPAOnLine.Services;
using CIPAOnLine.Exceptions;
using PagedList;

namespace CIPAOnLine.Controllers
{
    [AuthenticationFilter]
    public class VotosController : ApiController
    {
        private EleicoesService eleicoesService = new EleicoesService();
        private VotosService votosService = new VotosService();
        private UsuariosService usuariosService = new UsuariosService();

        [HttpGet]
        [Route("api/Votos/QtdaVotantes/{codEleicao}")]
        [ResponseType(typeof(object))]
        public IHttpActionResult QtdaVotantes(int codEleicao)
        {
            try { 
                int qtdaVotos = votosService.GetQtdaVotos(codEleicao);
                return Ok(new { Votantes = qtdaVotos, NaoVotantes = eleicoesService.GetQtdaFuncionarios(codEleicao) - qtdaVotos });
            } catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [HttpGet]
        [Route("api/Votos/QtdaVotosPorCandidato/{codEleicao}")]
        [ResponseType(typeof(IEnumerable<QtdaVotosDTO>))]
        public IHttpActionResult QtdaVotosPorCandidato(int codEleicao)
        {
            try
            {
                return Ok(votosService.QtdaVotosPorCandidato(codEleicao));
            } catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
            
        }

        [HttpGet]
        [Route("api/Votos/Relatorio/Eleitores/{codEleicao}")]
        [ResponseType(typeof(IEnumerable<EleitorDTO>))]
        public IHttpActionResult GetRelatorioEleitores(int codEleicao, string pesquisa = null, int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return Ok(votosService.RelatorioEleitores(codEleicao, pesquisa)
                    .OrderBy(f => f.Nome)
                    .ToPagedList(pageNumber, pageSize));
            } catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não encontrada!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [Route("api/Votos/Relatorio/Eleitores/{codEleicao}/PaginationInfo")]
        [ResponseType(typeof(PaginationInfoDTO))]
        public IHttpActionResult GetEleitoresPaginationInfo(int codEleicao, string pesquisa = null, int pageSize = 50)
        {
            try
            {
                return Ok(votosService.GetEleitoresPaginationInfo(codEleicao, pesquisa, pageSize));
            }
            catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [HttpGet]
        [Route("api/Votos/Resultado/{codEleicao}")]
        [ResponseType(typeof(IEnumerable<ResultadoDTO>))]
        public IHttpActionResult GetResultado(int codEleicao)
        {
            try
            {
                return Ok(votosService.GetResultado(codEleicao));
            } catch(QtdaMinCipeiroGrupoNaoEncontradaException e)
            {
                return Content(HttpStatusCode.InternalServerError, "Não existe cadastro no banco para quantidade de cipeiros para empresas do grupo " + e.CodigoGrupo + "!");
            } catch (EleicaoNaoEncontradaException)
            {
                return Content(HttpStatusCode.NotFound, "Eleição não cadastrada!");
            } catch (CandidatosInsuficientesException e)
            {
                return Content(HttpStatusCode.BadRequest, "Não houveram candidaturas suficientes para preencher todas vagas! (Qtda. de Efetivos: " + e.QtdaEfetivos + "; Qtda de Suplentes: " + e.QtdaSuplentes + "; Qtda de Candidatos: " + e.QtdaCandidatos + ")");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        [ResponseType(typeof(VotoDTO))]
        public IHttpActionResult PostVoto(Voto voto)
        {
            try
            {
                if (votosService.VotoExiste(voto.FuncionarioIdEleitor, voto.CodigoEleicao))
                {
                    return Content(HttpStatusCode.BadRequest, "Voto já registrado!");
                }

                voto.FuncionarioIdEleitor = usuariosService.GetUsuario(User.Identity.Name).FuncionarioId.Value;
                return Content(HttpStatusCode.Created, new VotoDTO(votosService.RegistraVoto(voto)));
            } catch (CandidatoNaoEncontradoException)
            {
                return Content(HttpStatusCode.BadRequest, "O funcionário informado não se candidatou nessa eleição!");
            } catch (FuncionarioNaoEncontradoException)
            {
                return Content(HttpStatusCode.BadRequest, "Matrícula do funcionário eleitor não encontrada!");
            } catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocorreu um erro desconhecido. Por favor, entre em contato com o suporte.");
            }
        }

        
    }
}