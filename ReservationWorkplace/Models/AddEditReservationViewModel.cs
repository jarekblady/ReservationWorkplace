using System.ComponentModel.DataAnnotations;

namespace ReservationWorkplace.Models
{
    public class AddEditReservationViewModel
    {
        [Required]
        public DateTime TimeFrom { get; set; }
        [Required]
        public DateTime TimeTo { get; set; }
    }
}
