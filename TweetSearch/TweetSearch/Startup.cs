using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TweetSearch.Startup))]
namespace TweetSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
