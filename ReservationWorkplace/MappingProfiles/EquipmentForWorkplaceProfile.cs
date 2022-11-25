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
            CreateMap<EquipmentForWorkplace, EquipmentForWorkplaceDto>();
            CreateMap<EquipmentForWorkplaceDto, EquipmentForWorkplace>();

            CreateMap<EquipmentForWorkplaceDto, EquipmentForWorkplaceViewModel>();
            CreateMap<EquipmentForWorkplaceViewModel, EquipmentForWorkplaceDto>();
        }
    }
}
