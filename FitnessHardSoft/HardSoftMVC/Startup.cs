using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HardSoftMVC.Startup))]
namespace HardSoftMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
