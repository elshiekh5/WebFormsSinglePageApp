using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SinglePageAppWebForms.Startup))]
namespace SinglePageAppWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
