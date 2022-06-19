using System;
using CS_project.Areas.Identity.Data;
using CS_project.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CS_project.Areas.Identity.IdentityHostingStartup))]
namespace CS_project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CS_project_authContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CS_project_authContextConnection")));

                services.AddDefaultIdentity<CS_projectUserApplication>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    })
                    .AddEntityFrameworkStores<CS_project_authContext>();
            });
        }
    }
}