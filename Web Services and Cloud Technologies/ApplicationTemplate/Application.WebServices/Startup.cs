using Application.WebServices;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Application.WebServices
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}