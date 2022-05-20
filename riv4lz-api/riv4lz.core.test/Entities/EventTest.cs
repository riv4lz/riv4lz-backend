using System;
using System.Collections.Generic;
using riv4lz.core.Entities;
using riv4lz.core.Enums;
using Xunit;

namespace riv4lz.core.test.Entities;

public class EventTest
{
    private Event _event;

    public EventTest()
    {
        _event = new Event();
    }
    
    [Fact]
    public void Event_CanBeInitialized()
    {
        Assert.NotNull(_event);
    }
    
    [Fact]
    public void Event_Id_IsGuid()
    {
        Assert.IsType<Guid>(_event.Id);
    }
    
    [Fact]
    public void Event_SettingId_SetsId()
    {
        var id = Guid.NewGuid();
        _event.Id = id;
        Assert.Equal(id, _event.Id);
    }
    
    [Fact]
    public void Event_Time_IsDateTime()
    {
        Assert.IsType<DateTime>(_event.Time);
    }
    
    [Fact]
    public void Event_SettingTime_SetsTime()
    {
        var time = DateTime.Now;
        _event.Time = time;
        Assert.Equal(time, _event.Time);
    }
    
    [Fact]
    public void Event_Description_IsString()
    {
        _event.Description = "test";
        Assert.IsType<string>(_event.Description);
    }
    
    [Fact]
    public void Event_SettingDescription_SetsDescription()
    {
        var description = "Test";
        _event.Description = description;
        Assert.Equal(description, _event.Description);
    }
    
    [Fact]
    public void Event_Description_IsNullByDefault()
    {
        Assert.Null(_event.Description);
    }
    
    [Fact]
    public void Event_Price_IsDouble()
    {
        Assert.IsType<double>(_event.Price);
    }
    
    [Fact]
    public void Event_SettingPrice_SetsPrice()
    {
        var price = 1.0;
        _event.Price = price;
        Assert.Equal(price, _event.Price);
    }
    
    [Fact]
    public void Event_Price_IsZeroByDefault()
    {
        Assert.Equal(0.0, _event.Price);
    }
    
    [Fact]
    public void Event_Game_IsString()
    {
        _event.Game = "test";
        Assert.IsType<string>(_event.Game);
    }
    
    [Fact]
    public void Event_SettingGame_SetsGame()
    {
        var game = "Test";
        _event.Game = game;
        Assert.Equal(game, _event.Game);
    }
    
    [Fact]
    public void Event_Game_IsNullByDefault()
    {
        Assert.Null(_event.Game);
    }
    
    [Fact]
    public void Event_OrganisationId_IsGuid()
    {
        Assert.IsType<Guid>(_event.OrganisationId);
    }
    
    [Fact]
    public void Event_SettingOrganisationId_SetsOrganisationId()
    {
        var organisationId = Guid.NewGuid();
        _event.OrganisationId = organisationId;
        Assert.Equal(organisationId, _event.OrganisationId);
    }
    
    [Fact]
    public void Event_OrganisationId_IsEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _event.OrganisationId);
    }
    
    [Fact]
    public void Event_OrganisationProfile_IsProfile()
    {
        _event.OrganisationProfile = new Profile();
        Assert.IsType<Profile>(_event.OrganisationProfile);
    }
    
    [Fact]
    public void Event_SettingOrganisationProfile_SetsOrganisationProfile()
    {
        var profile = new Profile();
        _event.OrganisationProfile = profile;
        Assert.Equal(profile, _event.OrganisationProfile);
    }
    
    [Fact]
    public void Event_OrganisationProfile_IsNullByDefault()
    {
        Assert.Null(_event.OrganisationProfile);
    }
    
    [Fact]
    public void Event_Offers_CanBeAdded()
    {
        var offer = new Offer();
        _event.Offers = new List<Offer> { offer };
        Assert.Contains(offer, _event.Offers);
    }
    
    [Fact]
    public void Event_Offers_IsNullByDefault()
    {
        Assert.Null(_event.Offers);
    }
    
    [Fact]
    public void Event_Offers_RemoveOffer_RemovesOffer()
    {
        var offer = new Offer();
        _event.Offers = new List<Offer> { offer };
        _event.Offers.Remove(offer);
        Assert.DoesNotContain(offer, _event.Offers);
    }
    
    [Fact]
    public void Event_Teams_IsListOfTeam()
    {
        _event.Teams = new List<Team>();
        Assert.IsType<List<Team>>(_event.Teams);
    }
    
    [Fact]
    public void Event_SettingTeams_SetsTeams()
    {
        var teams = new List<Team>();
        _event.Teams = teams;
        Assert.Equal(teams, _event.Teams);
    }
    
    [Fact]
    public void Event_Teams_IsNullByDefault()
    {
        Assert.Null(_event.Teams);
    }
    
    [Fact]
    public void Event_Teams_AddTeam_AddsTeam()
    {
        var team = new Team();
        _event.Teams = new List<Team> { team };
        Assert.Contains(team, _event.Teams);
    }
    
    [Fact]
    public void Event_Teams_RemoveTeam_RemovesTeam()
    {
        var team = new Team();
        _event.Teams = new List<Team> { team };
        _event.Teams.Remove(team);
        Assert.DoesNotContain(team, _event.Teams);
    }
    
    [Fact]
    public void Event_EventStatus_IsEventStatus()
    {
        _event.EventStatus = new EventStatus();
        Assert.IsType<EventStatus>(_event.EventStatus);
    }
    
    [Fact]
    public void Event_SettingEventStatus_CanBePending()
    {
        _event.EventStatus = EventStatus.Pending;
        Assert.Equal(EventStatus.Pending, _event.EventStatus);
    }
    
    [Fact]
    public void Event_SettingEventStatus_CanBeClosed()
    {
        _event.EventStatus = EventStatus.Closed;
        Assert.Equal(EventStatus.Closed, _event.EventStatus);
    }
    
    [Fact]
    public void Event_SettingEventStatus_CanBeExpired()
    {
        _event.EventStatus = EventStatus.Expired;
        Assert.Equal(EventStatus.Expired, _event.EventStatus);
    }
    
}