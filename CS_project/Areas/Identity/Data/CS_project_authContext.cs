using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_project.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CS_project.Data
{
    public class CS_project_authContext : IdentityDbContext<CS_projectUserApplication>
    {
        public CS_project_authContext(DbContextOptions<CS_project_authContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
