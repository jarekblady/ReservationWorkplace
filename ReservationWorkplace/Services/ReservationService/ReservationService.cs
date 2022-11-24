using AutoMapper;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;
using ReservationWorkplace.Repositories.ReservationRepository;

namespace ReservationWorkplace.Services.ReservationService
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }


        public List<ReservationViewModel> GetAllReservation(int employeeId)
        {
            var reservations = _reservationRepository.ReservationGetAll(employeeId);
            var result = _mapper.Map<List<ReservationViewModel>>(reservations);
            return result;
        }

        public ReservationViewModel GetByIdReservation(int employeeId, int id)
        {
            var reservation = _reservationRepository.ReservationGetById(employeeId, id);
            var result = _mapper.Map<ReservationViewModel>(reservation);
            return result;
        }


        public void CreateReservation(ReservationViewModel model)
        {
            var reservation = new Reservation()
            {
                EmployeeId = model.EmployeeId,
                WorkplaceId = model.WorkplaceId,
                TimeFrom = model.TimeFrom,
                TimeTo = model.TimeTo
            };
            _reservationRepository.CreateReservation(reservation);
        }

        public void UpdateReservation(ReservationViewModel model)
        {
            var reservation = new Reservation()
            {
                EmployeeId = model.EmployeeId,
                WorkplaceId = model.WorkplaceId,
                TimeFrom = model.TimeFrom,
                TimeTo = model.TimeTo
            };
            _reservationRepository.UpdateReservation(reservation);
        }

        public void DeleteReservation(int employeeId, int id)
        {
            var reservation = _reservationRepository.ReservationGetById(employeeId, id);
            _reservationRepository.DeleteReservation(reservation);
        }
    }
}
