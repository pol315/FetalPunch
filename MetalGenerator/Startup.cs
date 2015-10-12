using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MetalGenerator.Startup))]
namespace MetalGenerator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
