using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.security.DataAccess;

namespace riv4lz.casterApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AuthContext>();
                var casterContext = services.GetRequiredService<CasterDbContext>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser<Guid>>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var signinManager = services.GetRequiredService<SignInManager<IdentityUser<Guid>>>();
                await context.Database.MigrateAsync();
                await casterContext.Database.EnsureCreatedAsync();
                await casterContext.Database.MigrateAsync();
                await AuthDbSeed.SeedData(context, userManager, roleManager);
            }
            catch (Exception e)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "An error occured during migration");
            }
            
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
