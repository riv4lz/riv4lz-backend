namespace riv4lz.security;

public class AuthDbSeed
{
    public static async Task SeedData(AuthContext context)
    {
        if (context.AuthUsers.Any())
        {
            return;
        }
        
        // Add seed data
        
        // await context.addstuff
        // await context.saveasync
    }
}