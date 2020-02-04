using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Belajar_Identity.Startup))]
namespace Belajar_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
