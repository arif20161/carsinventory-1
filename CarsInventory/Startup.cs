using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarsInventory.Startup))]
namespace CarsInventory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
