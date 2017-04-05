using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektniZadatakRadnaVerzija1.Startup))]
namespace ProjektniZadatakRadnaVerzija1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
