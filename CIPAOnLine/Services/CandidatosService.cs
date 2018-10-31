using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Web;

namespace CIPAOnLine.Services
{
    public class CandidatosService : IDisposable
    {
        private Modelo db = new Modelo();

        public IEnumerable<Candidato> GetCandidatos(int? codEleicao)
        {
            return db.Candidatos.ToList()
                .Where(x => codEleicao == null || codEleicao == x.CodigoEleicao);
        }

        public int GetQtdaCandidatos(int codEleicao)
        {
            return db.Candidatos.Count(x => x.CodigoEleicao == codEleicao && (x.Validado.HasValue && x.Validado.Value));
        }

        public IEnumerable<CandidatoFotoDTO> GetCandidatosParaVoto(Eleicao eleicao, Usuario usuario)
        {
            if (eleicao.CodigoEtapa != 9)
                throw new ForaEtapaVotacaoException(eleicao);

            if (db.Votos.Count(x => x.CodigoEleicao == eleicao.Codigo && x.MatriculaEleitor == usuario.MatriculaFuncionario) > 0 ||
                    db.VotosBrancos.Count(x => x.CodigoEleicao == eleicao.Codigo && x.MatriculaEleitor == usuario.MatriculaFuncionario) > 0)
                throw new VotoJaRealizadoException(usuario.Funcionario, eleicao);

            return db.Candidatos.ToList()
                .Where(x => x.CodigoEleicao == eleicao.Codigo && x.Validado.GetValueOrDefault())
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new CandidatoFotoDTO(x));
        }

        public Candidato GetCandidato(string matricula, int codEleicao)
        {
            EleicoesService eleicoesService = new EleicoesService();

            if (!eleicoesService.FuncionarioExiste(codEleicao, matricula))
                throw new FuncionarioNaoCadastradoEleicaoException(matricula, codEleicao);
            IEnumerable<Candidato> teste = db.Candidatos.Where(x => matricula == x.MatriculaFuncionario);
            Candidato c = db.Candidatos.Find(matricula, codEleicao);

            if (c == null) throw new CandidatoNaoEncontradoException();

            return c;
        }

        /// <summary>
        /// Verifica se o Funcionário é elegível (não pode ter sido eleito duas vezes consecutivas)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool Elegivel(Candidato c, Eleicao eleicao, Funcionario func)
        {
            VotosService votosService = new VotosService();
            List<ResultadoEleicao> resultados = votosService.VerificarEleicoesPorFuncionario(c.MatriculaFuncionario, func.Login);

            int anoPassado = eleicao.DataInicio.Year - 1;
            int anoRetrasado = anoPassado - 1;

            return !resultados.Any(x => x.Eleicao.DataInicio.Year == anoPassado) && !resultados.Any(x => x.Eleicao.DataInicio.Year == anoRetrasado);
        }

        public Candidato AddOrUpdateCandidato(Candidato c)
        {

            FuncionariosService funcService = new FuncionariosService();
            EleicoesService eleicoesService = new EleicoesService();

            //Adiciona ao contexto, ou atualiza
            Eleicao eleicao = eleicoesService.GetEleicao(c.CodigoEleicao);
            Funcionario func = funcService.GetFuncionario(c.MatriculaFuncionario);

            if (eleicao.Funcionarios.Count(x => x.MatriculaFuncionario == c.MatriculaFuncionario) <= 0)
                throw new FuncionarioNaoCadastradoEleicaoException(c.MatriculaFuncionario, c.CodigoEleicao);

            if (!Elegivel(c, eleicao, func))
                throw new FuncionarioNaoElegivelException("Não é permitida a inscrição de funcionários eleitos nas duas útlimas gestões!");

            if (!CandidatoExiste(c.MatriculaFuncionario, c.CodigoEleicao))
            {
                string modulo = eleicao.CodigoModulo == 2 ? "a Comissão Interna de Trabalhadores" : "a CIPA";
                EmailDTO email = new EmailDTO
                {
                    Message = string.Format(Resources.Emails.EmailCandidatura,
                        modulo, func.Login, func.Nome,
                        func.Cargo, func.Area),
                    To = new string[] { func.Email },
                    Copy = func.Gestor != null ? new string[] { func.Gestor.Email } : new string[] { },
                    Subject = "Candidatura Realizada"
                };

                Thread th = new Thread(EmailService.Send);
                th.Start(email);
            }

            db.Candidatos.AddOrUpdate(c);
            db.SaveChanges();
            return c;
        }

        public void ExcluirMotivoReprovacao (Candidato c)
        {
            CandidaturaReprovada reprovacao = db.CandidaturasReprovadas.FirstOrDefault(x => x.CodigoEleicao == c.CodigoEleicao && x.MatriculaFuncionario == c.MatriculaFuncionario);

            if (reprovacao != null)
                db.CandidaturasReprovadas.Remove(reprovacao);

            db.SaveChanges();
        } 

        public IEnumerable<CandidatoFotoDTO> GetCandidatosParaValidacao(Eleicao eleicao, bool? aprovado = null)
        {
            if (eleicao.CodigoEtapa != 4 && eleicao.CodigoEtapa != 19)
                throw new ForaEtapaCandidaturaException(eleicao);

            return db.Candidatos
                .Where(x => x.CodigoEleicao == eleicao.Codigo && aprovado == x.Validado).ToList()
                .Select(x => new CandidatoFotoDTO(x));
        }

        public Candidato AprovarCandidatura(Candidato candidato)
        {
            string modulo = candidato.Eleicao.CodigoModulo == 2 ? "a Comissão Interna de Trabalhadores" : "a CIPA";
            EmailDTO email = new EmailDTO
            {
                Message = string.Format(Resources.Emails.EmailAprovacaoCandidatura, 
                    modulo, candidato.Funcionario.Login, candidato.Funcionario.Nome, 
                    candidato.Funcionario.Cargo, candidato.Funcionario.Area),
                To = new string[] { candidato.Funcionario.Email },
                Copy = (candidato.Funcionario != null && candidato.Funcionario.Gestor != null) ? 
                    new string[] {candidato.Funcionario.Gestor.Email} : new string[] { },
                Subject = "Candidatura Aprovada"
            };

            Thread th = new Thread(EmailService.Send);
            th.Start(email);

            candidato.Validado = true;
            db.Entry(candidato).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return candidato;
        }

        public IEnumerable<Candidato> AprovarTodos(IEnumerable<Candidato> candidatos)
        {
            candidatos.ToList().ForEach(x =>
            {
                Candidato c = db.Candidatos.Find(x.MatriculaFuncionario, x.CodigoEleicao);
                if (c != null) {
                    AprovarCandidatura(c);
                    //c.Validado = flag;
                }
            });
            //db.SaveChanges();
            return candidatos;
        }

        public CandidaturaReprovada ReprovarCandidatura (CandidaturaReprovada candidatura)
        {
            candidatura.Codigo = 0;
            db.Entry(candidatura).State = System.Data.Entity.EntityState.Added;

            try {
                Candidato cand = GetCandidato(candidatura.MatriculaFuncionario, candidatura.CodigoEleicao);

                db.SaveChanges();

                string modulo = cand.Eleicao.CodigoModulo == 2 ? "a Comissão Interna de Trabalhadores" : "a CIPA";
                EmailDTO email = new EmailDTO
                {
                    Message = string.Format(Resources.Emails.EmailReprovacaoCandidatura,
                        modulo, cand.Funcionario.Login, cand.Funcionario.Nome,
                        cand.Funcionario.Cargo, cand.Funcionario.Area, candidatura.Motivo),
                    To = new string[] { cand.Funcionario.Email },
                    Copy = (cand.Funcionario != null && cand.Funcionario.Gestor != null) ? 
                        new string[] { cand.Funcionario.Gestor.Email } : new string[] { },
                    Subject = "Candidatura Reprovada"
                };

                Thread th = new Thread(EmailService.Send);
                th.Start(email);

            } catch (Exception e)
            {
                if (CandidatoExiste(candidatura.MatriculaFuncionario, candidatura.CodigoEleicao))
                    throw new CandidatoNaoEncontradoException();
                else
                    throw e;
            }

            Candidato c = db.Candidatos.Find(candidatura.MatriculaFuncionario, candidatura.CodigoEleicao);
            c.Validado = false;
            db.SaveChanges();
            return candidatura;
        }

        public IEnumerable<CandidatoDTO> ToDTO(IEnumerable<Candidato> candidatos)
        {
            return candidatos.Select(x => new CandidatoDTO(x));
        }

        public bool CandidatoExiste (string matricula, int codigoEleicao)
        {
            return db.Candidatos.Count(x => x.MatriculaFuncionario == matricula && x.CodigoEleicao == codigoEleicao) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}