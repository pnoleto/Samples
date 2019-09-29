//-----------------------------------------------------------------------
// <copyright file="Startup.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------

using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebAPI.Startup))]
namespace WebAPI
{
    public class Startup
    {
        /// <summary>
        /// Configurações do Token de acesso as WebApis
        /// </summary>
        /// <returns></returns>
        private OAuthAuthorizationServerOptions AccessTokenOptions()
        {
            return new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(30),
                Provider = new AccessTokenProvider(),
                RefreshTokenProvider = new RefreshAccessTokenProvider()
            };
        }

        public void Configuration(IAppBuilder app)
        {
            // configuracao WebApi
            var config = new HttpConfiguration();
            // Ativa o registro das rotas da WebAPI
            WebApiConfig.Register(config);
            // ativando cors
            app.UseCors(CorsOptions.AllowAll);
            // Ativando o metodo de autenticação na api
            app.UseOAuthAuthorizationServer(AccessTokenOptions());
            // Ativando a geração de token na api
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            // ativando configuração WebApi
            app.UseWebApi(config);
        }
    }
}