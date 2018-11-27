using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ankiety_PZ.Startup))]
namespace Ankiety_PZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
