using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.MappingProfiles
{
    public class WorkplaceProfile : Profile
    {
        public WorkplaceProfile()
        {
            CreateMap<Workplace, WorkplaceDto>()
                .ForMember(m => m.WorkplaceName, c => c.MapFrom(s => "Floor: " + s.Floor + ", Room: " + s.Room + ", Table: " + s.Table));
            CreateMap<WorkplaceDto, Workplace>();

            CreateMap<WorkplaceDto, WorkplaceViewModel>();
            CreateMap<WorkplaceViewModel, WorkplaceDto>();
        }
    }
}