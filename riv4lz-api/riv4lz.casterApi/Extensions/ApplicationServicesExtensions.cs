using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Cloudinary;
using riv4lz.Mediator.Commands.Auth;
using riv4lz.Mediator.Helpers;
using riv4lz.security.DataAccess;
using StackExchange.Redis;

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

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddSingleton<RedisInstance>();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("Postgres"));
            });

            services.AddDbContext<AuthContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("AuthConnection"));
            });

            services.AddDbContext<ChatContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("ChatConnection"));
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
                        .WithOrigins("http://localhost:3000")
                        .WithOrigins("http://10.0.2.2:8081")
                        .WithOrigins("https://10.0.2.2:8081")
                        .WithOrigins("http://localhost:8081")
                        .WithOrigins("https://localhost:8081")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
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


    
