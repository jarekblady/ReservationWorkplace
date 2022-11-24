using ReservationWorkplace.Models;

namespace ReservationWorkplace.Services.ReservationService
{
    public interface IReservationService
    {
        List<ReservationViewModel> GetAllReservation(int employeeId);
        ReservationViewModel GetByIdReservation(int employeeId, int id);
        void CreateReservation(ReservationViewModel model);
        void UpdateReservation(ReservationViewModel model);
        void DeleteReservation(int employeeId, int id);
    }
}
