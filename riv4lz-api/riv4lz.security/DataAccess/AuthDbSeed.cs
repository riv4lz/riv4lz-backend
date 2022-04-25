using Microsoft.AspNetCore.Identity;


namespace riv4lz.security.DataAccess;

public class AuthDbSeed
{
    public AuthDbSeed()
    {
        
    }
    public static async Task SeedData(AuthContext context,
        UserManager<IdentityUser<Guid>> userManager, RoleManager<IdentityRole<Guid>> roleManager, 
        SignInManager<IdentityUser<Guid>> signInManager)
    {
        var casterRole = new IdentityRole<Guid>() {Id = new Guid(), Name = "caster"};
        var organisationRole = new IdentityRole<Guid>() {Id = new Guid(), Name = "organisation"};

        var user1 = new IdentityUser<Guid>() {Id = Guid.NewGuid(), Email = "j@r.co", UserName = "Jonas"};
        var user2 = new IdentityUser<Guid>() {Id = Guid.NewGuid(), Email = "m@r.co", UserName = "Mike"};
        var user3 = new IdentityUser<Guid>() {Id = Guid.NewGuid(), Email = "f@r.co", UserName = "Frederik"};


        if (!context.Roles.Any())
        {
            await roleManager.CreateAsync(casterRole);
            await roleManager.CreateAsync(organisationRole);
        }
        
        //await context.Database.EnsureDeletedAsync();
        if (!userManager.Users.Any())
        {
            await userManager.CreateAsync(user1, "pw");
            await userManager.AddToRoleAsync(user1, casterRole.Name);

            await userManager.CreateAsync(user2, "pw");
            await userManager.AddToRoleAsync(user2, casterRole.Name);
            
            await userManager.CreateAsync(user3, "pw");
            await userManager.AddToRoleAsync(user3, casterRole.Name);
        }
    }
}