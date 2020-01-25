using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QREXP.Startup))]
namespace QREXP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
