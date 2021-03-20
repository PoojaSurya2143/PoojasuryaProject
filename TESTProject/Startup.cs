using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TESTProject.Startup))]
namespace TESTProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
