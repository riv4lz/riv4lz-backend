using AutoMapper;
using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.casterApi.MappingProfiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<CasterProfileEntity, CasterProfileDto>();
        CreateMap<RegisterCasterProfileDto, CasterProfileEntity>();
    }
}