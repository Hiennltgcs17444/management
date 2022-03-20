using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppASM2.Startup))]
namespace AppASM2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
