using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Koora.Startup))]
namespace Koora
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
