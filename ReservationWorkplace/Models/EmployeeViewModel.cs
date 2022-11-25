using System.ComponentModel.DataAnnotations;

namespace ReservationWorkplace.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public ICollection<ReservationViewModel> Reservations { get; set; }
    }
}
