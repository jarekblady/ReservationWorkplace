using AutoMapper;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDbContext _context;
        private readonly IMapper _mapper;

        public ReservationRepository(ReservationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public List<ReservationViewModel> ReservationGetAll(int employeeId)
        {
            var reservations = _context.Reservations.Where(r => r.EmployeeId == employeeId).ToList(); 
            var result = _mapper.Map<List<ReservationViewModel>>(reservations);
            return result;
        }

        public ReservationViewModel ReservationGetById(int employeeId, int id)
        {
            //var reservation = _context.Reservations.Where(r => r.EmployeeId == employeeId).FirstOrDefault(r => r.EmployeeId == employeeId && r.Id == id);
            var reservation = _context.Reservations.Where(r => r.EmployeeId == employeeId).FirstOrDefault(r => r.Id == id);
            var result = _mapper.Map<ReservationViewModel>(reservation);
            return result;
        }

        public int Create(int employeeId, int WorkplaceId, AddEditReservationViewModel model)
        {
            var reservationEntity = _mapper.Map<Reservation>(model);

            reservationEntity.EmployeeId = employeeId;
            reservationEntity.WorkplaceId = WorkplaceId;

            _context.Reservations.Add(reservationEntity);
            _context.SaveChanges();

            return reservationEntity.Id;
            
        }

        public int Update(int employeeId, int WorkplaceId, int id, AddEditReservationViewModel model)
        {
            var reservation = _context.Reservations.Where(r => r.EmployeeId == employeeId).FirstOrDefault(r => r.Id == id);

            reservation.TimeFrom = model.TimeFrom;
            reservation.TimeTo = model.TimeTo;
            reservation.EmployeeId = employeeId;
            reservation.WorkplaceId = WorkplaceId;

            _context.SaveChanges();

            return reservation.Id;

        }
        public void Delete(int employeeId, int id)
        {
            var reservation = _context.Reservations.Where(r => r.EmployeeId == employeeId).FirstOrDefault(r => r.Id == id);

            _context.Reservations.Remove(reservation);

            _context.SaveChanges();

        }
    }
}
