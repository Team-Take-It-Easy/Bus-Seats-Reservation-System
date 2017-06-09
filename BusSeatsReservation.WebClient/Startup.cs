using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusSeatsReservation.WebClient.Startup))]
namespace BusSeatsReservation.WebClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
