using AutoMapper;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;
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


        public List<EquipmentViewModel> GetAllEquipment()
        {
            var equipments = _equipmentRepository.EquipmentGetAll();
            var result = _mapper.Map<List<EquipmentViewModel>>(equipments);
            return result;
        }

        public EquipmentViewModel GetByIdEquipment(int id)
        {
            var equipment = _equipmentRepository.EquipmentGetById(id);
            var result = _mapper.Map<EquipmentViewModel>(equipment);
            return result;
        }


        public void CreateEquipment(EquipmentViewModel model)
        {
            var equipment = new Equipment()
            {
                Type = model.Type
            };
            _equipmentRepository.CreateEquipment(equipment);
        }

        public void UpdateEquipment(EquipmentViewModel model)
        {
            var equipment = new Equipment()
            {
                Type = model.Type
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
