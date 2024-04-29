using AutoMapper;
using HotelProject.Models;
using HotelProject.Models.DTOs;

namespace HotelProject.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GuestReservation, GuestReservationDTO>()
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.Guest!.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.Guest!.LastName))
                .ForMember(dest => dest.PersonalNumber, options => options.MapFrom(src => src.Guest!.PersonalNumber))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.Guest!.PhoneNumber))
                .ForMember(dest => dest.CheckInDate, options => options.MapFrom(src => src.Reservation!.CheckInDate))
                .ForMember(dest => dest.CheckOutDate, options => options.MapFrom(src => src.Reservation!.CheckOutDate))
                .ReverseMap();
            CreateMap<GuestReservationForCreatingDTO, Guest>().ReverseMap();
            CreateMap<GuestReservationForCreatingDTO, Reservation>().ReverseMap();
            CreateMap<GuestReservationForCreatingDTO, GuestReservation>().ReverseMap();

            CreateMap<GuestReservation, GuestReservationForUpdatingDTO>()
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.Guest!.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.Guest!.LastName))
                .ForMember(dest => dest.PersonalNumber, options => options.MapFrom(src => src.Guest!.PersonalNumber))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.Guest!.PhoneNumber))
                .ForMember(dest => dest.CheckInDate, options => options.MapFrom(src => src.Reservation!.CheckInDate))
                .ForMember(dest => dest.CheckOutDate, options => options.MapFrom(src => src.Reservation!.CheckOutDate))
                .ReverseMap();
            CreateMap<GuestReservationForUpdatingDTO, Guest>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.GuestId))
                .ReverseMap();
            CreateMap<GuestReservationForUpdatingDTO, Reservation>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.ReservationId))
                .ReverseMap();

            CreateMap<UserRegistrationDTO, ApplicationUser>()
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.Email))
                .ReverseMap();
        }
    }
}
