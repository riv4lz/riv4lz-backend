
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess.Entities;
using riv4lz.domain;

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
            
            var e1 = new Event()
            {
                Description = "We are going to play a game!",
                Id = Guid.NewGuid(),
                OrganisationId = orgs[0].OrganisationId,
                Organiser = "DCSA",
                Price = 9999.99,
                TeamOne = "Team One",
                TeamTwo = "Team Two",
                Time = DateTime.Today.AddMonths(6)
            };
            
            var e2 = new Event()
            {
                Description = "We are going to play another game!",
                Id = Guid.NewGuid(),
                OrganisationId = orgs[1].OrganisationId,
                Organiser = "LoLand",
                Price = 99.99,
                TeamOne = "Team Three",
                TeamTwo = "Team Four",
                Time = DateTime.Today.AddMonths(5)
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

        if(!_ctx.Comments.Any())
        {
            var c1 = new Comment()
            {
                Body = "Hey her er en besked!",
                CreatedAt = DateTime.Now.AddDays(-1),
                UserName = "Borat"
            };
            var c2 = new Comment()
            {
                Body = "Will you be there?",
                CreatedAt = DateTime.Now.AddDays(-2),
                UserName = "User"
            };
            var c3 = new Comment()
            {
                Body = "I will be there!",
                CreatedAt = DateTime.Now.AddDays(-3),
                UserName = "Bob"
            };
            var c4 = new Comment()
            {
                Body = "I am Nigerian prince, i give you money all the time!",
                CreatedAt = DateTime.Now.AddDays(-4),
                UserName = "Mufufu"
            };
            
            await _ctx.Comments.AddAsync(c1);
            await _ctx.Comments.AddAsync(c2);
            await _ctx.Comments.AddAsync(c3);
            await _ctx.Comments.AddAsync(c4);
            await _ctx.SaveChangesAsync();
        }
    }
}