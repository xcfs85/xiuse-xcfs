using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(xiuse.Startup))]
namespace xiuse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
