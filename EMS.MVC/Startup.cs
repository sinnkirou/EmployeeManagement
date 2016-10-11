using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMS.MVC.Startup))]
namespace EMS.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
