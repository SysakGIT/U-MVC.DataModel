using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(U7MVC.Startup))]
namespace U7MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
