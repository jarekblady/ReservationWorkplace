using System.ComponentModel.DataAnnotations;
using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Models
{
    public class EquipmentViewModel
    {
        public List<EquipmentDto> Equipments { get; set; }
        public EquipmentDto Equipment { get; set; }
    }
}
