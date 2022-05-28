using AutoMapper;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Dto;

namespace JHipster.NetLite.Core.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProjectDto, Project>().ReverseMap();
    }
}
