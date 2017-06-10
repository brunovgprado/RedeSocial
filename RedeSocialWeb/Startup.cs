using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedeSocialWeb.Startup))]
namespace RedeSocialWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
