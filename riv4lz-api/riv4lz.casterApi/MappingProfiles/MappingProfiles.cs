using AutoMapper;
using riv4lz.dataAccess.Entities;
using riv4lz.domain;
using riv4lz.Mediator.Dtos;

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
        CreateMap<CreateEventDto, Event>();
        
        CreateMap<Comment, CommentDto>();
        
    }
}