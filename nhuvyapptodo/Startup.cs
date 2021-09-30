using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nhuvyapptodo.Startup))]
namespace nhuvyapptodo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
