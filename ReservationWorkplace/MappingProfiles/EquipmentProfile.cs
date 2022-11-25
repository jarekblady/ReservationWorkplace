using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.MappingProfiles
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentDto, Equipment>();

            CreateMap<EquipmentDto, EquipmentViewModel>();
            CreateMap<EquipmentViewModel, EquipmentDto>();
        }
    }
}