using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AM_Assignment2.Startup))]
namespace AM_Assignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
