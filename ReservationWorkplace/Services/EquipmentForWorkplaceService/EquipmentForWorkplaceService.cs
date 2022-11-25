using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Repositories.EquipmentForWorkplaceRepository;

namespace ReservationWorkplace.Services.EquipmentForWorkplaceService
{
    public class EquipmentForWorkplaceService : IEquipmentForWorkplaceService
    {
        private readonly IEquipmentForWorkplaceRepository _equipmentForWorkplaceRepository;
        private readonly IMapper _mapper;

        public EquipmentForWorkplaceService(IEquipmentForWorkplaceRepository equipmentForWorkplaceRepository, IMapper mapper)
        {
            _equipmentForWorkplaceRepository = equipmentForWorkplaceRepository;
            _mapper = mapper;
        }


        public List<EquipmentForWorkplaceDto> GetAllEquipmentForWorkplace()
        {
            var equipmentForWorkplaces = _equipmentForWorkplaceRepository.EquipmentForWorkplaceGetAll();
            var result = _mapper.Map<List<EquipmentForWorkplaceDto>>(equipmentForWorkplaces);
            return result;
        }

        public EquipmentForWorkplaceDto GetByIdEquipmentForWorkplace(int id)
        {
            var equipmentForWorkplace = _equipmentForWorkplaceRepository.EquipmentForWorkplaceGetById(id);
            var result = _mapper.Map<EquipmentForWorkplaceDto>(equipmentForWorkplace);
            return result;
        }


        public void CreateEquipmentForWorkplace(EquipmentForWorkplaceDto dto)
        {
            var equipmentForWorkplace = new EquipmentForWorkplace()
            {
                Count = dto.Count,
                WorkplaceId = dto.WorkplaceId,
                EquipmentId = dto.EquipmentId
            };
            _equipmentForWorkplaceRepository.CreateEquipmentForWorkplace(equipmentForWorkplace);
        }

        public void UpdateEquipmentForWorkplace(EquipmentForWorkplaceDto dto)
        {
            var equipmentForWorkplace = new EquipmentForWorkplace()
            {
                Id = dto.Id,
                Count = dto.Count,
                WorkplaceId = dto.WorkplaceId,
                EquipmentId = dto.EquipmentId
            };
            _equipmentForWorkplaceRepository.UpdateEquipmentForWorkplace(equipmentForWorkplace); 
        }

        public void DeleteEquipmentForWorkplace(int id)
        {
            var equipmentForWorkplace = _equipmentForWorkplaceRepository.EquipmentForWorkplaceGetById(id);
            _equipmentForWorkplaceRepository.DeleteEquipmentForWorkplace(equipmentForWorkplace);
        }
    }
}

