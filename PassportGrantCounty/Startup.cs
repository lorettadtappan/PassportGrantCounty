using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassportGrantCounty.Startup))]
namespace PassportGrantCounty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
