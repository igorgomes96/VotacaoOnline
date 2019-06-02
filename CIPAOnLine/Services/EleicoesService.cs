using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Web;
using CIPAOnLine.Resources;
using System.Threading;
using System.Security.Claims;

namespace CIPAOnLine.Services
{
    public class EleicoesService : IDisposable
    {
        private Modelo db = new Modelo();
        private UnidadesService unidadesService = new UnidadesService();
        private SindicatosService sindicatosService = new SindicatosService();

        public IEnumerable<Eleicao> GetEleicoes(int? codigoModulo = null, bool? aberta = null)
        {
            IEnumerable<Eleicao> eleicoes = db.Eleicoes.ToList()
                    .Where(x => (codigoModulo == null || x.CodigoModulo == codigoModulo) && (aberta == null || (aberta.GetValueOrDefault() && x.DataFechamento == null) || (!aberta.GetValueOrDefault() && x.DataFechamento != null)));
            return eleicoes;

        }

        private QtdaEleicaoDTO GetQtda(Eleicao eleicao)
        {
            EleicaoQtdaRepresentantesDTO qtda = GetQtdaRepresentantes(eleicao.Codigo);
            return new QtdaEleicaoDTO
            {
                TotalFuncionarios = eleicao.Funcionarios?.Count ?? 0,
                TotalCandidatos = eleicao.Candidatos?.Count ?? 0,
                Efetivos = qtda.Efetivos,
                Suplentes = qtda.Suplentes
            };
        }

        public void AtualizaPrazoEtapa(PrazoEtapa prazo)
        {
            PrazoEtapa anterior = GetEtapaAnterior(prazo);
            if (anterior != null && prazo.DataProposta.GetValueOrDefault().Date < anterior.DataProposta.GetValueOrDefault().Date)
                throw new CronogramaInconsistenteException("A data deve ser maior que a data proposta para a etapa anterior (" + anterior.DataProposta.Value.ToString("dd/MM/yy") + ")");

            PrazoEtapa proximo = GetProximaEtapa(prazo);
            if (proximo != null && prazo.DataProposta.GetValueOrDefault().Date > proximo.DataProposta.GetValueOrDefault().Date)
                throw new CronogramaInconsistenteException("A data deve ser menor que a data proposta para a próxima etapa (" + proximo.DataProposta.Value.ToString("dd/MM/yy") + ")");


            db.PrazosEtapas.AddOrUpdate(prazo);
            db.SaveChanges();
        }

        public IEnumerable<Funcionario> GetFuncionarios(int codEleicao, string pesquisa = null)
        {
            Eleicao eleicao = GetEleicao(codEleicao);
            if (string.IsNullOrWhiteSpace(pesquisa))
            {
                return eleicao.Funcionarios;
            } else
            {
                pesquisa = pesquisa.ToLower().Trim();
                return eleicao.Funcionarios.Where(f => f.Nome.ToLower().Contains(pesquisa));
            }
        }

        public PaginationInfoDTO GetFuncionariosPaginationInfo(int codEleicao, string pesquisa, int pageSize)
        {
            PaginationInfoDTO pagination = new PaginationInfoDTO { PageSize = pageSize, PageNumber = 1 };
            var funcionarios = GetFuncionarios(codEleicao, pesquisa);
            pagination.Total = funcionarios.Count();
            pagination.TotalPages = (pagination.Total + pagination.PageSize - 1) / pagination.PageSize;
            return pagination;
        }

        public ICollection<FiltroEleicaoDTO> GetFiltroEleicoes(ClaimsPrincipal claims, int codigoModulo)
        {
            //Abertas
            Dictionary<int, UnidadeFiltroDTO> unidadesAbertas = new Dictionary<int, UnidadeFiltroDTO>();

            int? funcionarioId = null;
            if (claims.Claims.Any(c => c.Type == ClaimTypes.NameIdentifier))
                funcionarioId = int.Parse(claims.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<int> codigoEmpresas = claims.FindAll("company").Select(x => int.Parse(x.Value)).ToList();

            foreach (Eleicao el in db.Eleicoes.Where(x => x.DataFechamento == null && x.CodigoModulo == codigoModulo).ToList())
            {
                if ((claims.IsInRole(Perfil.ADMINISTRADOR) && codigoEmpresas.Contains(el.Unidade.CodigoEmpresa)) || (funcionarioId.HasValue && FuncionarioExiste(el.Codigo, funcionarioId.Value)))
                {
                    {
                        if (!unidadesAbertas.ContainsKey(el.CodigoUnidade))
                            unidadesAbertas.Add(el.CodigoUnidade, new UnidadeFiltroDTO { Unidade = new UnidadeDTO(el.Unidade), Eleicoes = new List<EleicaoDTO>() });

                        EleicaoDTO e = new EleicaoDTO(el)
                        {
                            QtdaEleicao = GetQtda(el)
                        };
                        unidadesAbertas[el.CodigoUnidade].Eleicoes.Add(e);

                    }
                }
            }


            //Fechadas
            Dictionary<int, UnidadeFiltroDTO> unidadesFechadas = new Dictionary<int, UnidadeFiltroDTO>();

            foreach (Eleicao el in db.Eleicoes.Where(x => x.DataFechamento != null && x.CodigoModulo == codigoModulo).ToList())
            {
                if ((claims.IsInRole(Perfil.ADMINISTRADOR) && codigoEmpresas.Contains(el.Unidade.CodigoEmpresa)) || (funcionarioId.HasValue && FuncionarioExiste(el.Codigo, funcionarioId.Value)))
                {
                    if (!unidadesFechadas.ContainsKey(el.CodigoUnidade))
                        unidadesFechadas.Add(el.CodigoUnidade, new UnidadeFiltroDTO { Unidade = new UnidadeDTO(el.Unidade), Eleicoes = new List<EleicaoDTO>() });

                    EleicaoDTO e = new EleicaoDTO(el)
                    {
                        QtdaEleicao = GetQtda(el)
                    };
                    unidadesFechadas[el.CodigoUnidade].Eleicoes.Add(e);
                }
            }

            ICollection<FiltroEleicaoDTO> retorno = new List<FiltroEleicaoDTO>
            {
                new FiltroEleicaoDTO
                {
                    Label = "Abertas",
                    Unidades = unidadesAbertas.Values
                },
                new FiltroEleicaoDTO
                {
                    Label = "Fechadas",
                    Unidades = unidadesFechadas.Values
                }
            };

            return retorno;

        }

        public bool DeleteFuncionario(Eleicao eleicao, int funcionarioId)
        {

            Candidato candidato = eleicao.Candidatos.FirstOrDefault(x => x.FuncionarioId == funcionarioId && x.CodigoEleicao == eleicao.Codigo);
            if (candidato != null)
            {
                var reprovacoes = db.CandidaturasReprovadas.Where(c => c.FuncionarioId == funcionarioId && c.CodigoEleicao == eleicao.Codigo).ToList();
                foreach (var reprovacao in reprovacoes)
                    db.CandidaturasReprovadas.Remove(reprovacao);

                db.Candidatos.Remove(candidato);
                db.SaveChanges();
            }
            Funcionario f = eleicao.Funcionarios.FirstOrDefault(x => x.Id == funcionarioId);
            if (f != null)
            {
                eleicao.Funcionarios.Remove(f);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public void DeleteTodosFuncionarios(Eleicao eleicao)
        {
            eleicao.Funcionarios.Clear();
            db.SaveChanges();
        }

        public int GetQtdaFuncionarios(int codEleicao)
        {
            Eleicao eleicao = GetEleicao(codEleicao);
            return eleicao.Funcionarios.Count();
        }

        public EleicaoQtdaRepresentantesDTO GetQtdaRepresentantes(int codEleicao)
        {
            Eleicao eleicao = GetEleicao(codEleicao);
            float total = GetQtdaFuncionarios(eleicao.Codigo);

            EleicaoQtdaRepresentantesDTO retorno = null;
            if (eleicao.CodigoModulo == 1)
            {  //CIPA
                QtdaGrupo qtEfetivos = db.QtdasGrupos
                    .Where(x => x.CodigoGrupo == eleicao.Unidade.CodigoGrupo
                        && x.QtdaMin <= total && x.Efetivo)
                   .OrderByDescending(x => x.QtdaMin)
                   .FirstOrDefault();

                QtdaGrupo qtSuplentes = db.QtdasGrupos
                    .Where(x => x.CodigoGrupo == eleicao.Unidade.CodigoGrupo
                        && x.QtdaMin <= total && !x.Efetivo)
                   .OrderByDescending(x => x.QtdaMin)
                   .FirstOrDefault();

                if (qtEfetivos == null || qtSuplentes == null)
                    throw new QtdaMinCipeiroGrupoNaoEncontradaException(eleicao.Unidade.CodigoGrupo, GetQtdaFuncionarios(eleicao.Codigo));

                int acrescimo = total > qtEfetivos.AcrescimoLimite.QtdaLimite ?
                    (int)Math.Floor(((total - qtEfetivos.AcrescimoLimite.QtdaLimite) / qtEfetivos.AcrescimoLimite.IntervaloLimite) * qtEfetivos.AcrescimoLimite.QtdaAcrescimo) : 0;

                retorno = new EleicaoQtdaRepresentantesDTO(eleicao, qtEfetivos.Valor + acrescimo, qtSuplentes.Valor + acrescimo);
            }
            else //COMISSÃO
            {
                QtdaComissaoInterna q = db.QtdasComissaoInterna.Where(x => x.QtdaMin >= total).FirstOrDefault();
                retorno = new EleicaoQtdaRepresentantesDTO(eleicao, q.Valor, 0);
            }


            return retorno;
        }

        /// <summary>
        /// Adiciona o funcionário ao processo eleitoral. Se ele já estiver, retorna false; se não, true
        /// </summary>
        /// <param name="codEleicao"></param>
        /// <param name="funcionarioId"></param>
        /// <returns></returns>
        public bool AddFuncionario(int codEleicao, int funcionarioId)
        {
            Eleicao eleicao = GetEleicao(codEleicao);
            Funcionario func = db.Funcionarios.Find(funcionarioId);

            if (func == null) throw new FuncionarioNaoEncontradoException(funcionarioId);

            if (!eleicao.Funcionarios.Contains(func))
            {
                eleicao.Funcionarios.Add(func);
                db.SaveChanges();
                return true;
            }

            return false;

        }

        public TotalFuncionariosEleitoresDTO GetTotalFuncionariosEleitores(Eleicao eleicao)
        {
            return new TotalFuncionariosEleitoresDTO
            {
                CodigoEleicao = eleicao.Codigo,
                TotalEleitores = eleicao.Funcionarios.Count(),
                TotalFuncionarios = db.Funcionarios.Count()
            };
        }

        public bool FuncionarioExiste(int codEleicao, int funcionarioId)
        {
            Eleicao e = GetEleicao(codEleicao);

            return e.Funcionarios.Any(x => x.Id == funcionarioId);
        }

        public IEnumerable<string> GetTodasGestoes(int codigoModulo)
        {
            return db.Eleicoes.Where(x => x.CodigoModulo == codigoModulo).Select(x => x.Gestao).Distinct().ToList();
        }

        public Eleicao GetEleicaoAtual(int codigoModulo, int codUnidade)
        {
            return db.Eleicoes.Where(x => x.DataFechamento == null && x.CodigoModulo == codigoModulo && x.CodigoUnidade == codUnidade).FirstOrDefault();
        }

        public IEnumerable<Eleicao> GetEleicoesPorFuncionario(int codigoModulo, string matriculaFuncionario)
        {
            return db.Eleicoes.Where(x => x.DataFechamento == null && x.CodigoModulo == codigoModulo && x.Funcionarios.Any(y => y.MatriculaFuncionario == matriculaFuncionario)).ToList();
        }

        public Eleicao GetEleicaoPorGestaoPorUnidade(int codigoModulo, string gestao, int codigoUnidade)
        {
            Eleicao e = db.Eleicoes.Where(x => x.Gestao == gestao && x.CodigoUnidade == codigoUnidade && x.CodigoModulo == codigoModulo).FirstOrDefault();
            if (e == null)
                throw new EleicaoNaoEncontradaException();

            return e;
        }


        public Eleicao GetEleicao(int codigo)
        {
            Eleicao e = db.Eleicoes.Find(codigo);

            if (e == null) throw new EleicaoNaoEncontradaException();

            return e;
        }



        private PrazoEtapa GetProximaEtapa(PrazoEtapa prazoEtapa)
        {
            Eleicao eleicao = GetEleicao(prazoEtapa.CodigoEleicao);
            return eleicao.PrazosEtapas
                .Where(x => x.Ordem > prazoEtapa.Ordem)
                .OrderBy(x => x.Ordem).FirstOrDefault();

        }

        private PrazoEtapa GetEtapaAnterior(PrazoEtapa prazoEtapa)
        {
            Eleicao eleicao = GetEleicao(prazoEtapa.CodigoEleicao);
            return eleicao.PrazosEtapas
                .Where(x => x.Ordem < prazoEtapa.Ordem)
                .OrderByDescending(x => x.Ordem).FirstOrDefault();

        }

        private PrazoEtapa GetProximaEtapa(Eleicao eleicao)
        {
            PrazoEtapa etapaAtual = db.PrazosEtapas.Find(eleicao.Codigo, eleicao.CodigoEtapa);
            return eleicao.PrazosEtapas
                .Where(x => x.Ordem > etapaAtual.Ordem)
                .OrderBy(x => x.Ordem).FirstOrDefault();
        }

        private void PassarParaProximaEtapa(Eleicao eleicao, Usuario user)
        {
            PrazoEtapa etapaAtual = db.PrazosEtapas.Find(eleicao.Codigo, eleicao.CodigoEtapa);

            PrazoEtapa proxima = GetProximaEtapa(eleicao);

            PrazoEtapa ultima = eleicao.PrazosEtapas.Where(x => x.Etapa.CodigoModulo == eleicao.CodigoModulo)
                .OrderByDescending(x => x.Ordem).FirstOrDefault();

            if (proxima == null && etapaAtual != ultima) throw new EleicaoEncerradaException(eleicao);

            if (proxima != null)
                proxima.DataRealizada = DateTime.Today;
            else
            {
                eleicao.DataFechamento = DateTime.Today;
                SalvaResultado(eleicao.Codigo);
            }

            eleicao.CodigoEtapa = proxima?.CodigoEtapa;

            db.SaveChanges();
        }

        public Eleicao ProximaEtapa(Eleicao eleicao, Usuario user)
        {
            PrazoEtapa etapaAtual = db.PrazosEtapas.Find(eleicao.Codigo, eleicao.CodigoEtapa);
            PrazoEtapa proxima = GetProximaEtapa(eleicao);

            // Verifica se a data atual é maior que a data prevista para o encerramento do período de candidatura,
            // se há candidatos suficientes e se não existem candidaturas pendentes de aprovação
            if (etapaAtual.CodigoEtapa == 4 || etapaAtual.CodigoEtapa == 19)
            {
                EleicaoQtdaRepresentantesDTO qtda = GetQtdaRepresentantes(eleicao.Codigo);
                int qtdaCandidatos = eleicao.Candidatos.Count();

                //if (proxima.DataProposta.GetValueOrDefault().Date > DateTime.Today)
                //    throw new AntesDataPrevistaException(proxima.DataProposta.GetValueOrDefault());

                if (etapaAtual.Eleicao.Candidatos.Count(x => x.Validado == null) > 0)
                    throw new CandidaturasPendentesException();

                if ((qtda.Efetivos + qtda.Suplentes) > qtdaCandidatos)
                    throw new CandidatosInsuficientesException(qtdaCandidatos, qtda.Efetivos, qtda.Suplentes);
            }

            // Verifica se a data atual é maior que a data prevista para o encerramento do período de votação e
            // se há votos suficientes para o encerramento desse período
            if (etapaAtual.CodigoEtapa == 9 || etapaAtual.CodigoEtapa == 24)
            {
                VotosService votosService = new VotosService();
                ResultadoDTO todos = votosService.GetResultado(eleicao.Codigo);

                int qtdaTotal = GetQtdaFuncionarios(eleicao.Codigo);
                int qtdaVotos = votosService.GetQtdaVotos(eleicao.Codigo);

                if (((float)qtdaVotos / (float)qtdaTotal) < 0.5)
                    throw new VotosInsuficientesException(qtdaTotal % 2 == 1 ? (int)((qtdaTotal + 1) / 2) : (int)(qtdaTotal / 2));

            }

            PassarParaProximaEtapa(eleicao, user);

            return eleicao;
        }



        private void SalvaResultado(int codEleicao)
        {
            VotosService votosService = new VotosService();
            ResultadoEleicao resultado = null;
            ResultadoDTO todos = votosService.GetResultado(codEleicao);

            Eleicao eleicao = GetEleicao(codEleicao);

            int qtdaTotal = GetQtdaFuncionarios(codEleicao);
            int qtdaVotos = votosService.GetQtdaVotos(codEleicao);

            if (((float)qtdaVotos / (float)qtdaTotal) < 0.5)
                throw new VotosInsuficientesException(qtdaTotal % 2 == 1 ? (int)((qtdaTotal + 1) / 2) : (int)(qtdaTotal / 2));


            foreach (CandidatoEleitoDTO q in todos.Efetivos)
            {
                resultado = new ResultadoEleicao
                {
                    CodigoEleicao = codEleicao,
                    CodigoEmpresa = eleicao.Unidade.CodigoEmpresa,
                    RazaoSocial = eleicao.Unidade.Empresa.RazaoSocial,
                    MatriculaFuncionario = q.MatriculaFuncionario,
                    Login = q.Login,
                    Cargo = q.Cargo,
                    Area = q.Area,
                    DataAdmissao = q.DataAdmissao,
                    QtdaVotos = q.QtdaVotos,
                    Thumbnail = q.Thumbnail,
                    Foto = db.FuncionariosFotos.Where(x => x.FuncionarioId == q.Id).FirstOrDefault()?.Foto,
                    Efetivo = true
                };
                db.ResultadosEleicoes.AddOrUpdate(resultado);
            }

            foreach (CandidatoEleitoDTO q in todos.Suplentes)
            {
                resultado = new ResultadoEleicao
                {
                    CodigoEleicao = codEleicao,
                    CodigoEmpresa = eleicao.Unidade.CodigoEmpresa,
                    RazaoSocial = eleicao.Unidade.Empresa.RazaoSocial,
                    MatriculaFuncionario = q.MatriculaFuncionario,
                    Login = q.Login,
                    Cargo = q.Cargo,
                    Area = q.Area,
                    DataAdmissao = q.DataAdmissao,
                    QtdaVotos = q.QtdaVotos,
                    Thumbnail = q.Thumbnail,
                    Foto = db.FuncionariosFotos.Where(x => x.FuncionarioId == q.Id).FirstOrDefault()?.Foto,
                    Efetivo = false
                };
                db.ResultadosEleicoes.AddOrUpdate(resultado);
            }

            db.SaveChanges();


        }

        public void AtualizaEleicao(EleicaoDTO eleicao)
        {
            Eleicao e = GetEleicao(eleicao.Codigo);

            e.CodigoSindicato = eleicao.CodigoSindicato;
            e.CodigoUnidade = eleicao.CodigoUnidade;

            db.SaveChanges();
        }

        public Eleicao SalvarComCronograma(EleicaoDTO eleicao)
        {
            if (!unidadesService.UnidadeExiste(eleicao.CodigoUnidade))
                throw new UnidadeNaoEncontradaException(eleicao.CodigoUnidade);

            if (eleicao.CodigoSindicato.HasValue && !sindicatosService.SindicatoExiste(eleicao.CodigoSindicato.Value) && eleicao.CodigoModulo == 1)
                throw new SindicatoNaoEncontradoException(eleicao.CodigoSindicato.Value);

            Eleicao nova = new Eleicao
            {
                CodigoEtapa = db.Etapas.Where(x => x.CodigoEtapa == db.Etapas.Where(y => y.CodigoModulo == eleicao.CodigoModulo).Min(y => y.CodigoEtapa)).FirstOrDefault()?.CodigoEtapa,
                CodigoUnidade = eleicao.CodigoUnidade,
                CodigoModulo = eleicao.CodigoModulo,
                Gestao = eleicao.Gestao,
                CodigoSindicato = eleicao.CodigoSindicato == 0 ? null : eleicao.CodigoSindicato,
                DataInicio = eleicao.DataInicio
            };

            db.Eleicoes.Add(nova);

            PrazoEtapa EtapaAnterior = null;
            foreach (PrazosEtapasDTO pe in eleicao.PrazosEtapasObj.OrderBy(x => x.Ordem))
            {
                if (EtapaAnterior != null && pe.DataProposta < EtapaAnterior.DataProposta)
                {
                    throw new CronogramaInconsistenteException(pe.GetPrazoEtapa(), EtapaAnterior);
                }
                PrazoEtapa p = new PrazoEtapa
                {
                    CodigoEleicao = nova.Codigo,
                    CodigoEtapa = pe.CodigoEtapa,
                    DataProposta = pe.DataProposta,
                    DataRealizada = pe.DataRealizada,
                    Ordem = pe.Ordem
                };

                if (pe.CodigoEtapa == 1) p.DataRealizada = DateTime.Today;

                db.PrazosEtapas.Add(p);
                EtapaAnterior = p;
            }

            db.SaveChanges();

            return nova;
        }

        public bool FuncionarioCadastrado(int codEleicao, string login, int funcionarioId)
        {
            Eleicao eleicao = db.Eleicoes.Find(codEleicao);
            if (eleicao == null)
                throw new EleicaoNaoEncontradaException();

            return eleicao.Funcionarios.Any(x => x.Login == login && x.Id == funcionarioId);

        }

        public bool EleicaoExiste(int codigo)
        {
            return db.Eleicoes.Count(x => x.Codigo == codigo) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}