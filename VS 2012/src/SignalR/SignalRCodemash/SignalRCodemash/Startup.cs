using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRCodemash.Startup))]
namespace SignalRCodemash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
