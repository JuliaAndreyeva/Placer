using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class ManagerProfile : Profile
{
    public ManagerProfile()
    {
        CreateMap<Manager, ManagerDTO>(); 
    }
}