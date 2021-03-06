using System;
using System.Collections.Generic;
using riv4lz.core.Entities;
using riv4lz.core.Enums;
using Xunit;

namespace riv4lz.core.test.Entities;

public class ProfileTest
{
    private Profile _profile;

    public ProfileTest()
    {
        _profile = new Profile();
    }
    
    [Fact]
    public void Profile_CanBeInitialized()
    {
        Assert.NotNull(_profile);
    }
    
    [Fact]
    public void Profile_Id_IsGuid()
    {
        Assert.IsType<Guid>(_profile.Id);
    }
    
    [Fact]
    public void Profile_Id_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _profile.Id);
    }
    
    [Fact]
    public void Profile_Id_CanBeSet()
    {
        var id = Guid.NewGuid();
        _profile.Id = id;
        Assert.Equal(id, _profile.Id);
    }
    
    [Fact]
    public void Profile_Name_IsString()
    {
        _profile.Name = "Test";
        Assert.IsType<string>(_profile.Name);
    }
    
    [Fact]
    public void Profile_Name_IsNullByDefault()
    {
        Assert.Null(_profile.Name);
    }
    
    [Fact]
    public void Profile_Name_CanBeSet()
    {
        var name = "Test";
        _profile.Name = name;
        Assert.Equal(name, _profile.Name);
    }
    
    [Fact]
    public void Profile_Name_CanBeSetToNull()
    {
        var name = "Test";
        _profile.Name = name;
        _profile.Name = null;
        Assert.Null(_profile.Name);
    }
    
    [Fact]
    public void Profile_UserType_IsUserType()
    {
        Assert.IsType<UserType>(_profile.UserType);
    }
    
    [Fact]
    public void Profile_UserType_CanBeCaster()
    {
        _profile.UserType = UserType.Caster;
        Assert.Equal(UserType.Caster, _profile.UserType);
    }
    
    [Fact]
    public void Profile_UserType_CanBeOrganisation()
    {
        _profile.UserType = UserType.Organisation;
        Assert.Equal(UserType.Organisation, _profile.UserType);
    }
    
    [Fact]
    public void Profile_Description_IsString()
    {
        _profile.Description = "Test";
        Assert.IsType<string>(_profile.Description);
    }
    
    [Fact]
    public void Profile_Description_IsNullByDefault()
    {
        Assert.Null(_profile.Description);
    }
    
    [Fact]
    public void Profile_Description_CanBeSet()
    {
        var description = "Test";
        _profile.Description = description;
        Assert.Equal(description, _profile.Description);
    }
    
    [Fact]
    public void Profile_FacebookUrl_IsString()
    {
        _profile.FacebookUrl = "Test";
        Assert.IsType<string>(_profile.FacebookUrl);
    }
    
    [Fact]
    public void Profile_FacebookUrl_IsNullByDefault()
    {
        Assert.Null(_profile.FacebookUrl);
    }
    
    [Fact]
    public void Profile_FacebookUrl_CanBeSet()
    {
        var facebookUrl = "Test";
        _profile.FacebookUrl = facebookUrl;
        Assert.Equal(facebookUrl, _profile.FacebookUrl);
    }
    
    [Fact]
    public void Profile_TwitterUrl_IsString()
    {
        _profile.TwitterUrl = "Test";
        Assert.IsType<string>(_profile.TwitterUrl);
    }
    
    [Fact]
    public void Profile_TwitterUrl_IsNullByDefault()
    {
        Assert.Null(_profile.TwitterUrl);
    }
    
    [Fact]
    public void Profile_TwitterUrl_CanBeSet()
    {
        var twitterUrl = "Test";
        _profile.TwitterUrl = twitterUrl;
        Assert.Equal(twitterUrl, _profile.TwitterUrl);
    }
    
    [Fact]
    public void Profile_DiscordUrl_IsString()
    {
        _profile.DiscordUrl = "Test";
        Assert.IsType<string>(_profile.DiscordUrl);
    }
    
    [Fact]
    public void Profile_DiscordUrl_IsNullByDefault()
    {
        Assert.Null(_profile.DiscordUrl);
    }
    
    [Fact]
    public void Profile_DiscordUrl_CanBeSet()
    {
        var discordUrl = "Test";
        _profile.DiscordUrl = discordUrl;
        Assert.Equal(discordUrl, _profile.DiscordUrl);
    }
    
    [Fact]
    public void Profile_TwitchUrl_IsString()
    {
        _profile.TwitchUrl = "Test";
        Assert.IsType<string>(_profile.TwitchUrl);
    }
    
    [Fact]
    public void Profile_TwitchUrl_IsNullByDefault()
    {
        Assert.Null(_profile.TwitchUrl);
    }
    
    [Fact]
    public void Profile_TwitchUrl_CanBeSet()
    {
        var twitchUrl = "Test";
        _profile.TwitchUrl = twitchUrl;
        Assert.Equal(twitchUrl, _profile.TwitchUrl);
    }
    
    [Fact]
    public void Profile_WebsiteUrl_IsString()
    {
        _profile.WebsiteUrl = "Test";
        Assert.IsType<string>(_profile.WebsiteUrl);
    }
    
    [Fact]
    public void Profile_WebsiteUrl_IsNullByDefault()
    {
        Assert.Null(_profile.WebsiteUrl);
    }
    
    [Fact]
    public void Profile_WebsiteUrl_CanBeSet()
    {
        var websiteUrl = "Test";
        _profile.WebsiteUrl = websiteUrl;
        Assert.Equal(websiteUrl, _profile.WebsiteUrl);
    }
    
    [Fact]
    public void Profile_Offers_CanBeListOfOffers()
    {
        _profile.Offers = new List<Offer>();
        Assert.IsType<List<Offer>>(_profile.Offers);
    }
    
    [Fact]
    public void Profile_Offers_IsNullByDefault()
    {
        Assert.Null(_profile.Offers);
    }
    
    [Fact]
    public void Profile_Offers_CanBeSet()
    {
        var offers = new List<Offer>();
        _profile.Offers = offers;
        Assert.Equal(offers, _profile.Offers);
    }
    
    [Fact]
    public void Profile_Offers_CanBeAdded()
    {
        _profile.Offers = new List<Offer>();
        var offer = new Offer();
        _profile.Offers.Add(offer);
        Assert.Contains(offer, _profile.Offers);
    }
    
    [Fact]
    public void Profile_Offers_CanBeRemoved()
    {
        _profile.Offers = new List<Offer>();
        var offer = new Offer();
        _profile.Offers.Add(offer);
        _profile.Offers.Remove(offer);
        Assert.DoesNotContain(offer, _profile.Offers);
    }
    
    [Fact]
    public void Profile_Offers_CanBeCleared()
    {
        _profile.Offers = new List<Offer>();
        var offer = new Offer();
        _profile.Offers.Add(offer);
        _profile.Offers.Clear();
        Assert.Empty(_profile.Offers);
    }
    
    [Fact]
    public void Profile_Offers_CanBeSetToNull()
    {
        _profile.Offers = new List<Offer>();
        _profile.Offers = null;
        Assert.Null(_profile.Offers);
    }
    
    [Fact]
    public void Profile_Offers_CanBeSetToEmptyList()
    {
        _profile.Offers = new List<Offer>();
        _profile.Offers = new List<Offer>();
        Assert.Empty(_profile.Offers);
    }
    
    [Fact]
    public void Profile_Events_CanBeListOfEvent()
    {
        _profile.Events = new List<Event>();
        Assert.IsType<List<Event>>(_profile.Events);
    }

    [Fact]
    public void Profile_Events_IsNullByDefault()
    {
        Assert.Null(_profile.Events);
    }

    [Fact]
    public void Profile_Events_CanBeSet()
    {
        var e = new Event();
        _profile.Events = new List<Event>();
        _profile.Events.Add(e);

        Assert.Contains(e, _profile.Events);
    }
    
    [Fact]
    public void Profile_Events_CanBeAdded()
    {
        _profile.Events = new List<Event>();
        var e = new Event();
        _profile.Events.Add(e);
        Assert.Contains(e, _profile.Events);
    }
    
    [Fact]
    public void Profile_Events_CanBeRemoved()
    {
        _profile.Events = new List<Event>();
        var e = new Event();
        _profile.Events.Add(e);
        _profile.Events.Remove(e);
        Assert.DoesNotContain(e, _profile.Events);
    }
    
    [Fact]
    public void Profile_Events_CanBeCleared()
    {
        _profile.Events = new List<Event>();
        var e = new Event();
        _profile.Events.Add(e);
        _profile.Events.Clear();
        Assert.Empty(_profile.Events);
    }
    
    [Fact]
    public void Profile_Events_CanBeSetToNull()
    {
        _profile.Events = new List<Event>();
        _profile.Events = null;
        Assert.Null(_profile.Events);
    }
    
    [Fact]
    public void Profile_ProfileImageUrl_CanBeSet()
    {
        _profile.ProfileImageUrl = "http://www.example.com/image.jpg";
        Assert.Equal("http://www.example.com/image.jpg", _profile.ProfileImageUrl);
    }
    
    [Fact]
    public void Profile_ProfileImageUrl_CanBeSetToNull()
    {
        _profile.ProfileImageUrl = "http://www.example.com/image.jpg";
        _profile.ProfileImageUrl = null;
        Assert.Null(_profile.ProfileImageUrl);
    }
    
    [Fact]  
    public void Profile_ProfileImageUrl_CanBeSetToEmptyString()
    {
        _profile.ProfileImageUrl = "http://www.example.com/image.jpg";
        _profile.ProfileImageUrl = string.Empty;
        Assert.Equal(string.Empty, _profile.ProfileImageUrl);
    }
    
    [Fact]
    public void Profile_ProfileImageUrl_CanBeSetToWhitespace()
    {
        _profile.ProfileImageUrl = "http://www.example.com/image.jpg";
        _profile.ProfileImageUrl = " ";
        Assert.Equal(" ", _profile.ProfileImageUrl);
    }
    
    [Fact]
    public void Profile_ProfileImageUrl_IsString()
    {
        _profile.ProfileImageUrl = "http://www.example.com/image.jpg";
        Assert.IsType<string>(_profile.ProfileImageUrl);
    }
    
    [Fact]
    public void Profile_ProfileImageUrl_IsNullByDefault()
    {
        Assert.Null(_profile.ProfileImageUrl);
    }

    [Fact]
    public void Profile_BannerImageUrl_IsString()
    {
        _profile.BannerImageUrl = "http://www.example.com/image.jpg";
        Assert.IsType<string>(_profile.BannerImageUrl);
    }
    
    [Fact]
    public void Profile_BannerImageUrl_CanBeSet()
    {
        _profile.BannerImageUrl = "http://www.example.com/image.jpg";
        Assert.Equal("http://www.example.com/image.jpg", _profile.BannerImageUrl);
    }
    
    [Fact]
    public void Profile_BannerImageUrl_CanBeSetToNull()
    {
        _profile.BannerImageUrl = "http://www.example.com/image.jpg";
        _profile.BannerImageUrl = null;
        Assert.Null(_profile.BannerImageUrl);
    }
    
    [Fact]
    public void Profile_BannerImageUrl_CanBeSetToEmptyString()
    {
        _profile.BannerImageUrl = "http://www.example.com/image.jpg";
        _profile.BannerImageUrl = string.Empty;
        Assert.Equal(string.Empty, _profile.BannerImageUrl);
    }
    
    [Fact]
    public void Profile_BannerImageUrl_CanBeSetToWhitespace()
    {
        _profile.BannerImageUrl = "http://www.example.com/image.jpg";
        _profile.BannerImageUrl = " ";
        Assert.Equal(" ", _profile.BannerImageUrl);
    }
    
    [Fact]
    public void Profile_BannerImageUrl_IsNullByDefault()
    {
        Assert.Null(_profile.BannerImageUrl);
    }
    
}