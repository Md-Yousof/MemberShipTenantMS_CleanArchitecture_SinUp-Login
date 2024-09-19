using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Application.DTO_s
{
    public class AssetDto
    {
        public int AssetId { get; set; }
        public string? AssetName { get; set; }
        public string? Description { get; set; }

        //public ICollection<TenantProfile>? TenantProfiles { get; set; }
    }
}
