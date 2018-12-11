using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistema.UI.Startup))]
namespace Sistema.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
