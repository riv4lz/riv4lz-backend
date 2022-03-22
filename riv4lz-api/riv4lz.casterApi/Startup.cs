using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using riv4lz.casterApi.Extensions;
using riv4lz.dataAccess;
using riv4lz.security;
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

            services.AddControllers();
            services.AddApplicationServices();
            services.AddIdentityServices(_configuration);
            
            //TODO fix
            
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
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CasterDbContext casterDbContext)
        {
            if (env.IsDevelopment())
            {
                new CasterDbSeeder(casterDbContext).SeedDevelopment();
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
