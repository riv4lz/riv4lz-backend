using Microsoft.AspNetCore.Identity;

namespace riv4lz.security;

public class AuthDbSeed
{
    public static async Task SeedData(AuthContext context, UserManager<AppUser> userManager)
    {
        //await context.Database.EnsureDeletedAsync();
        if (!userManager.Users.Any())
        {
            var users = new List<AppUser>()
            {
                new AppUser() {Email = "jonas@riv4lz.com", UserName = "Jonas"},
                new AppUser() {Email = "mike@riv4lz.com", UserName = "Mike"},
                new AppUser() {Email = "frederik@riv4lz.com", UserName = "Frederik"},
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "t");
            }
        }
    }
}