using Microsoft.AspNetCore.Identity;
using riv4lz.security;

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
            
            services.AddAuthentication();

            return services;
        }
    }
}

