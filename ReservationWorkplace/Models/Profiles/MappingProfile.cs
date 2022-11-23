using AutoMapper;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Reservation, ReservationViewModel>()
                .ForMember(m =>m.Floor, c => c.MapFrom(s => s.Workplace.Floor))
                .ForMember(m => m.Room, c => c.MapFrom(s => s.Workplace.Room))
                .ForMember(m => m.Table, c => c.MapFrom(s => s.Workplace.Table));
            CreateMap<AddEditReservationViewModel, Reservation>();
        }
    }
}
