using ReservationWorkplace.Models;

namespace ReservationWorkplace.Services.EquipmentService
{
    public interface IEquipmentService
    {
        List<EquipmentViewModel> GetAllEquipment();
        EquipmentViewModel GetByIdEquipment(int id);
        void CreateEquipment(EquipmentViewModel model);
        void UpdateEquipment(EquipmentViewModel model);
        void DeleteEquipment(int id);
    }
}
