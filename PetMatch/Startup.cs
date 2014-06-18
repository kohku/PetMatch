using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetMatch.Startup))]
namespace PetMatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
