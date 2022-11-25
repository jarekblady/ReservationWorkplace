using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Services.EquipmentForWorkplaceService
{
    public interface IEquipmentForWorkplaceService
    {
        List<EquipmentForWorkplaceDto> GetAllEquipmentForWorkplace();
        EquipmentForWorkplaceDto GetByIdEquipmentForWorkplace(int id);
        void CreateEquipmentForWorkplace(EquipmentForWorkplaceDto dto);
        void UpdateEquipmentForWorkplace(EquipmentForWorkplaceDto dto);
        void DeleteEquipmentForWorkplace(int id);
    }
}
