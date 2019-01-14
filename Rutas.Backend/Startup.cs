using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rutas.Backend.Startup))]
namespace Rutas.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
