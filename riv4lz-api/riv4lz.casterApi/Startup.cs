using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using riv4lz.casterApi.Extensions;
using riv4lz.dataAccess;
using riv4lz.Mediator;
using riv4lz.Mediator.Commands.CasterCommands;
using riv4lz.security.DataAccess;

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

            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddApplicationServices();
            services.AddIdentityServices(_configuration);
            
            
            services.AddSwaggerDocumentation();

            services.AddDbContext<CasterDbContext>(options =>
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
                        .AllowAnyMethod();
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CasterDbContext casterDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Dev-cors");
                new CasterDbSeeder(casterDbContext).SeedDevelopment();
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
            });
            
        }
    }
}
