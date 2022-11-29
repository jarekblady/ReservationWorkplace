using System.ComponentModel.DataAnnotations;
using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Models
{
    public class ReservationViewModel
    {
        public List<ReservationDto> Reservations { get; set; }
        public ReservationDto Reservation { get; set; }
        
    }
}
