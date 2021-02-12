using System;
using IngameDemo.Web.Areas.Identity.Data;
using IngameDemo.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IngameDemo.Web.Areas.Identity.IdentityHostingStartup))]
namespace IngameDemo.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IngameDemoWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IngameDemoWebContextConnection")));

                services.AddDefaultIdentity<IngameDemoWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IngameDemoWebContext>();
            });
        }
    }
}