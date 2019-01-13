using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using CIPAOnLine.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace CIPAOnLine.Jwt
{
    public class TokenServices
    {
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateToken(string username, int expireMinutes = 300, params string[] roles)
        {
            UsuariosService usuariosService = new UsuariosService();
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            Usuario usuario = usuariosService.GetUsuario(username);
            List<int> empresas = usuario.Empresas?.Select(x => x.Codigo).ToList() ?? new List<int>();

            if (usuario.Funcionario != null && !empresas.Contains(usuario.Funcionario.CodigoEmpresa))
                empresas.Add(usuario.Funcionario.CodigoEmpresa);

            var now = DateTime.UtcNow;
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            claims.AddRange(empresas.Select(e => new Claim("company", e.ToString())));
            if (usuario.FuncionarioId.HasValue)
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.FuncionarioId.Value.ToString()));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        private static bool ValidateToken(string token, out IPrincipal principal)
        {
            principal = GetPrincipal(token);

            if (!(principal.Identity is ClaimsIdentity identity))
                return false;

            if (!identity.IsAuthenticated)
                return false;

            // More validate to check whether username exists in system

            return true;
        }

        public static Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            IPrincipal principal;

            if (ValidateToken(token, out principal))
            {
                return Task.FromResult(principal);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                return principal;
            }

            catch (Exception)
            {
                //should write log
                return null;
            }
        }
    }
}