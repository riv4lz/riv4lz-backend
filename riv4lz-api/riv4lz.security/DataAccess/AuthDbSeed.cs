using Microsoft.AspNetCore.Identity;
using riv4lz.security.Models;

namespace riv4lz.security.DataAccess;

public class AuthDbSeed
{
    public static async Task SeedData(AuthContext context, UserManager<IdentityUser<Guid>> userManager)
    {
        //await context.Database.EnsureDeletedAsync();
        if (!userManager.Users.Any())
        {
            var users = new List<AppUser>()
            {
                new AppUser() {Id = new Guid(), Email = "jonas@riv4lz.com", UserName = "Jonas"},
                new AppUser() {Id = new Guid(), Email = "mike@riv4lz.com", UserName = "Mike"},
                new AppUser() {Id = new Guid(), Email = "frederik@riv4lz.com", UserName = "Frederik"},
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "t");
            }
        }
    }
}