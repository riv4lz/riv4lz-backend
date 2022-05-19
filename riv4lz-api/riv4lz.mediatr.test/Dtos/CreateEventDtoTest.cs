using System;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Events;
using Xunit;

namespace riv4lz.mediatr.test.Dtos;

public class CreateEventDtoTest
{
    private CreateEventDto _createEventDto;

    public CreateEventDtoTest()
    {
        _createEventDto = new CreateEventDto();
    }
    
    [Fact]
    public void CreateEventDto_CanBeInitialized()
    {
        Assert.NotNull(_createEventDto);
    }
    
    [Fact]
    public void CreateEventDto_Id_IsGuid()
    {
        Assert.IsType<Guid>(_createEventDto.Id);
    }
    
    [Fact]
    public void CreateEventDto_Id_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _createEventDto.Id);
    }
    
    [Fact]
    public void CreateEventDto_Id_CanBeSet()
    {
        var id = Guid.NewGuid();
        _createEventDto.Id = id;
        Assert.Equal(id, _createEventDto.Id);
    }
    
    [Fact]
    public void CreateEventDto_OrganisationId_IsGuid()
    {
        Assert.IsType<Guid>(_createEventDto.OrganisationId);
    }
    
    [Fact]
    public void CreateEventDto_OrganisationId_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _createEventDto.OrganisationId);
    }
    
    [Fact]
    public void CreateEventDto_OrganisationId_CanBeSet()
    {
        var id = Guid.NewGuid();
        _createEventDto.OrganisationId = id;
        Assert.Equal(id, _createEventDto.OrganisationId);
    }
    
    [Fact]
    public void CreateEventDto_Time_IsDateTime()
    {
        Assert.IsType<DateTime>(_createEventDto.Time);
    }
    
    [Fact]
    public void CreateEventDto_Time_CanBeSet()
    {
        var time = DateTime.Now;
        _createEventDto.Time = time;
        Assert.Equal(time, _createEventDto.Time);
    }
    
    [Fact]
    public void CreateEventDto_Description_IsString()
    {
        _createEventDto.Description = "test";
        Assert.IsType<string>(_createEventDto.Description);
    }
    
    [Fact]
    public void CreateEventDto_Description_CanBeSet()
    {
        var description = "test";
        _createEventDto.Description = description;
        Assert.Equal(description, _createEventDto.Description);
    }
    
    [Fact]
    public void CreateEventDto_Description_CanBeNull()
    {
        _createEventDto.Description = null;
        Assert.Null(_createEventDto.Description);
    }
    
    [Fact]
    public void CreateEventDto_Description_CanBeEmpty()
    {
        _createEventDto.Description = "";
        Assert.Equal("", _createEventDto.Description);
    }
    
    [Fact]
    public void CreateEventDto_Description_CanBeWhitespace()
    {
        _createEventDto.Description = " ";
        Assert.Equal(" ", _createEventDto.Description);
    }
    
    [Fact]
    public void CreateEventDto_Description_IsNullByDefault()
    {
        Assert.Null(_createEventDto.Description);
    }
    
    [Fact]
    public void CreateEventDto_TeamOne_IsTeamDto()
    {
        _createEventDto.TeamOne = new TeamDto();
        Assert.IsType<TeamDto>(_createEventDto.TeamOne);
    }
    
    [Fact]
    public void CreateEventDto_TeamOne_CanBeSet()
    {
        var team = new TeamDto();
        _createEventDto.TeamOne = team;
        Assert.Equal(team, _createEventDto.TeamOne);
    }
    
    [Fact]
    public void CreateEventDto_TeamOne_IsNullByDefault()
    {
        Assert.Null(_createEventDto.TeamOne);
    }
    
    [Fact]
    public void CreateEventDto_TeamTwo_IsTeamDto()
    {
        _createEventDto.TeamTwo = new TeamDto();
        Assert.IsType<TeamDto>(_createEventDto.TeamTwo);
    }
    
    [Fact]
    public void CreateEventDto_TeamTwo_CanBeSet()
    {
        var team = new TeamDto();
        _createEventDto.TeamTwo = team;
        Assert.Equal(team, _createEventDto.TeamTwo);
    }
    
    [Fact]
    public void CreateEventDto_TeamTwo_IsNullByDefault()
    {
        Assert.Null(_createEventDto.TeamTwo);
    }
    
    [Fact]
    public void CreateEventDto_Price_IsDouble()
    {
        Assert.IsType<double>(_createEventDto.Price);
    }
    
    [Fact]
    public void CreateEventDto_Price_CanBeSet()
    {
        var price = 1.0;
        _createEventDto.Price = price;
        Assert.Equal(price, _createEventDto.Price);
    }
    
    [Fact]
    public void CreateEventDto_Price_IsZeroByDefault()
    {
        Assert.Equal(0.0, _createEventDto.Price);
    }
    
}