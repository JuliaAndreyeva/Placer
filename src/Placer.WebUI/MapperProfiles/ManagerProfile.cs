using AutoMapper;
using Placer.Application.DTO;
using Placer.WebUI.ViewModels.Managers;

namespace Placer.WebUI.MapperProfiles;

public class ManagerProfile : Profile
{
    public ManagerProfile()
    {
        CreateMap<ManagerDTO, ManagerViewModel>();
    }
}