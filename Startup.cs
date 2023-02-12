using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResturantFinder.Startup))]
namespace ResturantFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
