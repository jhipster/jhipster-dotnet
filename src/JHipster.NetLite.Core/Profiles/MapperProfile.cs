using AutoMapper;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Dto;

namespace JHipster.NetLite.Web.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProjectDto, Project>().ReverseMap();
    }
}
