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
            CreateMap<Reservation, ReservationDto>()
                    .ForMember(d => d.FirstName, c => c.MapFrom(s => s.Employee.FirstName))
                    .ForMember(d => d.LastName, c => c.MapFrom(s => s.Employee.LastName))
                    .ForMember(m => m.FullName, c => c.MapFrom(s => s.Employee.FirstName + " " + s.Employee.LastName))
                    .ForMember(d => d.Floor, c => c.MapFrom(s => s.Workplace.Floor))
                    .ForMember(d => d.Room, c => c.MapFrom(s => s.Workplace.Room))
                    .ForMember(d => d.Table, c => c.MapFrom(s => s.Workplace.Table))
                    .ForMember(d => d.WorkplaceName, c => c.MapFrom(s => "Floor: " + s.Workplace.Floor + ", Room: " + s.Workplace.Room + ", Table: " + s.Workplace.Table));
            CreateMap<ReservationDto, Reservation>();
        }
    }
}