using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_authenticate.Startup))]
namespace Vidly_authenticate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
