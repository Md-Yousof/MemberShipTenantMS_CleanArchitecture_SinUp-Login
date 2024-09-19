using MemberShipTenantMS_CleanArchitecture_Application.Assets;
using MemberShipTenantMS_CleanArchitecture_Application.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipTenantMS_CleanArchitecture_Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly AssetService _assetService;
        public AssetController(AssetService assetService) 
        {
            this._assetService = assetService;
        }

        //[Authorize(Roles ="User")]
        [HttpGet]
        public async Task<IActionResult> GetAllAssetAsync()
        {
            var asset = await _assetService.GetAllAsset();
            if(asset == null)
            {
                throw new Exception("Asset Not Available here..");
            }
            return Ok(asset);
        }

        //[Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(AssetDto asset)
        {
            var create = await _assetService.CreateAsset(asset);
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return Ok(create);

        }
    }
}
