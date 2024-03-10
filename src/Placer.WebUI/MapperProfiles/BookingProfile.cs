using AutoMapper;
using Placer.Core.Entities;
using Placer.WebUI.ViewModels.Booking;

namespace Placer.WebUI.MapperProfiles;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, CreateBookingViewModel>()
            .ForMember(dest => dest.Name, opt => opt.Ignore())
            .ForMember(dest => dest.BookingPrice, opt => opt.MapFrom(src => src.Price));

        CreateMap<CreateBookingViewModel, Booking>()
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.BookingPrice));
        
        CreateMap<Tour, CreateBookingViewModel>()
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TourPrice, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.BookerId, opt => opt.Ignore())
            .ReverseMap();
    }
}