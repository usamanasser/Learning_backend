using Microsoft.AspNetCore.Hosting;
using LMS.Web.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace LMS.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}