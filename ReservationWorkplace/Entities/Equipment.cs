namespace ReservationWorkplace.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }
    }
}
