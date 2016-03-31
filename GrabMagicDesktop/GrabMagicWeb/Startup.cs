using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrabMagicWeb.Startup))]
namespace GrabMagicWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
