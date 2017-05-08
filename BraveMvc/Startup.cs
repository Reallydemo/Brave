using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BraveMvc.Startup))]
namespace BraveMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
