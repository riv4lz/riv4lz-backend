using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Photos;
using riv4lz.Mediator.Commands.Auth;
using riv4lz.security.DataAccess;

namespace riv4lz.casterApi.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration _configuration)
        {
            services.AddControllers(options =>
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = _configuration.GetConnectionString("Redis");
                options.InstanceName = "riv4lz_";
            });

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_configuration.GetConnectionString("CasterConnection"));
            });

            services.AddDbContext<AuthContext>(options =>
            {
                options.UseSqlite(_configuration.GetConnectionString("AuthConnection"));
            });

            services.AddDbContext<ChatContext>(options =>
            {
                options.UseSqlite(_configuration.GetConnectionString("ChatConnection"));
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
                
                options.AddPolicy("Prod-cors", policy =>
                {
                    policy
                        .WithOrigins("https://riv4lz:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddMediatR(typeof(CreateUser.Handler).Assembly);
            services.AddAutoMapper(typeof(Startup));
            services.AddSignalR();
            services.Configure<CloudinarySettings>(_configuration.GetSection("Cloudinary"));

            return services;
        }
    }
}


    
