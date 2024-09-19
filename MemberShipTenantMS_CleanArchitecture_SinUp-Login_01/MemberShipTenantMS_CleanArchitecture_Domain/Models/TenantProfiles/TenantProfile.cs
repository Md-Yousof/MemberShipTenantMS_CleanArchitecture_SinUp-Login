using MemberShipTenantMS_CleanArchitecture_Domain.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Domain.Models.TenantProfiles
{
    public class TenantProfile
    {
        public int TenantProfileId { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public int AssetId { get; set; }
        [JsonIgnore]
        public Asset Asset { get; set; }
        // Foreign Key
        public int MemberProfileId { get; set; }
        //public MemberProfile MemberProfiles { get; set; }

    }
}
