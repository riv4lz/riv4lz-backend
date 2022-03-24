using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using riv4lz.casterApi.PolicyHandlers;
using riv4lz.casterApi.Services;
using riv4lz.security.DataAccess;

namespace riv4lz.casterApi.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<IdentityUser<Guid>>(options =>
                {
                    options.Password.RequiredLength = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AuthContext>()
                .AddSignInManager<SignInManager<IdentityUser<Guid>>>();

            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JwtConfig:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(RoleRequirement), policy =>
                {
                    policy.Requirements.Add(new RoleRequirement());
                });
            });
            services.AddTransient<IAuthorizationHandler, CasterRoleRequirementHandler>();
            services.AddScoped<TokenService>();
            return services;
        }
    }
}

