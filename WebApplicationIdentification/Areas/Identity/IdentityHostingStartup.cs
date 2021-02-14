using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationIdentification.Areas.Identity.Data;
using WebApplicationIdentification.Data;

[assembly: HostingStartup(typeof(WebApplicationIdentification.Areas.Identity.IdentityHostingStartup))]
namespace WebApplicationIdentification.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApplicationIdentificationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebApplicationIdentificationContextConnection")));

                services.AddDefaultIdentity<WebApplicationIdentificationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebApplicationIdentificationContext>();
            });
        }
    }
}