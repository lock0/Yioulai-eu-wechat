using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yioulaieuwechat.Web.Startup))]
namespace Yioulaieuwechat.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
