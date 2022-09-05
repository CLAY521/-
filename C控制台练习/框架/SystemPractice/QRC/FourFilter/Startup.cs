using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FourFilter.Startup))]
namespace FourFilter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
