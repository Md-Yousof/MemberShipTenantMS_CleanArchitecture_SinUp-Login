using MemberShipTenantMS_CleanArchitecture_Domain.Models.TenantProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Domain.Models.Assets
{
    public class Asset
    {
        public int AssetId { get; set; }
        public string? AssetName { get; set; }
        public string? Description { get; set; }
        public ICollection<TenantProfile>? TenantProfiles { get; set; }

    }
}
