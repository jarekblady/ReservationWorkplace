using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Services.ReservationService
{
    public interface IReservationService
    {
        List<ReservationDto> GetAllReservation(int employeeId);
        ReservationDto GetByIdReservation(int employeeId, int id);
        void CreateReservation(ReservationDto dto);
        void UpdateReservation(ReservationDto dto);
        void DeleteReservation(int employeeId, int id);
    }
}
