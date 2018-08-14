using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelPlannerAppProject.Startup))]
namespace TravelPlannerAppProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
