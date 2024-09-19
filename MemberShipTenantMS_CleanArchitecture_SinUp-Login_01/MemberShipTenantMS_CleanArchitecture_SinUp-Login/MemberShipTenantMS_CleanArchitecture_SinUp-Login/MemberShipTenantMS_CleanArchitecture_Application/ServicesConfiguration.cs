using MemberShipTenantMS_CleanArchitecture_Application.Assets;
using MemberShipTenantMS_CleanArchitecture_Application.Authentication;
using Microsoft.AspNetCore.Cors.Infrastructure;
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

            return services;
        }
    }
}
