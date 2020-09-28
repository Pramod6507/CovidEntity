using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CovidEntity.Startup))]
namespace CovidEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
