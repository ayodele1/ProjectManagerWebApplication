using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectManager.Web.Startup))]
namespace ProjectManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
