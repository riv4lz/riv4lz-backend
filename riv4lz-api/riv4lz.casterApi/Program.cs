using Microsoft.AspNetCore.Identity;
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
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                var context = services.GetRequiredService<AuthContext>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser<Guid>>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var ctx = services.GetRequiredService<DataContext>();
                var chatCtx = services.GetRequiredService<ChatContext>();
                await context.Database.EnsureDeletedAsync();
                await ctx.Database.EnsureDeletedAsync();
                await chatCtx.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
                await ctx.Database.EnsureCreatedAsync();
                await chatCtx.Database.EnsureCreatedAsync();
                //await AuthDbSeed.SeedData(context, userManager, roleManager, ctx, chatCtx);
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
