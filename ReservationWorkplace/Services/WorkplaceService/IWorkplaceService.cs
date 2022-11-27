using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Services.WorkplaceService
{
    public interface IWorkplaceService
    {
        List<WorkplaceDto> GetAllWorkplace();
        WorkplaceDto GetByIdWorkplace(int id);
        void CreateWorkplace(WorkplaceDto dto);
        void UpdateWorkplace(WorkplaceDto dto);
        void DeleteWorkplace(int id);
        List<EquipmentForWorkplaceDto> GetAllEquipmentForWorkplaceId(int workplaceId);
        EquipmentForWorkplaceDto GetByIdEquipmentForWorkplace(int id);
        void AddEquipmentForWorkplace(EquipmentForWorkplaceDto dto);
        void UpdateEquipmentForWorkplace(EquipmentForWorkplaceDto dto);
        void DeleteEquipmentForWorkplace(int id);
    }
}
