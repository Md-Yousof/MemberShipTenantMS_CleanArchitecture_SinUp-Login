using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Application.Services
{
    public interface ITokenService
    {
        JwtSecurityToken GetToken(List<Claim> authClaims);
    }
}
