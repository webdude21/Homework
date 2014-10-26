using Exam.WebForms;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Exam.WebForms
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