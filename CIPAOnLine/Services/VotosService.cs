﻿using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
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
                        db.Votos.Count(y => y.MatriculaCandidato == cand.MatriculaFuncionario && y.CodigoEleicao == codEleicao)))
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

        public ICollection<EleitorDTO> RelatorioEleitores(int codEleicao)
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

            return union;
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
                .Select(x => new CandidatoEleitoDTO(x, db.Votos.Count(y => y.MatriculaCandidato == x.MatriculaFuncionario && y.CodigoEleicao == codEleicao)))
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
            voto.DataHorario = DateTime.Now;

            if (!eleicoesService.FuncionarioExiste(voto.CodigoEleicao, voto.MatriculaCandidato))
                throw new CandidatoNaoEncontradoException();

            if (!eleicoesService.FuncionarioExiste(voto.CodigoEleicao, voto.MatriculaEleitor))
                throw new FuncionarioNaoEncontradoException(voto.MatriculaEleitor);

            db.Votos.Add(voto);
            db.SaveChanges();

            return voto;
        }

        public VotoBranco RegistrarVotoBranco(VotoBranco voto)
        {
            EleicoesService eleicoesService = new EleicoesService();
            voto.IP = HttpContext.Current.Request.UserHostAddress;
            voto.DataHorario = DateTime.Now;

            if (!eleicoesService.FuncionarioExiste(voto.CodigoEleicao, voto.MatriculaEleitor))
                throw new FuncionarioNaoEncontradoException(voto.MatriculaEleitor);

            db.VotosBrancos.Add(voto);
            db.SaveChanges();

            return voto;
        }

        public List<ResultadoEleicao> VerificarEleicoesPorFuncionario(string matricula, string login)
        {
            return db.ResultadosEleicoes.Where(x => x.Login == login && x.MatriculaFuncionario == matricula).ToList();
        }

        public bool VotoExiste(string eleitor, int codEleicao)
        {
            return db.Votos.Count(e => e.MatriculaEleitor == eleitor && e.CodigoEleicao == codEleicao) +
                db.VotosBrancos.Count(e => e.MatriculaEleitor == eleitor && e.CodigoEleicao == codEleicao) > 0;
        }

        public void Dispose()
        {
           db.Dispose();
        }
    }
}