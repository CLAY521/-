using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HttpWebRequestMvc.Startup))]
namespace HttpWebRequestMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
