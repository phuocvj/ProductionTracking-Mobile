using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ProdTracking.Website.Startup))]
namespace ProdTracking.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
