using Microsoft.Owin;
using Owin;
using ReportManager.BusinessRules;

[assembly: OwinStartupAttribute(typeof(ReportManager.Startup))]
namespace ReportManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            //BusinessRulesXPTO.Main();
        }
    }
}
