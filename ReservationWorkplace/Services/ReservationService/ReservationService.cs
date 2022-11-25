using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Repositories.ReservationRepository;

namespace ReservationWorkplace.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }


        public List<ReservationDto> GetAllReservation(int employeeId)
        {
            var reservations = _reservationRepository.ReservationGetAll(employeeId);
            var result = _mapper.Map<List<ReservationDto>>(reservations);
            return result;
        }

        public ReservationDto GetByIdReservation(int employeeId, int id)
        {
            var reservation = _reservationRepository.ReservationGetById(employeeId, id);
            var result = _mapper.Map<ReservationDto>(reservation);
            return result;
        }


        public void CreateReservation(ReservationDto dto)
        {
            var reservation = new Reservation()
            {
                EmployeeId = dto.EmployeeId,
                WorkplaceId = dto.WorkplaceId,
                TimeFrom = dto.TimeFrom,
                TimeTo = dto.TimeTo
            };
            _reservationRepository.CreateReservation(reservation);
        }

        public void UpdateReservation(ReservationDto dto)
        {
            var reservation = new Reservation()
            {
                EmployeeId = dto.EmployeeId,
                WorkplaceId = dto.WorkplaceId,
                TimeFrom = dto.TimeFrom,
                TimeTo = dto.TimeTo
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
