using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Domain.Models.Authentication_Authorization.AddUserRoles
{
    public class AddUserModel
    {
        public string UserEmail { get; set; }
        public string[] Roles { get; set; }
    }
}
