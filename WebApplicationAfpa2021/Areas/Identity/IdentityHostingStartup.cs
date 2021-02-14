using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationAfpa2021.Areas.Identity.Data;
using WebApplicationAfpa2021.Data;

[assembly: HostingStartup(typeof(WebApplicationAfpa2021.Areas.Identity.IdentityHostingStartup))]
namespace WebApplicationAfpa2021.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DefaultContextIdentity>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultContextConnection")));

                services.AddDefaultIdentity<WebApplicationAfpa2021User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DefaultContextIdentity>();
            });
        }
    }
}