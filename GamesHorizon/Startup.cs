using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamesHorizon.Startup))]
namespace GamesHorizon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
