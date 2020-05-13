using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AxDBInventory.Startup))]
namespace AxDBInventory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
