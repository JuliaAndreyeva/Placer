using AutoMapper;
using Placer.Application.DTO;
using Placer.Core.Entities;

namespace Placer.Application.MapperProfiles;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<CreationBookingDTO, Tour>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TourId))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TourPrice))
            .ReverseMap();
            
        CreateMap<Booking, CreationBookingDTO>()
            .ForMember(dest => dest.Nonce, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Tour, opt => opt.Ignore())
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.BookingPrice));

        CreateMap<RecentBookingDTO, Booking>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.BookingPrice))
            .ReverseMap();
        
        CreateMap<PastBookingDTO, Booking>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.BookingPrice))
            .ReverseMap();
    }
}