using MemberShipTenantMS_CleanArchitecture_Application.DTO_s;
using MemberShipTenantMS_CleanArchitecture_Domain.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Application.Assets
{
    public class AssetService
    {
        private readonly IAssetRepository _asset;
        public AssetService(IAssetRepository asset) 
        {
            _asset = asset;
        }

        public async Task<AssetDto> CreateAsset(AssetDto assetDto)
        {
            var asset = new Asset
            {
                AssetName = assetDto.AssetName,
                Description = assetDto.Description,

            };

            var assets =  await _asset.CreateAsync(asset);
            assetDto.AssetId = assets.AssetId;
            return assetDto;


        }

        public async Task<IEnumerable<AssetDto>> GetAllAsset()
        {
            var assets = await _asset.GetAllAsynce();
            return assets.Select(a => new AssetDto
            {
                AssetId = a.AssetId,
                AssetName = a.AssetName,
                Description = a.Description
            }).ToList();
        }
    }
}
