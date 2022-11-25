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
            CreateMap<Workplace, WorkplaceDto>();
            CreateMap<WorkplaceDto, Workplace>();

            CreateMap<WorkplaceDto, WorkplaceViewModel>();
            CreateMap<WorkplaceViewModel, WorkplaceDto>();
        }
    }
}