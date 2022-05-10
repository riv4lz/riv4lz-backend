using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using riv4lz.casterApi.Extensions;
using riv4lz.casterApi.SignalR;
using riv4lz.dataAccess;
using riv4lz.Mediator.Commands.Auth;
using riv4lz.security.DataAccess;
using StackExchange.Redis;

namespace riv4lz.casterApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddApplicationServices(_configuration);
            services.AddIdentityServices(_configuration);
            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext, ChatContext chatContext)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Dev-cors");
                new DbSeeder(dataContext, chatContext).SeedDevelopment();
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }

            if (env.IsProduction())
            {
                app.UseCors("Prod-cors");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
            
        }
    }
}
