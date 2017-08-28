using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SwirlFeed.Startup))]
namespace SwirlFeed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
