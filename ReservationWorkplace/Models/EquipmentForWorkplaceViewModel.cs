using System.ComponentModel.DataAnnotations;
using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Models
{
    public class EquipmentForWorkplaceViewModel
    {
        public List<EquipmentForWorkplaceDto> EquipmentForWorkplaces { get; set; }
        public EquipmentForWorkplaceDto EquipmentForWorkplace { get; set; }
    }
}
