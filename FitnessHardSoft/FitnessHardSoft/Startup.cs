using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessHardSoft.Startup))]
namespace FitnessHardSoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
