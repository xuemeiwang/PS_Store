using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PS_Store.Startup))]
namespace PS_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
