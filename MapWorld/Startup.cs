using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapWorld.Startup))]
namespace MapWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
