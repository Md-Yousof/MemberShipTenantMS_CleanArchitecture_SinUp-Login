using MemberShipTenantMS_CleanArchitecture_Application.Assets;
using MemberShipTenantMS_CleanArchitecture_Application.Services;
using MemberShipTenantMS_CleanArchitecture_Domain.Models.Assets;
using MemberShipTenantMS_CleanArchitecture_Insfractructure.Assets;


//using MemberShipTenantMS_CleanArchitecture_Application.Services.Models;
using MemberShipTenantMS_CleanArchitecture_Insfractructure.DATA.Context;
using MemberShipTenantMS_CleanArchitecture_Insfractructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Insfractructure
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });


            ////Add Email Configs
            //var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            // services.AddSingleton(emailConfig);


            ////add Config for Required Email
            //services.Configure<IdentityOptions>(options =>

            //    options.SignIn.RequireConfirmedEmail = true

            //);


            //services.AddMailKit(config => config.UseMailKit(new MailKitOptions()
            //{
            //    Server = configuration["EmailConfiguration:SmtpServer"],
            //    Port = Convert.ToInt32(configuration["EmailConfiguration:Port"]),
            //    SenderName = configuration["EmailConfiguration:From"],
            //    SenderEmail = configuration["EmailConfiguration:Username"],
            //    Account = configuration["EmailConfiguration:Username"],
            //    Password = configuration["EmailConfiguration:Password"],
            //    Security = true
            //}));


           
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IAssetRepository), typeof(AssetRepository));

            //services.AddScoped<ITokenService, TokenService>();
            // services.AddScoped(typeof(IEmailService), typeof(EmailService));

            // services.AddScoped<IEmailService, EmailService>();

            return services;
        }

    }
}