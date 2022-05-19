using System;
using riv4lz.core.Entities;
using riv4lz.core.Enums;
using Xunit;

namespace riv4lz.core.test.Entities;

public class OfferTest
{
    private Offer _offer;

    public OfferTest()
    {
        _offer = new Offer();
    }
    
    [Fact]
    public void Offer_CanBeInitialized()
    {
        Assert.NotNull(_offer);
    }
    
    [Fact]
    public void Offer_Id_IsGuid()
    {
        Assert.IsType<Guid>(_offer.Id);
    }
    
    [Fact]
    public void Offer_Id_IsEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _offer.Id);
    }
    
    [Fact]
    public void Offer_Id_IsNotEmptyAfterSet()
    {
        _offer.Id = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _offer.Id);
    }
    
    [Fact]
    public void Offer_Id_CanBeSet()
    {
        var id = Guid.NewGuid();
        _offer.Id = id;
        Assert.Equal(id, _offer.Id);
    }
    
    [Fact]
    public void Offer_OfferStatus_IsOfferStatus()
    {
        Assert.IsType<OfferStatus>(_offer.OfferStatus);
    }
    
    [Fact]
    public void Offer_OfferStatus_CanBePending()
    {
        _offer.OfferStatus = OfferStatus.Pending;
        Assert.Equal(OfferStatus.Pending, _offer.OfferStatus);
    }
    
    [Fact]
    public void Offer_OfferStatus_CanBeClosed()
    {
        _offer.OfferStatus = OfferStatus.Closed;
        Assert.Equal(OfferStatus.Closed, _offer.OfferStatus);
    }
    
    [Fact]
    public void Offer_OfferStatus_CanBeRejected()
    {
        _offer.OfferStatus = OfferStatus.Rejected;
        Assert.Equal(OfferStatus.Rejected, _offer.OfferStatus);
    }
    
    [Fact]
    public void Offer_OfferStatus_CanBeExpired()
    {
        _offer.OfferStatus = OfferStatus.Expired;
        Assert.Equal(OfferStatus.Expired, _offer.OfferStatus);
    }
    
    [Fact]
    public void Offer_EventId_IsGuid()
    {
        Assert.IsType<Guid>(_offer.EventId);
    }
    
    [Fact]
    public void Offer_EventId_IsEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _offer.EventId);
    }
    
    [Fact]
    public void Offer_EventId_IsNotEmptyAfterSet()
    {
        _offer.EventId = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _offer.EventId);
    }
    
    [Fact]
    public void Offer_EventId_CanBeSet()
    {
        var id = Guid.NewGuid();
        _offer.EventId = id;
        Assert.Equal(id, _offer.EventId);
    }
    
    [Fact]
    public void Offer_Event_IsEvent()
    {
        _offer.Event = new Event();
        Assert.IsType<Event>(_offer.Event);
    }
    
    [Fact]
    public void Offer_Event_CanBeSet()
    {
        var e = new Event();
        _offer.Event = e;
        Assert.Equal(e, _offer.Event);
    }
    
    [Fact]
    public void Offer_CasterId_IsGuid()
    {
        Assert.IsType<Guid>(_offer.CasterId);
    }
    
    [Fact]
    public void Offer_CasterId_IsEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _offer.CasterId);
    }
    
    [Fact]
    public void Offer_CasterId_IsNotEmptyAfterSet()
    {
        _offer.CasterId = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _offer.CasterId);
    }
    
    [Fact]
    public void Offer_CasterId_CanBeSet()
    {
        var id = Guid.NewGuid();
        _offer.CasterId = id;
        Assert.Equal(id, _offer.CasterId);
    }
    
    [Fact]
    public void Offer_Caster_IsProfile()
    {
        _offer.Caster = new Profile();
        Assert.IsType<Profile>(_offer.Caster);
    }
    
    [Fact]
    public void Offer_Caster_CanBeSet()
    {
        var p = new Profile();
        _offer.Caster = p;
        Assert.Equal(p, _offer.Caster);
    }
}