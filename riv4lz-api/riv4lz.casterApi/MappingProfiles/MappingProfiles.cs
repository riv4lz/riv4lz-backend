using AutoMapper;
using riv4lz.core.Entities;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Casters;
using riv4lz.Mediator.Dtos.Events;
using riv4lz.Mediator.Dtos.Organisations;

namespace riv4lz.casterApi.MappingProfiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<CasterProfile, CasterProfileDto>();
        CreateMap<RegisterCasterProfileDto, CasterProfile>();
        CreateMap<UpdateCasterProfileDto, CasterProfile>();
        
        CreateMap<OrganisationProfile, OrganisationProfileDto>();
        CreateMap<RegisterOrganisationProfileDto, OrganisationProfile>();
        CreateMap<UpdateOrganisationProfileDto, OrganisationProfile>();

        CreateMap<Event, EventDto>();
        CreateMap<Event, EventWithOffersDto>();
        CreateMap<CreateEventDto, Event>();
        
        CreateMap<Offer, OfferDto>();
        CreateMap<CreateOfferDto, Offer>();
        
        CreateMap<Message, MessageDto>();
        CreateMap<MessageDto, Message>();
        CreateMap<CreateMessageDto, MessageDto>();
        CreateMap<CreateMessageDto, Message>();
        
        CreateMap<ChatRoom, ChatRoomWithMessagesDto>();
        CreateMap<ChatRoom, ChatRoomDto>();
        
        CreateMap<Team, TeamDto>();
    }
}