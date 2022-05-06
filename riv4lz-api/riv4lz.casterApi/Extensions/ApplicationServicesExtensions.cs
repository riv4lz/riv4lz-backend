using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Commands.Auth;
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
            
            services.AddSingleton<ConnectionMultiplexer>(config =>
            {
                var configuration = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_configuration.GetConnectionString("CasterConnection"));
            });

            services.AddDbContext<AuthContext>(options =>
            {
                options.UseSqlite(_configuration.GetConnectionString("AuthConnection"));
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

            services.AddMediatR(typeof(CreateUser.Handler).Assembly);
            services.AddAutoMapper(typeof(Startup));
            services.AddSignalR();
            

            return services;
        }
    }
}


    
