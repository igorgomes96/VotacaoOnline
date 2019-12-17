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
            if (eleicao.CodigoEtapa != 9 && eleicao.CodigoEtapa != 24)
                throw new ForaEtapaVotacaoException(eleicao);

            if (db.Votos.Count(x => x.CodigoEleicao == eleicao.Codigo && x.FuncionarioIdEleitor == usuario.FuncionarioId) > 0 ||
                    db.VotosBrancos.Count(x => x.CodigoEleicao == eleicao.Codigo && x.FuncionarioIdEleitor == usuario.FuncionarioId) > 0)
                throw new VotoJaRealizadoException(usuario.Funcionario, eleicao);

            return db.Candidatos.ToList()
                .Where(x => x.CodigoEleicao == eleicao.Codigo && x.Validado.GetValueOrDefault())
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new CandidatoFotoDTO(x));
        }

        public Candidato GetCandidato(int funcionarioId, int codEleicao)
        {
            EleicoesService eleicoesService = new EleicoesService();

            if (!eleicoesService.FuncionarioExiste(codEleicao, funcionarioId))
                throw new FuncionarioNaoCadastradoEleicaoException(funcionarioId, codEleicao);
            IEnumerable<Candidato> teste = db.Candidatos.Where(x => funcionarioId == x.FuncionarioId);
            Candidato c = db.Candidatos.Find(funcionarioId, codEleicao);

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
            List<ResultadoEleicao> resultados = votosService.VerificarEleicoesPorFuncionario(c.FuncionarioId, func.Login);

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
            Funcionario func = funcService.GetFuncionario(c.FuncionarioId);

            if (eleicao.Funcionarios.Count(x => x.Id == c.FuncionarioId) <= 0)
                throw new FuncionarioNaoCadastradoEleicaoException(c.FuncionarioId, c.CodigoEleicao);

            if (!Elegivel(c, eleicao, func))
                throw new FuncionarioNaoElegivelException("Não é permitida a inscrição de funcionários eleitos nas duas útlimas gestões!");


            string modulo = eleicao.CodigoModulo == 2 ? "a Comissão Interna de Trabalhadores" : "a CIPA";

            EmailDTO email = new EmailDTO
            {
                Message = EmailService.ReplaceParams(Resources.Emails.EmailConfirmacaoCandidatura,
                    Tuple.Create("@MODULO", modulo), Tuple.Create("@NOME", func.Nome),
                    Tuple.Create("@CARGO", func.Cargo), Tuple.Create("@AREA", func.Area)),
                To = new List<string> { func.Email },
                Copy = func.Gestor != null ? new List<string> { func.Gestor.Email } : new List<string> { },
                Subject = "Candidatura Realizada"
            };

            Thread th = new Thread(EmailService.Send);
            th.Start(email);
            
            db.Candidatos.AddOrUpdate(c);
            db.SaveChanges();
            return c;
        }



        public void ExcluirMotivoReprovacao(Candidato c)
        {
            CandidaturaReprovada reprovacao = db.CandidaturasReprovadas.FirstOrDefault(x => x.CodigoEleicao == c.CodigoEleicao && x.FuncionarioId == c.FuncionarioId);

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
                Message = EmailService.ReplaceParams(Resources.Emails.EmailAprovacaoCandidatura,
                    Tuple.Create("@MODULO", modulo), Tuple.Create("@NOME", candidato.Funcionario.Nome),
                    Tuple.Create("@CARGO", candidato.Funcionario.Cargo), Tuple.Create("@AREA", candidato.Funcionario.Area)),
                To = new List<string> { candidato.Funcionario.Email },
                Copy = (candidato.Funcionario != null && candidato.Funcionario.Gestor != null) ?
                    new List<string> { candidato.Funcionario.Gestor.Email } : new List<string> { },
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
                Candidato c = db.Candidatos.Find(x.FuncionarioId, x.CodigoEleicao);
                if (c != null)
                {
                    AprovarCandidatura(c);
                    //c.Validado = flag;
                }
            });
            //db.SaveChanges();
            return candidatos;
        }

        public CandidaturaReprovada ReprovarCandidatura(CandidaturaReprovada candidatura)
        {
            candidatura.Codigo = 0;
            db.Entry(candidatura).State = System.Data.Entity.EntityState.Added;

            try
            {
                Candidato cand = GetCandidato(candidatura.FuncionarioId, candidatura.CodigoEleicao);

                db.SaveChanges();

                string modulo = cand.Eleicao.CodigoModulo == 2 ? "a Comissão Interna de Trabalhadores" : "a CIPA";
                EmailDTO email = new EmailDTO
                {
                    Message = EmailService.ReplaceParams(Resources.Emails.EmailReprovacaoCandidatura,
                    Tuple.Create("@MODULO", modulo), Tuple.Create("@NOME", cand.Funcionario.Nome),
                    Tuple.Create("@CARGO", cand.Funcionario.Cargo), Tuple.Create("@AREA", cand.Funcionario.Area),
                    Tuple.Create("@MOTIVO", candidatura.Motivo)),
                    To = new List<string> { cand.Funcionario.Email },
                    Copy = (cand.Funcionario != null && cand.Funcionario.Gestor != null) ?
                        new List<string> { cand.Funcionario.Gestor.Email } : new List<string>{ },
                    Subject = "Candidatura Reprovada"
                };

                Thread th = new Thread(EmailService.Send);
                th.Start(email);

            }
            catch (Exception e)
            {
                if (CandidatoExiste(candidatura.FuncionarioId, candidatura.CodigoEleicao))
                    throw new CandidatoNaoEncontradoException();
                else
                    throw e;
            }

            Candidato c = db.Candidatos.Find(candidatura.FuncionarioId, candidatura.CodigoEleicao);
            c.Validado = false;
            db.SaveChanges();
            return candidatura;
        }

        public IEnumerable<CandidatoDTO> ToDTO(IEnumerable<Candidato> candidatos)
        {
            return candidatos.Select(x => new CandidatoDTO(x));
        }

        public bool CandidatoExiste(int funcionarioId, int codigoEleicao)
        {
            return db.Candidatos.Count(x => x.FuncionarioId == funcionarioId && x.CodigoEleicao == codigoEleicao) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}