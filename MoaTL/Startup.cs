using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoaTL.Startup))]
namespace MoaTL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
