using AutoMapper;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Reservation, ReservationViewModel>();
            CreateMap<ReservationViewModel, Reservation>();
        }
    }
}
