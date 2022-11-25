using Microsoft.EntityFrameworkCore;
using ReservationWorkplace.Entities;

namespace ReservationWorkplace.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDbContext _context;

        public ReservationRepository(ReservationDbContext context)
        {
            _context = context;
        }

        public List<Reservation> ReservationGetAll()
        {

            return _context.Reservations.Include(e => e.Employee).Include(w => w.Workplace).ToList();
        }

        public Reservation ReservationGetById(int id)
        {
            return _context.Reservations.Include(e => e.Employee).Include(w => w.Workplace).FirstOrDefault(r => r.Id == id);
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
