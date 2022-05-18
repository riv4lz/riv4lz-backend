using System;
using System.Collections.Generic;
using riv4lz.core.Entities;
using Xunit;

namespace riv4lz.core.test.Entities;

public class TeamTest
{
    private Team _team;
    public TeamTest()
    {
        _team = new Team();
    }

    [Fact]
    public void Team_CanBeInitialized()
    {
        Assert.NotNull(_team);
    }
    
    [Fact]
    public void Team_SettingName_SetsName()
    {
        _team.Name = "Test";
        Assert.Equal("Test", _team.Name);
    }
    
    [Fact]
    public void Team_SettingId_SetsId()
    {
        var id = new Guid();
        _team.Id = id;
        Assert.Equal(id, _team.Id);
    }
    
    [Fact]
    public void Team_AddingEvent_AddsEvent()
    {
        var event1 = new Event();
        var event2 = new Event();
        _team.Events = new List<Event>();
        _team.Events.Add(event1);
        _team.Events.Add(event2);
        Assert.Equal(2, _team.Events.Count);
    }
    
    [Fact]
    public void Team_Id_IsGuid()
    {
        Assert.IsType<Guid>(_team.Id);
    }
    
    [Fact]
    public void Team_Name_IsString()
    {
        _team.Name = "Test";
        Assert.IsType<string>(_team.Name);
    }
    
}