using ReservationWorkplace.Models;

namespace ReservationWorkplace.Services.WorkplaceService
{
    public interface IWorkplaceService
    {
        List<WorkplaceViewModel> GetAllWorkplace();
        WorkplaceViewModel GetByIdWorkplace(int id);
        void CreateWorkplace(WorkplaceViewModel model);
        void UpdateWorkplace(WorkplaceViewModel model);
        void DeleteWorkplace(int id);
    }
}
