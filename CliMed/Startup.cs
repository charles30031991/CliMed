using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CliMed.Startup))]
namespace CliMed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
