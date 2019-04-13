using CIPAOnLine.Exceptions;
using CIPAOnLine.Jwt;
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
            if (authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFailureResult("Tipo de autenticação não reconhecida!", request);
                return Task.FromResult<object>(null);
            }

            // 4. If there are credentials that the filter understands, try to validate them.
            // 5. If the credentials are bad, set the error result.
            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Credenciais não encontradas", request);
                return Task.FromResult<object>(null);
            }

            string Token = authorization.Parameter;

            IPrincipal principal = AuthenticateAsync(Token)?.Result;
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


        private Task<IPrincipal> AuthenticateAsync(string token)
        {

            try
            {
                return TokenServices.AuthenticateJwtToken(token);
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