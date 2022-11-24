using ReservationWorkplace.Entities;


namespace ReservationWorkplace.Repositories.EquipmentForWorkplaceRepository
{
    public interface IEquipmentForWorkplaceRepository
    {
        List<EquipmentForWorkplace> EquipmentForWorkplaceGetAll();
        EquipmentForWorkplace EquipmentForWorkplaceGetById(int id);
        void CreateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        void UpdateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        void DeleteEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
    }
}