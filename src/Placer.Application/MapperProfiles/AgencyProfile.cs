using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class AgencyProfile : Profile
{
    public AgencyProfile()
    {
        CreateMap<Agency, AgencyDTO>(); 
    }
}