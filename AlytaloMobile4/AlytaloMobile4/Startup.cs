using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlytaloMobile4.Startup))]
namespace AlytaloMobile4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
