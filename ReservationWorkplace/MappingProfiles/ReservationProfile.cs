using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.MappingProfiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();

            CreateMap<ReservationDto, ReservationViewModel>();
            CreateMap<ReservationViewModel, ReservationDto>();
        }
    }
}