using MemberShipTenantMS_CleanArchitecture_Domain.Models.Assets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Insfractructure.Services
{
    public static class ModelsSeeder
    {
        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
                new IdentityRole { Name = "HR", ConcurrencyStamp = "3", NormalizedName = "HR" }
            );
        }

        public static void SeedAssets(ModelBuilder builder)
        {
            builder.Entity<Asset>().HasData(
                new Asset { AssetId = 1, AssetName = "Asset-1", Description = "Asset-1 Managing Admin" },
                new Asset { AssetId = 2, AssetName = "Asset-2", Description = "Asset-2 Managing Admin" },
                new Asset { AssetId = 3, AssetName = "Asset-3", Description = "Asset-3 Managing Admin" }
            );
        }
    }
}