using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Domain.Models.Assets
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsynce();
        Task<Asset> CreateAsync(Asset asset);
    }
}
