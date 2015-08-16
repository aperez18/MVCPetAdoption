using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPetAdoption.Startup))]
namespace MVCPetAdoption
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
