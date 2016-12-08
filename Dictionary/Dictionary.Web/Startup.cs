using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dictionary.Web.Startup))]
namespace Dictionary.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
