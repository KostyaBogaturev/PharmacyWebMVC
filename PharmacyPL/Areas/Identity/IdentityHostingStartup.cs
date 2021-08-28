using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PharmacyPL.Data;

[assembly: HostingStartup(typeof(PharmacyPL.Areas.Identity.IdentityHostingStartup))]
namespace PharmacyPL.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PharmacyPLContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PharmacyPLContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PharmacyPLContext>();
            });
        }
    }
}