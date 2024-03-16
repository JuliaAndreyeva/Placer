using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;
using Placer.WebUI.ViewModels.Bookings;

namespace Placer.WebUI.MapperProfiles;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<CreationBookingDTO, CreateBookingViewModel>()
            .ForMember(dest => dest.BookingPrice, opt => opt.MapFrom(src => src.BookingPrice));

        CreateMap<CreateBookingViewModel, CreationBookingDTO>()
            .ForMember(dest => dest.BookingPrice, opt => opt.MapFrom(src => src.BookingPrice));
        
        CreateMap<ListRecentBookingsViewModel, RecentBookingDTO>().ReverseMap();
        CreateMap<ListPastBookingsViewModel, PastBookingDTO>().ReverseMap();
    }
}