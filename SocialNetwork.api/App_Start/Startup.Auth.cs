using Microsoft.Owin.Security.OAuth;
using Owin;
using SocialNetwork.api.App_Start;
using SocialNetwork.api.Models;
using SocialNetwork.api.Providers;
using System;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SocialNetwork.api
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {

            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);


            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                Provider = new ApplicationOAuthProvider(),
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                // Nota: Remover esta linha antes de colocar em produção
                AllowInsecureHttp = true
            };

       
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}