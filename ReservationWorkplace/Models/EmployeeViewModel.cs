using ReservationWorkplace.Entities;

namespace ReservationWorkplace.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
