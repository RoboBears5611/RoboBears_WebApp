using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoboBears.Startup))]
namespace RoboBears
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
