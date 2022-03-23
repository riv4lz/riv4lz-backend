using Microsoft.AspNetCore.Identity;
using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;

namespace riv4lz.security.DataAccess;

public class AuthDbSeed
{
    public AuthDbSeed()
    {
        
    }
    public static async Task SeedData(AuthContext context,
        UserManager<IdentityUser<Guid>> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {

        if (!context.Roles.Any())
        {
            
            var roles = new List<IdentityRole<Guid>>()
            {
                new IdentityRole<Guid>() {Id = new Guid(), Name = "Caster"},
                new IdentityRole<Guid>() {Id = new Guid(), Name = "Organisation"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
            
            
        }
        
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

            //await userManager.AddToRoleAsync(users[1], "Caster");
            //await userManager.AddToRoleAsync(users[1], "Caster");
            //await userManager.AddToRoleAsync(users[1], "Caster");
        }

        
        
        
    }
}