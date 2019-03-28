//-----------------------------------------------------------------------
// <copyright file="RefreshAccessTokenProvider.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace WebAPI
{
    internal class RefreshAccessTokenProvider : AuthenticationTokenProvider
    {
        /// <summary>
        /// Cria um novo token de refresh token com um expire time padrao e adicona ao contexto
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            context.Ticket.Properties.IssuedUtc = DateTime.Now;
            context.Ticket.Properties.ExpiresUtc = DateTime.Now.AddMinutes(30);

            await base.CreateAsync(context);
        }

        /// <summary>
        /// Deserializa o token criado no contexto de acesso do usuario 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
            await base.ReceiveAsync(context);
        }
    }
}