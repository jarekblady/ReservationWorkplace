using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.MappingProfiles
{
    public class EquipmentForWorkplaceProfile : Profile
    {
        public EquipmentForWorkplaceProfile()
        {
            CreateMap<EquipmentForWorkplace, EquipmentForWorkplaceDto>()
                    .ForMember(d => d.Type, c => c.MapFrom(s => s.Equipment.Type))
                    .ForMember(d => d.WorkplaceName, c => c.MapFrom(s => "Floor: " + s.Workplace.Floor + ", Room: " + s.Workplace.Room + ", Table: " + s.Workplace.Table));
            CreateMap<EquipmentForWorkplaceDto, EquipmentForWorkplace>();

        }
    }
}
