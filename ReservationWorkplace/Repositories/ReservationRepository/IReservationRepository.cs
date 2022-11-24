using ReservationWorkplace.Entities;


namespace ReservationWorkplace.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        List<Reservation> ReservationGetAll(int employeeId);
        Reservation ReservationGetById(int employeeId, int id);
        void CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
    }
}
