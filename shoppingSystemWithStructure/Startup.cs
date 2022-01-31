using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shoppingSystemWithStructure.Startup))]
namespace shoppingSystemWithStructure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
