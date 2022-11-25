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


        public List<ReservationDto> GetAllReservation()
        {
            var reservations = _reservationRepository.ReservationGetAll();
            var result = _mapper.Map<List<ReservationDto>>(reservations);
            return result;
        }

        public ReservationDto GetByIdReservation(int id)
        {
            var reservation = _reservationRepository.ReservationGetById(id);
            var result = _mapper.Map<ReservationDto>(reservation);
            return result;
        }


        public void CreateReservation(ReservationDto dto)
        {
            var reservation = new Reservation()
            {
                TimeFrom = dto.TimeFrom,
                TimeTo = dto.TimeTo,
                EmployeeId = dto.EmployeeId,
                WorkplaceId = dto.WorkplaceId
            };
            _reservationRepository.CreateReservation(reservation);
        }

        public void UpdateReservation(ReservationDto dto)
        {
            var reservation = new Reservation()
            {
                Id = dto.Id,
                TimeFrom = dto.TimeFrom,
                TimeTo = dto.TimeTo,
                EmployeeId = dto.EmployeeId,
                WorkplaceId = dto.WorkplaceId
            };
            _reservationRepository.UpdateReservation(reservation);
        }

        public void DeleteReservation(int id)
        {
            var reservation = _reservationRepository.ReservationGetById(id);
            _reservationRepository.DeleteReservation(reservation);
        }
    }
}
