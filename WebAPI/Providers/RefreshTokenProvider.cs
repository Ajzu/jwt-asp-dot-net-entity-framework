using EnityModel;
using Microsoft.Owin.Security.Infrastructure;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace WebAPI.Providers
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");


            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var token = new RefreshToken()
            {
                RefreshTokensId = refreshTokenId,
                ClientId = clientid,
                Subject = context.Ticket.Identity.Name,
                IssuedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.IssuedAt;
            context.Ticket.Properties.ExpiresUtc = token.ExpiresAt;

            token.ProtectedTicket = context.SerializeTicket();
            RefreshTokenService refreshTokenService = new RefreshTokenService();
            var result = await refreshTokenService.AddRefreshToken(token);

            if (result.Success)
            {
                context.SetToken(refreshTokenId);
            }


        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {

            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string refreshTokenId = context.Token;

            RefreshTokenService refreshTokenService = new RefreshTokenService();
            var refreshToken = await refreshTokenService.FindRefreshToken(refreshTokenId);

            if (refreshToken.Success)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.Data.ProtectedTicket);
                var result = await refreshTokenService.RemoveRefreshToken(refreshToken.Data);
            }

        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);

            if (context.Ticket == null)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                context.Response.ReasonPhrase = "invalid token";
                return;
            }

            if (context.Ticket.Properties.ExpiresUtc <= DateTime.UtcNow)
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                context.Response.ReasonPhrase = "unauthorized";
                return;
            }

            context.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddDays(2);
            context.SetTicket(context.Ticket);
        }
    }
}