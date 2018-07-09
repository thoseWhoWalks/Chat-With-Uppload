using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(App.UI.Startup))]

namespace App.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
