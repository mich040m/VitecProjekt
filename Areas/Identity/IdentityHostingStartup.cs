using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VitecProjekt.Areas.Identity.Data;
using VitecProjekt.Models;

[assembly: HostingStartup(typeof(VitecProjekt.Areas.Identity.IdentityHostingStartup))]
namespace VitecProjekt.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<VitecProjektContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("VitecProjektContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<VitecProjektContext>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<VitecProjektContext>();
            });
        }
    }
}