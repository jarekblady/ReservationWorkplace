using System.ComponentModel.DataAnnotations;

namespace ReservationWorkplace.Models
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<EquipmentForWorkplaceViewModel> EquipmentForWorkplaces { get; set; }
    }
}
