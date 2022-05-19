using riv4lz.core.Entities;
using riv4lz.core.Enums;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Casters;
using riv4lz.Mediator.Dtos.Chat;
using riv4lz.Mediator.Dtos.Events;
using Profile = riv4lz.core.Entities.Profile;

namespace riv4lz.casterApi.Helpers;

public class MappingProfiles: AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<Profile, ProfileDto>()
            .ForMember(d => d.ProfileImage,
                opt => opt
                    .MapFrom(s => s.Images.FirstOrDefault(i => i.ImageType == ImgType.Profile)))
            .ForMember(d => d.BannerImage,
                opt => opt
                    .MapFrom(s => s.Images.FirstOrDefault(i => i.ImageType == ImgType.Banner)));
        
        CreateMap<RegisterProfileDto, Profile>();
        CreateMap<UpdateProfileDto, Profile>();

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