using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Helpers;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Services
{
    public class VotosService : IDisposable
    {
        private Modelo db = new Modelo();


        public int GetQtdaVotos(int codEleicao)
        {
            EleicoesService eleicoesService = new EleicoesService();
            Eleicao eleicao = eleicoesService.GetEleicao(codEleicao);
            return db.Votos.Count(x => x.CodigoEleicao == codEleicao) + db.VotosBrancos.Count(x => x.CodigoEleicao == codEleicao);
        }

        public ICollection<QtdaVotosDTO> QtdaVotosPorCandidato(int codEleicao)
        {
            EleicoesService eleicoesService = new EleicoesService();
            Eleicao eleicao = eleicoesService.GetEleicao(codEleicao);

            ICollection<QtdaVotosDTO> votos =
                    (from cand in db.Candidatos.Where(x => x.CodigoEleicao == codEleicao && x.Validado.HasValue && x.Validado.Value).ToList()
                    select new QtdaVotosDTO(cand,
                        db.Votos.Count(y => y.FuncionarioIdCandidato == cand.FuncionarioId && y.CodigoEleicao == codEleicao)))
                    .OrderBy(x => x.Candidato.Nome).OrderBy(x => x.Candidato.DataAdmissao).OrderByDescending(x => x.QtdaVotos).ToList();

            votos.Add(new QtdaVotosDTO
            {
                Candidato = new CandidatoDTO
                {
                    Nome = "(EM BRANCO)",
                },
                QtdaVotos = db.VotosBrancos.Count(x => x.CodigoEleicao == codEleicao)
            });

            return votos;
        }

        public ICollection<EleitorDTO> RelatorioEleitores(int codEleicao, string pesquisa = null)
        {
            EleicoesService eleicoesService = new EleicoesService();
            if (!eleicoesService.EleicaoExiste(codEleicao))
                throw new EleicaoNaoEncontradaException();

            ICollection<EleitorDTO> votos = db.Votos.ToList()
                .Where(x => x.CodigoEleicao == codEleicao)
                .OrderByDescending(x => x.DataHorario)
                .Select(x => new EleitorDTO(x)).ToList();

            ICollection<EleitorDTO> emBranco = db.VotosBrancos.ToList()
                .Where(x => x.CodigoEleicao == codEleicao)
                .Select(x => new EleitorDTO(x)).ToList();

            ICollection<EleitorDTO> union = votos.Union(emBranco).ToList();

            if (string.IsNullOrWhiteSpace(pesquisa))
            {
                return union;
            }
            else
            {
                pesquisa = pesquisa.ToLower().Trim();
                return union.Where(e => e.Nome.ToLower().Contains(pesquisa)).ToList();
            }

        }

        public ICollection<VotoDTO> GetVotosBrancos(int codEleicao)
        {
            EleicoesService eleicoesService = new EleicoesService();
            Eleicao eleicao = eleicoesService.GetEleicao(codEleicao);
            return eleicao.VotosBrancos.Select(x => new VotoDTO(x)).ToList();
        }

        public ResultadoDTO GetResultado(int codEleicao)
        {
            EleicoesService eleicoesService = new EleicoesService();
            EleicaoQtdaRepresentantesDTO qtda = eleicoesService.GetQtdaRepresentantes(codEleicao);

            IEnumerable<CandidatoEleitoDTO> query =
                db.Candidatos.Where(x => x.CodigoEleicao == codEleicao).ToList()
                .Select(x => new CandidatoEleitoDTO(x, db.Votos.Count(y => y.FuncionarioIdCandidato == x.FuncionarioId && y.CodigoEleicao == codEleicao)))
                .OrderByDescending(x => x.QtdaVotos).ThenBy(x => x.DataAdmissao).ThenBy(x => x.DataNascimento).ThenBy(x => x.Nome).Take(qtda.Efetivos + qtda.Suplentes);

            if (query.Count() < (qtda.Suplentes + qtda.Efetivos))
                throw new CandidatosInsuficientesException(query.Count(), qtda.Efetivos, qtda.Suplentes);

            ResultadoDTO resultado = new ResultadoDTO
            {
                Efetivos = query.Take(qtda.Efetivos).ToList(),
                Suplentes = query.Reverse().Take(qtda.Suplentes).Reverse().ToList()
            };

            return resultado;
        }

        public Voto RegistraVoto(Voto voto)
        {
            EleicoesService eleicoesService = new EleicoesService();
            voto.IP = HttpContext.Current.Request.UserHostAddress;
            voto.DataHorario = HelpersMethods.HorarioBrasilia();

            if (!eleicoesService.FuncionarioExiste(voto.CodigoEleicao, voto.FuncionarioIdCandidato))
                throw new CandidatoNaoEncontradoException();

            if (!eleicoesService.FuncionarioExiste(voto.CodigoEleicao, voto.FuncionarioIdEleitor))
                throw new FuncionarioNaoEncontradoException(voto.FuncionarioIdEleitor);

            db.Votos.Add(voto);
            db.SaveChanges();

            return voto;
        }

        public VotoBranco RegistrarVotoBranco(VotoBranco voto)
        {
            EleicoesService eleicoesService = new EleicoesService();
            voto.IP = HttpContext.Current.Request.UserHostAddress;
            voto.DataHorario = HelpersMethods.HorarioBrasilia();

            if (!eleicoesService.FuncionarioExiste(voto.CodigoEleicao, voto.FuncionarioIdEleitor))
                throw new FuncionarioNaoEncontradoException(voto.FuncionarioIdEleitor);

            db.VotosBrancos.Add(voto);
            db.SaveChanges();

            return voto;
        }

        public List<ResultadoEleicao> VerificarEleicoesPorFuncionario(int funcionarioId, string login)
        {
            FuncionariosService funcService = new FuncionariosService();
            Funcionario funcionario = funcService.GetFuncionario(funcionarioId);
            return db.ResultadosEleicoes
                .Where(x => x.Login == login && x.MatriculaFuncionario == funcionario.MatriculaFuncionario && x.CodigoEmpresa == funcionario.CodigoEmpresa).ToList();
        }

        public bool VotoExiste(int eleitor, int codEleicao)
        {
            return db.Votos.Count(e => e.FuncionarioIdEleitor == eleitor && e.CodigoEleicao == codEleicao) +
                db.VotosBrancos.Count(e => e.FuncionarioIdEleitor == eleitor && e.CodigoEleicao == codEleicao) > 0;
        }

        public PaginationInfoDTO GetEleitoresPaginationInfo(int codEleicao, string pesquisa, int pageSize)
        {
            PaginationInfoDTO pagination = new PaginationInfoDTO { PageSize = pageSize, PageNumber = 1 };
            var eleitores = RelatorioEleitores(codEleicao, pesquisa);
            pagination.Total = eleitores.Count();
            pagination.TotalPages = (pagination.Total + pagination.PageSize - 1) / pagination.PageSize;
            return pagination;
        }

        public void Dispose()
        {
           db.Dispose();
        }
    }
}