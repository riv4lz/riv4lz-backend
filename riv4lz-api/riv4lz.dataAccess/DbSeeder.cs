using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;

namespace riv4lz.dataAccess;

public class DbSeeder
{
    private readonly DataContext _ctx;

    public DbSeeder(DataContext ctx)
    {
        _ctx = ctx;
    }

    public async void SeedDevelopment()
    {
        await _ctx.Database.EnsureCreatedAsync();

        if (!_ctx.Teams.Any())
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
            
            await _ctx.Teams.AddRangeAsync(t1, t2, t3, t4, t5, t6);
            await _ctx.SaveChangesAsync();
        }

        if (!_ctx.CasterProfiles.Any())
        {
            var caster1 = new CasterProfile()
            {
                CasterId = Guid.NewGuid(),
                BannerImage = "",
                Description = "Will cast for money!",
                DiscordURL = "discord.gg/url",
                FacebookURL = "facebook.com/url",
                FirstName = "Borat",
                LastName = "Boratsen",
                GamerTag = "BoraTheCaster",
                ProfileImage = "url",
                TwitchURL = "twitch.tv/url",
                TwitterURL = "twitter.com/url",
            };
            
            var caster2 = new CasterProfile()
            {
                CasterId = Guid.NewGuid(),
                BannerImage = "",
                Description = "Will cast for MORE money!",
                DiscordURL = "discord.gg/url",
                FacebookURL = "facebook.com/url",
                FirstName = "Mike",
                LastName = "Hovedskov",
                GamerTag = "Frann0",
                ProfileImage = "url",
                TwitchURL = "twitch.tv/url",
                TwitterURL = "twitter.com/url",
            };
            
            await _ctx.CasterProfiles.AddAsync(caster1);
            await _ctx.CasterProfiles.AddAsync(caster2);
            await _ctx.SaveChangesAsync();
        }

        if (!_ctx.OrganisationProfiles.Any())
        {
            var org1 = new OrganisationProfile()
            {
                OrganisationId = Guid.NewGuid(),
                BannerImage = "",
                Description = "We host the greatest matches in the world!",
                DiscordURL = "discord.gg/url",
                FacebookURL = "facebook.com/url",
                FirstName = "Jonas",
                LastName = "Nielsen",
                OrganisationName = "DCSA",
                ProfileImage = "url",
                TwitchURL = "twitch.tv/url",
                TwitterURL = "twitter.com/url",
            };
            var org2 = new OrganisationProfile()
            {
                OrganisationId = Guid.NewGuid(),
                BannerImage = "",
                Description = "All LOL games in the world!",
                DiscordURL = "discord.gg/url",
                FacebookURL = "facebook.com/url",
                FirstName = "Frederik",
                LastName = "Otto",
                OrganisationName = "LoLand",
                ProfileImage = "url",
                TwitchURL = "twitch.tv/url",
                TwitterURL = "twitter.com/url",
            };
            
            await _ctx.OrganisationProfiles.AddAsync(org1);
            await _ctx.OrganisationProfiles.AddAsync(org2);
            await _ctx.SaveChangesAsync();
        }

        if (!_ctx.Events.Any())
        {
            var orgs = await _ctx.OrganisationProfiles.ToListAsync();
            var teams = await _ctx.Teams.ToListAsync();
            
            var e1 = new Event()
            {
                Description = "We are going to play a game!",
                Id = Guid.NewGuid(),
                OrganisationId = orgs[0].OrganisationId,
                Organiser = "DCSA",
                Price = 9999.99,
                Teams = new List<Team>(){teams[0], teams[1]},
                Time = DateTime.Today.AddMonths(6),
                Game = "Counter Strike: Global Offensive",
            };
            
            var e2 = new Event()
            {
                Description = "We are going to play another game!",
                Id = Guid.NewGuid(),
                OrganisationId = orgs[1].OrganisationId,
                Organiser = "LoLand",
                Price = 99.99,
                Teams = new List<Team>(){teams[2], teams[3]},
                Time = DateTime.Today.AddMonths(5),
                Game = "LOL"
            };
            
            await _ctx.Events.AddAsync(e1);
            await _ctx.Events.AddAsync(e2);
            await _ctx.SaveChangesAsync();
        }

        if (!_ctx.Offers.Any())
        {
            var casters = await _ctx.CasterProfiles.ToListAsync();
            var events = await _ctx.Events.ToListAsync();
            
            var o1 = new Offer()
            {
                Id = Guid.NewGuid(),
                EventId = events[0].Id,
                CasterId = casters[0].CasterId,
            };
            
            var o2 = new Offer()
            {
                Id = Guid.NewGuid(),
                EventId = events[0].Id,
                CasterId = casters[1].CasterId,
            };

            var o4 = new Offer()
            {
                Id = Guid.NewGuid(),
                EventId = events[1].Id,
                CasterId = casters[0].CasterId,
            };
            
            var o5 = new Offer()
            {
                Id = Guid.NewGuid(),
                EventId = events[1].Id,
                CasterId = casters[1].CasterId,
            };
            
            await _ctx.Offers.AddAsync(o1);
            await _ctx.Offers.AddAsync(o2);
            await _ctx.Offers.AddAsync(o4);
            await _ctx.Offers.AddAsync(o5);
            await _ctx.SaveChangesAsync();
        }

        if (!_ctx.ChatRooms.Any())
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
                UserName = "Chatman",
                Text = "Hello World!",
            };
            var message2 = new Message()
            {
                ChatRoomId = r1.Id,
                Id = Guid.NewGuid(),
                UserName = "Admin",
                Text = "Hello Chatman!",
            };
            var message3 = new Message()
            {
                ChatRoomId = r1.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                Text = "You don't know me!",
            };
            
            var message11 = new Message()
            {
                ChatRoomId = r2.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                Text = "Hello World!",
            };
            var message12 = new Message()
            {
                ChatRoomId = r2.Id,
                Id = Guid.NewGuid(),
                UserName = "Admin",
                Text = "Hello Chatman!",
            };
            var message13 = new Message()
            {
                ChatRoomId = r2.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                Text = "You don't know me!",
            };
            
            var message20 = new Message()
            {
                ChatRoomId = r3.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                Text = "Hello World!",
            };
            var message21 = new Message()
            {
                ChatRoomId = r3.Id,
                Id = Guid.NewGuid(),
                UserName = "Admin",
                Text = "Hello Chatman!",
            };
            var message22 = new Message()
            {
                ChatRoomId = r3.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                Text = "You don't know me!",
            };
            
            var message30 = new Message()
            {
                ChatRoomId = r4.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                Text = "Hello World!",
            };
            var message31 = new Message()
            {
                ChatRoomId = r4.Id,
                Id = Guid.NewGuid(),
                UserName = "Admin",
                Text = "Hello Chatman!",
            };
            var message32 = new Message()
            {
                ChatRoomId = r4.Id,
                Id = Guid.NewGuid(),
                UserName = "Chatman",
                Text = "You don't know me!",
            };
            
            await _ctx.ChatRooms.AddAsync(r1);
            await _ctx.ChatRooms.AddAsync(r2);
            await _ctx.ChatRooms.AddAsync(r3);
            await _ctx.ChatRooms.AddAsync(r4);
            await _ctx.Messages.AddAsync(message);
            await _ctx.Messages.AddAsync(message2);
            await _ctx.Messages.AddAsync(message3);
            await _ctx.Messages.AddAsync(message11);
            await _ctx.Messages.AddAsync(message12);
            await _ctx.Messages.AddAsync(message13);
            await _ctx.Messages.AddAsync(message20);
            await _ctx.Messages.AddAsync(message21);
            await _ctx.Messages.AddAsync(message22);
            await _ctx.Messages.AddAsync(message30);
            await _ctx.Messages.AddAsync(message31);
            await _ctx.Messages.AddAsync(message32);
            await _ctx.SaveChangesAsync();
        }
        
        
    }
}