using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Invoicer.Startup))]
namespace Invoicer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
