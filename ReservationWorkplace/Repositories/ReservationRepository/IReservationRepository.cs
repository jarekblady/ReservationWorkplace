using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;


namespace ReservationWorkplace.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        List<ReservationViewModel> ReservationGetAll(int employeeId);
        ReservationViewModel ReservationGetById(int employeeId, int id);
    }
}
