using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClaimsTest3.Startup))]
namespace ClaimsTest3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
