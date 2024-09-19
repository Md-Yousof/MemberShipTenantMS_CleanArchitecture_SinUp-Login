using MemberShipTenantMS_CleanArchitecture_Domain.Models.Assets;
using MemberShipTenantMS_CleanArchitecture_Insfractructure.DATA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Insfractructure.Assets
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _context;
        public AssetRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<Asset> CreateAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        public async Task<IEnumerable<Asset>> GetAllAsynce()
        {
            return await _context.Assets.ToListAsync();
        }
    }
}
