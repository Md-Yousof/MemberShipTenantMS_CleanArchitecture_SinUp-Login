using MemberShipTenantMS_CleanArchitecture_Domain.Models.Assets;
using MemberShipTenantMS_CleanArchitecture_Insfractructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Insfractructure.DATA.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // SeedRoles(Builder);
            ModelsSeeder.SeedRoles(builder);
            ModelsSeeder.SeedAssets(builder);

        }

        //private static void SeedRoles(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityRole>().HasData(
        //        new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
        //        new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
        //        new IdentityRole() { Name = "HR", ConcurrencyStamp = "3", NormalizedName = "HR" }

        //   );
        //}
    }
}
