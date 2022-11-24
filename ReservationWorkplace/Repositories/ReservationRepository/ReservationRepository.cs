using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDbContext _context;

        public ReservationRepository(ReservationDbContext context)
        {
            _context = context;
        }



        public List<Reservation> ReservationGetAll(int employeeId)
        {

            return _context.Reservations.Where(r => r.EmployeeId == employeeId).ToList();
        }

        public Reservation ReservationGetById(int employeeId, int id)
        {
            return _context.Reservations.Where(r => r.EmployeeId == employeeId).FirstOrDefault(r => r.Id == id);
        }

        public void CreateReservation(Reservation reservation)
        {

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            
        }

        public void UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();

        }
        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);

            _context.SaveChanges();

        }
    }
}
