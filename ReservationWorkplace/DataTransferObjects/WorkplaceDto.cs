namespace ReservationWorkplace.DataTransferObjects
{
    public class WorkplaceDto
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
        public ICollection<ReservationDto> Reservations { get; set; }
        public ICollection<EquipmentForWorkplaceDto> EquipmentForWorkplaces { get; set; }
    }
}
