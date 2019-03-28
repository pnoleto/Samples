//-----------------------------------------------------------------------
// <copyright file="AccessTokenProvider.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Services;

namespace WebAPI
{
    public class AccessTokenProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Valida as credenciais de usuario pelo clientId e Secret
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            await base.ValidateClientAuthentication(context);
        }

        /// <summary>
        /// Valida as credenciais de usuario informadas pelo lusername e password
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (LoginService.Login(context.UserName, context.Password))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.PrimarySid, System.Guid.NewGuid().ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                context.Validated(identity);
            }
            else
            {
                context.SetError("acesso inválido", "As credenciais do usuário não conferem....");
                return;
            }

            await base.GrantResourceOwnerCredentials(context);
        }

        /// <summary>
        /// Cria um novo tokem e adiciona no contexto da solicitação do cliente
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            AuthenticationTicket ticket = new AuthenticationTicket(context.Ticket.Identity, context.Ticket.Properties);
            context.Validated(ticket);
            await base.GrantRefreshToken(context);
        }
    }
}