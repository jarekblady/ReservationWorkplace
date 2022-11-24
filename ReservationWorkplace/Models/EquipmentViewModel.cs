using ReservationWorkplace.Entities;

namespace ReservationWorkplace.Models
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }
    }
}
