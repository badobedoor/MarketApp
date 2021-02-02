using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminPanal.Startup))]
namespace AdminPanal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
