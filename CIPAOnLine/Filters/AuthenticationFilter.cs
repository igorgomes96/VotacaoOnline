using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using CIPAOnLine.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace CIPAOnLine.Filters
{
    public class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        //private DateTime DATA_EXPIRACAO = new DateTime(2018, 12, 31);

        public bool AllowMultiple
        {
            get
            {
                return true;
            }
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {

            // 1. Look for credentials in the request.
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            //if (DateTime.Today > DATA_EXPIRACAO)
            //{
            //    context.ErrorResult = new AuthenticationFailureResult("O período experimental do sistema de Votação Online expirou! Contate os responsáveis pelo sistema.", request);
            //    return;
            //}

            // 2. If there are no credentials, do nothing.
            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Requisição sem credenciais!", request);
                return Task.FromResult<object>(null);
            }

            // 3. If there are credentials but the filter does not recognize the authentication scheme, do nothing.
            if (authorization.Scheme != "Basic")
            {
                context.ErrorResult = new AuthenticationFailureResult("Tipo de autenticação não reconhecida!", request);
                return Task.FromResult<object>(null);
            }

            // 4. If there are credentials that the filter understands, try to validate them.
            // 5. If the credentials are bad, set the error result.
            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Credenciais não encontradas", request);
                return Task.FromResult<object>(null);
            }

            string Token = authorization.Parameter;

            IPrincipal principal = AuthenticateAsync(Token);
            if (principal == null)
                context.ErrorResult = new AuthenticationFailureResult("Usuário não autenticado ou sessão expirada!", request);

            // 6. If the credentials are valid, set principal.
            else
            {
                context.Principal = principal;
                Thread.CurrentPrincipal = principal;
            }

            return Task.FromResult<object>(null);
        }


        private IPrincipal AuthenticateAsync(string Token)
        {

            //Modelo db = new Modelo();
            //Sessao s = null;
            //try { 
            ////Verifica a Sessão
            //    s = await db.Sessoes.FindAsync(Token);
            //} catch (Exception e)
            //{
            //    Trace.WriteLine(e.Message);
            //}
            ////Se não houver sessão aberta, retorna
            //if (s == null) return null;

            ////Se a sessão tiver expirado, exclui do banco e retorna
            //if (s.Fim.Value < DateTime.Now)
            //{
            //    db.Sessoes.Remove(s);
            //    db.SaveChanges();
            //    return null;
            //}

            //s.Fim = DateTime.Now.AddHours(24.0);    //Atualiza prazo para expirar

            try { 
                string[] values = CryptoGraph.Decrypt(Token).Split(':');

                if (values.Length != 3) return null;

                DateTime expirationTime = DateTime.ParseExact(values[1], "yyyyMMddHHmm", CultureInfo.CreateSpecificCulture("pt-BR"));

                if (DateTime.Now > expirationTime) return null;

                IPrincipal p = new GenericPrincipal(new GenericIdentity(values[0]), new[] { values[2] });

                //db.SaveChanges();
                return p;
            } catch
            {
                return null;
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}