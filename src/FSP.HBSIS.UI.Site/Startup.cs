using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSP.HBSIS.UI.Site.Startup))]
namespace FSP.HBSIS.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
