using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TsmBank.Startup))]
namespace TsmBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
