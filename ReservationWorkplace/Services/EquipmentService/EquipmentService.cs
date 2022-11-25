using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Repositories.EquipmentRepository;

namespace ReservationWorkplace.Services.EquipmentService
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }


        public List<EquipmentDto> GetAllEquipment()
        {
            var equipments = _equipmentRepository.EquipmentGetAll();
            var result = _mapper.Map<List<EquipmentDto>>(equipments);
            return result;
        }

        public EquipmentDto GetByIdEquipment(int id)
        {
            var equipment = _equipmentRepository.EquipmentGetById(id);
            var result = _mapper.Map<EquipmentDto>(equipment);
            return result;
        }


        public void CreateEquipment(EquipmentDto dto)
        {
            var equipment = new Equipment()
            {
                Type = dto.Type
            };
            _equipmentRepository.CreateEquipment(equipment);
        }

        public void UpdateEquipment(EquipmentDto dto)
        {
            var equipment = new Equipment()
            {
                Id = dto.Id,
                Type = dto.Type
            };
            _equipmentRepository.UpdateEquipment(equipment); ;
        }

        public void DeleteEquipment(int id)
        {
            var equipment = _equipmentRepository.EquipmentGetById(id);
            _equipmentRepository.DeleteEquipment(equipment);
        }
    }
}
