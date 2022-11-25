using System.ComponentModel.DataAnnotations;

namespace ReservationWorkplace.Models
{
    public class EquipmentForWorkplaceViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int WorkplaceId { get; set; }
        public WorkplaceViewModel Workplace { get; set; }

        public int EquipmentId { get; set; }
        public EquipmentViewModel Equipment { get; set; }
    }
}
