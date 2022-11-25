using System.ComponentModel.DataAnnotations;

namespace ReservationWorkplace.Models
{
    public class WorkplaceViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int Room { get; set; }
        [Required]
        public int Table { get; set; }
        public ICollection<ReservationViewModel> Reservations { get; set; }
        public ICollection<EquipmentForWorkplaceViewModel> EquipmentForWorkplaces { get; set; }
    }
}
