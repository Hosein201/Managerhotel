using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Managerhotel.Startup))]
namespace Managerhotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
