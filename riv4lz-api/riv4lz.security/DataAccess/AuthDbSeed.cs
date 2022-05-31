using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;
using riv4lz.core.Enums;
using riv4lz.dataAccess;


namespace riv4lz.security.DataAccess;

public class AuthDbSeed
{
    public AuthDbSeed()
    {
       
    }
    public static async Task SeedData(AuthContext authCtx,
        UserManager<IdentityUser<Guid>> userManager, RoleManager<IdentityRole<Guid>> roleManager, DataContext ctx, ChatContext chatCtx)
    {
        var casterRole = new IdentityRole<Guid>() {Id = new Guid(), Name = "Caster"};
        var organisationRole = new IdentityRole<Guid>() {Id = new Guid(), Name = "Organisation"};

        var user1 = new IdentityUser<Guid>() {Id = Guid.NewGuid(), Email = "j@r.co", UserName = "Jonas"};
        var user2 = new IdentityUser<Guid>() {Id = Guid.NewGuid(), Email = "m@r.co", UserName = "Mike"};
        var user3 = new IdentityUser<Guid>() {Id = Guid.NewGuid(), Email = "f@r.co", UserName = "Frederik"};

        //await authCtx.Database.EnsureDeletedAsync();
        //await authCtx.Database.EnsureCreatedAsync();

        if (!authCtx.Roles.Any())
        {
            await roleManager.CreateAsync(casterRole);
            await roleManager.CreateAsync(organisationRole);
            await authCtx.SaveChangesAsync();
        }
        
        if (!userManager.Users.Any())
        {
            await userManager.CreateAsync(user1, "pw");
            await userManager.AddToRoleAsync(user1, casterRole.Name);

            await userManager.CreateAsync(user2, "pw");
            await userManager.AddToRoleAsync(user2, casterRole.Name);
            
            await userManager.CreateAsync(user3, "pw");
            await userManager.AddToRoleAsync(user3, organisationRole.Name);

            await authCtx.SaveChangesAsync();
        }
        
        //await ctx.Database.EnsureDeletedAsync();
        //await ctx.Database.EnsureCreatedAsync();
        
        if (!ctx.Teams.Any())
        {
            var t1 = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "Strikers",
            };
            var t2 = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "EDG",
            };
            var t3 = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "Cloud9",
            };
            var t4 = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "SK Gaming",
            };
            var t5 = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "Spirit of Amiga",
            };
            var t6 = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "Virtus.pro",
            };
            
            await ctx.Teams.AddRangeAsync(t1, t2, t3, t4, t5, t6);
            await ctx.SaveChangesAsync();
        }

        
        
        if (!ctx.Profiles.Any())
        {
            var caster1 = new Profile()
            {
                Id = user1.Id,
                Description = "Will cast for money!",
                DiscordUrl = "discord.gg/url",
                FacebookUrl = "facebook.com/url",
                Name = "BoraTheCaster",
                TwitchUrl = "twitch.tv/url",
                TwitterUrl = "twitter.com/url",
                UserType = UserType.Caster,
                BannerImageUrl = "",
                ProfileImageUrl = ""
            };
            
            var caster2 = new Profile()
            {
                Id = user2.Id,
                Description = "Will cast for MORE money!",
                DiscordUrl = "discord.gg/url",
                FacebookUrl = "facebook.com/url",
                Name = "Frann0",
                TwitchUrl = "twitch.tv/url",
                TwitterUrl = "twitter.com/url",
                UserType = UserType.Caster,
                BannerImageUrl = "",
                ProfileImageUrl = ""
            };
            
            var org1 = new Profile()
            {
                Id = user3.Id,
                Description = "We host the greatest matches in the world!",
                DiscordUrl = "discord.gg/url",
                FacebookUrl = "facebook.com/url",
                Name = "DCSA",
                TwitchUrl = "twitch.tv/url",
                TwitterUrl = "twitter.com/url",
                UserType = UserType.Organisation,
                BannerImageUrl = "",
                ProfileImageUrl = ""
            };
            
            
            await ctx.Profiles.AddAsync(org1);
            await ctx.Profiles.AddAsync(caster1);
            await ctx.Profiles.AddAsync(caster2);
            await ctx.SaveChangesAsync();
        }

        /*

        if (!ctx.Events.Any())
        {
            var orgs = await ctx.Profiles.Where(p => p.UserType == UserType.Organisation).ToListAsync();
            var teams = await ctx.Teams.ToListAsync();
            // com
            var e1 = new Event()
            {
                Description = "We are going to play a game!",
                Id = Guid.NewGuid(),
                OrganisationId = orgs[0].Id,
                Price = 9999.99,
                Teams = new List<Team>(){teams[0], teams[1]},
                Time = DateTime.Today.AddMonths(6),
                Game = "Counter Strike: Global Offensive",
            };
            
            var e2 = new Event()
            {
                Description = "We are going to play another game!",
                Id = Guid.NewGuid(),
                OrganisationId = orgs[1].Id,
                Price = 99.99,
                Teams = new List<Team>(){teams[1], teams[3]},
                Time = DateTime.Today.AddMonths(5),
                Game = "LOL"
            };
            
            await ctx.Events.AddAsync(e1);
            await ctx.Events.AddAsync(e2);
            await ctx.SaveChangesAsync();
        }

        if (!ctx.Offers.Any())
        {
            var casters = await ctx.Profiles.Where(p => p.UserType == UserType.Caster).ToListAsync();
            var events = await ctx.Events.ToListAsync();
            
            var o1 = new Offer()
            {
                Id = Guid.NewGuid(),
                EventId = events[0].Id,
                CasterId = casters[0].Id,
            };
            
            var o2 = new Offer()
            {
                Id = Guid.NewGuid(),
                EventId = events[0].Id,
                CasterId = casters[1].Id,
            };

            var o4 = new Offer()
            {
                Id = Guid.NewGuid(),
                EventId = events[1].Id,
                CasterId = casters[0].Id,
            };
            
            var o5 = new Offer()
            {
                Id = Guid.NewGuid(),
                EventId = events[1].Id,
                CasterId = casters[1].Id,
            };
            
            await ctx.Offers.AddAsync(o1);
            await ctx.Offers.AddAsync(o2);
            await ctx.Offers.AddAsync(o4);
            await ctx.Offers.AddAsync(o5);
            await ctx.SaveChangesAsync();
        }
        //await chatCtx.Database.EnsureDeletedAsync();
        //await chatCtx.Database.EnsureCreatedAsync();
        */
        
        if (!chatCtx.ChatRooms.Any())
        {
            var r1 = new ChatRoom()
            {
                Id = Guid.NewGuid(),
                Name = "general",
            };
            var r2 = new ChatRoom()
            {
                Id = Guid.NewGuid(),
                Name = "counter strike",
            };
            var r3 = new ChatRoom()
            {
                Id = Guid.NewGuid(),
                Name = "lol",
            };
            var r4 = new ChatRoom()
            {
                Id = Guid.NewGuid(),
                Name = "wow",
            };
            
            

            var message = new Message()
            {
                ChatRoomId = r1.Id,
                Id = Guid.NewGuid(),
                UserName = "BoraTheCaster",
                ProfileImageUrl = "",
                Text = "Hello World!",
            };
            var message2 = new Message()
            {
                ChatRoomId = r1.Id,
                Id = Guid.NewGuid(),
                UserName = "Frann0",
                ProfileImageUrl = "",
                Text = "Hello BoraT!",
            };
            var message3 = new Message()
            {
                ChatRoomId = r1.Id,
                Id = Guid.NewGuid(),
                ProfileImageUrl = "",
                UserName = "DCSA",
                Text = "Also hello!",
            };
            
            var message11 = new Message()
            {
                ChatRoomId = r2.Id,
                Id = Guid.NewGuid(),
                UserName = "BoraTheCaster",
                ProfileImageUrl = "",
                Text = "Hello World!",
            };
            var message12 = new Message()
            {
                ChatRoomId = r2.Id,
                Id = Guid.NewGuid(),
                UserName = "Frann0",
                ProfileImageUrl = "",
                Text = "Hello Chatman!",
            };
            var message13 = new Message()
            {
                ChatRoomId = r2.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                ProfileImageUrl = "",
                Text = "You don't know me!",
            };
            
            var message20 = new Message()
            {
                ChatRoomId = r3.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                ProfileImageUrl = "",
                Text = "Hello World!",
            };
            var message21 = new Message()
            {
                ChatRoomId = r3.Id,
                Id = Guid.NewGuid(),
                UserName = "Admin",
                ProfileImageUrl = "",
                Text = "Hello Chatman!",
            };
            var message22 = new Message()
            {
                ChatRoomId = r3.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                ProfileImageUrl = "",
                Text = "You don't know me!",
            };
            
            var message30 = new Message()
            {
                ChatRoomId = r4.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                ProfileImageUrl = "",
                Text = "Hello World!",
            };
            var message31 = new Message()
            {
                ChatRoomId = r4.Id,
                Id = Guid.NewGuid(),
                UserName = "Admin",
                ProfileImageUrl = "",
                Text = "Hello Chatman!",
            };
            var message32 = new Message()
            {
                ChatRoomId = r4.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                ProfileImageUrl = "",
                Text = "You don't know me!",
            };
            
            await chatCtx.ChatRooms.AddAsync(r1);
            await chatCtx.ChatRooms.AddAsync(r2);
            await chatCtx.ChatRooms.AddAsync(r3);
            await chatCtx.ChatRooms.AddAsync(r4);
            await chatCtx.Messages.AddAsync(message);
            await chatCtx.Messages.AddAsync(message2);
            await chatCtx.Messages.AddAsync(message3);
            await chatCtx.Messages.AddAsync(message11);
            await chatCtx.Messages.AddAsync(message12);
            await chatCtx.Messages.AddAsync(message13);
            await chatCtx.Messages.AddAsync(message20);
            await chatCtx.Messages.AddAsync(message21);
            await chatCtx.Messages.AddAsync(message22);
            await chatCtx.Messages.AddAsync(message30);
            await chatCtx.Messages.AddAsync(message31);
            await chatCtx.Messages.AddAsync(message32);
            await chatCtx.SaveChangesAsync();
        
        }
        
    }
    
    
}