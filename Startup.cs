using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myCoinPurse.Startup))]
namespace myCoinPurse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
