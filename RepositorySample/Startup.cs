using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RepositorySample.Startup))]
namespace RepositorySample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
