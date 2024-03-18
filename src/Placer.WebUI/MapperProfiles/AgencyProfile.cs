using AutoMapper;
using Placer.Application.DTO;
using Placer.WebUI.ViewModels.Agencies;

namespace Placer.WebUI.MapperProfiles;

public class AgencyProfile : Profile
{
    public AgencyProfile()
    {
        CreateMap<AgencyDTO, AgencyViewModel>();
    }
}