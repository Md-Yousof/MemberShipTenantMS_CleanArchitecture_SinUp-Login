using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Domain.Models.Authentication_Authorization.Roles
{
    public interface IRoleService
    {
        Task<List<RoleModel>> GetRolesAsync();

        Task<List<string>> GetUserRolesAsync(string emailId);

        Task<List<string>> AddRolesAsync(string[] roles);

        Task<bool> AddUserRoleAsync(string userEmail, string[] roles);

    }
}
