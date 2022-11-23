using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;


namespace ReservationWorkplace.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        List<ReservationViewModel> ReservationGetAll(int employeeId);
        ReservationViewModel ReservationGetById(int employeeId, int id);
        int Create(int employeeId, int WorkplaceId, AddEditReservationViewModel model);
        int Update(int employeeId, int WorkplaceId, int id, AddEditReservationViewModel model);
        void Delete(int employeeId, int id);
    }
}
