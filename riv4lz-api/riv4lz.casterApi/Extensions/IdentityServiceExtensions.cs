using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using riv4lz.casterApi.Services;
using riv4lz.security;
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
            services.AddScoped<TokenService>();

            return services;
        }
    }
}

