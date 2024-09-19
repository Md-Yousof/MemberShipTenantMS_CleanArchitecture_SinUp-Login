using MemberShipTenantMS_CleanArchitecture_Application.Assets;
using MemberShipTenantMS_CleanArchitecture_Application.Authentication;
using MemberShipTenantMS_CleanArchitecture_Domain.Models.Authentication_Authorization.Roles;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Application
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {

            services.AddScoped<AuthenticationService>();
            services.AddScoped<AssetService>();

            services.AddScoped<IRoleService, RoleService>();



            return services;
        }
    }
}
