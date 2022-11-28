using System.ComponentModel.DataAnnotations;

namespace ReservationWorkplace.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public ICollection<ReservationViewModel> Reservations { get; set; }


    }
}
