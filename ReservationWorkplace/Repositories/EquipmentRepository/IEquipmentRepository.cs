using ReservationWorkplace.Entities;


namespace ReservationWorkplace.Repositories.EquipmentRepository
{
    public interface IEquipmentRepository
    {
        List<Equipment> EquipmentGetAll();
        Equipment EquipmentGetById(int id);
        void CreateEquipment(Equipment equipment);
        void UpdateEquipment(Equipment equipment);
        void DeleteEquipment(Equipment equipment);
    }
}