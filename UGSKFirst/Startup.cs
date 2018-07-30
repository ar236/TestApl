using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UGSKFirst.Startup))]
namespace UGSKFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
