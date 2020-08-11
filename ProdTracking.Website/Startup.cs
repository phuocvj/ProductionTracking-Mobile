using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProdTracking.Website.Startup))]
namespace ProdTracking.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
