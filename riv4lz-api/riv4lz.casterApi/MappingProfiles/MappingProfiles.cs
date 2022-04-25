using AutoMapper;
using riv4lz.dataAccess.Entities;
using riv4lz.domain;
using riv4lz.Mediator.Dtos;

namespace riv4lz.casterApi.MappingProfiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<CasterProfileEntity, CasterProfileDto>();
        CreateMap<RegisterCasterProfileDto, CasterProfileEntity>();
        CreateMap<UpdateCasterProfileDto, CasterProfileEntity>();
        
        CreateMap<OrganisationProfileEntity, OrganisationProfileDto>();
        CreateMap<RegisterOrganisationProfileDto, OrganisationProfileEntity>();
        CreateMap<UpdateOrganisationProfileDto, OrganisationProfileEntity>();

        CreateMap<EventEntity, EventDto>();
        CreateMap<CreateEventDto, EventEntity>();
        
        CreateMap<Comment, CommentDto>();
        
    }
}