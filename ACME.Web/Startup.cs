using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACME.Web.Startup))]
namespace ACME.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
