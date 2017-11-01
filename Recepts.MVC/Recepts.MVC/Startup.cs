using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Recepts.MVC.App_Start;
using Recepts.MVC.Resolvers;

[assembly: OwinStartupAttribute(typeof(Recepts.MVC.Startup))]
namespace Recepts.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          
            var config = new HubConfiguration();
            config.Resolver = new NinjectSignalRDependencyResolver(NinjectWebCommon.Kernel);

            app.MapSignalR(config);
        }
    }
}
