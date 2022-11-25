using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Services.EquipmentService
{
    public interface IEquipmentService
    {
        List<EquipmentDto> GetAllEquipment();
        EquipmentDto GetByIdEquipment(int id);
        void CreateEquipment(EquipmentDto dto);
        void UpdateEquipment(EquipmentDto dto);
        void DeleteEquipment(int id);
    }
}
