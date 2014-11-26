using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(V1.TestAutomation.SampleApp.Startup))]
namespace V1.TestAutomation.SampleApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
