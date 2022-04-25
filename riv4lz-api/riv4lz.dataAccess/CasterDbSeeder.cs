
using riv4lz.dataAccess.Entities;

namespace riv4lz.dataAccess;

public class CasterDbSeeder
{
    private readonly CasterDbContext _ctx;

    public CasterDbSeeder(CasterDbContext ctx)
    {
        _ctx = ctx;
    }

    public async void SeedDevelopment()
    {
        _ctx.Database.EnsureCreated();

        if (!_ctx.CasterProfiles.Any())
        {
            var caster1 = new CasterProfileEntity()
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
            
            var caster2 = new CasterProfileEntity()
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
            var org1 = new OrganisationProfileEntity()
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
            var org2 = new OrganisationProfileEntity()
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
    }
}