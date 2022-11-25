using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Services.ReservationService
{
    public interface IReservationService
    {
        List<ReservationDto> GetAllReservation();
        ReservationDto GetByIdReservation(int id);
        void CreateReservation(ReservationDto dto);
        void UpdateReservation(ReservationDto dto);
        void DeleteReservation(int id);
    }
}
