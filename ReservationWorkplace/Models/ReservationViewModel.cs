using System.ComponentModel.DataAnnotations;

namespace ReservationWorkplace.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeViewModel Employee { get; set; }
        
        public int WorkplaceId { get; set; }
        public WorkplaceViewModel Workplace { get; set; }

    }
}
